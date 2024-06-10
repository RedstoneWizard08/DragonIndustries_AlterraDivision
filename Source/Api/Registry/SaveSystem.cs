﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Xml;
using Nautilus.Assets;
using Nautilus.Utility;
using ReikaKalseki.DIAlterra.Api.Auxiliary;
using ReikaKalseki.DIAlterra.Api.Util;
using UnityEngine;
using Object = UnityEngine.Object;

namespace ReikaKalseki.DIAlterra.Api.Registry;

public static class SaveSystem
{
    private static readonly Dictionary<string, SaveHandler> handlers = new();
    private static readonly Dictionary<string, XmlElement> saveData = new();

    private static readonly List<Tuple<Action<Player, XmlElement>, Action<Player, XmlElement>>> playerSaveHandler =
        new();

    private static readonly string xmlPathRoot;
    private static bool loaded;

    static SaveSystem()
    {
        SaveUtils.RegisterOnFinishLoadingEvent(handleLoad);
        SaveUtils.RegisterOnSaveEvent(handleSave);

        xmlPathRoot = Path.Combine(Path.GetDirectoryName(SNUtil.diDLL.Location), "persistentData");
    }

    public static void addSaveHandler(ICustomPrefab pfb, SaveHandler h)
    {
        addSaveHandler(pfb.Info.ClassID, h);
    }

    public static void addSaveHandler(string classID, SaveHandler h)
    {
        handlers[classID] = h;
    }

    public static void addPlayerSaveCallback<O>(FieldInfo field, Func<O> instance)
    {
        if (field == null)
            throw new Exception("No such field!");
        addPlayerSaveCallback((ep, e) => saveToXML(e, field.Name, field.GetValue(instance.Invoke())),
            (ep, e) => setField(e, field.Name, field, instance.Invoke()));
    }

    public static void addPlayerSaveCallback(Action<Player, XmlElement> save, Action<Player, XmlElement> load)
    {
        playerSaveHandler.Add(new Tuple<Action<Player, XmlElement>, Action<Player, XmlElement>>(save, load));
    }

    public static void handleSave()
    {
        var path = Path.Combine(xmlPathRoot, SaveLoadManager.main.currentSlot + ".dat");
        var doc = new XmlDocument();
        var rootnode = doc.CreateElement("Root");
        doc.AppendChild(rootnode);
        foreach (var pi in Object.FindObjectsOfType<PrefabIdentifier>())
        {
            var sh = getHandler(pi, false);
            if (sh != null)
            {
                SNUtil.log("Found " + sh + " save handler for " + pi.ClassId, SNUtil.diDLL);
                sh.data = doc.CreateElement("object");
                sh.data.SetAttribute("objectID", pi.Id);
                sh.save(pi);
                doc.DocumentElement.AppendChild(sh.data);
            }
        }

        var e = doc.CreateElement("player");
        foreach (var t in playerSaveHandler)
        {
            if (t.Item1 == null)
            {
                SNUtil.log("Could not run save handler " + t + " on player: no save hook", SNUtil.diDLL);
                continue;
            }

            try
            {
                t.Item1.Invoke(Player.main, e);
            }
            catch (Exception ex)
            {
                SNUtil.log("Save handler " + t + " on player threw " + ex, SNUtil.diDLL);
            }
        }

        doc.DocumentElement.AppendChild(e);
        SNUtil.log("Saving " + doc.DocumentElement.ChildNodes.Count + " objects to disk", SNUtil.diDLL);
        Directory.CreateDirectory(xmlPathRoot);
        doc.Save(path);
    }

    public static void handleLoad()
    {
        var path = Path.Combine(xmlPathRoot, SaveLoadManager.main.currentSlot + ".dat");
        if (!File.Exists(path))
            path = Path.Combine(xmlPathRoot, SaveLoadManager.main.currentSlot + ".xml");
        if (File.Exists(path))
        {
            var doc = new XmlDocument();
            doc.Load(path);
            saveData.Clear();
            foreach (XmlElement e in doc.DocumentElement.ChildNodes)
                saveData[e.Name == "player" ? "player" : e.GetAttribute("objectID")] = e;
            SNUtil.log("Loaded " + saveData.Count + " object entries from disk", SNUtil.diDLL);
        }
    }

    public static void populateLoad()
    {
        if (loaded)
            return;
        loaded = true;
        SNUtil.log("Applying saved object entries", SNUtil.diDLL);
        if (saveData.ContainsKey("player"))
            foreach (var t in playerSaveHandler)
            {
                if (t.Item2 == null)
                {
                    SNUtil.log("Could not run load handler " + t + " on player: no load hook", SNUtil.diDLL);
                    continue;
                }

                try
                {
                    t.Item2.Invoke(Player.main, saveData["player"]);
                }
                catch (Exception ex)
                {
                    SNUtil.log("Save handler " + t + " on player threw " + ex, SNUtil.diDLL);
                }
            }

        foreach (var pi in Object.FindObjectsOfType<PrefabIdentifier>())
        {
            var sh = getHandler(pi, true);
            if (sh != null)
            {
                SNUtil.log("Found " + sh + " load handler for " + pi.ClassId + " [" + pi.id + "]", SNUtil.diDLL);
                try
                {
                    sh.load(pi);
                }
                catch (Exception e)
                {
                    SNUtil.log("Threw error loading object " + pi.ClassId + " " + pi.Id + ": " + e, SNUtil.diDLL);
                }
            }
        }
    }

