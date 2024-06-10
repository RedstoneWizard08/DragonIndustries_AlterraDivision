using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Xml;
using ReikaKalseki.DIAlterra.Api.Auxiliary;
using ReikaKalseki.DIAlterra.Api.Base;
using ReikaKalseki.DIAlterra.Api.Instantiable;
using ReikaKalseki.DIAlterra.Api.Util;
using UnityEngine;
using Random = UnityEngine.Random;

namespace ReikaKalseki.DIAlterra.Api.Registry;

public class WorldgenDatabase
{
    private readonly List<PositionedPrefab> objects = new();

    private readonly Assembly ownerMod;

    public WorldgenDatabase()
    {
        ownerMod = SNUtil.tryGetModDLL();
    }

    public void load(Predicate<string> loadFile = null)
    {
        var root = Path.GetDirectoryName(ownerMod.Location);
        var folder = Path.Combine(root, "XML/WorldgenSets");
        objects.Clear();
        if (Directory.Exists(folder))
        {
            var files = Directory.EnumerateFiles(folder, "*.*", SearchOption.AllDirectories)
                .Where(isLoadableWorldgenXML);
            SNUtil.log("Loading worldgen maps from folder '" + folder + "': " + string.Join(", ", files), ownerMod);
            foreach (var file in files)
            {
                if (loadFile != null && !loadFile.Invoke(file))
                {
                    SNUtil.log("Skipping worldgen map file @ " + file, ownerMod);
                    continue;
                }

                loadXML(file);
            }
        }
        else
        {
            SNUtil.log("Worldgen XMLs not found!", ownerMod);
        }
    }

    private bool isLoadableWorldgenXML(string file)
    {
        var ext = Path.GetExtension(file);
        if (ext == ".xml")
            return true;
        if (ext == ".gen")
        {
            var xml = File.Exists(file.Replace(".gen", ".xml"));
            if (xml)
                SNUtil.log("Skipping packed worldgen XML " + file + " as an unpacked version is present", ownerMod);
            return !xml;
        }

        return false;
    }

    private void loadXML(string file)
    {
        SNUtil.log("Loading worldgen map from XML file @ " + file, ownerMod);
        string xml;
        if (file.EndsWith(".gen", StringComparison.InvariantCultureIgnoreCase))
        {
            byte[] arr;
            using (var inp = File.OpenRead(file))
            {
                using (var zip = new GZipStream(inp, CompressionMode.Decompress, true))
                {
                    using (var mem = new MemoryStream())
                    {
                        zip.CopyTo(mem);
                        arr = mem.ToArray();
                    }
                }
            }

            arr = arr.Reverse().Skip(8).Where((b, idx) => idx % 2 == 0).ToArray();
            xml = Encoding.UTF8.GetString(arr);
        }
        else
        {
            xml = File.ReadAllText(file);
        }

        var doc = new XmlDocument();
        doc.LoadXml(xml);
        var loaded = 0;
        foreach (XmlElement e in doc.DocumentElement.ChildNodes)
            try
            {
                var count = e.GetAttribute("count");
                var ch = e.GetAttribute("chance");
                var amt = string.IsNullOrEmpty(count) ? 1 : int.Parse(count);
                var chance = string.IsNullOrEmpty(ch) ? 1 : double.Parse(ch);
                for (var i = 0; i < amt; i++)
                    if (Random.Range(0F, 1F) <= chance)
                    {
                        var ot = ObjectTemplate.construct(e);
                        if (ot == null)
                            throw new Exception("No worldgen loadable for '" + e.Name + "' " + e.format() + ": NULL");

                        if (ot is DIPositionedPrefab)
                        {
                            var pfb = (DIPositionedPrefab) ot;
                            if (pfb.isCrate)
                                GenUtil.spawnItemCrate(pfb.position, pfb.tech, pfb.rotation);
                            //CrateFillMap.instance.addValue(gen.position, gen.tech);
                            else if (pfb.isDatabox)
                                GenUtil.spawnDatabox(pfb.position, pfb.tech, pfb.rotation);
                            //DataboxTypingMap.instance.addValue(gen.position, gen.tech);
                            //else if (gen.isFragment) {
                            //    GenUtil.spawnFragment(gen.position, gen.rotation);
                            //	FragmentTypingMap.instance.addValue(gen.position, gen.tech);
                            //}
                            else
                                GenUtil.registerWorldgen(pfb, pfb.getManipulationsCallable());
                            //SNUtil.log("Loaded worldgen prefab "+pfb+" for "+e.format(), ownerMod);
                            objects.Add(pfb);
                            loaded++;
                        }
                        else if (ot is WorldGenerator)
                        {
                            var gen = (WorldGenerator) ot;
                            GenUtil.registerWorldgen(gen);
                            //SNUtil.log("Loaded worldgenator "+gen+" for "+e.format(), ownerMod);
                        }
                        else
                        {
                            throw new Exception("No worldgen loadable for '" + e.Name + "' " + e.format());
                        }
                    }
            }
            catch (Exception ex)
            {
                SNUtil.log("Could not load element " + e.format(), ownerMod);
                SNUtil.log(ex.ToString(), ownerMod);
            }

        SNUtil.log("Loaded " + loaded + " worldgen elements from file " + file);
    }

    public int getCount(string classID, Vector3? near = null, float dist = -1)
    {
        var ret = 0;
        foreach (var pfb in objects)
            if (pfb.prefabName == classID)
                if (dist < 0 || near == null || !near.HasValue || Vector3.Distance(near.Value, pfb.position) <= dist)
                    ret++;
        return ret;
    }
}