using System;
using System.Collections.Generic;
using Nautilus.Assets;
using ReikaKalseki.DIAlterra.Api.Util;

namespace ReikaKalseki.DIAlterra.Api.Registry;

public class ItemRegistry
{
    public static readonly ItemRegistry instance = new();

    private readonly List<Action<ICustomPrefab>> listeners = new();

    private readonly Dictionary<string, ICustomPrefab> registry = new();
    private readonly Dictionary<TechType, ICustomPrefab> registryTech = new();

    private ItemRegistry()
    {
    }

    public ICustomPrefab getItem(string id)
    {
        if (registry.ContainsKey(id))
        {
            SNUtil.log("Fetching item '" + id + "'", SNUtil.tryGetModDLL(true));
            return registry[id];
        }

        SNUtil.log("Could not find item '" + id + "'", SNUtil.tryGetModDLL(true));
        return null;
    }

    public void addListener(Action<ICustomPrefab> a)
    {
        listeners.Add(a);
    }

    public ICustomPrefab getItem(TechType tt, bool doLog = true)
    {
        if (registryTech.ContainsKey(tt))
        {
            if (doLog)
                SNUtil.log("Fetching item '" + tt + "'", SNUtil.tryGetModDLL(true));
            return registryTech[tt];
        }

        if (doLog)
            SNUtil.log("Could not find item '" + tt + "'", SNUtil.tryGetModDLL(true));
        return null;
    }

    public void addItem(ICustomPrefab di)
    {
        registry[di.Info.ClassID] = di;
        registryTech[di.Info.TechType] = di;
        SNUtil.log("Registering item '" + di + "'", SNUtil.tryGetModDLL(true));
        foreach (var a in listeners) a(di);
    }
}