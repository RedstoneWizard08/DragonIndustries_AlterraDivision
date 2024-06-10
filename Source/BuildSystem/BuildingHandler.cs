/*
 * Created by SharpDevelop.
 * User: Reika
 * Date: 11/04/2022
 * Time: 4:11 PM
 *
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Xml;
using Nautilus.Handlers;
using Nautilus.Utility;
using ReikaKalseki.DIAlterra.Api.Auxiliary;
using ReikaKalseki.DIAlterra.Api.Base;
using ReikaKalseki.DIAlterra.Api.Instantiable;
using ReikaKalseki.DIAlterra.Api.Registry;
using ReikaKalseki.DIAlterra.Api.Registry.VanillaData;
using ReikaKalseki.DIAlterra.Api.Util;
using ReikaKalseki.DIAlterra.BuildSystem.ObjectManipulation;
using TMPro;
using UnityEngine;
using Object = UnityEngine.Object;

namespace ReikaKalseki.DIAlterra.BuildSystem;

public class BuildingHandler
{
    public static readonly BuildingHandler instance = new();

    private readonly List<ManipulationBase> globalTransforms = new();
    private BasicText controlHint = new(TextAlignmentOptions.Center);
    private readonly Dictionary<int, PlacedObject> items = new();

    private PlacedObject lastPlaced;

    private readonly List<string> text = new();

    private BuildingHandler()
    {
        addText("LMB to select, Lalt+RMB to place selected on ground at look, LCtrl+RMB to duplicate them there");
        addText("Lalt+Arrow keys to move L/R Fwd/Back; +/- for U/D; add Z to make relative to obj");
        addText("Lalt+QR to yaw; [] to pitch (Z); ,. to roll (X); add Z to make relative to obj");
        addText("Add C for fast, X for slow; DEL to delete all selected");
    }

    public bool isEnabled { get; private set; }

    private void addText(string s)
    {
        text.Add(s);
        controlHint.SetLocation(0, 300);
        controlHint.SetSize(16);
    }

    public void addCommand(string key, Action call)
    {
        ConsoleCommandsHandler.RegisterConsoleCommand(key, call);
        addText("/" + key + ": " + call.Method.Name);
    }

    public void addCommand<T>(string key, Action<T> call)
    {
        ConsoleCommandsHandler.RegisterConsoleCommand(key, call);
        addText("/" + key + ": " + call.Method.Name);
    }

    public void addCommand<T, R>(string key, Func<T, R> call)
    {
        ConsoleCommandsHandler.RegisterConsoleCommand(key, call);
        addText("/" + key + ": " + call.Method.Name);
    }

    public void addCommand<T1, T2>(string key, Action<T1, T2> call)
    {
        ConsoleCommandsHandler.RegisterConsoleCommand(key, call);
        addText("/" + key + ": " + call.Method.Name);
    }

    public void setEnabled(bool on)
    {
        isEnabled = on;
        foreach (var go in items.Values)
            try
            {
                go.fx.SetActive(go.isSelected);
            }
            catch (Exception ex)
            {
                SNUtil.writeToChat("Could not set enabled state of " + go + " due to GO error: " + ex);
            }

        if (on)
            controlHint.ShowMessage(string.Join("\n", text.ToArray()));
        else
            controlHint.Hide();
    }

    public void selectedInfo()
    {
        foreach (var go in items.Values)
            if (go.isSelected)
                SNUtil.writeToChat(go.ToString());
    }

    public void activateObject()
    {
        foreach (var go in items.Values)
            if (go.isSelected)
                ObjectUtil.fullyEnable(go.obj);
    }

    public void setScale(float sc)
    {
        var sc2 = Vector3.one * sc;
        foreach (var go in items.Values)
            if (go.isSelected)
            {
                go.obj.transform.localScale = sc2;
                go.scale = sc2;
            }
    }

    public void dumpTextures()
    {
        foreach (var go in items.Values)
            if (go.isSelected)
                RenderUtil.dumpTextures(SNUtil.diDLL, go.obj.GetComponentInChildren<Renderer>());
    }

    internal static int genID(GameObject go)
    {
        /*
            if (go.transform != null && go.transform.gameObject != null)
                return go.transform.gameObject.GetInstanceID();
            else*/
        return go.GetInstanceID();
    }

    public void handleRClick(bool isCtrl = false)
    {
        var transform = MainCamera.camera.transform;
        var position = transform.position;
        var forward = transform.forward;
        var ray = new Ray(position, forward);
        if (UWE.Utils.RaycastIntoSharedBuffer(ray, 30, -5, QueryTriggerInteraction.Ignore) > 0)
        {
            var hit = UWE.Utils.sharedHitBuffer[0];
            if (hit.transform != null)
            {
                if (isCtrl)
                {
                    var added = new List<PlacedObject>();
                    foreach (var p in new List<PlacedObject>(items.Values))
                        if (p.isSelected)
                        {
                            var b = PlacedObject.createNewObject(p);
                            items[b.referenceID] = b;
                            b.setRotation(MathUtil.unitVecToRotation(hit.normal));
                            b.setPosition(hit.point);
                            lastPlaced = b;
                            added.Add(b);
                        }

                    clearSelection();
                    foreach (var b in added)
                        select(b);
                }
                else if (KeyCodeUtils.GetKeyHeld(KeyCode.LeftAlt))
                {
                    foreach (var go in items.Values)
                        if (go.isSelected)
                        {
                            go.setRotation(MathUtil.unitVecToRotation(hit.normal));
                            go.setPosition(hit.point);
                        }
                }
            }
        }
    }

    public void handleClick(bool isCtrl = false)
    {
        GameObject found = null;
        float dist;
        Targeting.GetTarget(Player.main.gameObject, 40, out found, out dist);
        Targeting.Reset();
        if (found == null) SNUtil.writeToChat("Raytrace found nothing.");
        var has = getPlacement(found);
        //SNUtil.writeToChat("Has is "+has);
        if (has == null)
        {
            if (!isCtrl) clearSelection();
        }
        else if (isCtrl)
        {
            if (has.isSelected)
                deselect(has);
            else
                select(has);
        }
        else
        {
            clearSelection();
            select(has);
        }
    }

    public void selectAll()
    {
        foreach (var go in items.Values) select(go);
    }

    public void saveSelection(string file)
    {
        dumpSome(file, s => s.isSelected);
    }

    public void saveAll(string file)
    {
        dumpSome(file, s => true);
    }

    private void dumpSome(string file, Func<PlacedObject, bool> flag)
    {
        var path = getDumpFile(file);
        var doc = new XmlDocument();
        var rootnode = doc.CreateElement("Root");
        doc.AppendChild(rootnode);
        SNUtil.log("=================================");
        SNUtil.log("Building Handler has " + items.Count + " items: ");
        foreach (var go in items.Values)
            try
            {
                var use = flag(go);
                SNUtil.log(go + " dump = " + use);
                if (use)
                {
                    var e = doc.CreateElement(go.getTagName());
                    go.saveToXML(e);
                    doc.DocumentElement.AppendChild(e);
                }
            }
            catch (Exception e)
            {
                throw new Exception(go.ToString(), e);
            }

        SNUtil.log("=================================");
        doc.Save(path);
    }

    public void loadFile(string file)
    {
        var doc = new XmlDocument();
        doc.Load(getDumpFile(file));
        var rootnode = doc.DocumentElement;
        globalTransforms.Clear();
        DIPositionedPrefab.loadManipulations(rootnode.getAllChildrenIn("transforms"), globalTransforms);
        foreach (XmlElement e in rootnode.ChildNodes)
        {
            if (e.Name == "transforms")
                continue;
            try
            {
                buildElement(e);
            }
            catch (Exception ex)
            {
                SNUtil.log(ex.ToString());
                SNUtil.writeToChat("Could not load XML block, threw exception: " + ex + " from " + e.format());
            }
        }
    }

    private void buildElement(XmlElement e)
    {
        var count = e.GetAttribute("count");
        var amt = string.IsNullOrEmpty(count) ? 1 : int.Parse(count);
        for (var i = 0; i < amt; i++)
        {
            var ot = ObjectTemplate.construct(e);
            if (ot == null)
                throw new Exception("Could not load XML block, null result from '" + e.Name + "': " + e.format());
            switch (e.Name)
            {
                case "object":
                    var b = (PlacedObject) ot;
                    addObject(b);
                    foreach (var mb in globalTransforms)
                    {
                        SNUtil.log("Applying global " + mb + " to " + b);
                        mb.applyToObject(b);
                        SNUtil.log("Is now " + b);
                    }

                    break;
                case "generator":
                    var gen = (WorldGenerator) ot;
                    var li = new List<GameObject>();
                    gen.generate(li);
                    SNUtil.writeToChat("Ran generator " + gen + " which produced " + li.Count + " objects");
                    foreach (var go in li)
                    {
                        if (go == null)
                        {
                            SNUtil.writeToChat("Generator " + gen + " produced a null object!");
                            continue;
                        }

                        var b2 = new PlacedObject(go, ObjectUtil.getPrefabID(go));
                        addObject(b2);
                        var sel = go.AddComponent<BuilderPlaced>();
                        sel.placement = b2;
                    }

                    break;
            }
        }
    }

    private void addObject(PlacedObject b)
    {
        SNUtil.log("Loaded a " + b);
        items[b.referenceID] = b;
        lastPlaced = b;
        selectLastPlaced();
    }

    public string getDumpFile(string name)
    {
        var folder = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "ObjectDump");
        Directory.CreateDirectory(folder);
        return Path.Combine(folder, name + ".xml");
    }

    public void deleteSelected()
    {
        var li = new List<PlacedObject>(items.Values);
        foreach (var go in li)
            if (go.isSelected)
                delete(go);
    }

    private void delete(PlacedObject go)
    {
        Object.Destroy(go.obj);
        Object.Destroy(go.fx);
        items.Remove(go.referenceID);
    }

    /*
    private PlacedObject getSelectionFor(GameObject go) {
        PlacedObject s = getPlacement(go);
        if (s != null && selected.TryGetValue(s.referenceID, out s))
            return s;
        else
            return null;
    }*/

    public bool isSelected(GameObject go)
    {
        var s = getPlacement(go);
        return s != null && s.isSelected;
    }

    public void selectLastPlaced()
    {
        if (lastPlaced != null) select(lastPlaced);
    }

    public void syncObjects()
    {
        foreach (var p in items.Values)
            if (p.isSelected)
                p.sync();
    }

    private PlacedObject getPlacement(GameObject go)
    {
        if (go == null)
            return null;
        var pre = go.GetComponentInParent<BuilderPlaced>();
        if (pre != null) return pre.placement;

        SNUtil.writeToChat("Game object " + go + " (" + genID(go) + ") was not was not placed by the builder system.");
        return null;
    }

    public void select(GameObject go)
    {
        var pre = getPlacement(go);
        if (go != null && pre == null)
            ObjectUtil.dumpObjectData(go);
        if (pre != null) select(pre);
    }

    private void select(PlacedObject s)
    {
        //SNUtil.writeToChat("Selected "+s);
        s.setSelected(true);
    }

    public void deselect(GameObject go)
    {
        var pre = getPlacement(go);
        if (pre != null) deselect(pre);
    }

    private void deselect(PlacedObject go)
    {
        //SNUtil.writeToChat("Deselected "+go);
        go.setSelected(false);
    }

    public void clearSelection()
    {
        foreach (var go in items.Values) deselect(go);
    }

    public void manipulateSelected()
    {
        var s = KeyCodeUtils.GetKeyHeld(KeyCode.C) ? 0.15F : KeyCodeUtils.GetKeyHeld(KeyCode.X) ? 0.02F : 0.05F;
        foreach (var go in items.Values)
        {
            if (!go.isSelected)
                continue;
            var t = MainCamera.camera.transform;
            var rel = KeyCodeUtils.GetKeyHeld(KeyCode.Z);
            if (rel) t = go.obj.transform;
            var vec = t.forward.normalized;
            var right = t.right.normalized;
            var up = t.up.normalized;
            if (KeyCodeUtils.GetKeyHeld(KeyCode.UpArrow))
                go.move(vec * s);
            if (KeyCodeUtils.GetKeyHeld(KeyCode.DownArrow))
                go.move(vec * -s);
            if (KeyCodeUtils.GetKeyHeld(KeyCode.LeftArrow))
                go.move(right * -s);
            if (KeyCodeUtils.GetKeyHeld(KeyCode.RightArrow))
                go.move(right * s);
            if (KeyCodeUtils.GetKeyHeld(KeyCode.Equals)) //+
                go.move(up * s);
            if (KeyCodeUtils.GetKeyHeld(KeyCode.Minus))
                go.move(up * -s);
            if (KeyCodeUtils.GetKeyHeld(KeyCode.R))
                go.rotateYaw(s * 20, rel ? null : getCenter());
            if (KeyCodeUtils.GetKeyHeld(KeyCode.Q))
                go.rotateYaw(-s * 20, rel ? null : getCenter());
            if (KeyCodeUtils.GetKeyHeld(KeyCode.LeftBracket))
                go.rotate(0, 0, -s * 20, rel ? null : getCenter());
            if (KeyCodeUtils.GetKeyHeld(KeyCode.RightBracket))
                go.rotate(0, 0, s * 20, rel ? null : getCenter());
            if (KeyCodeUtils.GetKeyHeld(KeyCode.Comma))
                go.rotate(-s * 20, 0, 0, rel ? null : getCenter());
            if (KeyCodeUtils.GetKeyHeld(KeyCode.Period))
                go.rotate(s * 20, 0, 0, rel ? null : getCenter());
        }
    }

    private Vector3? getCenter()
    {
        if (items.Count == 0)
            return null;
        var vec = Vector3.zero;
        foreach (var obj in items.Values) vec += obj.position;
        vec /= items.Values.Count;
        return vec;
    }

    private int selectionCount()
    {
        var ret = 0;
        foreach (var p in items.Values)
            if (p.isSelected)
                ret++;
        return ret;
    }

    internal PlacedObject spawnPrefabAtLook(string arg)
    {
        if (!isEnabled)
            return null;
        var transform = MainCamera.camera.transform;
        var position = transform.position;
        var forward = transform.forward;
        var pos = position + forward.normalized * 7.5F;
        var id = getPrefabKeyFromID(arg);
        var b = PlacedObject.createNewObject(id);
        if (b != null)
        {
            b.obj.transform.SetPositionAndRotation(pos, Quaternion.identity);
            registerObject(b);
            SNUtil.writeToChat("Spawned a " + b);
            SNUtil.log("Spawned a " + b);
        }

        return b;
    }

    public void addRealObject_External(GameObject go, bool withChildren = false)
    {
        addRealObject(go, withChildren);
    }

    internal PlacedObject addRealObject(GameObject go, bool withChildren = false)
    {
        if (go.GetComponent<Base>() != null)
        {
            var bo = PlacedObject.createNewObject(go);
            registerObject(bo);
            bo.setSeabase();
            return bo;
        }

        var b = PlacedObject.createNewObject(go);
        if (b != null)
        {
            registerObject(b);
            SNUtil.writeToChat("Registered a pre-existing " + b);
            SNUtil.log("Registered a pre-existing " + b, SNUtil.diDLL);
            if (withChildren)
                foreach (Transform t in go.transform)
                    if (t.gameObject != go && t.gameObject != null)
                    {
                        var b2 = addRealObject(t.gameObject, true);
                        if (b2 != null)
                            b2.parent = b;
                    }
        }

        return b;
    }

    private void registerObject(PlacedObject b)
    {
        items[b.referenceID] = b;
        lastPlaced = b;
        selectLastPlaced();
    }
    /*
    public void spawnTechTypeAtLook(string tech) {
        spawnTechTypeAtLook(getTech(tech));
    }

    public void spawnTechTypeAtLook(TechType tech) {

    }

    private TechType getTech(string name) {

    }*/

    private string getPrefabKeyFromID(string id)
    {
        //if (id.Length >= 24 && id[8] == '-' && id[13] == '-' && id[18] == '-' && id[23] == '-')
        //    return id;
        if (id.StartsWith("res_", StringComparison.InvariantCultureIgnoreCase))
            try
            {
                return ((VanillaResources) typeof(VanillaResources).GetField(id.Substring(4).ToUpper()).GetValue(null))
                    .prefab;
            }
            catch (Exception ex)
            {
                SNUtil.log("Unable to fetch vanilla resource field '" + id + "': " + ex);
                return null;
            }

        if (id.StartsWith("flora_", StringComparison.InvariantCultureIgnoreCase))
            try
            {
                return ((VanillaFlora) typeof(VanillaFlora).GetField(id.Substring(6).ToUpper()).GetValue(null))
                    .getRandomPrefab(false);
            }
            catch (Exception ex)
            {
                SNUtil.log("Unable to fetch vanilla flora field '" + id + "': " + ex);
                return null;
            }

        if (id.StartsWith("fauna_", StringComparison.InvariantCultureIgnoreCase))
            try
            {
                return ((VanillaCreatures) typeof(VanillaCreatures).GetField(id.Substring(6).ToUpper()).GetValue(null))
                    .prefab;
            }
            catch (Exception ex)
            {
                SNUtil.log("Unable to fetch vanilla creature field '" + id + "': " + ex);
                return null;
            }

        if (id.StartsWith("fragment_", StringComparison.InvariantCultureIgnoreCase))
            try
            {
                var idx1 = id.IndexOf('_');
                var idx2 = id.IndexOf('_', idx1 + 1);
                var index = int.Parse(id.Substring(idx1 + 1, idx2 - idx1 - 1));
                var tt = SNUtil.getTechType(id.Substring(idx2 + 1));
                if (tt == TechType.None)
                    throw new Exception("No techtype found");
                return GenUtil.getFragment(tt, index).Info.ClassID;
            }
            catch (Exception ex)
            {
                SNUtil.log("Unable to fetch tech fragment '" + id + "': " + ex);
                return null;
            }

        if (id.StartsWith("pda_", StringComparison.InvariantCultureIgnoreCase))
            try
            {
                var page = PDAManager.getPage(id.Substring(4));
                if (page == null)
                    throw new Exception("No page found");
                return page.getPDAClassID();
            }
            catch (Exception ex)
            {
                SNUtil.log("Unable to fetch pda '" + id + "': " + ex);
                return null;
            }

        //if (id.IndexOf('/') >= 0)
        //    return PrefabData.getPrefabID(id);
        //return PrefabData.getPrefabIDByShortName(id);
        return id;
    }
}