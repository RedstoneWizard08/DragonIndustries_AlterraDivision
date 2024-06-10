using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using Nautilus.Assets;
using Nautilus.Crafting;
using Nautilus.Handlers;
using ReikaKalseki.DIAlterra.Api.Auxiliary;
using ReikaKalseki.DIAlterra.Api.Instantiable;
using ReikaKalseki.DIAlterra.Api.Instantiable.Prefab;
using ReikaKalseki.DIAlterra.Api.Registry;
using ReikaKalseki.DIAlterra.Api.Registry.Runtime;
using ReikaKalseki.DIAlterra.Api.Util;
using UnityEngine;

namespace ReikaKalseki.DIAlterra.Api.Base;

public abstract class RetexturedFish : DICustomPrefab, DIPrefab<StringPrefabContainer>
{
    private static readonly Dictionary<TechType, RetexturedFish> creatures = new();
    private static readonly Dictionary<string, RetexturedFish> creatureIDs = new();
    public readonly List<BiomeType> eggSpawns = new();

    private readonly List<BiomeBase> nativeBiomesCave = new();
    private readonly List<BiomeBase> nativeBiomesSurface = new();

    private readonly Assembly ownerMod;
    public bool bigEgg = true;
    public int cookableIntoBase = 0;
    public TechType eggBase = TechType.None;
    public float eggMaturationTime = 2400;
    public float eggScale = 1;
    public float eggSpawnRate = 0;
    private readonly XMLLocale.LocaleEntry locale;

    public float scanTime = 2;

    [SetsRequiredMembers]
    protected RetexturedFish(XMLLocale.LocaleEntry e, string pfb) : this(e.key, e.name, e.desc, pfb)
    {
        locale = e;
    }

    [SetsRequiredMembers]
    protected RetexturedFish(string id, string name, string desc, string pfb) : base(id, name, desc)
    {
        baseTemplate = new StringPrefabContainer(pfb);
        ownerMod = SNUtil.tryGetModDLL();
        typeof(CustomPrefab).GetField("Mod", BindingFlags.Instance | BindingFlags.NonPublic).SetValue(this, ownerMod);

        creatures[Info.TechType] = this;
        creatureIDs[Info.ClassID] = this;

        if (locale != null && !string.IsNullOrEmpty(locale.pda))
            SNUtil.addPDAEntry(this, scanTime, locale.getField<string>("category"), locale.pda,
                locale.getField<string>("header"), null);

        if (eggBase != TechType.None)
            CustomEgg.createAndRegisterEgg(this, eggBase, eggScale, desc, bigEgg,
                e => { e.eggProperties.setGrowingPeriod(eggMaturationTime); }, eggSpawnRate, eggSpawns.ToArray());

        //GenUtil.registerSlotWorldgen(ClassID, PrefabFileName, TechType, EntitySlot.Type.Creature, LargeWorldEntity.CellLevel.Medium, BiomeType.SeaTreaderPath_OpenDeep_CreatureOnly, 1, 0.15F);
        //GenUtil.registerSlotWorldgen(ClassID, PrefabFileName, TechType, EntitySlot.Type.Medium, LargeWorldEntity.CellLevel.Medium, BiomeType.GrandReef_TreaderPath, 1, 0.3F);

        // BehaviourData.behaviourTypeList[Info.TechType] = getBehavior(); // TODO

        var basis = CraftData.entClassTechTable[baseTemplate.prefab];
        // Bioreactor.SetBioReactorCharge(Info.TechType, BaseBioReactor.charge[basis]);
        BaseBioReactor.charge[Info.TechType] = BaseBioReactor.charge[basis];

        if (CraftData.equipmentTypes.ContainsKey(basis) && CraftData.equipmentTypes[basis] == EquipmentType.Hand)
            CraftData.equipmentTypes[Info.TechType] = EquipmentType.Hand;

        if (cookableIntoBase > 0)
        {
            var cooked = CraftData.cookedCreatureList[basis];
            var cured = SNUtil.getTechType(("Cured" + cooked).Replace("Cooked", ""));
            CraftDataHandler.SetCookedVariant(Info.TechType, cooked);
            SNUtil.log("Adding delegate cooking/curing of " + this + " into " + cooked + " & " + cured);

            var rec = new RecipeData();
            rec.Ingredients.Add(new CraftData.Ingredient(Info.TechType, 1));
            var alt = new DuplicateRecipeDelegateWithRecipe(cooked, rec);
            alt.category = TechCategory.CookedFood;
            alt.group = TechGroup.Survival;
            alt.craftingType = CraftTree.Type.Fabricator;
            alt.craftingMenuTree = new[] {"Survival", "CookedFood"};
            alt.ownerMod = ownerMod;
            alt.craftTime = 2; //time not fetchable, not in dict(?!)
            alt.setRecipe(cookableIntoBase);
            alt.unlock = Info.TechType;
            alt.allowUnlockPopups = true;
            alt.prefab.Register();
            TechnologyUnlockSystem.instance.addDirectUnlock(Info.TechType, alt.prefab.Info.TechType);

            rec = new RecipeData();
            rec.Ingredients.Add(new CraftData.Ingredient(Info.TechType, 1));
            rec.Ingredients.Add(new CraftData.Ingredient(TechType.Salt, 1));
            alt = new DuplicateRecipeDelegateWithRecipe(cured, rec);
            alt.category = TechCategory.CuredFood;
            alt.group = TechGroup.Survival;
            alt.craftingType = CraftTree.Type.Fabricator;
            alt.craftingMenuTree = new[] {"Survival", "CuredFood"};
            alt.ownerMod = ownerMod;
            alt.craftTime = 2;
            alt.setRecipe(cookableIntoBase);
            alt.unlock = Info.TechType;
            alt.allowUnlockPopups = true;
            alt.prefab.Register();
            TechnologyUnlockSystem.instance.addDirectUnlock(Info.TechType, alt.prefab.Info.TechType);
        }

        SetGameObject(GetGameObject());
    }

