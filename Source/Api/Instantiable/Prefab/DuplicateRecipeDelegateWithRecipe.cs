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

public sealed class DuplicateRecipeDelegateWithRecipe : CraftingGadget, DuplicateItemDelegate
{
    public readonly TechType basis;
    public new readonly DICustomPrefab prefab;
    private readonly RecipeData recipe;
    public bool allowUnlockPopups = false;
    public TechCategory category = TechCategory.Misc;
    public string[] craftingMenuTree = new string[0];
    public CraftTree.Type craftingType = CraftTree.Type.None;
    public float craftTime = 0.1F;
    public TechGroup group = TechGroup.Uncategorized;
    public Assembly ownerMod;

    public Atlas.Sprite sprite;

    public string suffixName = "";
    public TechType unlock = TechType.None;

    [SetsRequiredMembers]
    public DuplicateRecipeDelegateWithRecipe(CraftingGadget s, RecipeData r) : base(s.prefab(), new RecipeData())
    {
        basis = s.prefab().Info.TechType;
        prefab = s.prefab() as DICustomPrefab;
        recipe = r;
        unlock = s.prefab().GetGadget<ScanningGadget>().RequiredForUnlock;
        group = s.prefab().GetGadget<ScanningGadget>().GroupForPda;
        category = s.prefab().GetGadget<ScanningGadget>().CategoryForPda;
        craftingType = s.FabricatorType;
        craftTime = s.CraftingTime;
        craftingMenuTree = s.StepsToFabricatorTab;
        suffixName = " (x" + r.craftAmount + ")";
        if (s is BasicCraftingItem)
            sprite = ((BasicCraftingItem) s).sprite;
        if (s is DIPrefab<PrefabReference>)
            ownerMod = ((DIPrefab<PrefabReference>) s).getOwnerMod();
        // FriendlyName = FriendlyName + suffixName;
        onPatched();
    }

    [SetsRequiredMembers]
    public DuplicateRecipeDelegateWithRecipe(TechType from, RecipeData r) : base(
        new CustomPrefab(from.AsString() + "_delegate", "", ""), new RecipeData())
    {
        basis = from;
        prefab = null;
        recipe = r;
        suffixName = r.craftAmount > 1 ? " (x" + r.craftAmount + ")" : "";
        sprite = SpriteManager.Get(from);
        onPatched();
    }

    private void onPatched()
    {
        prefab.SetGameObject(ObjectUtil.createWorldObject(CraftData.GetClassIdForTechType(basis),
            true, false));

        prefab.SetPdaGroupCategory(group, category);
        prefab.SetUnlock(unlock);
        prefab.Info.WithSizeInInventory(CraftData.GetItemSize(basis));
        prefab.SetRecipe(recipe).WithFabricatorType(craftingType).WithCraftingTime(craftTime)
            .WithStepsToFabricatorTab(craftingMenuTree);

        if (ownerMod == null)
            throw new Exception("Delegate item " + basis.AsString() + "/" + prefab.Info.ClassID +
                                " has no source mod!");
        if (sprite == null)
            throw new Exception("Delegate item " + basis + "/" + prefab.Info.ClassID + " has no sprite!");
        SNUtil.log(
            "Constructed craftable delegate of " + basis.AsString() + ": " + prefab.Info.ClassID + " @ " +
            RecipeUtil.toString(recipe) + " @ " + string.Join("/", craftingMenuTree), ownerMod);
        DuplicateRecipeDelegate.addDelegate(this);
    }

    public string getNameSuffix()
    {
        return suffixName;
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
        return Language.main.Get("Tooltip_" + basis.AsString());
    }

    public bool allowTechUnlockPopups()
    {
        return allowUnlockPopups;
    }

    public void setRecipe(int amt = 1)
    {
        for (var i = 0; i < amt; i++)
            recipe.LinkedItems.Add(basis);
        recipe.craftAmount = 0;
        suffixName = amt > 1 ? " (x" + amt + ")" : "";
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
}