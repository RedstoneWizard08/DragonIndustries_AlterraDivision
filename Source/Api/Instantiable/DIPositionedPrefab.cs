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
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Security;
using System.Xml;
using Nautilus.Handlers;
using ReikaKalseki.DIAlterra.Api.Auxiliary;
using ReikaKalseki.DIAlterra.Api.Registry;
using ReikaKalseki.DIAlterra.Api.Registry.VanillaData;
using ReikaKalseki.DIAlterra.Api.Util;
using ReikaKalseki.DIAlterra.BuildSystem.ObjectManipulation;
using UnityEngine;

namespace ReikaKalseki.DIAlterra.Api.Instantiable;

[Serializable]
public class DIPositionedPrefab : PositionedPrefab
{
    public static readonly string TAGNAME = "dicustomprefab";

    private static readonly Dictionary<string, ModifiedObjectPrefab> prefabCache = new();

    private static HashSet<string> prefabNamespaces = new() {"ReikaKalseki.DIAlterra"};

    [SerializeField] public TechType tech = TechType.None;

    [SerializeField] internal readonly List<ManipulationBase> manipulations = new();

    static DIPositionedPrefab()
    {
        registerType(TAGNAME, e => new DIPositionedPrefab(e.getProperty("prefab")));
    }

    public DIPositionedPrefab(string pfb) : base(pfb)
    {
    }

    public DIPositionedPrefab(PositionedPrefab pfb) : base(pfb)
    {
    }

    public bool isSeabase { get; protected set; }
    public bool isBasePiece { get; internal set; }
    public bool isCrate { get; private set; }
    public bool isFragment { get; private set; }
    public bool isDatabox { get; private set; }
    public bool isPDA { get; private set; }
    public bool isO2Pipe { get; private set; }

    public ModifiedObjectPrefab customPrefab { get; private set; }

    public static void addPrefabNamespace(string s)
    {
        prefabNamespaces.Add(s);
    }

    public override string ToString()
    {
        return base.ToString().Replace(" @ ", " [" + tech + "] @ ");
    }

    public void setSeabase()
    {
        isSeabase = true;
        prefabName = "seabase";
    }

    public override string getTagName()
    {
        return TAGNAME;
    }

    public override void saveToXML(XmlElement e)
    {
        var n = prefabName;
        if (isBasePiece)
        {
            e.addProperty("piece", prefabName);
            prefabName = "basePart";
        }

        base.saveToXML(e);
        prefabName = n;
        if (tech != TechType.None)
            e.addProperty("tech", Enum.GetName(typeof(TechType), tech));
        if (manipulations.Count > 0)
        {
            var e1 = e.OwnerDocument.CreateElement("objectManipulation");
            foreach (var mb in manipulations)
            {
                var e2 = e.OwnerDocument.CreateElement(mb.GetType().Name);
                mb.saveToXML(e2);
                e1.AppendChild(e2);
            }

            e.AppendChild(e1);
        }
    }

    public Action<GameObject> getManipulationsCallable()
    {
        return go =>
        {
            foreach (var mb in manipulations) mb.applyToObject(go);
        };
    }

    public override GameObject createWorldObject()
    {
        if (isBasePiece)
        {
            var go = ObjectUtil.getBasePiece(prefabName);
            if (go != null)
            {
                go.transform.position = position;
                go.transform.rotation = rotation;
                go.transform.localScale = scale;
            }

            return go;
        }

        return base.createWorldObject();
    }

