﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Xml;
using ReikaKalseki.DIAlterra.Api.Auxiliary;
using ReikaKalseki.DIAlterra.Api.Util;
using UnityEngine;

namespace ReikaKalseki.DIAlterra.Api.Instantiable;

public class XMLLocale
{
    private static readonly LocaleEntry NOT_FOUND = new(null, "NOTFOUND", "#NULL", "#NULL", "#NULL");

    private readonly Dictionary<string, LocaleEntry> entries = new();
    private readonly Assembly ownerMod;

    public readonly string relativePath;

    private XmlDocument xmlFile;

    public XMLLocale(Assembly owner, string path)
    {
        ownerMod = owner;
        relativePath = path;
    }

    public void load()
    {
        xmlFile = loadXML();
        if (xmlFile.DocumentElement == null)
            throw new Exception("No XML file at " + relativePath);
        foreach (XmlElement e in xmlFile.DocumentElement.ChildNodes)
        {
            var lc = constructEntry(e);
            entries[lc.key] = lc;
        }

        SNUtil.log("XML DB '" + this + "' loaded " + entries.Count + " entries: " + string.Join(", ", entries.Keys),
                ownerMod); /*
                foreach (LocaleEntry e in entries.Values) {
                    SNUtil.log(e.ToString());
                }*/
    }

    private XmlDocument loadXML()
    {
        var loc = Path.GetDirectoryName(ownerMod.Location);
        var path = Path.Combine(loc, relativePath);
        var doc = new XmlDocument();
        if (File.Exists(path))
            doc.Load(path);
        else
            SNUtil.log("Could not find XML file " + path + "!", ownerMod);
        return doc;
    }

    private LocaleEntry constructEntry(XmlElement e)
    {
        return new LocaleEntry(e);
    }

    public LocaleEntry getEntry(string id)
    {
        if (entries.ContainsKey(id))
            return entries[id];
        SNUtil.log("Could not find locale entry '" + id + "'", ownerMod);
        return NOT_FOUND;
    }

    public IEnumerable<LocaleEntry> getEntries()
    {
        return entries.Values;
    }

    private static string cleanString(string input)
    {
        if (string.IsNullOrEmpty(input))
            return input;
        var parts = input.Trim().Split('\n');
        for (var i = 0; i < parts.Length; i++) parts[i] = parts[i].Trim();
        return string.Join("\n", parts);
    }

    public class LocaleEntry
    {
        public readonly string desc;

        private readonly XmlElement element;

        public readonly string key;
        public readonly string name;
        public readonly string pda;

        internal LocaleEntry(XmlElement e) : this(e, e.Name, cleanString(e.getProperty("name")),
            cleanString(e.getProperty("desc", true)), cleanString(e.getProperty("pda")))
        {
        }

        internal LocaleEntry(XmlElement e, string k, string n, string d, string p)
        {
            key = k;
            name = n;
            desc = d;
            pda = p;

            element = e;
        }

        public override string ToString()
        {
            return key + ": " + name + " / " + desc;
        }

        public string dump()
        {
            return element == null ? "<null>" : element.format();
        }

        public bool hasField(string key)
        {
            return element != null && element.hasProperty(key);
        }

        public T getField<T>(string key) where T : class
        {
            return getField<T>(key, null);
        }

        public T getField<T>(string key, T fallback)
        {
            if (element == null)
                return fallback;
            var t = typeof(T);
            if (t == typeof(Int3))
            {
                var vec = element.getVector(key);
                return vec != null && vec.HasValue ? (T) Convert.ChangeType(vec.Value.roundToInt3(), t) : fallback;
            }

            if (t == typeof(Vector3))
            {
                var vec = element.getVector(key);
                return vec != null && vec.HasValue ? (T) Convert.ChangeType(vec.Value, t) : fallback;
            }

            if (t == typeof(Quaternion))
            {
                var vec = element.getQuaternion(key);
                return vec != null && vec.HasValue ? (T) Convert.ChangeType(vec.Value, t) : fallback;
            }

            if (t == typeof(string))
            {
                var get = element.getProperty(key, true);
                return (T) Convert.ChangeType(get == null ? null : cleanString(get), t);
            }

            if (t == typeof(bool)) return (T) Convert.ChangeType(element.getBoolean(key), t);
            if (t == typeof(int)) return (T) Convert.ChangeType(element.getInt(key, (int) (object) fallback), t);
            if (t == typeof(float))
            {
                var fall = (double) (object) fallback;
                return (T) Convert.ChangeType((float) element.getFloat(key, fall), t);
            }

            if (t == typeof(double))
            {
                var fall = (double) (object) fallback;
                return (T) Convert.ChangeType(element.getFloat(key, fall), t);
            }

            throw new Exception("Undefined data type '" + t + "'");
        }
    }
}