using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using Nautilus.Assets;
using Nautilus.Handlers;
using ReikaKalseki.DIAlterra.Api.Auxiliary;
using ReikaKalseki.DIAlterra.Api.Instantiable;
using ReikaKalseki.DIAlterra.Api.Registry;
using ReikaKalseki.DIAlterra.Api.Registry.VanillaData;
using ReikaKalseki.DIAlterra.Api.Util;
using UnityEngine;

namespace ReikaKalseki.DIAlterra.Api.Base;

public sealed class BasicCustomPlant : DICustomPrefab, DIPrefab<FloraPrefabFetch>, Flora
{
    private static readonly Dictionary<TechType, BasicCustomPlant> plants = new();
    private static readonly Dictionary<string, BasicCustomPlant> plantIDs = new();

    private readonly List<BiomeBase> nativeBiomesCave = new();
    private readonly List<BiomeBase> nativeBiomesSurface = new();

    private readonly Assembly ownerMod;

    public readonly BasicCustomPlantSeed seed;

    public HarvestType collectionMethod = HarvestType.DamageAlive;
    public int finalCutBonus = 2;

    [SetsRequiredMembers]
    public BasicCustomPlant(XMLLocale.LocaleEntry e, FloraPrefabFetch template, string seedPfb,
        string seedName = "Seed") : this(e.key, e.name, e.desc, template, seedPfb, seedName)
    {
    }

    [SetsRequiredMembers]
    public BasicCustomPlant(string id, string name, string desc, FloraPrefabFetch template, string seedPfb,
        string seedName = "Seed") : base(id, name, desc)
    {
        baseTemplate = template;
        ownerMod = SNUtil.tryGetModDLL();
        seed = seedPfb == null ? null : new BasicCustomPlantSeed(this, seedPfb, seedName);
        plants[Info.TechType] = this;
        plantIDs[Info.ClassID] = this;
        if (collectionMethod != HarvestType.None || generateSeed())
        {
            seed?.Register();
            ItemRegistry.instance.addItem(seed);
            setPlantSeed(seed, this);
            CraftData.harvestTypeList[Info.TechType] = collectionMethod;
            if (seed != null) CraftData.harvestOutputList[Info.TechType] = seed.Info.TechType;
            CraftData.harvestFinalCutBonusList[Info.TechType] = finalCutBonus;
            SNUtil.log("Finished patching " + this + " > " + CraftData.GetHarvestOutputData(Info.TechType), ownerMod);
        }

        var go = ObjectUtil.getModPrefabBaseObject(this);
        var p = go.EnsureComponent<Pickupable>();
        p.isPickupable = false;
        go.EnsureComponent<ImmuneToPropulsioncannon>();
        SetGameObject(go);
    }

    public float glowIntensity { get; set; }
    public FloraPrefabFetch baseTemplate { get; set; }

    public void prepareGameObject(GameObject go, Renderer[] r)
    {
    }

    public Assembly getOwnerMod()
    {
        return ownerMod;
    }

    public bool isResource()
    {
        return true;
    }

    public string getTextureFolder()
    {
        return "Plants";
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

    public static void setPlantSeed(ICustomPrefab seed, BasicCustomPlant plant)
    {
        plants[seed.Info.TechType] = plant;
        plantIDs[seed.Info.ClassID] = plant;
    }

    public BasicCustomPlant addNativeBiome(BiomeBase b, bool caveOnly = false)
    {
        nativeBiomesCave.Add(b);
        if (!caveOnly)
            nativeBiomesSurface.Add(b);
        return this;
    }

    public void addPDAEntry(string text, float scanTime = 2, string header = null)
    {
        var e = new PDAScanner.EntryData();
        e.key = Info.TechType;
        e.scanTime = scanTime;
        e.locked = true;
        var page = PDAManager.createPage("ency_" + Info.ClassID, Info.PrefabFileName, text, "Lifeforms");
        page.addSubcategory("Flora").addSubcategory(isExploitable() ? "Exploitable" : "Sea");
        if (header != null)
            page.setHeaderImage(TextureManager.getTexture(ownerMod, "Textures/PDA/" + header));
        page.register();
        e.encyclopedia = page.id;
        PDAHandler.AddCustomScannerEntry(e);
    }

    public Atlas.Sprite getIcon()
    {
        return TextureManager.getSprite(ownerMod, "Textures/Items/" + ObjectUtil.formatFileName(this));
    }

    public sealed override string ToString()
    {
        return base.ToString() + " [" + Info.TechType + "] / " + Info.ClassID + " / " + Info.PrefabFileName + " S=" +
               seed;
    }

    private bool isExploitable()
    {
        return collectionMethod != HarvestType.None || isResource();
    }

    private bool generateSeed()
    {
        return collectionMethod != HarvestType.None;
    }

    public Plantable.PlantSize getSize()
    {
        return Plantable.PlantSize.Large;
    }

    public float getScaleInGrowbed(bool indoors)
    {
        return 1;
    }

    public bool canGrowAboveWater()
    {
        return false;
    }

    public bool canGrowUnderWater()
    {
        return true;
    } /*

    public virtual float getGrowthTime() {
        return 1200;
    }

    public virtual void prepareGrowingPlant(GrowingPlant g) {

    }*/

    public void modifySeed(GameObject go)
    {
    }

    public static BasicCustomPlant getPlant(TechType tt)
    {
        return plants.ContainsKey(tt) ? plants[tt] : null;
    }

    public static BasicCustomPlant getPlant(string id)
    {
        return plantIDs.ContainsKey(id) ? plantIDs[id] : null;
    }
}

public class FloraPrefabFetch : PrefabReference
{
    private readonly VanillaFlora flora;