    public float glowIntensity { get; set; }
    public StringPrefabContainer baseTemplate { get; set; }

    public bool isResource()
    {
        return false;
    }

    public virtual string getTextureFolder()
    {
        return "Creature";
    }

    public virtual void prepareGameObject(GameObject go, Renderer[] r)
    {
    }

    public Assembly getOwnerMod()
    {
        return ownerMod;
    }

    public RetexturedFish addNativeBiome(BiomeBase b, bool caveOnly = false)
    {
        nativeBiomesCave.Add(b);
        if (!caveOnly)
            nativeBiomesSurface.Add(b);
        return this;
    }

    public bool isNativeToBiome(Vector3 vec)
    {
        return isNativeToBiome(BiomeBase.getBiome(vec), WorldUtil.isInCave(vec));
    }

    public bool isNativeToBiome(BiomeBase b, bool cave)
    {
        return (cave ? nativeBiomesCave : nativeBiomesSurface).Contains(b);
    }

    public string getPrefabID()
    {
        return Info.ClassID;
    }

    public GameObject GetGameObject()
    {
        var world = ObjectUtil.getModPrefabBaseObject(this);
        world.EnsureComponent<TechTag>().type = Info.TechType;
        world.EnsureComponent<PrefabIdentifier>().ClassId = Info.ClassID;
        world.SetActive(true);
        return world;
    }

    public Atlas.Sprite getIcon()
    {
        return TextureManager.getSprite(ownerMod, "Textures/Items/" + ObjectUtil.formatFileName(this));
    }

    public sealed override string ToString()
    {
        return base.ToString() + " [" + Info.TechType + "] / " + Info.ClassID + " / " + Info.PrefabFileName;
    }

    public abstract BehaviourType getBehavior();

    public static RetexturedFish getFish(string id)
    {
        return creatureIDs.ContainsKey(id) ? creatureIDs[id] : null;
    }

    public static RetexturedFish getFish(TechType tt)
    {
        return creatures.ContainsKey(tt) ? creatures[tt] : null;
    }
}