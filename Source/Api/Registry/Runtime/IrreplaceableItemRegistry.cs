using System.Collections.Generic;
using Nautilus.Assets;
using ReikaKalseki.DIAlterra.Api.Instantiable;

namespace ReikaKalseki.DIAlterra.Api.Registry.Runtime;

public class IrreplaceableItemRegistry
{
    public static readonly IrreplaceableItemRegistry instance = new();

    private readonly HashSet<TechType> items = new();

    private IrreplaceableItemRegistry()
    {
    }

    public void registerItem(ICustomPrefab item)
    {
        registerItem(item.Info.TechType);
    }

    public void registerItem(TechType item)
    {
        items.Add(item);
    }

    public bool isIrreplaceable(TechType tt)
    {
        return items.Contains(tt);
    }
}