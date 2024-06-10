using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using ReikaKalseki.DIAlterra.Api.Registry.VanillaData;
using ReikaKalseki.DIAlterra.Api.Util;
using UnityEngine;

namespace ReikaKalseki.DIAlterra.Api.Base;

public abstract class BiomeBase : IComparable<BiomeBase>
{
    private static readonly List<string> variants = new()
    {
        "",
        "_cave",
        "_cave_dark",
        "_cave_light",
        "_cave_trans",
        "_CaveEntrance",
        "_Caves",
        "_Geyser",
        "_ThermalVent",
        "_Skeleton",
        "_Water"
    };

    private static readonly Dictionary<string, BiomeBase> biomeList = new();

    private static readonly UnknownBiome UNRECOGNIZED = new();

    internal static readonly Dictionary<Vector3, BiomeBase> biomeHoles = new();

    public readonly string displayName;
    private readonly HashSet<string> internalNames = new();
    public readonly float sceneryValue;

    protected BiomeBase(string d, float deco, params string[] ids)
    {
        sceneryValue = deco;
        displayName = d;
        foreach (var id in ids)
            registerID(this, id, SNUtil.tryGetModDLL(true));
    }

    public int CompareTo(BiomeBase ro)
    {
        if (this is VanillaBiomes && ro is VanillaBiomes)
            return VanillaBiomes.compare((VanillaBiomes) this, (VanillaBiomes) ro);
        if (this is VanillaBiomes)
            return -1;
        if (ro is VanillaBiomes)
            return 1;
        return string.Compare(displayName, ro.displayName, StringComparison.InvariantCultureIgnoreCase);
    }

    internal static void initializeBiomeHoles()
    {
        biomeHoles[new Vector3(1042.7F, -500F, 919.11F)] = VanillaBiomes.MOUNTAINS;
    }

    public static bool isUnrecognized(BiomeBase bb)
    {
        return bb == UNRECOGNIZED;
    }

    private static void registerID(BiomeBase b, string id, Assembly a)
    {
        foreach (var s in variants)
        {
            var key = (id + s).ToLowerInvariant();
            biomeList[key] = b;
            b.internalNames.Add(key);
            SNUtil.log("Registered biome " + b.displayName + " with id " + key, a);
        }
    }

    public bool containsID(string id)
    {
        if (id == null)
            return this == VanillaBiomes.VOID;
        return internalNames.Contains(id.ToLowerInvariant());
    }

    public IEnumerable<string> getIDs()
    {
        return new ReadOnlyCollection<string>(internalNames.ToList());
    }

    public override string ToString()
    {
        return GetType().Name + " " + displayName + ": [" + string.Join(", ", internalNames) + "]";
    }

    public static BiomeBase getBiome(Vector3 pos)
    {
        //if (logBiomeFetch)
        //	SNUtil.writeToChat("Getting biome at "+pos);
        var biome = DIHooks.getBiomeAt(WaterBiomeManager.main.GetBiome(pos, false), pos); //will fire the event
        //if (logBiomeFetch)
        //	SNUtil.writeToChat("WBM found "+biome);
        if (string.IsNullOrEmpty(biome))
            foreach (var kvp in biomeHoles)
                if (Vector3.Distance(kvp.Key, pos) <= 125)
                    //if (logBiomeFetch)
                    //	SNUtil.writeToChat("Matched to hole "+kvp.Key+", "+kvp.Value);
                    return kvp.Value;
        var ret = string.IsNullOrEmpty(biome) ? VanillaBiomes.VOID : getBiome(biome);
        //if (logBiomeFetch)
        //	SNUtil.writeToChat("Lookup to "+ret.displayName);
        return ret;
    }

    public static BiomeBase getBiome(string id)
    {
        id = id.ToLowerInvariant();
        return biomeList.ContainsKey(id) ? biomeList[id] : UNRECOGNIZED;
    }

    public abstract bool isCaveBiome();
    public abstract bool existsInSeveralPlaces();

    public abstract bool isInBiome(Vector3 pos);
}

internal class UnknownBiome : BiomeBase
{
    internal UnknownBiome() : base("[UNRECOGNIZED BIOME]", 0)
    {
    }

    public override bool isCaveBiome()
    {
        return false;
    }

    public override bool existsInSeveralPlaces()
    {
        return false;
    }

    public override bool isInBiome(Vector3 pos)
    {
        return false;
    }
}