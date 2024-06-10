using System.Collections.Generic;
using System.Reflection;
using JetBrains.Annotations;
using Nautilus.Assets;
using Nautilus.Assets.Gadgets;
using Nautilus.Crafting;
using ReikaKalseki.DIAlterra.Api.Auxiliary;
using ReikaKalseki.DIAlterra.Api.Instantiable;
using ReikaKalseki.DIAlterra.Api.Registry;
using ReikaKalseki.DIAlterra.Api.Registry.Runtime;
using ReikaKalseki.DIAlterra.Api.Registry.VanillaData;
using ReikaKalseki.DIAlterra.Api.Util;
using UnityEngine;

namespace ReikaKalseki.DIAlterra.Api.Base;

public abstract class CustomEquipable : EquipmentGadget, DIPrefab<CustomEquipable, StringPrefabContainer>
{
    public readonly string id;

    private readonly Assembly ownerMod;

    private readonly List<PlannedIngredient> recipe = new();

    public TechType dependency = TechType.None;
    private readonly PDAManager.PDAPage page;

    protected CustomEquipable(XMLLocale.LocaleEntry e, string template) : this(e.key, e.name, e.desc, template)
    {
        if (!string.IsNullOrEmpty(e.pda))
        {
            page = PDAManager.createPage("ency_" + prefab.Info.ClassID, prefab.Info.PrefabFileName, e.pda,
                "Tech/Equipment");
            var header = e.getField<string>("header");
            if (header != null)
                page.setHeaderImage(TextureManager.getTexture(SNUtil.tryGetModDLL(), "Textures/PDA/" + header));
            page.register();
        }
    }

    protected CustomEquipable(string id, string name, string desc, string template) : base(
        new CustomPrefab(id, name, desc))
    {
        ownerMod = SNUtil.tryGetModDLL();
        typeof(CustomPrefab).GetField("Mod", BindingFlags.Instance | BindingFlags.NonPublic)?.SetValue(this, ownerMod);
        this.id = id;

        baseTemplate = new StringPrefabContainer(template.Contains("/") ? PrefabData.getPrefabID(template) : template);

        ItemRegistry.instance.addItem(prefab);
        TechnologyUnlockSystem.instance.registerPage(prefab.Info.TechType, page);

        if (dependency != TechType.Unobtanium)
            prefab.SetUnlock(dependency);

        var recipeData = new RecipeData()
        {
            craftAmount = 1,
            LinkedItems = getAuxCrafted(),
            Ingredients = RecipeUtil.buildRecipeList(recipe)
        };

        prefab.SetEquipment(EquipmentType).WithQuickSlotType(QuickSlotType.Passive);
        prefab.SetRecipe(recipeData).WithFabricatorType(CraftTree.Type.Fabricator)
            .WithStepsToFabricatorTab("Personal", "Equipment");
        prefab.SetPdaGroupCategory(TechGroup.Personal, isArmor ? TechCategory.Equipment : TechCategory.Tools);
        (prefab as CustomPrefab)?.SetGameObject(ObjectUtil.getModPrefabBaseObject(this));
        prefab.Info.WithIcon(getIcon());
    }

    public bool isArmor { get; }

    public float glowIntensity { get; set; }

    public StringPrefabContainer baseTemplate { get; set; }
    /*
    public TechType getTechType() {
        TechType tech = TechType.None;
        TechTypeHandler.TryGetModdedTechType(id, out tech);
        return tech;
    }*/

    public CustomEquipable addIngredient(ItemDef item, int amt)
    {
        return addIngredient(item.getTechType(), amt);
    }

    public CustomEquipable addIngredient(CustomPrefab item, int amt)
    {
        return addIngredient(new ModPrefabTechReference(item), amt);
    }

    public CustomEquipable addIngredient(TechType item, int amt)
    {
        return addIngredient(new TechTypeContainer(item), amt);
    }

    public virtual void prepareGameObject(GameObject go, Renderer[] r)
    {
    }

    public Atlas.Sprite getIcon()
    {
        return TextureManager.getSprite(ownerMod, "Textures/Items/" + ObjectUtil.formatFileName(prefab));
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
        return "Items/Tools";
    }

    public CustomEquipable addIngredient(TechTypeReference item, int amt)
    {
        recipe.Add(new PlannedIngredient(item, amt));
        return this;
    }

    public void preventNaturalUnlock()
    {
        dependency = TechType.Unobtanium;
    }

    public virtual List<TechType> getAuxCrafted()
    {
        return new List<TechType>();
    }
}