    private static SaveHandler getHandler(PrefabIdentifier pi, bool needSaveData)
    {
        if (pi && !string.IsNullOrEmpty(pi.ClassId))
        {
            SaveHandler ret;
            XmlElement elem = null;
            //SNUtil.log("Attempting to load "+pi+" ["+pi.id+"]", SNUtil.diDLL);
            if (needSaveData && handlers.ContainsKey(pi.ClassId) && !saveData.ContainsKey(pi.Id))
                SNUtil.log("Object " + pi + " [" + pi.id + "] had no data to load!", SNUtil.diDLL);
            if (handlers.TryGetValue(pi.ClassId, out ret) && (!needSaveData || saveData.TryGetValue(pi.Id, out elem)))
            {
                if (elem != null)
                    ret.data = elem;
                return ret;
            }
        }

        return null;
    }

    internal static void saveToXML(XmlElement e, string s, object val)
    {
        if (val is string)
            e.addProperty(s, (string) val);
        else if (val is int)
            e.addProperty(s, (int) val);
        else if (val is bool)
            e.addProperty(s, (bool) val);
        if (val is float)
            e.addProperty(s, (float) val);
        if (val is double)
            e.addProperty(s, (double) val);
        else if (val is Vector3)
            e.addProperty(s, (Vector3) val);
        else if (val is Quaternion)
            e.addProperty(s, (Quaternion) val);
        else if (val is Color)
            e.addProperty(s, (Color) val);
    }

    internal static void setField(XmlElement e, string s, FieldInfo fi, object inst)
    {
        if (fi.FieldType == typeof(string))
            fi.SetValue(inst, e.getProperty(s, true));
        else if (fi.FieldType == typeof(bool))
            fi.SetValue(inst, e.getBoolean(s));
        else if (fi.FieldType == typeof(int))
            fi.SetValue(inst, e.getInt(s, 0));
        else if (fi.FieldType == typeof(float))
            fi.SetValue(inst, (float) e.getFloat(s, 0));
        else if (fi.FieldType == typeof(double))
            fi.SetValue(inst, e.getFloat(s, 0));
        else if (fi.FieldType == typeof(Vector3))
            fi.SetValue(inst, e.getVector(s, true).GetValueOrDefault());
        else if (fi.FieldType == typeof(Quaternion))
            fi.SetValue(inst, e.getQuaternion(s, true).GetValueOrDefault());
        else if (fi.FieldType == typeof(Color))
            fi.SetValue(inst, e.getColor(s, true, true).GetValueOrDefault());
    }

    public abstract class SaveHandler
    {
        protected internal XmlElement data;

        public abstract void save(PrefabIdentifier pi);
        public abstract void load(PrefabIdentifier pi);
    }

    public sealed class ComponentFieldSaveHandler<C> : SaveHandler where C : MonoBehaviour
    {
        private readonly List<string> fields = new();

        public ComponentFieldSaveHandler()
        {
        }

        public ComponentFieldSaveHandler(params string[] f) : this(f.ToList())
        {
        }

        public ComponentFieldSaveHandler(IEnumerable<string> f)
        {
            fields.AddRange(f);
        }

        public ComponentFieldSaveHandler<C> addField(string f)
        {
            fields.Add(f);
            return this;
        }

        public ComponentFieldSaveHandler<C> addAllFields()
        {
            foreach (var fi in typeof(C).GetFields(BindingFlags.Instance | BindingFlags.NonPublic |
                                                   BindingFlags.Public)) addField(fi.Name);
            return this;
        }

        public override void save(PrefabIdentifier pi)
        {
            var com = pi.GetComponentInChildren<C>();
            if (!com)
                return;
            foreach (var s in fields)
            {
                var val = getField(s).GetValue(com);
                saveToXML(data, s, val);
            }
        }

        public override void load(PrefabIdentifier pi)
        {
            var com = pi.GetComponentInChildren<C>();
            if (!com)
                return;
            foreach (var s in fields)
            {
                var fi = getField(s);
                setField(data, s, fi, com);
            }
        }

        private FieldInfo getField(string s)
        {
            return typeof(C).GetField(s, BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
        }

        public override string ToString()
        {
            return string.Format("[ComponentFieldSaveHandler Fields={0}]", fields.toDebugString());
        }
    }
}