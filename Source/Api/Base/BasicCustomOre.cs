using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using Nautilus.Assets;
using ReikaKalseki.DIAlterra.Api.Auxiliary;
using ReikaKalseki.DIAlterra.Api.Instantiable;
using ReikaKalseki.DIAlterra.Api.Registry;
using ReikaKalseki.DIAlterra.Api.Registry.VanillaData;
using ReikaKalseki.DIAlterra.Api.Util;
using UnityEngine;

namespace ReikaKalseki.DIAlterra.Api.Base;

public class BasicCustomOre : DICustomPrefab, DIPrefab<VanillaResources>
{
    public readonly bool isLargeResource;

    private readonly Assembly ownerMod;

    public string collectSound = CraftData.defaultPickupSound;
    public Vector2int inventorySize = new(1, 1);

    [SetsRequiredMembers]
    public BasicCustomOre(XMLLocale.LocaleEntry e, VanillaResources template) : this(e.key, e.name, e.desc, template)
    {
    }

    [SetsRequiredMembers]
    public BasicCustomOre(string id, string name, string desc, VanillaResources template) : base(id, name, desc)
    {
        ownerMod = SNUtil.tryGetModDLL();
        typeof(CustomPrefab).GetField("Mod", BindingFlags.Instance | BindingFlags.NonPublic).SetValue(this, ownerMod);
        baseTemplate = template;

        ItemRegistry.instance.addItem(this);

        if (collectSound != null)
            CraftData.pickupSoundList[Info.TechType] = collectSound;

        Info = Info.WithSizeInInventory(inventorySize).WithIcon(getIcon());
        SetGameObject(ObjectUtil.getModPrefabBaseObject(this));
    }

    public float glowIntensity { get; set; }
    public VanillaResources baseTemplate { get; set; }

    public virtual void prepareGameObject(GameObject go, Renderer[] r)
    {
    }

    public Atlas.Sprite getIcon()
    {
        return TextureManager.getSprite(ownerMod, "Textures/Items/" + ObjectUtil.formatFileName(this));
    }

    public virtual bool isResource()
    {
        return true;
    }

    public Assembly getOwnerMod()
    {
        return ownerMod;
    }

    public virtual string getTextureFolder()
    {
        return "Resources";
    }

    public void registerWorldgen(BiomeType biome, int amt, float chance)
    {
        SNUtil.log("Adding worldgen " + biome + " x" + amt + " @ " + chance + "% to " + this, ownerMod);
        GenUtil.registerOreWorldgen(this, biome, amt, chance);
    }

    public void addPDAEntry(string text, float scanTime = 2, string header = null)
    {
        SNUtil.addPDAEntry(this, scanTime, "PlanetaryGeology", text, header, null);
    }

    public sealed override string ToString()
    {
        return base.ToString() + " [" + Info.TechType + "] / " + Info.ClassID + " / " + Info.PrefabFileName;
    }
}