    public override void loadFromXML(XmlElement e)
    {
        base.loadFromXML(e);
        if (prefabName.StartsWith("res_", StringComparison.InvariantCultureIgnoreCase))
        {
            prefabName =
                ((VanillaResources) typeof(VanillaResources).GetField(prefabName.Substring(4).ToUpper()).GetValue(null))
                .prefab;
        }
        else if (prefabName.StartsWith("fauna_", StringComparison.InvariantCultureIgnoreCase))
        {
            prefabName =
                ((VanillaCreatures) typeof(VanillaCreatures).GetField(prefabName.Substring(6).ToUpper()).GetValue(null))
                .prefab;
        }
        else if (prefabName.StartsWith("flora_", StringComparison.InvariantCultureIgnoreCase))
        {
            prefabName = VanillaFlora.getByName(prefabName.Substring(6)).getRandomPrefab(false);
        }
        else if (prefabName.StartsWith("base_", StringComparison.InvariantCultureIgnoreCase))
        {
            isBasePiece = true;
        }
        else if (prefabName == "o2pipe")
        {
            isO2Pipe = true;
            prefabName = "08078333-1a00-42f8-8492-e2640c17a961";
            manipulations.Add(new PipeReconnection(e.getVector("connection").Value));
            SNUtil.log("Redirected customprefab to pipe " + prefabName, SNUtil.diDLL);
        }
        else if (prefabName == "crate")
        {
            isCrate = true;
            var techn = e.getProperty("item");
            tech = SNUtil.getTechType(techn);
            if (tech == TechType.None)
                throw new Exception("Cannot put nonexistent item '" + techn + "' in crate @ " + position + "!");
            prefabName = GenUtil.getOrCreateCrate(tech, e.getBoolean("sealed")).Info.ClassID;
            SNUtil.log("Redirected customprefab to crate " + prefabName, SNUtil.diDLL);
        }
        else if (prefabName == "databox")
        {
            isDatabox = true;
            var techn = e.getProperty("tech");
            tech = SNUtil.getTechType(techn);
            prefabName = GenUtil.getOrCreateDatabox(tech).Info.ClassID;
            SNUtil.log("Redirected customprefab to databox " + prefabName, SNUtil.diDLL);
        }
        else if (prefabName == "fragment")
        {
            isFragment = true;
            var techn = e.getProperty("tech");
            tech = SNUtil.getTechType(techn);
            var g = GenUtil.getFragment(tech, e.getInt("index", 0));
            if (g == null)
                throw new Exception("No such fragment!");
            prefabName = g.Info.ClassID;
            SNUtil.log("Redirected customprefab to fragment " + prefabName, SNUtil.diDLL);
        }
        else if (prefabName == "pda")
        {
            isPDA = true;
            var pagen = e.getProperty("page");
            var page = PDAManager.getPage(pagen);
            prefabName = page.getPDAClassID();
            SNUtil.log("Redirected customprefab to pda " + prefabName, SNUtil.diDLL);
        }
        else if (prefabName == "basePart")
        {
            isBasePiece = true;
            prefabName = e.getProperty("piece");
            var li0 = e.getDirectElementsByTagName("supportData");
            if (li0.Count == 1)
                manipulations.Add(new SeabaseLegLengthPreservation(li0[0]));
            SNUtil.log(
                "Redirected customprefab to base piece " + prefabName + " >> " + li0.Count + "::" +
                string.Join(", ", li0.Select(el => el.OuterXml)), SNUtil.diDLL);
        }
        else if (prefabName == "seabase")
        {
            prefabName = SeabaseReconstruction.getOrCreatePrefab(e).id;
            isSeabase = true;
            SNUtil.log("Redirected customprefab to seabase", SNUtil.diDLL);
        }

        //else if (prefabName == "fragment") {
        //	prefabName = ?;
        //	isFragment = true;
        //	string techn = e.getProperty("type");
        //	tech = SNUtil.getTechType(techn);
        //}
        var tech2 = e.getProperty("tech", true);
        if (tech == TechType.None && tech2 != null && tech2 != "None") tech = SNUtil.getTechType(tech2);
        var xli = e.OwnerDocument.DocumentElement != null
            ? e.OwnerDocument.DocumentElement.getAllChildrenIn("transforms")
            : null;
        if (xli != null)
            loadManipulations(xli, manipulations);
        var li = e.getDirectElementsByTagName("objectManipulation");
        if (li.Count == 1)
        {
            var mod = getManipulatedObject(li[0], this);
            if (mod != null)
            {
                prefabName = mod.Info.ClassID;
                tech = mod.Info.TechType;
            }
        }
    }

