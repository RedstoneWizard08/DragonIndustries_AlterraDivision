using System;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using Nautilus.Assets;
using Nautilus.Assets.Gadgets;
using Nautilus.Crafting;
using ReikaKalseki.DIAlterra.Api.Auxiliary;
using ReikaKalseki.DIAlterra.Api.Base;
using ReikaKalseki.DIAlterra.Api.Util;
using UnityEngine;

namespace ReikaKalseki.DIAlterra.Api.Instantiable.Prefab;

public sealed class UncraftingRecipeItem : CraftingGadget, DuplicateItemDelegate
{
    public readonly TechType basis;

    public new readonly ICustomPrefab prefab;
    public TechCategory category = TechCategory.Misc;
    public string[] craftingMenuTree = new string[0];
    public CraftTree.Type craftingType = CraftTree.Type.None;
    public float craftTime = 1F;
    public TechGroup group = TechGroup.Uncategorized;
    public Assembly ownerMod;

    public Atlas.Sprite sprite;

    [SetsRequiredMembers]
    public UncraftingRecipeItem(CraftingGadget s) : base(
        new CustomPrefab(s.prefab().Info.ClassID + "_uncrafting", s.prefab().Info.PrefabFileName, ""), new RecipeData())
    {
        basis = s.prefab().Info.TechType;
        prefab = s.prefab();
        group = s.prefab().GetGadget<ScanningGadget>().GroupForPda;
        category = s.prefab().GetGadget<ScanningGadget>().CategoryForPda;
        craftingType = s.FabricatorType;
        craftTime = s.CraftingTime;
        craftingMenuTree = s.StepsToFabricatorTab;
        if (s is BasicCraftingItem)
            sprite = ((BasicCraftingItem) s).sprite;
        if (s is DIPrefab<PrefabReference>)
            ownerMod = ((DIPrefab<PrefabReference>) s).getOwnerMod();
        onPatched();
    }

    [SetsRequiredMembers]
    public UncraftingRecipeItem(TechType from) : base(new CustomPrefab(from.AsString() + "_uncrafting", "", ""),
        new RecipeData())
    {
        basis = from;
        prefab = null;
        sprite = SpriteManager.Get(from);
        onPatched();
    }

    public string getNameSuffix()
    {
        return " (Uncrafting)";
    }

    public ICustomPrefab getPrefab()
    {
        return prefab;
    }

    public TechType getBasis()
    {
        return basis;
    }

    public Assembly getOwnerMod()
    {
        return ownerMod;
    }

    public string getTooltip()
    {
        return "Reclaiming the crafting ingredients.";
    }

    public bool allowTechUnlockPopups()
    {
        return false;
    }

    private void onPatched()
    {
        prefab.SetPdaGroupCategory(group, category);
        prefab.SetUnlock(basis);
        prefab.SetRecipe(getRecipe()).WithFabricatorType(craftingType).WithCraftingTime(craftTime)
            .WithStepsToFabricatorTab(craftingMenuTree);
        (prefab as CustomPrefab)?.SetGameObject(ObjectUtil.createWorldObject(CraftData.GetClassIdForTechType(basis),
            true, false));
        if (ownerMod == null)
            throw new Exception("Uncrafting item " + basis + "/" + prefab.Info.TechType + " has no source mod!");
        SNUtil.log(
            "Constructed uncrafting of " + basis + ": " + prefab.Info.TechType + " @ " +
            string.Join("/", craftingMenuTree),
            ownerMod);
        DuplicateRecipeDelegate.addDelegate(this);
    }

    public Atlas.Sprite getIcon()
    {
        return sprite;
    }

    public override string ToString()
    {
        return base.ToString() + " [" + prefab.Info.TechType + "] / " + prefab.Info.ClassID + " / " +
               prefab.Info.PrefabFileName;
    }

    private RecipeData getRecipe()
    {
        return RecipeUtil.createUncrafting(basis);
    }
}