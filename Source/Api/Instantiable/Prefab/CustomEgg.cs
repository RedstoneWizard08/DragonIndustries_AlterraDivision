using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using ECCLibrary;
using ECCLibrary.Data;
using Nautilus.Assets;
using Nautilus.Handlers;
using ReikaKalseki.DIAlterra.Api.Registry;
using ReikaKalseki.DIAlterra.Api.Util;
using UnityEngine;

namespace ReikaKalseki.DIAlterra.Api.Instantiable.Prefab;

public sealed class CustomEgg : DICustomPrefab
{
    private static readonly Dictionary<TechType, CustomEgg> eggs = new();

    private readonly string creatureID;

    public readonly TechType creatureToSpawn;

    public readonly WaterParkCreatureData eggProperties;

    private readonly Assembly ownerMod;
    private readonly TechType template;
    public string creatureHeldDesc;
    public int creatureSize = 3;

    public float eggScale = 1;

    public int eggSize = 2;

    private string eggTexture;
    private Action<GameObject> objectModify;
    private TechType undiscoveredTechType;

    [SetsRequiredMembers]
    public CustomEgg(ICustomPrefab pfb, TechType t) : this(pfb.Info.TechType, t, pfb.Info.ClassID)
    {
    }

    [SetsRequiredMembers]
    public CustomEgg(TechType c, TechType t) : this(c, t, c.AsString())
    {
    }

    [SetsRequiredMembers]
    private CustomEgg(TechType c, TechType t, string id, Assembly a = null) : base(id + "_Egg", id + " Egg",
        "Hatches a " + id)
    {
        ownerMod = a != null ? a : SNUtil.tryGetModDLL();
        creatureToSpawn = c;
        template = t;
        creatureID = id;

        // TODO: Implement
        // WaterParkCreatureData wpp =
        //     WaterParkCreature.waterParkCreatureParameters[eggSize >= 2 ? TechType.BoneShark : TechType.RabbitRay];
        // eggProperties = new WaterParkCreatureParameters(wpp.initialSize, wpp.maxSize, wpp.outsideSize,
        //     wpp.growingPeriod, wpp.isPickupableOutside);

        if (ownerMod == null)
            throw new Exception("Egg item " + creatureID + "/" + Info.TechType + " has no source mod!");

        CraftDataHandler.SetItemSize(creatureToSpawn, new Vector2int(creatureSize, creatureSize));

        // WaterParkCreature.waterParkCreatureParameters[creatureToSpawn] = eggProperties; // TODO

        undiscoveredTechType = EnumHandler.AddEntry<TechType>(Info.ClassID + "_undiscovered", ownerMod);
        SpriteHandler.RegisterSprite(undiscoveredTechType, GetItemSprite());
        CraftDataHandler.SetItemSize(undiscoveredTechType, CraftData.GetItemSize(Info.TechType));

        //WaterParkCreatureData data = ScriptableObject.CreateInstance<WaterParkCreatureData>();

        eggs[creatureToSpawn] = this;
        Info.WithSizeInInventory(new Vector2int(eggSize, eggSize));
    }

    protected override void OnRegister()
    {
        var pfb = ObjectUtil.createWorldObject(template);
        
        if (pfb == null)
        {
            
            SNUtil.log($"Failed to create egg prefab for {creatureID}: {Info.TechType} - Skipping...", ownerMod);
            return;
        }
        
        var egg = pfb.EnsureComponent<CreatureEgg>();
        egg.eggType = Info.TechType;
        egg.overrideEggType = undiscoveredTechType; //undiscovered
        egg.creatureType = creatureToSpawn;
        ObjectUtil.fullyEnable(pfb);
        pfb.transform.localScale = Vector3.one * eggScale;
        RenderUtil.swapTextures(ownerMod, pfb.GetComponentInChildren<Renderer>(), eggTexture + creatureID);
        if (objectModify != null)
            objectModify.Invoke(pfb);
        SetGameObject(pfb);
        
        SNUtil.log("Constructed custom egg for " + creatureID + ": " + Info.TechType, ownerMod);
    }

    public CustomEgg setTexture(string tex)
    {
        eggTexture = tex;
        SpriteHandler.RegisterSprite(creatureToSpawn,
            TextureManager.getSprite(ownerMod, eggTexture + creatureID + "_Hatched"));
        return this;
    }

    public CustomEgg modifyGO(Action<GameObject> a)
    {
        objectModify = a;
        return this;
    }

    public Atlas.Sprite GetItemSprite()
    {
        return TextureManager.getSprite(ownerMod, "Textures/Items/Egg_" + creatureID);
    }

    public static void updateLocale()
    {
        foreach (var e in eggs.Values)
        {
            var cname = Language.main.Get(e.creatureToSpawn);
            LanguageHandler.SetLanguageLine(e.Info.TechType.AsString(), cname + " Egg");
            LanguageHandler.SetLanguageLine("Tooltip_" + e.Info.TechType.AsString(), "Hatches a " + cname);

            LanguageHandler.SetLanguageLine(e.undiscoveredTechType.AsString(),
                Language.main.Get(TechType.BonesharkEggUndiscovered));
            LanguageHandler.SetLanguageLine("Tooltip_" + e.undiscoveredTechType.AsString(),
                Language.main.Get("Tooltip_" + TechType.BonesharkEggUndiscovered.AsString()));

            SNUtil.log("Relocalized " + e + " > " + Language.main.Get(e.Info.TechType), e.ownerMod);
            if (!string.IsNullOrEmpty(e.creatureHeldDesc))
                LanguageHandler.SetLanguageLine("Tooltip_" + e.creatureToSpawn.AsString(),
                    e.creatureHeldDesc + "\nRaised in containment.");
        }
    }

    public static CustomEgg getEgg(TechType creature)
    {
        return eggs.ContainsKey(creature) ? eggs[creature] : null;
    }

    public static CustomEgg createAndRegisterEgg(ICustomPrefab creature, TechType basis, float scale,
        string grownHeldDesc,
        bool isBig, Action<CustomEgg> modify, float eggSpawnRate = 1, params BiomeType[] spawn)
    {
        var egg = new CustomEgg(creature, basis);
        registerEgg(egg, scale, grownHeldDesc, isBig, modify, eggSpawnRate, spawn);
        return egg;
    }

    public static CustomEgg createAndRegisterEgg(TechType creature, TechType basis, float scale, string grownHeldDesc,
        bool isBig, Action<CustomEgg> modify, float eggSpawnRate = 1, params BiomeType[] spawn)
    {
        var egg = new CustomEgg(creature, basis);
        registerEgg(egg, scale, grownHeldDesc, isBig, modify, eggSpawnRate, spawn);
        return egg;
    }

    private static void registerEgg(CustomEgg egg, float scale, string grownHeldDesc, bool isBig,
        Action<CustomEgg> modify, float eggSpawnRate, params BiomeType[] spawn)
    {
        egg.setTexture("Textures/Eggs/");
        egg.creatureHeldDesc = grownHeldDesc;
        egg.eggScale = scale;
        if (!isBig)
        {
            egg.creatureSize = 2;
            egg.eggSize = 1;
        }

        modify?.Invoke(egg);
        egg.Register();
        
        foreach (var b in spawn)
            GenUtil.registerSlotWorldgen(egg.Info.ClassID, egg.Info.PrefabFileName, egg.Info.TechType,
                EntitySlot.Type.Small,
                LargeWorldEntity.CellLevel.Medium, b, 1, 0.2F * eggSpawnRate);
    }
}