    public static ModifiedObjectPrefab getManipulatedObject(XmlElement e, DIPositionedPrefab pfb)
    {
        loadManipulations(e, pfb.manipulations);
        if (pfb.manipulations.Count > 0)
        {
            var needReapply = false;
            foreach (var mb in pfb.manipulations)
                if (mb.needsReapplication())
                {
                    needReapply = true;
                    break;
                }

            if (needReapply)
            {
                var xmlKey = pfb.prefabName + "##" + SecurityElement.Escape(e.InnerXml);
                return getOrCreateModPrefab(pfb, xmlKey);
            }
        }

        return null;
    }

    private static ModifiedObjectPrefab getOrCreateModPrefab(DIPositionedPrefab orig, string key)
    {
        var pfb = prefabCache.ContainsKey(key) ? prefabCache[key] : null;
        if (pfb == null)
        {
            pfb = new ModifiedObjectPrefab(key, orig.prefabName, orig.manipulations);
            prefabCache[key] = pfb;
            pfb.Register();
            var from = orig.tech != TechType.None
                ? orig.tech
                : CraftData.entClassTechTable.GetOrDefault(key, TechType.None);
            if (from != TechType.None)
            {
                KnownTechHandler.SetAnalysisTechEntry(pfb.Info.TechType, new List<TechType> {from});
                var e = new PDAScanner.EntryData();
                e.key = pfb.Info.TechType;
                e.blueprint = from;
                e.destroyAfterScan = false;
                e.locked = true;
                e.scanTime = 5;
                PDAHandler.AddCustomScannerEntry(e);
            }

            SNUtil.log("Created customprefab GO template: " + key + " [" + from + "] > " + pfb, SNUtil.diDLL);
        }
        else
        {
            SNUtil.log("Using already-generated prefab for GO template: " + key + " > " + pfb, SNUtil.diDLL);
        }

        return pfb;
    }

    internal static void loadManipulations(XmlNodeList es, List<ManipulationBase> li)
    {
        if (es == null)
            return;
        foreach (XmlElement e2 in es)
        {
            var mb = loadManipulation(e2);
            if (mb != null)
                li.Add(mb);
        }
    }

    internal static void loadManipulations(XmlElement e, List<ManipulationBase> li)
    {
        loadManipulations(e.ChildNodes, li);
    }

    public static ManipulationBase loadManipulation(XmlElement e2)
    {
        try
        {
            if (e2 == null)
                throw new Exception("Null XML elem");
            Type t = null;
            foreach (var s in prefabNamespaces)
            {
                t = InstructionHandlers.getTypeBySimpleName(s + "." + e2.Name);
                if (t != null)
                    break;
            }

            if (t == null)
                throw new Exception("Type '" + e2.Name + "' not found; is a namespace missing from " +
                                    string.Join(", ", prefabNamespaces));
            var ct = t.GetConstructor(new Type[0]);
            if (ct == null)
                throw new Exception("Constructor not found");
            try
            {
                var mb = (ManipulationBase) ct.Invoke(new object[0]);
                mb.loadFromXML(e2);
                return mb;
            }
            catch (Exception ex)
            {
                throw new Exception("Construction error " + ex);
            }
        }
        catch (Exception ex)
        {
            var err = "Could not rebuild manipulation from XML " + e2.Name + "/" + e2.InnerText + ": " + ex;
            SNUtil.log(err, SNUtil.diDLL);
            SNUtil.writeToChat(err);
            return null;
        }
    }
}

public class ModifiedObjectPrefab : GenUtil.CustomPrefabImpl
{
    private readonly List<ManipulationBase> mods = new();

    [SetsRequiredMembers]
    internal ModifiedObjectPrefab(string key, string template, List<ManipulationBase> li) : base(key, template)
    {
        mods = li;
    }

    public sealed override void prepareGameObject(GameObject go, Renderer[] r)
    {
        foreach (var mb in mods) mb.applyToObject(go);
    }

    public override string ToString()
    {
        return "Modified " + baseTemplate.prefab + getString(mods);
    }

    private static string getString(List<ManipulationBase> li)
    {
        return " x" + li.Count + "=" + string.Join("/", li.Select(mb => mb.GetType().Name));
    }
}