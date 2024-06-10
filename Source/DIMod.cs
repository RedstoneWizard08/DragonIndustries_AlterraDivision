using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using BepInEx;
using BepInEx.Logging;
using ECCLibrary;
using HarmonyLib;
using Nautilus.Assets.Gadgets;
using Nautilus.Handlers;
using Nautilus.Utility;
using ReikaKalseki.DIAlterra.Api.Base;
using ReikaKalseki.DIAlterra.Api.Instantiable;
using ReikaKalseki.DIAlterra.Api.Instantiable.Prefab;
using ReikaKalseki.DIAlterra.Api.Registry;
using ReikaKalseki.DIAlterra.Api.Util;
using ReikaKalseki.DIAlterra.BuildSystem;
using ReikaKalseki.DIAlterra.Config;
using UnityEngine;
using Object = UnityEngine.Object;

//Needed for most Unity Enginer manipulations: Vectors, GameObjects, Audio, etc.
//For data read/write methods
//For data read/write methods
//Working with Lists and Collections
//More advanced manipulation of lists/collections

namespace ReikaKalseki.DIAlterra;

[BepInPlugin(PluginInfo.PLUGIN_GUID, PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]
[BepInDependency("com.snmodding.nautilus")]
public class DIMod : BaseUnityPlugin
{
    public const string MOD_KEY = "ReikaKalseki.DIAlterra";
    
    public static readonly ManualLogSource LOGGER = new ManualLogSource(PluginInfo.PLUGIN_NAME);
    public static readonly XMLLocale locale = new(SNUtil.diDLL, "XML/locale.xml");
    /*
    private static readonly List<SNMod> mods = new List<SNMod>();

    public static void addMod(SNMod mod) {
        mods.Add(mod);
    }
    */
    //public static readonly ModLogger logger = new ModLogger();

    public static readonly Config<DIConfig.ConfigEntries> config = new(SNUtil.diDLL);

    internal static readonly Dictionary<TechType, ScanningGadget> machineList = new();

    public void Start()
    {
        RuntimeHelpers.RunClassConstructor(typeof(PlacedObject).TypeHandle);
        RuntimeHelpers.RunClassConstructor(typeof(DIPositionedPrefab).TypeHandle);
        RuntimeHelpers.RunClassConstructor(typeof(WorldGenerator).TypeHandle);
        //mods.Insert(0, new SNMod(MOD_KEY));
    }

    public void Awake()
    {
        SNUtil.log("Start DI Main Init", SNUtil.diDLL);
        config.load();

        var harmony = new Harmony(MOD_KEY);
        FileLog.logPath = Path.Combine(Path.GetDirectoryName(SNUtil.diDLL.Location)!, "harmony-log.txt");
        FileLog.Log("Ran mod register, started harmony (harmony log)");
        SNUtil.log("Ran mod register, started harmony", SNUtil.diDLL);
        try
        {
            harmony.PatchAll(SNUtil.diDLL);
        }
        catch (Exception ex)
        {
            FileLog.Log("Caught exception when running patcher!");
            FileLog.Log(ex.Message);
            FileLog.Log(ex.StackTrace);
            FileLog.Log(ex.ToString());
        }

        ModVersionCheck.getFromGitVsInstall("Dragon Industries", SNUtil.diDLL, "DragonIndustries_AlterraDivision")
            .register();
        // SNUtil.checkModHash(SNUtil.diDLL); // TODO: Re-enable

        new ObjectDeleter().Register();

        locale.load();

        var spineEel = createEgg(TechType.SpineEel, TechType.BonesharkEgg, 1, "SpineEelDesc", true, 0.16F, 4, 0.5F,
            BiomeType.BonesField_Ground, BiomeType.LostRiverJunction_Ground).modifyGO(e =>
        {
            var li = new List<Renderer>();
            foreach (var r in e.GetComponentsInChildren<Renderer>())
            {
                RenderUtil.makeTransparent(r);
                RenderUtil.setGlossiness(r.material, 10, 6, 0.5F);
                r.material.SetColor("_SpecColor", new Color(1, 1, 0.8F, 1));
                r.material.SetFloat("_SrcBlend", 5);
                r.material.SetFloat("_DstBlend", 10);
                r.material.SetFloat("_SrcBlend2", 2);
                r.material.SetFloat("_DstBlend2", 10);
                li.Add(r);
            }

            foreach (var r in li)
                for (var i = 0; i < 3; i++)
                {
                    var sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                    sphere.transform.localScale = Vector3.one * 0.1F;
                    sphere.name = "EggGlow_" + i;
                    sphere.transform.SetParent(r.transform.parent);
                    sphere.transform.localPosition =
                        MathUtil.getRandomVectorAround(new Vector3(-0.3F, 0.24F, 0), 0.15F);
                    sphere.transform.localRotation = Quaternion.identity;
                    ObjectUtil.removeComponent<Collider>(sphere);
                    MaterialUtils.ApplySNShaders(sphere, 0f, 0f, 5f);
                    var r2 = sphere.GetComponentInChildren<Renderer>();
                    r2.material.SetColor("_GlowColor", new Color(1, 0.75F, 0.33F, 1));
                    RenderUtil.setEmissivity(r2, 0.8F);
                    RenderUtil.setGlossiness(r2, 4, 0, 0);
                }
        });
        createEgg(TechType.GhostRayBlue, TechType.JumperEgg, 1.75F, "GhostRayDesc", true, 0.12F, 2, 1,
            BiomeType.TreeCove_LakeFloor);
        createEgg(TechType.GhostRayRed, TechType.CrabsnakeEgg, 1.25F, "CrimsonRayDesc", true, 0.6F, 2, 1,
            BiomeType.InactiveLavaZone_Chamber_Floor_Far);
        createEgg(TechType.Biter, TechType.RabbitrayEgg, 1F, "BiterDesc", false, 0.6F, 2, 1,
            BiomeType.GrassyPlateaus_CaveFloor, BiomeType.Mountains_CaveFloor);
        createEgg(TechType.Blighter, TechType.RabbitrayEgg, 1F, "BlighterDesc", false, 0.6F, 2, 1,
            BiomeType.BloodKelp_CaveFloor);
        GenUtil.registerSlotWorldgen("b5d6cf1a-7d42-45f2-a0f3-0e05ff707502", "WorldEntities/Eggs/JumperEgg.prefab",
            TechType.JumperEgg, EntitySlot.Type.Small, LargeWorldEntity.CellLevel.Medium, BiomeType.Kelp_CaveFloor, 1,
            0.32F);

        /*
        dispatchLoadPhase("loadConfig");
        dispatchLoadPhase("afterConfig");
        dispatchLoadPhase("doPatches");
        dispatchLoadPhase("addItems");
        dispatchLoadPhase("loadMain");
        dispatchLoadPhase("loadConfig");
        */
        addCommands();

        SpriteHandler.RegisterSprite(TechType.PDA,
            TextureManager.getSprite(SNUtil.diDLL, "Textures/ScannerSprites/PDA"));
        SpriteHandler.RegisterSprite(TechType.Databox,
            TextureManager.getSprite(SNUtil.diDLL, "Textures/ScannerSprites/Databox"));
        SpriteHandler.RegisterSprite(TechType.ReaperLeviathan,
            TextureManager.getSprite(SNUtil.diDLL, "Textures/ScannerSprites/Reaper"));

        SNUtil.log("Finish DI Main Init", SNUtil.diDLL);

        //dispatchLoadPhase("loadModInteract");
        //dispatchLoadPhase("loadFinal");
        BiomeBase.initializeBiomeHoles();

        ModVersionCheck.fetchRemoteVersions();

        SNUtil.log("Finish DI Post Init", SNUtil.diDLL);
    }

    private static void killSelf()
    {
        var v = Player.main.GetVehicle();
        if (v)
            v.GetComponent<LiveMixin>().TakeDamage(99999);
        if (Player.main.currentSub && Player.main.currentSub.isCyclops)
            Player.main.currentSub.GetComponent<LiveMixin>().TakeDamage(99999);
        Player.main.GetComponent<LiveMixin>().TakeDamage(99999);
    }

    private static CustomEgg createEgg(TechType creature, TechType basis, float scale, string locKey, bool isBig,
        float grownScale, float daysToGrow, float rate, params BiomeType[] spawn)
    {
        Action<CustomEgg> a = e =>
        {
            e.eggProperties.maxSize = grownScale;
            if (!isBig)
                e.eggProperties.initialSize = Mathf.Max(e.eggProperties.initialSize, 0.2F);
            e.eggProperties.setGrowingPeriod(daysToGrow * 20 * 60);
        };
        SNUtil.allowDIDLL = true;
        SNUtil.log($"Registering egg for {creature} (basis {basis})...");
        var egg = CustomEgg.createAndRegisterEgg(creature, basis, scale, locale.getEntry(locKey).desc, isBig, a, rate,
            spawn);
        SNUtil.allowDIDLL = false;
        return egg;
    }

    private static void dispatchLoadPhase(string phase)
    {
        /*
            foreach (SNMod mod in mods) {

            }*/
    }

    private static void addCommands()
    {
        BuildingHandler.instance.addCommand<string, PlacedObject>("pfb", BuildingHandler.instance.spawnPrefabAtLook);
        //BuildingHandler.instance.addCommand<string>("btt", BuildingHandler.instance.spawnTechTypeAtLook);
        BuildingHandler.instance.addCommand<bool>("bden", BuildingHandler.instance.setEnabled);
        BuildingHandler.instance.addCommand("bdsa", BuildingHandler.instance.selectAll);
        BuildingHandler.instance.addCommand("bdslp", BuildingHandler.instance.selectLastPlaced);
        BuildingHandler.instance.addCommand("bdsync", BuildingHandler.instance.syncObjects);
        BuildingHandler.instance.addCommand<string>("bdexs", BuildingHandler.instance.saveSelection);
        BuildingHandler.instance.addCommand<string>("bdexa", BuildingHandler.instance.saveAll);
        BuildingHandler.instance.addCommand<string>("bdld", BuildingHandler.instance.loadFile);
        BuildingHandler.instance.addCommand("bdinfo", BuildingHandler.instance.selectedInfo);
        BuildingHandler.instance.addCommand("bdtex", BuildingHandler.instance.dumpTextures);
        BuildingHandler.instance.addCommand("bdact", BuildingHandler.instance.activateObject);
        BuildingHandler.instance.addCommand<float>("bdsc", BuildingHandler.instance.setScale);
        ConsoleCommandsHandler.RegisterConsoleCommand<Action<string, bool>>("sound", SoundManager.playSound);
        ConsoleCommandsHandler.RegisterConsoleCommand("dumpBiomeTex", DIHooks.dumpWaterscapeTextures);
        ConsoleCommandsHandler.RegisterConsoleCommand("biomeAt", printBiomeData);
        ConsoleCommandsHandler.RegisterConsoleCommand("killSelf", killSelf);
        ConsoleCommandsHandler.RegisterConsoleCommand("clear000", clear000);
        ConsoleCommandsHandler.RegisterConsoleCommand("particle", spawnParticle);
        ConsoleCommandsHandler.RegisterConsoleCommand("hideVersions", DIHooks.hideVersions);
        //ConsoleCommandsHandler.RegisterConsoleCommand<Action>("autoUpdate", DIHooks.autoUpdate);
        //ConsoleCommandsHandler.RegisterConsoleCommand<Action<string, string, string>>("exec", DebugExec.run);
        ConsoleCommandsHandler.RegisterConsoleCommand("vehicleToMe", bringVehicleToPlayer);
    }

    private static void bringVehicleToPlayer(string type)
    {
        MonoBehaviour v = null;
        switch (type.ToLowerInvariant())
        {
            case "seamoth":
                v = WorldUtil.getClosest<SeaMoth>(Player.main.transform.position);
                break;
            case "prawn":
            case "exosuit":
                v = WorldUtil.getClosest<Exosuit>(Player.main.transform.position);
                break;
            case "cyclops":
                v = WorldUtil.getClosest<SubRoot>(Player.main.transform.position);
                break;
        }

        if (v)
        {
            var pos = Camera.main.transform.position + Camera.main.transform.forward * 10;
            if (v is Vehicle)
                ((Vehicle) v).TeleportVehicle(pos, v.transform.rotation);
            else if (v is SubRoot && ((SubRoot) v).isCyclops) v.transform.position = pos;
        }
    }

    private static void printBiomeData()
    {
        SNUtil.writeToChat("Current native biome: " +
                           WaterBiomeManager.main.GetBiome(Player.main.transform.position, false));
        SNUtil.writeToChat("Localized DI name: " + BiomeBase.getBiome(Player.main.transform.position).displayName);
    }

    private static void spawnParticle(string pfb, float dur)
    {
        WorldUtil.spawnParticlesAt(Camera.main.transform.position + Camera.main.transform.forward.normalized * 10, pfb,
            dur, true);
    }

    private static void clear000()
    {
        foreach (var go in WorldUtil.getObjectsNear(Vector3.zero, 0.2F))
            if (go && go.activeInHierarchy && go.transform.position.magnitude < 0.02F)
            {
                var pi = go.FindAncestor<PrefabIdentifier>();
                if (pi && !pi.GetComponentInChildren<Vehicle>() && !pi.GetComponentInChildren<Player>() &&
                    !pi.GetComponentInChildren<SubRoot>())
                    Destroy(pi.gameObject);
            }
    }

    public static void restartGame()
    {
        var svc = PlatformUtils.main.services;
        if (svc is PlatformServicesSteam)
            ((PlatformServicesSteam) svc).RestartInSteam();
    }
}