    private readonly string prefab;

    public FloraPrefabFetch(string pfb)
    {
        prefab = pfb;
    }

    public FloraPrefabFetch(VanillaFlora f)
    {
        flora = f;
    }

    public string getPrefabID()
    {
        return flora == null ? prefab : flora.getRandomPrefab(false);
    }
}

public class BasicCustomPlantSeed : DICustomPrefab, DIPrefab<StringPrefabContainer>
{
    public readonly BasicCustomPlant plant;

    public Atlas.Sprite sprite;

    [SetsRequiredMembers]
    public BasicCustomPlantSeed(BasicCustomPlant p, string pfb, string seedName = "Seed") : base(
        p.Info.ClassID + "_seed",
        p.Info.PrefabFileName + " " + seedName, "")
    {
        plant = p;
        typeof(CustomPrefab).GetField("Mod", BindingFlags.Instance | BindingFlags.NonPublic)
            .SetValue(this, p.getOwnerMod());
        sprite = plant.getIcon();
        baseTemplate = new StringPrefabContainer(pfb);
        SetGameObject(GetGameObject());
        Info.WithSizeInInventory(CraftData.GetItemSize(plant.Info.TechType));
    }

    public float glowIntensity { get; set; }

    public StringPrefabContainer baseTemplate { get; set; }
    /*
    public GrowingPlant getPlant(GameObject go) {
        return go.GetComponent<Plantable>().model.GetComponent<GrowingPlant>();
    }*/

    public Assembly getOwnerMod()
    {
        return plant.getOwnerMod();
    }

    public virtual void prepareGameObject(GameObject go, Renderer[] r)
    {
    }

    public bool isResource()
    {
        return true;
    }

    public string getTextureFolder()
    {
        return "Items";
    }

    public Atlas.Sprite getIcon()
    {
        return sprite;
    }

    public GameObject GetGameObject()
    {
        var go = ObjectUtil.getModPrefabBaseObject(this);
        var pp = go.EnsureComponent<Pickupable>();
        pp.isPickupable = true;

        var p = go.EnsureComponent<Plantable>();
        p.aboveWater = plant.canGrowAboveWater();
        p.underwater = plant.canGrowUnderWater();
        p.isSeedling = true;
        p.plantTechType = plant.Info.TechType;
        p.size = plant.getSize();
        p.pickupable = pp;

        p.modelScale = Vector3.one * plant.getScaleInGrowbed(false);
        p.modelIndoorScale = Vector3.one * plant.getScaleInGrowbed(true);

        //GrowingPlant g = getPlant(go);
        //g.growthDuration = plant.getGrowthTime();
        //plant.prepareGrowingPlant(g);

        //ObjectUtil.convertTemplateObject(p.model, plant); //this is the GROWING but not grown one
        /*
        GrowingPlant grow = p.model.EnsureComponent<GrowingPlant>();
        grow.seed = p;
        grow.enabled = true;

        bool active = grow.grownModelPrefab.active;
        grow.grownModelPrefab = UnityEngine.Object.Instantiate(grow.grownModelPrefab);
        grow.grownModelPrefab.SetActive(active);
        ObjectUtil.convertTemplateObject(grow.grownModelPrefab, plant);
        grow.grownModelPrefab.SetActive(true); //FIXME does not work
        Renderer r = grow.grownModelPrefab.GetComponentInChildren<Renderer>();
        plant.prepareGameObject(grow.grownModelPrefab, r);
        grow.growingTransform = grow.grownModelPrefab.transform;
        grow.growingTransform.gameObject.SetActive(true);*/
        /*
        CapsuleCollider cu = plant.GetGameObject().GetComponentInChildren<CapsuleCollider>();
        if (cu != null) {
            CapsuleCollider cc = p.model.EnsureComponent<CapsuleCollider>();
            cc.radius = cu.radius*0.8F;
            cc.center = cu.center;
            cc.direction = cu.direction;
            cc.height = cu.height;
            cc.material = cu.material;
            cc.name = cu.name;
            cc.enabled = cu.enabled;
            cc.isTrigger = cu.isTrigger;
        }*/

        plant.modifySeed(go);

        return go;
    }

    public sealed override string ToString()
    {
        return base.ToString() + " [" + Info.TechType + "] / " + Info.ClassID + " / " + Info.PrefabFileName;
    }
}