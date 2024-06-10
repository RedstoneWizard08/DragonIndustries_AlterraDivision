using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using Nautilus.Assets;
using Nautilus.Assets.Gadgets;
using Nautilus.Crafting;
using Nautilus.Handlers;
using ReikaKalseki.DIAlterra.Api.Auxiliary;
using ReikaKalseki.DIAlterra.Api.Instantiable;
using ReikaKalseki.DIAlterra.Api.Registry;
using ReikaKalseki.DIAlterra.Api.Registry.VanillaData;
using ReikaKalseki.DIAlterra.Api.Util;
using UnityEngine;

namespace ReikaKalseki.DIAlterra.Api.Base;

public class BasicCraftingItem : CraftingGadget, DIPrefab<BasicCraftingItem, StringPrefabContainer>
{
    private static bool addedTab;

    private static readonly Dictionary<string, BasicCraftingItem> registry = new();
    public readonly List<PlannedIngredient> byproducts = new();
    public readonly string id;

    protected readonly Assembly ownerMod;

    private readonly List<PlannedIngredient> recipe = new();
    public string craftingSubCategory = "" + TechCategory.BasicMaterials;
    public float craftingTime = 0;
    public Vector2int inventorySize = new(1, 1);

    public int numberCrafted = 1;
    public Action<Renderer> renderModify = null;
    public Atlas.Sprite sprite = null;
    public TechType unlockRequirement = TechType.None;

    [SetsRequiredMembers]
    public BasicCraftingItem(XMLLocale.LocaleEntry e, string template) : this(e.key, e.name, e.desc, template)
    {
    }

    [SetsRequiredMembers]
    public BasicCraftingItem(string id, string name, string desc, string template) : base(
        new CustomPrefab(id, name, desc), new RecipeData())
    {
        ownerMod = SNUtil.tryGetModDLL();
        // typeof(CustomPrefab).GetField("Mod", BindingFlags.Instance | BindingFlags.NonPublic).SetValue(this, ownerMod);
        this.id = id;

        if (!addedTab)
            //CraftTreeHandler.AddTabNode(CraftTree.Type.Fabricator, "DIIntermediate", "Intermediate Products", SpriteManager.Get(TechType.HatchingEnzymes));
            addedTab = true;

        baseTemplate = new StringPrefabContainer(template.Contains("/") ? PrefabData.getPrefabID(template) : template);

        ItemRegistry.instance.addItem(prefab);
        prefab.SetRecipe(getRecipe()).WithFabricatorType(CraftTree.Type.Fabricator).WithCraftingTime(craftingTime)
            .WithStepsToFabricatorTab("Resources", craftingSubCategory);
        prefab.SetUnlock(unlockRequirement);
        prefab.SetPdaGroupCategory(TechGroup.Resources, CategoryForPDA);
        prefab.Info.WithSizeInInventory(inventorySize);
        (prefab as CustomPrefab)?.SetGameObject(GetGameObject());
    }

    private TechCategory CategoryForPDA
    {
        get
        {
            var ret = TechCategory.Misc;
            if (Enum.TryParse(craftingSubCategory, out ret))
                return ret;
            if (EnumHandler.TryGetValue(craftingSubCategory, out ret))
                return ret;
            return TechCategory.BasicMaterials;
        }
    }

    public float glowIntensity { get; set; }
    public StringPrefabContainer baseTemplate { get; set; }

    /*
    public TechType getTechType() {
        TechType tech = TechType.None;
        TechTypeHandler.TryGetModdedTechType(id, out tech);
        return tech;
    }*/

    public BasicCraftingItem addIngredient(ItemDef item, int amt)
    {
        return addIngredient(item.getTechType(), amt);
    }

    public BasicCraftingItem addIngredient(CustomPrefab item, int amt)
    {
        return addIngredient(new ModPrefabTechReference(item), amt);
    }

    public BasicCraftingItem addIngredient(TechType item, int amt)
    {
        return addIngredient(new TechTypeContainer(item), amt);
    }

    public Assembly getOwnerMod()
    {
        return ownerMod;
    }

    public virtual bool isResource()
    {
        return false;
    }

    public virtual string getTextureFolder()
    {
        return "Items/World";
    }

    public virtual void prepareGameObject(GameObject go, Renderer[] r)
    {
    }

    public BasicCraftingItem addIngredient(TechTypeReference item, int amt)
    {
        recipe.Add(new PlannedIngredient(item, amt));
        return this;
    }

    public GameObject GetGameObject()
    {
        var go = ObjectUtil.getModPrefabBaseObject(this);
        if (renderModify != null)
            renderModify(go.GetComponentInChildren<Renderer>());
        return go;
    }

    protected RecipeData getRecipe()
    {
        return new RecipeData()
        {
            Ingredients = RecipeUtil.buildRecipeList(recipe),
            craftAmount = numberCrafted,
            LinkedItems = RecipeUtil.buildLinkedItems(byproducts)
        };
    }

    public Atlas.Sprite getIcon()
    {
        return sprite;
    }

    public sealed override string ToString()
    {
        return base.ToString() + " [" + prefab.Info.TechType + "] / " + prefab.Info.ClassID + " / " +
               prefab.Info.PrefabFileName;
    }
}