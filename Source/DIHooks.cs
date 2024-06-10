using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Nautilus.Assets;
using Nautilus.Handlers;
using Nautilus.Utility;
using ReikaKalseki.DIAlterra.Api.Base;
using ReikaKalseki.DIAlterra.Api.Instantiable;
using ReikaKalseki.DIAlterra.Api.Instantiable.Component;
using ReikaKalseki.DIAlterra.Api.Instantiable.Prefab;
using ReikaKalseki.DIAlterra.Api.Registry;
using ReikaKalseki.DIAlterra.Api.Registry.Runtime;
using ReikaKalseki.DIAlterra.Api.Util;
using ReikaKalseki.DIAlterra.BuildSystem;
using ReikaKalseki.DIAlterra.BuildSystem.ObjectManipulation;
using ReikaKalseki.DIAlterra.Config;
using Story;
using TMPro;
using UnityEngine;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;

//using System.Net.Http;
//using System.Threading.Tasks;
//using Oculus.Newtonsoft.Json;
//using Oculus.Newtonsoft.Json.Linq;

namespace ReikaKalseki.DIAlterra;

public static class DIHooks
{
    internal static readonly float NEAR_LAVA_RADIUS = 16;

    private static float worldLoadTime = -1;

    public static event Action<DayNightCycle> onDayNightTickEvent;
    public static event Action onWorldLoadedEvent;
    public static event Action<Player> onPlayerTickEvent;
    public static event Action<SeaMoth> onSeamothTickEvent;
    public static event Action<Exosuit> onPrawnTickEvent;
    public static event Action<SubRoot> onCyclopsTickEvent;
    public static event Action<DamageToDeal> onDamageEvent;
    public static event Action<Pickupable, Exosuit, bool> onItemPickedUpEvent;
    public static event Action<CellManager, LargeWorldEntity> onEntityRegisterEvent;
    public static event Action<SkyApplier> onSkyApplierSpawnEvent;
    public static event Action<Constructable, bool> onConstructedEvent;
    public static event Action<BaseRoot> onBaseLoadedEvent;
    public static event Action<StorageContainer> inventoryOpenedEvent;
    public static event Action<StorageContainer> inventoryClosedEvent;
    public static event Action<BiomeCheck> getBiomeEvent;
    public static event Action<WaterTemperatureCalculation> getTemperatureEvent;
    public static event Action<GameObject> onKnifedEvent;
    public static event Action<KnifeAttempt> knifeAttemptEvent;
    public static event Action<GravTrapGrabAttempt> gravTrapAttemptEvent;
    public static event Action<SeaMoth, int, TechType, bool> onSeamothModulesChangedEvent;
    public static event Action<SubRoot> onCyclopsModulesChangedEvent;
    public static event Action<Exosuit, int, TechType, bool> onPrawnModulesChangedEvent;
    public static event Action<SeaMoth, TechType, int> onSeamothModuleUsedEvent;
    public static event Action<SNCameraRoot> onSonarUsedEvent;
    public static event Action<SeaMoth> onSeamothSonarUsedEvent;
    public static event Action<SubRoot> onCyclopsSonarUsedEvent;
    public static event Action<GameObject> onEggHatchedEvent;
    public static event Action<EMPBlast, GameObject> onEMPHitEvent;
    public static event Action<EMPBlast, Collider> onEMPTouchEvent;

    public static event Action<StringBuilder, TechType, GameObject> itemTooltipEvent;

    //public static event Action<WaterFogValues> fogCalculateEvent;
    public static event Action<BuildabilityCheck> constructabilityEvent;
    public static event Action<BreathabilityCheck> breathabilityEvent;
    public static event Action<StoryHandCheck> storyHandEvent;
    public static event Action<RadiationCheck> radiationCheckEvent;
    public static event Action<BulkheadLaserCutterHoverCheck> bulkheadLaserHoverEvent;

    public static event Action<KnifeHarvest> knifeHarvestEvent;

    //public static event Action<MusicSelectionCheck> musicBiomeChoiceEvent;
    public static event Action<FruitPlantTag> onFruitPlantTickEvent;
    public static event Action<ReaperLeviathan, Vehicle> reaperGrabVehicleEvent;
    public static event Action<FMOD_CustomEmitter> onSoundPlayedEvent;
    public static event Action<SolarEfficiencyCheck> solarEfficiencyEvent;
    public static event Action<Vehicle, Player> vehicleEnterEvent;
    public static event Action<DepthCompassCheck> depthCompassEvent;
    public static event Action<Survival, Player, bool> respawnEvent;
    public static event Action<PropulsibilityCheck> propulsibilityEvent;
    public static event Action<Drillable, Vector3, Exosuit> drillableDrillTickEvent;
    public static event Action<DroppabilityCheck> droppabilityEvent;
    public static event Action<MapRoomFunctionality> scannerRoomTickEvent;
    public static event Action itemsLostEvent;
    public static event Action<StorageContainer, GUIHand> storageHoverEvent;
    public static event Action<ModuleFireCostCheck> moduleFireCostEvent;
    public static event Action<PDAScanner.EntryData> scanCompleteEvent;
    public static event Action selfScanEvent;
    public static event Action<uGUI_MapRoomScanner> scannerRoomTechTypeListingEvent;
    public static event Action<StasisEffectCheck> onStasisRifleFreezeEvent;
    public static event Action<StasisEffectCheck> onStasisRifleUnfreezeEvent;

    public static event Action<RedundantScanEvent> onRedundantScanEvent;

    // public static event Action<EquipmentCompatibilityCheck> equipmentCompatibilityCheckEvent;
    public static event Action<EquipmentTypeCheck> equipmentTypeCheckEvent;
    public static event Action<EatAttempt> tryEatEvent;
    public static event Action<Survival, GameObject> onEatEvent;
    public static event Action<SwimSpeedCalculation> getSwimSpeedEvent;
    public static event Action<Bed> onSleepEvent;
    public static event Action<FoodRateCalculation> getFoodRateEvent;
    public static event Action<PlayerInput> getPlayerInputEvent;
    public static event Action<Bullet, Vehicle> onTorpedoFireEvent;
    public static event Action<SeamothTorpedo, Transform> onTorpedoExplodeEvent;

    private static BasicText updateNotice = new(TextAlignmentOptions.Center);

    private static readonly HashSet<TechType> gravTrapTechSet = new();

    public static readonly string itemNotDroppableLocaleKey = "ItemNotDroppable";

    private static bool hasLoadedAWorld;
    private static bool outdatedMods;

    private static bool isKnifeHarvesting;
    private static CustomBiome currentCustomBiome;

    public static bool skipWorldForces = false;
    public static bool skipSkyApplier = false;

    static DIHooks()
    {
        SNUtil.log("Initializing DIHooks");

        PrecursorTeleporter.TeleportEventStart += startTeleport;
        PrecursorTeleporter.TeleportEventEnd += stopTeleport;
    }

    public class PlayerInput
    {
        public readonly Vector3 originalInput;
        public Vector3 selectedInput;

        internal PlayerInput(Vector3 vec)
        {
            originalInput = vec;
            selectedInput = vec;
        }
    }

    public class DamageToDeal
    {
        public readonly float originalAmount;
        public readonly DamageType type;
        public readonly GameObject target;
        public readonly GameObject dealer;

        private bool disallowFurtherChanges;

        internal float amount;

        internal DamageToDeal(float amt, DamageType tt, GameObject tgt, GameObject dl)
        {
            originalAmount = amt;
            amount = originalAmount;
            type = tt;
            target = tgt;
            dealer = dl;
            disallowFurtherChanges = false;
        }

        public void lockValue()
        {
            disallowFurtherChanges = true;
        }

        public void setValue(float amt)
        {
            if (disallowFurtherChanges)
                return;
            amount = amt;
            if (amount < 0)
                amount = 0;
        }

        public float getAmount()
        {
            return amount;
        }
    }

    public class KnifeHarvest
    {
        public readonly GameObject hit;
        public readonly TechType objectType;
        public readonly bool isAlive;
        public readonly bool wasAlive;

        public readonly HarvestType harvestType;
        public readonly TechType defaultDrop;

        public readonly Dictionary<TechType, int> drops = new();

        internal KnifeHarvest(GameObject go, TechType tt, bool isa, bool was)
        {
            hit = go;
            objectType = tt;
            isAlive = isa;
            wasAlive = was;
            harvestType = CraftData.GetHarvestTypeFromTech(tt);
            defaultDrop = CraftData.GetHarvestOutputData(tt);

            if ((harvestType == HarvestType.DamageAlive && wasAlive) ||
                (harvestType == HarvestType.DamageDead && !isAlive))
            {
                var num = 1;
                if (harvestType == HarvestType.DamageAlive && !isAlive)
                    num += CraftData.GetHarvestFinalCutBonus(tt);

                if (defaultDrop != TechType.None)
                    drops[defaultDrop] = num;
            }
        }
    }

    public class BiomeCheck
    {
        public readonly string originalValue;
        public readonly Vector3 position;

        private bool disallowFurtherChanges;

        internal string biome;

        internal BiomeCheck(string amt, Vector3 pos)
        {
            originalValue = amt;
            biome = originalValue;
            position = pos;
            disallowFurtherChanges = false;
        }

        public void lockValue()
        {
            disallowFurtherChanges = true;
        }

        public void setValue(string b)
        {
            if (disallowFurtherChanges)
                return;
            biome = b;
        }
    }
    /*
    public class MusicSelectionCheck {

        public readonly string originalBiome;
        public readonly MusicManager manager;

        private bool disallowFurtherChanges;

        internal string biomeToDelegateTo;

        internal MusicSelectionCheck(string biome, MusicManager mgr) {
            originalBiome = biome;
            biomeToDelegateTo = originalBiome;
            manager = mgr;
            disallowFurtherChanges = false;
        }

        public void lockValue() {
            disallowFurtherChanges = true;
        }

        public void setValue(string b) {
            if (disallowFurtherChanges)
                return;
            biomeToDelegateTo = b;
        }

    }*/

    public class WaterTemperatureCalculation
    {
        public readonly float originalValue;
        public readonly Vector3 position;
        public readonly WaterTemperatureSimulation manager;

        private bool disallowFurtherChanges;

        internal float temperature;

        internal WaterTemperatureCalculation(float amt, WaterTemperatureSimulation sim, Vector3 pos)
        {
            originalValue = amt;
            temperature = originalValue;
            position = pos;
            manager = sim;
            disallowFurtherChanges = false;
        }

        public void lockValue()
        {
            disallowFurtherChanges = true;
        }

        public float getTemperature()
        {
            return temperature;
        }

        public void setValue(float amt)
        {
            //SNUtil.writeToChat("Setting water temp to "+amt);
            if (disallowFurtherChanges)
                return;
            temperature = amt;
        }
    }

    public class SwimSpeedCalculation
    {
        public readonly float originalValue;

        private bool disallowFurtherChanges;

        internal float speed;

        internal SwimSpeedCalculation(float amt)
        {
            originalValue = amt;
            speed = originalValue;
            disallowFurtherChanges = false;
        }

        public void lockValue()
        {
            disallowFurtherChanges = true;
        }

        public float getValue()
        {
            return speed;
        }

        public void setValue(float amt)
        {
            //SNUtil.writeToChat("Setting water temp to "+amt);
            if (disallowFurtherChanges)
                return;
            speed = amt;
        }
    }

    public class FoodRateCalculation
    {
        public readonly float originalValue;
        public float rate;

        internal FoodRateCalculation(float amt)
        {
            originalValue = amt;
            rate = originalValue;
        }
    }

    public class WaterFogValues
    {
        public readonly Color originalColor;
        public readonly float originalDensity;
        public readonly float originalSunValue;

        public Color color;
        public float density;
        public float sunValue;

        internal WaterFogValues(Color c, float d, float s)
        {
            originalColor = c;
            originalDensity = d;
            originalSunValue = s;
            density = d;
            color = c;
            sunValue = s;
        }
    }

    public class EatAttempt
    {
        public readonly Survival survival;
        public readonly GameObject food;

        public bool allowEat = true;

        internal EatAttempt(Survival s, GameObject go)
        {
            survival = s;
            food = go;
        }
    }

    public class KnifeAttempt
    {
        public readonly LiveMixin target;
        public readonly bool defaultValue;

        public bool allowKnife = true;

        internal KnifeAttempt(LiveMixin tgt, bool def)
        {
            target = tgt;
            defaultValue = def;
        }
    }

    public class GravTrapGrabAttempt
    {
        public readonly Gravsphere gravtrap;
        public readonly GameObject target;
        public readonly bool defaultValue;

        public bool allowGrab;

        internal GravTrapGrabAttempt(Gravsphere s, GameObject tgt, bool def)
        {
            gravtrap = s;
            target = tgt;
            defaultValue = def;
            allowGrab = def;
        }
    }

    public class BuildabilityCheck
    {
        public readonly bool originalValue;
        public readonly Collider placeOn;

        public bool placeable;
        public bool ignoreSpaceRequirements = false;

        internal BuildabilityCheck(bool orig, Collider pos)
        {
            originalValue = orig;
            placeable = orig;
            placeOn = pos;
        }
    }

    public class BreathabilityCheck
    {
        public readonly bool originalValue;
        public readonly Player player;

        public bool breathable;

        internal BreathabilityCheck(bool orig, Player ep)
        {
            originalValue = orig;
            breathable = orig;
            player = ep;
        }
    }
    /*
    public class EquipmentCompatibilityCheck {

        public readonly bool originalValue;
        public readonly Equipment container;
        public readonly Pickupable item;
        public readonly EquipmentType itemType;
        public readonly EquipmentType slotType;

        public bool allow;

        internal EquipmentCompatibilityCheck(Equipment box, Pickupable pp, EquipmentType t1, EquipmentType t2, bool orig) {
            originalValue = orig;
            allow = orig;
            container = box;
            item = pp;
            itemType = t1;
            slotType = t2;
        }

    }*/

    public class EquipmentTypeCheck
    {
        public readonly EquipmentType originalValue;
        public readonly TechType item;

        public EquipmentType type;

        internal EquipmentTypeCheck(TechType pp, EquipmentType orig)
        {
            originalValue = orig;
            type = orig;
            item = pp;
        }
    }

    public class StoryHandCheck
    {
        public readonly StoryGoal originalValue;
        public readonly StoryHandTarget component;

        public bool usable = true;
        public StoryGoal goal;

        internal StoryHandCheck(StoryGoal orig, StoryHandTarget tgt)
        {
            originalValue = orig;
            goal = orig;
            component = tgt;
        }
    }

    public class RadiationCheck
    {
        public readonly Vector3 position;
        public readonly float originalValue; //0-1

        public float value;

        internal RadiationCheck(Vector3 pos, float orig)
        {
            originalValue = orig;
            value = orig;
            position = pos;
        }
    }

    public class PropulsibilityCheck
    {
        public readonly GameObject obj;
        public readonly float originalValue;
        public readonly MonoBehaviour gunComponent;
        public readonly bool isMass;

        public float value;

        internal PropulsibilityCheck(GameObject go, float orig, MonoBehaviour gun, bool mass)
        {
            originalValue = orig;
            value = orig;
            obj = go;
            isMass = mass;
            gunComponent = gun;
        }
    }

    public class SolarEfficiencyCheck
    {
        public readonly SolarPanel panel;
        public readonly float originalValue;

        public float value;

        internal SolarEfficiencyCheck(SolarPanel pos, float orig)
        {
            originalValue = orig;
            value = orig;
            panel = pos;
        }
    }

    public class BulkheadLaserCutterHoverCheck
    {
        public readonly Sealed obj;

        public string refusalLocaleKey = null;

        internal BulkheadLaserCutterHoverCheck(Sealed s)
        {
            obj = s;
        }
    }

    public class DepthCompassCheck
    {
        public readonly int originalValue;
        public readonly int originalCrushValue;

        public int value;
        public int crushValue;

        internal DepthCompassCheck(int orig, int crush)
        {
            originalValue = orig;
            value = orig;

            originalCrushValue = crush;
            crushValue = crush;
        }
    }

    public class DroppabilityCheck
    {
        public readonly Pickupable item;
        public readonly bool notify;
        public readonly bool defaultAllow;

        public bool allow;
        public string error = null;

        internal DroppabilityCheck(Pickupable pp, bool n, bool a)
        {
            item = pp;
            notify = n;
            defaultAllow = a;
            allow = defaultAllow;
        }
    }

    public class ModuleFireCostCheck
    {
        public readonly TechType module;
        public readonly Vehicle vehicle;
        public readonly float originalValue;

        public float value;

        internal ModuleFireCostCheck(Vehicle v, TechType item, float orig)
        {
            originalValue = orig;
            value = orig;
            module = item;
            vehicle = v;
        }
    }

    public class StasisEffectCheck
    {
        public readonly StasisSphere sphere;
        public readonly Rigidbody body;

        public bool applyKinematicChange = true;
        public bool addToTargetList = true;
        public bool sendMessage = true;
        public bool doFX = true;

        internal StasisEffectCheck(StasisSphere s, Rigidbody b)
        {
            sphere = s;
            body = b;
        }
    }

    public class RedundantScanEvent
    {
        public bool preventNormalDrop = false;
    }

    public static void onTick(DayNightCycle cyc)
    {
        if (BuildingHandler.instance.isEnabled)
        {
            if (GameInput.GetButtonDown(GameInput.Button.LeftHand))
                BuildingHandler.instance.handleClick(KeyCodeUtils.GetKeyHeld(KeyCode.LeftControl));
            if (GameInput.GetButtonDown(GameInput.Button.RightHand))
                BuildingHandler.instance.handleRClick(KeyCodeUtils.GetKeyHeld(KeyCode.LeftControl));

            if (KeyCodeUtils.GetKeyHeld(KeyCode.Delete)) BuildingHandler.instance.deleteSelected();

            if (KeyCodeUtils.GetKeyHeld(KeyCode.LeftAlt)) BuildingHandler.instance.manipulateSelected();
        }

        CustomBiome.tickMusic(cyc);

        if (getWorldAge() > 0.25F) SaveSystem.populateLoad();

        onDayNightTickEvent?.Invoke(cyc);
    }

    public static void onMainMenuLoaded()
    {
        worldLoadTime = -1;
    }

    public static void onWorldLoaded()
    {
        var warnRestart = hasLoadedAWorld;
        hasLoadedAWorld = true;
        worldLoadTime = Time.time;
        SNUtil.log("Intercepted world load", SNUtil.diDLL);
        DuplicateRecipeDelegate.updateLocale();
        CustomEgg.updateLocale();
        PickedUpAsOtherItem.updateLocale();
        SeamothModule.updateLocale();
        /*
        SNUtil.log("Item goals:", SNUtil.diDLL);
        foreach (Story.ItemGoal g in Story.StoryGoalManager.main.itemGoalTracker.goals)
            SNUtil.log(g.key+" from "+g.techType, SNUtil.diDLL);
        SNUtil.log("Location goals:", SNUtil.diDLL);
        foreach (Story.LocationGoal g in Story.StoryGoalManager.main.locationGoalTracker.goals)
            SNUtil.log(g.key+" at "+g.location+" ("+g.position+")", SNUtil.diDLL);
        SNUtil.log("Biome goals:", SNUtil.diDLL);
        foreach (Story.BiomeGoal g in Story.StoryGoalManager.main.biomeGoalTracker.goals)
            SNUtil.log(g.key+" in "+g.biome, SNUtil.diDLL);
        SNUtil.log("Compound goals:", SNUtil.diDLL);
        foreach (Story.CompoundGoal g in Story.StoryGoalManager.main.compoundGoalTracker.goals)
            SNUtil.log(g.key+" of ["+string.Join(", ",g.preconditions)+"]", SNUtil.diDLL);
        */
        LanguageHandler.SetLanguageLine("BulkheadInoperable", "Bulkhead is inoperable");

        //SaveSystem.populateLoad();

        var vers = ModVersionCheck.getOutdatedVersions();
        updateNotice.SetLocation(0, 250);
        updateNotice.SetSize(24);
        updateNotice.SetColor(Color.yellow);
        var li = new List<string>();
        outdatedMods = vers.Count > 0;
        if (outdatedMods)
        {
            li.Add("Your versions of the following mods are out of date:");
            foreach (var mv in vers)
                li.Add(mv.modName + ": Current version " + mv.currentVersion + ", newest version " +
                       mv.remoteVersion.Invoke());
            li.Add("Update your mods to remove this warning.");
            //li.Add("Run the /autoUpdate command to download and install these updates automatically.");
        }

        vers = ModVersionCheck.getErroredVersions();
        if (vers.Count > 0)
        {
            li.Add("Several mods failed to fetch version information:");
            foreach (var mv in vers)
                li.Add(mv.modName + ": Installed version " + mv.currentVersion + ", remote version " +
                       mv.remoteVersion.Invoke());
            if (SNUtil.checkPiracy())
            {
                li.Add(
                    "<color=#ff5050ff>This appears to be a result of pirating the game, which cuts its internet connection. There is nothing that can be done without buying Subnautica.</color>");
            }
            else
            {
                li.Add(
                    "You should redownload and reinstall mods with local errors and contact Reika if remote versions are invalid.");
                li.Add("This message can be temporarily hidden with /hideVersions");
            }
        }

        if (warnRestart)
            li.Add(
                "You have reloaded a save without exiting the game. This breaks mod loading and will damage your world. Restart your game when changing/reloading saves.\nExit the game now, and DO NOT SAVE before doing so.");
        if (li.Count > 0)
            updateNotice.ShowMessage(string.Join("\n", li));
        else
            updateNotice.Hide();

        onWorldLoadedEvent?.Invoke();
    }
    /*
    internal static void autoUpdate() { //TODO move to own class, and make msg prep and call its own method
        if (outdatedMods | true) {
            SNUtil.writeToChat("Downloading new versions of mods...");
            string dirpath = Path.Combine(Environment.CurrentDirectory, "DIDownloads");
            Directory.CreateDirectory(dirpath);
            using(HttpClient client = new HttpClient()) {
                HttpRequestMessage msg = new HttpRequestMessage(HttpMethod.Get, "https://api.github.com/repos/ReikaKalseki/Reika_SubnauticaModsShared/releases/latest");
                msg.Headers.Add("User-Agent", "Dragon Industries Autoupdate");
                msg.Headers.Add("Accept", "application/vnd.github+json");
                msg.Headers.Add("X-GitHub-Api-Version", "2022-11-28");
                Task<HttpResponseMessage> resp = client.SendAsync(msg);
                resp.RunSynchronously();
                Task<string> task = resp.Result.Content.ReadAsStringAsync();
                task.RunSynchronously();
                JObject json = JObject.Parse(task.Result);
                int id = (int)json["id"];
                msg = new HttpRequestMessage(HttpMethod.Get, "https://api.github.com/repos/ReikaKalseki/Reika_SubnauticaModsShared/releases/"+id+"/assets");
                msg.Headers.Add("User-Agent", "Dragon Industries Autoupdate");
                msg.Headers.Add("Accept", "application/vnd.github+json");
                msg.Headers.Add("X-GitHub-Api-Version", "2022-11-28");
                resp = client.SendAsync(msg);
                resp.RunSynchronously();
                task = resp.Result.Content.ReadAsStringAsync();
                task.RunSynchronously();
                json = JObject.Parse(task.Result);
                foreach (JObject mod in json.Values()) {
                    string url = ((string)json["browser_download_url"]).Replace("\"", "");
                    SNUtil.writeToChat("Downloading from "+url);
                    new System.Net.WebClient().DownloadFile(url, Path.Combine(dirpath, url.Substring(url.LastIndexOf('/')+1)));
                }
            }
        }
        else {
            SNUtil.writeToChat("No outdated mods, no download will be performed.");
        }

        //https://github.com/ReikaKalseki/Reika_SubnauticaModsShared/releases/download/Downloads/AqueousEngineering.zip
        //https://github.com/ReikaKalseki/Reika_SubnauticaModsShared/releases/download/Downloads/Dragon_Industries_-_Alterra_Division.zip
    }*/

    internal static void hideVersions()
    {
        updateNotice.Hide();
    }

    public static float getWorldAge()
    {
        return worldLoadTime < 0 ? -1 : Time.time - worldLoadTime;
    }

    public static bool isWorldLoaded()
    {
        return worldLoadTime > 0;
    }

    public static void tickPlayer(Player ep)
    {
        var b = BiomeBase.getBiome(Camera.main.transform.position) as CustomBiome;
        if (currentCustomBiome != b)
            recomputeFog();
        currentCustomBiome = b;
        if (Time.timeScale <= 0)
            return;
        updateNotice.SetColor(Color.yellow);

        StoryHandler.instance.tick(ep);

        onPlayerTickEvent?.Invoke(ep);
    }

    public static void tickSeamoth(SeaMoth sm)
    {
        if (Time.timeScale <= 0)
            return;

        onSeamothTickEvent?.Invoke(sm);
    }

    public static void tickPrawn(Exosuit sm)
    {
        if (Time.timeScale <= 0)
            return;

        onPrawnTickEvent?.Invoke(sm);
    }

    public static void tickSub(SubRoot sub)
    {
        if (Time.timeScale <= 0)
            return;

        if (sub.isCyclops && onCyclopsTickEvent != null)
            onCyclopsTickEvent.Invoke(sub);
    }

    public static void updateSeamothModules(SeaMoth sm, int slotID, TechType techType, bool added)
    {
        for (var i = 0; i < sm.slotIDs.Length; i++)
        {
            var slot = sm.slotIDs[i];
            var techTypeInSlot = sm.modules.GetTechTypeInSlot(slot);
            if (techTypeInSlot != TechType.None)
            {
                object sp = ItemRegistry.instance.getItem(techTypeInSlot, false);

                // ReSharper disable once ConditionIsAlwaysTrueOrFalse
                if (sp is SeamothDepthModule module)
                    // ReSharper disable once HeuristicUnreachableCode
                    sm.crushDamage.SetExtraCrushDepth(Mathf.Max(module.depthBonus,
                        sm.crushDamage.extraCrushDepth));
            }
        }

        onSeamothModulesChangedEvent?.Invoke(sm, slotID, techType, added);
    }

    public static void updateCyclopsModules(SubRoot sm)
    {
        onCyclopsModulesChangedEvent?.Invoke(sm);
    }

    public static void updatePrawnModules(Exosuit sm, int slotID, TechType techType, bool added)
    {
        onPrawnModulesChangedEvent?.Invoke(sm, slotID, techType, added);
    }

    public static void useSeamothModule(SeaMoth sm, TechType techType, int slotID)
    {
        var sp = ItemRegistry.instance.getItem(techType, false);
        if (sp is SeamothModule)
        {
            var smm = (SeamothModule) sp;
            smm.onFired(sm, slotID, sm.GetSlotCharge(slotID));
            sm.quickSlotTimeUsed[slotID] = Time.time;
            sm.quickSlotCooldown[slotID] = smm.getUsageCooldown();
        }

        onSeamothModuleUsedEvent?.Invoke(sm, techType, slotID);
    }

    public static float getWaterTemperature(float ret, WaterTemperatureSimulation sim, Vector3 pos)
    {
        if (getTemperatureEvent != null)
        {
            var calc = new WaterTemperatureCalculation(ret, sim, pos);
            getTemperatureEvent.Invoke(calc);
            return calc.temperature;
        }

        return ret;
    }

    public static float recalculateDamage(float damage, DamageType type, GameObject target, GameObject dealer)
    {
        if (DIMod.config.getBoolean(DIConfig.ConfigEntries.INFITUBE) && ObjectUtil.isCoralTube(target))
            return Mathf.Min(damage, target.FindAncestor<LiveMixin>().health - 1);
        var pi = target.GetComponent<PrefabIdentifier>();
        if (pi && pi.ClassId == CustomEgg.getEgg(TechType.SpineEel).Info.ClassID &&
            (type == DamageType.Acid || type == DamageType.Poison))
            return 0;
        if (onDamageEvent != null)
        {
            var deal = new DamageToDeal(damage, type, target, dealer);
            onDamageEvent.Invoke(deal);
            return deal.amount;
        }

        return damage;
    }

    public static string getBiomeAt(string orig, Vector3 pos)
    {
        if (getBiomeEvent != null)
        {
            var deal = new BiomeCheck(orig, pos);
            getBiomeEvent.Invoke(deal);
            return deal.biome;
        }

        return orig;
    }

    public static void doKnifeHarvest(Knife caller, GameObject target, bool isAlive, bool wasAlive)
    {
        var tt = CraftData.GetTechType(target);
        if (tt == TechType.Creepvine)
            GoalManager.main.OnCustomGoalEvent("Cut_Creepvine");
        if (tt == TechType.BigCoralTubes && DIMod.config.getBoolean(DIConfig.ConfigEntries.INFITUBE) &&
            target.FindAncestor<LiveMixin>().health <= 2)
            wasAlive = false;
        var harv = new KnifeHarvest(target, tt, isAlive, wasAlive);
        knifeHarvestEvent?.Invoke(harv);
        isKnifeHarvesting = true;
        foreach (var kvp in harv.drops)
            CraftData.AddToInventory(kvp.Key, kvp.Value, false, false);
        isKnifeHarvesting = false;
    }

    public static void fireKnifeHarvest(GameObject target, Dictionary<TechType, int> drops)
    {
        var harv = new KnifeHarvest(target, CraftData.GetTechType(target), false, false);
        harv.drops.Clear();
        drops.ForEach(kvp => harv.drops[kvp.Key] = kvp.Value);
        knifeHarvestEvent?.Invoke(harv);
        foreach (var kvp in harv.drops)
            CraftData.AddToInventory(kvp.Key, kvp.Value, false, false);
    }

    public static void onPrawnItemPickedUp(Pickupable pp)
    {
        if (pp)
            onItemPickedUp(pp, Player.main.GetVehicle() as Exosuit);
    }

    public static void onItemPickedUp(Pickupable p)
    {
        onItemPickedUp(p, null);
    }

    public static void onItemPickedUp(Pickupable p, Exosuit prawn)
    {
        var collected = new List<Pickupable> {p};
        var tt = p.GetTechType();
        var mapTo = PickedUpAsOtherItem.getPickedUpAsOther(tt);
        //SNUtil.writeToChat("Pickup "+tt+" >> "+mapTo);
        if (mapTo != null)
        {
            if (prawn)
                prawn.storageContainer.container.DestroyItem(tt);
            else
                Inventory.main.container.DestroyItem(tt);

            Object.Destroy(p.gameObject); //not immediate because prawn is animation
            var tt2 = mapTo.getTemplate();
            var n = mapTo.getNumberCollectedAs();
            SNUtil.log("Converting pickup '" + p + "' to '" + tt2 + "' x" + n, SNUtil.diDLL);
            collected.Clear();
            for (var i = 0; i < n; i++)
            {
                var go = ObjectUtil.createWorldObject(tt2, true, false);
                p = go.GetComponent<Pickupable>();
                if (prawn)
                    prawn.storageContainer.container.UnsafeAdd(new InventoryItem(p));
                else
                    Inventory.main.Pickup(p);
                collected.Add(p);
            }

            SNUtil.log("Conversion complete", SNUtil.diDLL);
            tt = tt2;
        }

        if (tt == TechType.None)
        {
            var tag = p.gameObject.GetComponent<TechTag>();
            if (tag)
                tt = tag.type;
        }

        if (tt == TechType.None)
        {
            var pi = p.gameObject.GetComponent<PrefabIdentifier>();
            if (pi)
                tt = CraftData.entClassTechTable[pi.ClassId];
        }

        if (tt != TechType.None)
            TechnologyUnlockSystem.instance.triggerDirectUnlock(tt);
        /*
        foreach (Renderer r in p.gameObject.GetComponentsInChildren<Renderer>()) {
            foreach (Material m in r.materials) {
                //m.DisableKeyword("FX_BUILDING"); //breaks items which use it for their appearance
            }
        }
        */
        var cc = WorldUtil.getClosest<GenUtil.CustomCrate>(p.gameObject);
        if (cc)
            cc.onPickup(p);

        if (onItemPickedUpEvent != null)
            foreach (var pp in collected)
                onItemPickedUpEvent.Invoke(pp, prawn, isKnifeHarvesting);
    }

    public static bool canPlayerBreathe(bool orig, Player p)
    {
        if (p.GetComponent<TemporaryBreathPrevention>())
            return false;
        if (breathabilityEvent != null)
        {
            var deal = new BreathabilityCheck(orig, p);
            breathabilityEvent.Invoke(deal);
            return deal.breathable;
        }

        return orig;
    }

    public static void onEntityRegister(CellManager cm, LargeWorldEntity lw)
    {
        if (worldLoadTime < 0)
            onWorldLoaded(); /*
            if (lw.cellLevel != LargeWorldEntity.CellLevel.Global) {
                BatchCells batchCells;
                Int3 block = cm.streamer.GetBlock(lw.transform.position);
                Int3 key = block / cm.streamer.blocksPerBatch;
                if (cm.batch2cells.TryGetValue(key, out batchCells)) {
                            Int3 u = block % cm.streamer.blocksPerBatch;
                            Int3 cellSize = BatchCells.GetCellSize((int)lw.cellLevel, cm.streamer.blocksPerBatch);
                            Int3 cellId = u / cellSize;
                            bool flag = cellId.x < 0 || cellId.y < 0 || cellId.z < 0;
                    if (!flag) {
                        try {
                            //batchCells.Get(cellId, (int)lw.cellLevel);
                            batchCells.GetCells((int)lw.cellLevel).Get(cellId);
                        }
                        catch {
                            flag = true;
                        }
                    }
                    if (flag) {
                        SNUtil.log("Moving object "+lw.gameObject+" to global cell, as it is outside the world bounds and was otherwise going to bind to an OOB cell.");
                        lw.cellLevel = LargeWorldEntity.CellLevel.Global;
                    }
                }
            }*/
        onEntityRegisterEvent?.Invoke(cm, lw);
    }

    public static void onPopup(uGUI_PopupNotification gui)
    {
        /*
            System.Diagnostics.StackTrace t = new System.Diagnostics.StackTrace();
            t.ToString();*/
        //SNUtil.log("TRIGGER POPUP UNLOCK "+System.Environment.StackTrace, SNUtil.diDLL);
    }

    public static void onFarmedPlantGrowingSpawn(Plantable p, GameObject plant)
    {
        var tt = p.gameObject.GetComponent<TechTag>();
        if (tt)
        {
            var plantType = BasicCustomPlant.getPlant(tt.type);
            //SNUtil.writeToChat("Planted "+tt+" > "+plantType);
            if (plantType != null)
            {
                //SNUtil.writeToChat(plant.GetComponentsInChildren<Renderer>(true).Length+" Renderers");
                RenderUtil.swapToModdedTextures(plant.GetComponentInChildren<Renderer>(true), plantType);
                plant.gameObject.EnsureComponent<TechTag>().type = plantType.Info.TechType;
                plant.gameObject.EnsureComponent<PrefabIdentifier>().ClassId = plantType.Info.ClassID;
            }
        }
    }

    public static void onFarmedPlantGrowDone(GrowingPlant p, GameObject plant)
    {
        var tt = p.gameObject.GetComponent<TechTag>();
        if (tt)
        {
            var plantType = BasicCustomPlant.getPlant(tt.type);
            //SNUtil.writeToChat("Grew "+tt+" > "+plantType);
            if (plantType != null) ObjectUtil.convertTemplateObject(plant, plantType);
        }
    }

    public static void onDockingBaySpawn(VehicleDockingBay b)
    {
        b.gameObject.EnsureComponent<DockLock>();
    }

    public static void onSkyApplierSpawn(SkyApplier pk)
    {
        var pi = pk.GetComponent<PrefabIdentifier>(); /*
        if (pi) {
            foreach (Collider c in pi.GetComponentsInChildren<Collider>())
                c.gameObject.EnsureComponent<ColliderPrefabLink>().init(pi);
        }*/
        if (pk.GetComponent<Vehicle>())
        {
            pk.gameObject.EnsureComponent<FixedBounds>()._bounds = new Bounds(Vector3.zero, Vector3.one * 5);
            var go = ObjectUtil.getChildObject(pk.gameObject, "LavaWarningTrigger");
            if (!go)
            {
                go = new GameObject("LavaWarningTrigger");
                go.transform.localPosition = Vector3.zero;
                go.transform.localRotation = Quaternion.identity;
                go.transform.SetParent(pk.transform);
            }

            var sp = go.EnsureComponent<SphereCollider>();
            sp.center = Vector3.zero;
            sp.radius = NEAR_LAVA_RADIUS;
            sp.isTrigger = true;
            go.EnsureComponent<LavaWarningTriggerDetector>();
        }

        var fp = pk.GetComponent<FruitPlant>();
        if (fp) fp.gameObject.EnsureComponent<FruitPlantTag>().setPlant(fp);
        onSkyApplierSpawnEvent?.Invoke(pk);
    }

    //private static bool needsLavaDump = true;

    public class FruitPlantTag : MonoBehaviour
    {
        private FruitPlant plant;
        private float baseGrowthTime;

        private float lastTickTime = -1;

        internal void setPlant(FruitPlant fp)
        {
            plant = fp;
            baseGrowthTime = fp.fruitSpawnInterval;
        }

        public FruitPlant getPlant()
        {
            return plant;
        }

        public float getBaseGrowthTime()
        {
            return baseGrowthTime;
        }

        private void Update()
        {
            if (onFruitPlantTickEvent != null)
            {
                var time = DayNightCycle.main.timePassedAsFloat;
                if (time - lastTickTime >= 0.5F)
                {
                    lastTickTime = time;
                    onFruitPlantTickEvent.Invoke(this);
                }
            }
        }
    }

    public class DockLock : MonoBehaviour
    {
        private VehicleDockingBay bay;

        private float lastTime;

        public void Update()
        {
            if (!bay)
                bay = GetComponent<VehicleDockingBay>();

            if (bay.dockedVehicle && DayNightCycle.main.timePassedAsFloat - lastTime >= 0.5F &&
                !bay.dockedVehicle.GetComponentInParent<SubRoot>())
            {
                bay.DockVehicle(bay.dockedVehicle);
                SNUtil.writeToChat("Re-binding vehicle " + bay.dockedVehicle + " to docking bay " +
                                   bay.gameObject.GetFullHierarchyPath());
                lastTime = DayNightCycle.main.timePassedAsFloat;
            }
        }
    }

    public class LavaWarningTriggerDetector : IgnoreTrigger
    {
        private TemperatureDamage damage;
        private Vehicle vehicle;
        private Collider sphere;

        private float lastLavaTime = -1;
        private float lastGeyserTime = -1;

        private float lastCheckTime = -1;

        private static readonly List<Vector3> spherePoints = new();
        private static readonly int RAYS_PER_TICK = 10;
        private static int spherePointIndex;

        private float ambientTemperatureMinusLava;

        static LavaWarningTriggerDetector()
        {
            computePoints();
        }

        private static void computePoints()
        {
            var phi = Mathf.PI * (3F - Mathf.Sqrt(5F)); // golden angle in radians
            for (var i = 0; i < 100; i++)
            {
                var y = 1 - i / (100 - 1F) * 2; // y goes from 1 to -1
                var radius = Mathf.Sqrt(1 - y * y); // radius at y

                var theta = phi * i; // golden angle increment

                var x = Mathf.Cos(theta) * radius;
                var z = Mathf.Sin(theta) * radius;

                spherePoints.Add(new Vector3(x, y, z));
            }

            for (var i = 0; i < 150; i++)
            {
                var ang = Random.Range(0F, 360F);
                var x = Mathf.Cos(Mathf.Deg2Rad * ang) * NEAR_LAVA_RADIUS;
                var z = Mathf.Sin(Mathf.Deg2Rad * ang) * NEAR_LAVA_RADIUS;
                spherePoints.Add(new Vector3(x, -Random.Range(0F, 1F), z));
            }

            spherePoints.Shuffle();
        }

        private void Update()
        {
            if (!damage)
                damage = gameObject.FindAncestor<TemperatureDamage>();
            if (!vehicle)
                vehicle = gameObject.FindAncestor<Vehicle>();
            if (!sphere)
                sphere = gameObject.GetComponent<Collider>();
            gameObject.transform.localPosition = Vector3.zero;

            var time = DayNightCycle.main.timePassedAsFloat;
            var dT = time - lastCheckTime;
            if (dT >= 0.5)
            {
                lastCheckTime = time;
                ambientTemperatureMinusLava = WaterTemperatureSimulation.main.GetTemperature(transform.position);
            }

            if (damage && ambientTemperatureMinusLava >= 90)
                checkNearbyLava();
        }

        private void checkNearbyLava()
        {
            for (var i = spherePointIndex; i < Math.Min(spherePointIndex + RAYS_PER_TICK, spherePoints.Count); i++)
            {
                var vec = spherePoints[i];
                var hits = Physics.RaycastAll(transform.position, vec.normalized, NEAR_LAVA_RADIUS,
                    Voxeland.GetTerrainLayerMask());
                //SNUtil.writeToChat(vec+" > "+hits.Length);
                foreach (var hit in hits)
                    if (hit.transform && checkLava(hit.point, Vector3.zero))
                    {
                        spherePointIndex = i;
                        return;
                    }
            }

            spherePointIndex += RAYS_PER_TICK;
            if (spherePointIndex >= spherePoints.Count)
                spherePointIndex = 0;
        }

        private void OnTriggerStay(Collider other)
        {
            if (damage && ambientTemperatureMinusLava >= 90)
            {
                Vector3 norm;
                checkLava(getCollisionPoint(other, out norm), norm);
            }
        }

        private Vector3 getCollisionPoint(Collider other, out Vector3 norm)
        {
            float depth = 0;

            var ctr = transform.position;
            if (Physics.ComputePenetration(other, other.transform.position, other.transform.rotation, sphere, ctr,
                    Quaternion.identity, out norm, out depth))
                return ctr + norm * (NEAR_LAVA_RADIUS - depth);

            return Vector3.zero;
        }

        private bool checkLava(Vector3 pt, Vector3 norm)
        {
            //SNUtil.log("Checking lava: "+pt+" @ "+lastLavaTime, SNUtil.diDLL);
            if (norm.magnitude < 0.01F)
                norm = transform.position - pt;
            if (damage.lavaDatabase.IsLava(pt, norm))
            {
                markLavaDetected();
                //SNUtil.writeToChat("Wide lava: "+pt+" @ "+lastLavaTime);
                //SNUtil.log("Is lava", SNUtil.diDLL);
                return true;
            }

            return false;
        }

        public void markLavaDetected()
        {
            lastLavaTime = DayNightCycle.main.timePassedAsFloat;
        }

        public void markGeyserDetected()
        {
            lastGeyserTime = DayNightCycle.main.timePassedAsFloat;
        }

        public bool isInGeyser()
        {
            return Mathf.Abs(DayNightCycle.main.timePassedAsFloat - lastGeyserTime) <= 0.5F;
        }

        public bool isInLava()
        {
            /*
                if (needsLavaDump) {
                    dmg.lavaDatabase.LazyInitialize();
                    needsLavaDump = false;
                    List<string> li = new List<string>();
                    Dictionary<byte, List<BlockTypeClassification>> db = dmg.lavaDatabase.lavaBlocks;
                    foreach (KeyValuePair<byte, List<BlockTypeClassification>> kvp in db) {
                        List<BlockTypeClassification> li0 = kvp.Value;
                        li.Add("==========================");
                        li.Add("Byte "+kvp.Key+": "+li0.Count+" entries: ");
                        foreach (BlockTypeClassification bb in li0) {
                            li.Add("Type "+bb.blockType+", inclination ["+bb.minInclination+"-"+bb.maxInclination+"], mat='"+bb.material+"'");
                        }
                        li.Add("==========================");
                        li.Add("");
                    }
                    string path = "E:/INet/SNlavadump.txt";
                    File.WriteAllLines(path, li);
                }*/
            return Mathf.Abs(DayNightCycle.main.timePassedAsFloat - lastLavaTime) <= 2;
        }
    }

    public static void onStoryGoalCompleted(string key)
    {
        StoryHandler.instance.NotifyGoalComplete(key);
    }

    public static bool isItemUsable(TechType tt)
    {
        return tt == TechType.Bladderfish || UsableItemRegistry.instance.isUsable(tt);
    }

    public static bool useItem(Survival s, GameObject useObj)
    {
        var flag = false;
        if (useObj != null)
        {
            var tt = CraftData.GetTechType(useObj);
            if (tt == TechType.None)
            {
                var component = useObj.GetComponent<Pickupable>();
                if (component)
                    tt = component.GetTechType();
            }

            SNUtil.log("Player used item " + tt, SNUtil.diDLL);
            flag = UsableItemRegistry.instance.use(tt, s, useObj);
            if (flag)
                FMODUWE.PlayOneShot(AudioUtils.GetFmodAsset(CraftData.GetUseEatSound(tt)), Player.main.transform.position);
        }

        return flag;
    }

    public static bool isItemDroppable(Pickupable pp, bool notify)
    {
        var flag = Inventory.CanDropItemHere(pp, notify);
        if (pp && IrreplaceableItemRegistry.instance.isIrreplaceable(pp.GetTechType()))
        {
            if (notify)
                ErrorMessage.AddError(DIMod.locale.getEntry(itemNotDroppableLocaleKey).desc);
            return false;
        }

        if (pp && droppabilityEvent != null)
        {
            var dropCheck = new DroppabilityCheck(pp, notify, flag);
            droppabilityEvent.Invoke(dropCheck);
            flag = dropCheck.allow;
            if (notify && !flag && !string.IsNullOrEmpty(dropCheck.error)) ErrorMessage.AddError(dropCheck.error);
        }

        return flag;
    }

    public static void onScanComplete(PDAScanner.EntryData data)
    {
        if (data != null)
        {
            TechnologyUnlockSystem.instance.triggerDirectUnlock(data.key);
            scanCompleteEvent?.Invoke(data);
        }
    }

    public static void tickLaserCutting(Sealed s, float amt)
    {
        if (s._sealed && s.maxOpenedAmount >= 0)
        {
            string key = null;
            if (s.GetComponent<BulkheadDoor>() && bulkheadLaserHoverEvent != null)
            {
                var ch = new BulkheadLaserCutterHoverCheck(s);
                bulkheadLaserHoverEvent.Invoke(ch);
                key = ch.refusalLocaleKey;
            }

            if (string.IsNullOrEmpty(key))
            {
                s.openedAmount = Mathf.Min(s.openedAmount + amt, s.maxOpenedAmount);
                if (Mathf.Approximately(s.openedAmount, s.maxOpenedAmount))
                {
                    s._sealed = false;
                    s.openedEvent.Trigger(s);
                    //Debug.Log("Trigger opened event");
                }
            }
        }
    }

    public static void getBulkheadMouseoverText(BulkheadDoor bk)
    {
        if (bk.enabled && !bk.opened)
        {
            var s = bk.GetComponent<Sealed>();
            if (s && s.IsSealed())
            {
                if (s.maxOpenedAmount < 0)
                {
                    HandReticle.main.SetText(HandReticle.TextType.Use, "BulkheadInoperable", true);
                    HandReticle.main.SetIcon(HandReticle.IconType.None);
                }
                else
                {
                    string key = null;
                    if (bulkheadLaserHoverEvent != null)
                    {
                        var ch = new BulkheadLaserCutterHoverCheck(s);
                        bulkheadLaserHoverEvent.Invoke(ch);
                        key = ch.refusalLocaleKey;
                        HandReticle.main.SetIcon(HandReticle.IconType.HandDeny);
                    }

                    if (string.IsNullOrEmpty(key))
                    {
                        HandReticle.main.SetText(HandReticle.TextType.Use, "SealedInstructions",
                            true); //is a locale key
                        HandReticle.main.SetProgress(s.GetSealedPercentNormalized());
                        HandReticle.main.SetIcon(HandReticle.IconType.Progress);
                    }
                    else
                    {
                        HandReticle.main.SetText(HandReticle.TextType.Use, key, true);
                        HandReticle.main.SetIcon(HandReticle.IconType.None);
                    }
                }
            }
            else
            {
                HandReticle.main.SetIcon(HandReticle.IconType.Hand);
                HandReticle.main.SetText(HandReticle.TextType.Use, bk.opened ? "Close" : "Open", true);
            }
        }
    }

    public static void onBulkheadClick(BulkheadDoor bk)
    {
        var componentInParent = bk.GetComponentInParent<Base>();
        //PreventDeconstruction prev = bk.GetComponentInParent<PreventDeconstruction>();
        var s = bk.GetComponent<Sealed>();
        if (s != null && s.IsSealed())
        {
        }
        else if (componentInParent != null && !componentInParent.isPlaced)
        {
            bk.SetState(!bk.opened);
        }
        else if (bk.enabled && !bk.opened)
        {
            if (!GameOptions.GetVrAnimationMode()) return;
            bk.SetState(!bk.opened);
        }
    }

    public static bool isInsideForHatch(UseableDiveHatch hatch)
    {
        var wb = hatch.gameObject.GetComponent<SeabaseReconstruction.WorldgenBaseWaterparkHatch>();
        if (wb)
            return wb.isPlayerInside();
        return Player.main.IsInsideWalkable() && Player.main.currentWaterPark == null;
    }

    public static void onConstructionComplete(Constructable c, bool finished)
    {
        if (finished)
            TechnologyUnlockSystem.instance.triggerDirectUnlock(c.techType);

        onConstructedEvent?.Invoke(c, finished);
    }

    public static void onVehicleBayFinish(Constructor c, GameObject go)
    {
        var tt = CraftData.GetTechType(go);
        if (tt != TechType.None)
            TechnologyUnlockSystem.instance.triggerDirectUnlock(tt);
    }

    public static void onBaseLoaded(BaseRoot root)
    {
        onBaseLoadedEvent?.Invoke(root);
    }

    public static void onInvOpened(StorageContainer sc)
    {
        inventoryOpenedEvent?.Invoke(sc);
    }

    public static void onInvClosed(StorageContainer sc)
    {
        inventoryClosedEvent?.Invoke(sc);
    }

    public static void onKnifed(GameObject go)
    {
        if (go && onKnifedEvent != null)
            onKnifedEvent.Invoke(go);
        if (go && Inventory.main.GetHeld().GetTechType() == TechType.HeatBlade)
        {
            //allow thermoblade to cook dead fish
            var tt = CraftData.GetTechType(go);
            if (tt != TechType.None && CraftData.cookedCreatureList.TryGetValue(tt, out var value))
            {
                var lv = go.GetComponent<LiveMixin>();
                if (lv && !lv.IsAlive())
                {
                    var put = ObjectUtil.createWorldObject(value);
                    if (put)
                    {
                        put.transform.position = go.transform.position;
                        put.transform.rotation = go.transform.rotation;
                        put.transform.localScale = go.transform.localScale;
                        Object.Destroy(go);
                    }
                }
            }
        }
    }

    public static bool isObjectKnifeable(LiveMixin lv)
    {
        if (!lv)
            return true;
        var k = new KnifeAttempt(lv, !lv.weldable && lv.knifeable && !lv.GetComponent<EscapePod>());
        knifeAttemptEvent?.Invoke(k);
        return k.allowKnife;
    }

    public static bool canGravTrapGrab(Gravsphere s, GameObject go)
    {
        if (!s || !go)
            return false;

        if (gravTrapTechSet.Count == 0)
            gravTrapTechSet.AddRange(Gravsphere.allowedTechTypes);

        var pp = go.GetComponent<Pickupable>();
        var def = (pp == null || !pp.attached) && gravTrapTechSet.Contains(CraftData.GetTechType(go));

        var k = new GravTrapGrabAttempt(s, go, def);
        gravTrapAttemptEvent?.Invoke(k);
        //SNUtil.writeToChat("Gravsphre "+s+" tried to grab "+go+": "+def+" > "+k.allowGrab);
        return k.allowGrab;
    }

    public static void hoverSeamothTorpedoStorage(SeaMoth sm, HandTargetEventData data)
    {
        for (var i = 0; i < sm.slotIDs.Length; i++)
        {
            var ii = sm.GetSlotItem(i);
            if (ii != null && ii.item)
            {
                var storage = SeamothModule.getStorageHandler(ii.item.GetTechType());
                if (storage != null)
                {
                    var component = ii.item.GetComponent<SeamothStorageContainer>();
                    //SNUtil.writeToChat("Found "+component+" ["+storage.title+"] for "+ii.item.GetTechType());
                    if (component)
                    {
                        HandReticle.main.SetText(HandReticle.TextType.Use, storage.localeKey, true);
                        HandReticle.main.SetIcon(HandReticle.IconType.Hand);
                    }
                }
            }
        }
    }

    public static void openSeamothTorpedoStorage(SeaMoth sm, Transform transf)
    {
        var foundMatch = TechType.None;
        Inventory.main.ClearUsedStorage();
        for (var i = 0; i < sm.slotIDs.Length; i++)
        {
            var ii = sm.GetSlotItem(i);
            if (ii != null && ii.item)
            {
                var tt = ii.item.GetTechType();
                if (foundMatch == tt || foundMatch == TechType.None)
                {
                    var storage = SeamothModule.getStorageHandler(tt);
                    if (storage != null)
                    {
                        var component = ii.item.GetComponent<SeamothStorageContainer>();
                        if (component)
                        {
                            foundMatch = tt;
                            storage.apply(component);
                            Inventory.main.SetUsedStorage(component.container, true);
                        }
                    }
                }
            }
        }

        if (foundMatch != TechType.None)
            //SNUtil.writeToChat("Opening "+SeamothModule.getStorageHandler(foundMatch).title+" for "+foundMatch);
            Player.main.GetPDA().Open(PDATab.Inventory, transf, null);
    }

    public static float getTemperatureForDamage(TemperatureDamage dmg)
    {
        if (Mathf.Abs(Time.time - dmg.timeDamageStarted) <= 2.5F) //active lava dmg
            //SNUtil.writeToChat(dmg+" Touch lava: "+dmg.timeDamageStarted+" > "+Mathf.Abs(Time.time-dmg.timeDamageStarted));
            return 1200;
        var warn = dmg.GetComponentInChildren<LavaWarningTriggerDetector>();
        if (warn && warn.isInLava())
            return dmg.gameObject.FindAncestor<Exosuit>() ? 300 : 400;
        if (warn && warn.isInGeyser())
            return 180;
        var v = dmg.GetComponent<Vehicle>();
        if (v)
            return v.precursorOutOfWater ? 25 : v.GetTemperature();
        return WaterTemperatureSimulation.main.GetTemperature(dmg.transform.position);
    }

    public static void pingSonar(SNCameraRoot cam)
    {
        if (cam && onSonarUsedEvent != null)
            onSonarUsedEvent.Invoke(cam);
    }

    public static void pingSeamothSonar(SeaMoth cam)
    {
        if (cam && onSeamothSonarUsedEvent != null)
            onSeamothSonarUsedEvent.Invoke(cam);
    }

    public static void pingCyclopsSonar(CyclopsSonarButton cam)
    {
        if (cam && onCyclopsSonarUsedEvent != null)
        {
            var sb = cam.gameObject.FindAncestor<SubRoot>();
            if (sb)
                onCyclopsSonarUsedEvent.Invoke(sb);
        }
    }

    public static void onEggHatched(GameObject hatched)
    {
        if (hatched)
        {
            ObjectUtil.fullyEnable(hatched);
            onEggHatchedEvent?.Invoke(hatched);
        }
    }

    public static void onEMPHit(EMPBlast e, MonoBehaviour com)
    {
        if (com && onEMPHitEvent != null) onEMPHitEvent.Invoke(e, com.gameObject);
    }

    public static void onEMPTouch(EMPBlast e, Collider c)
    {
        if (c && onEMPTouchEvent != null) onEMPTouchEvent.Invoke(e, c);
    }

    public static void appendItemTooltip(StringBuilder sb, TechType tt, GameObject obj)
    {
        var mix = obj.GetComponent<InfectedMixin>();
        if (mix)
        {
            var tip = getInfectionTooltip(mix);
            if (!string.IsNullOrEmpty(tip))
                TooltipFactory.WriteDescription(sb,
                    tip); //TooltipFactory.WriteDescription(sb, "Infected: "+((int)(mix.infectedAmount*100))+"%");
        }

        var peep = obj.GetComponent<Peeper>();
        if (peep && peep.isHero) TooltipFactory.WriteDescription(sb, "Contains unusual enzymes.");
        itemTooltipEvent?.Invoke(sb, tt, obj);
    }

    private static string getInfectionTooltip(InfectedMixin mix)
    {
        if (mix.IsInfected())
        {
            var amt = mix.infectedAmount;
            //return "Infected: "+((int)(amt*100))+"%";
            if (amt >= 0.75)
                return "This creature is severely infected.";
            if (amt >= 0.5)
                return "Exhibiting symptoms of significant systemic infection.";
            if (amt >= 0.25)
                return "Showing signs of infection.";
            return "Elevated bacterial levels detected.";
        }

        var lv = mix.GetComponent<LiveMixin>();
        return !lv || lv.IsAlive() ? "Status: Healthy." : null;
    }
    /*
   public static WaterscapeVolume.Settings currentRenderVolume = new WaterscapeVolume.Settings();

   public static void overrideFog(WaterBiomeManager biomes, Vector3 pos, bool detail, WaterscapeVolume.Settings settings) {
       if (KeyCodeUtils.GetKeyHeld(KeyCode.LeftControl)) {
           currentRenderVolume.copyObject(settings);
       }
       if (KeyCodeUtils.GetKeyHeld(KeyCode.LeftAlt)) {
           settings = currentRenderVolume;
       }
       biomes.atmosphereVolumeMaterial.SetVector(ShaderPropertyID._Value, biomes.GetExtinctionTextureValue(settings));
       biomes.atmosphereVolumeMaterial.SetVector(ShaderPropertyID._Value1, biomes.GetScatteringTextureValue(settings));
       biomes.atmosphereVolumeMaterial.SetVector(ShaderPropertyID._Value2, biomes.GetEmissiveTextureValue(settings));
   }

   public static void onFogRasterized(WaterBiomeManager biomes, Vector3 pos, bool detail) {
       SNUtil.writeToChat("Rasterizing fog @ "+pos);
   }*/

    public static Vector4 interceptExtinction(Vector4 orig, WaterscapeVolume.Settings settings)
    {
        var at = BiomeBase.getBiome(Camera.main.transform.position);
        if (at is CustomBiome)
        {
            var b = (CustomBiome) at;
            var d = b.getMurkiness(settings.murkiness) / 100f;
            var scatter = b.getScatteringFactor(settings.scattering);
            var vector = b.getColorFalloff(settings.absorption) + scatter * Vector3.one;
            var ret = new Vector4(vector.x, vector.y, vector.z, scatter) * d;
            ret.w = b.getFogStart(settings.startDistance);
            return ret;
        }

        return orig;
    }

    public static Vector4 interceptScattering(Vector4 orig, WaterscapeVolume.Settings settings)
    {
        var at = BiomeBase.getBiome(Camera.main.transform.position);
        if (at is CustomBiome)
        {
            var b = (CustomBiome) at;
            var factor = b.getScatterFactor(settings.GetExtinctionAndScatteringCoefficients().w);
            var linear = b.getWaterColor(settings.scatteringColor.linear);
            Vector4 result;
            result.x = linear.r * factor;
            result.y = linear.g * factor;
            result.z = linear.b * factor;
            result.w = b.getSunScale(settings.sunlightScale) * WaterBiomeManager.main.waterTransmission;
            return result;
        }

        return orig;
    }

    public static Vector4 interceptEmissive(Vector4 orig, WaterscapeVolume.Settings settings)
    {
        var at = BiomeBase.getBiome(Camera.main.transform.position);
        if (at is CustomBiome)
            return ((CustomBiome) at).getEmissiveVector(orig);
        return orig;
    }

    public static void recomputeFog()
    {
        SNUtil.log("Recomputing fog @ " + Camera.main.transform.position, SNUtil.diDLL);
        WaterBiomeManager.main.Rebuild();
        WaterBiomeManager.main.BuildSettingsTextures();
    }

    public static void dumpWaterscapeTextures()
    {
        var wbm = WaterBiomeManager.main;
        //string biome = wbm.GetBiome(Camera.main.transform.position);
        //SNUtil.writeToChat("Dumping biome textures @ "+biome);
        foreach (var f in typeof(WaterBiomeManager).GetFields((BindingFlags) 0x7fffffff))
        {
            var get = f.GetValue(wbm);
            if (get is RenderTexture)
            {
                SNUtil.writeToChat("Dumping RenderTexture WaterBiomeManager::" + f.Name);
                RenderUtil.dumpTexture(SNUtil.diDLL, f.Name, (RenderTexture) get);
            }
            else if (get is Texture2D)
            {
                SNUtil.writeToChat("Dumping Texture2D WaterBiomeManager::" + f.Name);
                RenderUtil.dumpTexture(SNUtil.diDLL, f.Name, (Texture2D) get);
            }
            //SNUtil.writeToChat("Skipping non-texture object "+get);
        }
    }
    /*
    public static void interceptChosenFog(WaterscapeVolume vol, Camera cam) {
        vol.SetupWaterPlane(cam, vol.waterPlane);
        vol.biomeManager.SetupConstantsForCamera(cam);
        if (vol.fogEnabled)
            Shader.SetGlobalFloat(ShaderPropertyID._UweFogEnabled, 1f);
        float transmission = vol.GetTransmission();
        Shader.SetGlobalFloat(ShaderPropertyID._UweCausticsScale, vol.causticsScale * vol.surface.GetCausticsWorldToTextureScale());
        Shader.SetGlobalVector(ShaderPropertyID._UweCausticsAmount, new Vector3(vol.causticsAmount, vol.surface.GetCausticsTextureScale() * vol.causticsAmount, vol.surface.GetCausticsTextureScale()));
        Shader.SetGlobalFloat(ShaderPropertyID._UweWaterTransmission, transmission);
        Shader.SetGlobalFloat(ShaderPropertyID._UweWaterEmissionAmbientScale, vol.emissionAmbientScale);
        float depth = (cam.transform.position.y - vol.aboveWaterMinHeight) / (vol.aboveWaterMaxHeight - vol.aboveWaterMinHeight);
        float fogDensity = Mathf.Lerp(1f, vol.aboveWaterDensityScale, depth);
        Shader.SetGlobalFloat(ShaderPropertyID._UweExtinctionAndScatteringScale, fogDensity);
        if (vol.sky != null) {
            Vector3 lightDirection = vol.sky.GetLightDirection();
        if (KeyCodeUtils.GetKeyHeld(KeyCode.LeftAlt))
            lightDirection.x = 1;
        if (KeyCodeUtils.GetKeyHeld(KeyCode.LeftControl))
            lightDirection.y = 1;
        if (KeyCodeUtils.GetKeyHeld(KeyCode.LeftShift))
            lightDirection.z = 1;
        if (KeyCodeUtils.GetKeyHeld(KeyCode.Tab))
            SNUtil.writeToChat(lightDirection.ToString());
            lightDirection.y = Mathf.Min(lightDirection.y, -0.01f);
            Vector3 camLight = -cam.worldToCameraMatrix.MultiplyVector(lightDirection);
            Color lightColor = vol.sky.GetLightColor();
            Vector4 fogValues = lightColor;
            fogValues.w = vol.sunLightAmount * transmission;
            float brightness = lightColor.r * 0.3f + lightColor.g * 0.59f + lightColor.b * 0.11f;
            Shader.SetGlobalVector(ShaderPropertyID._UweFogVsLightDirection, camLight);
            Shader.SetGlobalVector(ShaderPropertyID._UweFogWsLightDirection, lightDirection);
            Shader.SetGlobalVector(ShaderPropertyID._UweFogLightColor, fogValues);
            Shader.SetGlobalFloat(ShaderPropertyID._UweFogLightGreyscaleColor, brightness);
        }
        else {
            Shader.SetGlobalFloat(ShaderPropertyID._UweFogLightAmount, 0f);
        }
        Shader.SetGlobalVector(ShaderPropertyID._UweColorCastFactor, new Vector2(vol.colorCastDistanceFactor, vol.colorCastDepthFactor));
        Shader.SetGlobalFloat(ShaderPropertyID._UweAboveWaterFogStartDistance, vol.aboveWaterStartDistance);
        Vector3 scatter = default(Vector3);
        scatter.x = (1f - vol.scatteringPhase * vol.scatteringPhase) / 12.566371f;
        scatter.y = 1f + vol.scatteringPhase * vol.scatteringPhase;
        scatter.z = 2f * vol.scatteringPhase;
        Shader.SetGlobalVector(ShaderPropertyID._UweFogMiePhaseConst, scatter);
        Shader.SetGlobalFloat(ShaderPropertyID._UweSunAttenuationFactor, vol.sunAttenuation);
    }*/
    /*
    public static void interceptChosenFog(WaterscapeVolume vol, Camera cam) {
        if (!vol || !cam)
            return;
        float t = (cam.transform.position.y - vol.aboveWaterMinHeight) / (vol.aboveWaterMaxHeight - vol.aboveWaterMinHeight);
        float fogDensity = Mathf.Lerp(1f, vol.aboveWaterDensityScale, t);

        Vector4 fogColor = default(Vector4);
        if (vol.sky != null)
        {
            Vector3 lightDirection = vol.sky.GetLightDirection();
            lightDirection.y = Mathf.Min(lightDirection.y, -0.01f);
            Vector3 v = -cam.worldToCameraMatrix.MultiplyVector(lightDirection);
            fogColor = vol.sky.GetLightColor();
            fogColor.w = vol.sunLightAmount * vol.GetTransmission();
            Shader.SetGlobalVector(ShaderPropertyID._UweFogVsLightDirection, v);
            Shader.SetGlobalVector(ShaderPropertyID._UweFogWsLightDirection, lightDirection);
        }/*
        CustomBiome b = BiomeBase.getBiome(cam.transform.position) as CustomBiome;
        if (b != null) {
            fogColor = fogColor.setXYZ(b.getFogColor(fogColor.getXYZ()));
            fogColor.w = b.getSunIntensity(fogColor.w);
            fogDensity = b.getFogDensity(fogDensity);
        }
        WaterFogValues wf = new WaterFogValues(fogColor.asColor(), fogDensity, fogColor.w);
        if (fogCalculateEvent != null)
            fogCalculateEvent.Invoke(wf);
        Vector4 vec4 = wf.color.toVectorA();
        vec4.w = wf.sunValue;*/ /*Vector4 vec4 = fogColor;
        //SNUtil.writeToChat("Fog color "+vec4+", with density "+fogDensity.ToString("0.000"));
        Shader.SetGlobalVector(ShaderPropertyID._UweFogLightColor, vec4);
        Shader.SetGlobalFloat(ShaderPropertyID._UweExtinctionAndScatteringScale, /*wf.density*/ /*fogDensity);
        float value3 = fogColor.x * 0.3f + fogColor.y * 0.59f + fogColor.z * 0.11f;
        Shader.SetGlobalFloat(ShaderPropertyID._UweFogLightGreyscaleColor, value3);
        Vector3 v2 = default(Vector3);
        v2.x = (1f - vol.scatteringPhase * vol.scatteringPhase) / 12.566371f;
        v2.y = 1f + vol.scatteringPhase * vol.scatteringPhase;
        v2.z = 2f * vol.scatteringPhase;
        Shader.SetGlobalVector(ShaderPropertyID._UweFogMiePhaseConst, v2);
        Shader.SetGlobalFloat(ShaderPropertyID._UweSunAttenuationFactor, vol.sunAttenuation);
        Shader.SetGlobalVector(ShaderPropertyID._UweColorCastFactor, new Vector2(vol.colorCastDistanceFactor, vol.colorCastDepthFactor));
        Shader.SetGlobalFloat(ShaderPropertyID._UweAboveWaterFogStartDistance, vol.aboveWaterStartDistance);
        //SNUtil.writeToChat("Applying fog of "+vol+" @ "+vol.transform.position);
    }*/

    public static bool interceptConstructability( /*Collider c*/)
    {
        var orig = Builder.UpdateAllowed();
        //SNUtil.writeToChat("Testing constructability of "+Builder.constructableTechType+", default value = "+orig);
        if (constructabilityEvent != null)
        {
            //SNUtil.writeToChat("Event has listeners");
            var aimTransform = Builder.GetAimTransform();
            RaycastHit hit;
            Collider target = null;
            if (Physics.Raycast(aimTransform.position, aimTransform.forward, out hit, Builder.placeMaxDistance,
                    Builder.placeLayerMask.value, QueryTriggerInteraction.Ignore))
                target = hit.collider;
            else
                target = null;
            //SNUtil.writeToChat("Placement target: "+target+" "+(target == null ? "" : target.gameObject.GetFullHierarchyPath()));
            //SNUtil.writeToChat("Space check: "+Builder.CheckSpace(Builder.placePosition, Builder.placeRotation, Builder.bounds, Builder.placeLayerMask.value, target));
            var deal = new BuildabilityCheck(orig, target);
            constructabilityEvent.Invoke(deal);
            //SNUtil.writeToChat("Event state: "+deal.placeable+" / "+deal.ignoreSpaceRequirements);
            return
                deal.placeable; // && (target == null || deal.ignoreSpaceRequirements || Builder.CheckSpace(Builder.placePosition, Builder.placeRotation, Builder.bounds, Builder.placeLayerMask.value, target));
        }

        return orig;
    }
    /*
    public static float getPowerRelayCapacity(float orig, PowerRelay relay) {
        SubRoot sub = relay.gameObject.FindAncestor<SubRoot>();
        if (sub) {
            foreach (CustomMachineLogic lgc in sub.GetComponentsInChildren<CustomMachineLogic>()) {
                orig += lgc.getBaseEnergyStorageCapacityBonus();
            }
        }
        return orig;
    }*/ /*

    public static void addPowerToSeabaseDelegateViaPowerSourceSet(PowerSource src, float amt, MonoBehaviour component) {
        SubRoot sub = component.gameObject.FindAncestor<SubRoot>();
        if (sub) {
            sub.powerRelay.AddEnergy(amount, out stored);
        }
        else {
            src.power = amt;
        }
    }*/

    public static void updateSolarPanel(SolarPanel p)
    {
        if (!p)
            return;
        var c = p.gameObject.GetComponent<Constructable>();
        if (c && c.constructed)
        {
            var eff = p.GetRechargeScalar();
            if (solarEfficiencyEvent != null)
            {
                var ch = new SolarEfficiencyCheck(p, eff);
                solarEfficiencyEvent.Invoke(ch);
                eff = ch.value;
            }

            var gen = eff * DayNightCycle.main.deltaTime * 0.25f * 5f;
            var sub = p.gameObject.FindAncestor<SubRoot>();
            if (sub)
            {
                float trash;
                sub.powerRelay.AddEnergy(gen, out trash);
            }
            else
            {
                p.powerSource.power = Mathf.Clamp(p.powerSource.power + gen, 0f, p.powerSource.maxPower);
            }
        }
    }

    public static bool addPowerToSeabaseDelegate(IPowerInterface pi, float amount, out float stored,
        MonoBehaviour component)
    {
        var sub = component.gameObject.FindAncestor<SubRoot>();
        if (sub)
            return sub.powerRelay.AddEnergy(amount, out stored);
        return pi.AddEnergy(amount, out stored);
    }
    /*
    public static string getBiomeToUseForMusic(string biome, MusicManager mgr) {
        if (musicBiomeChoiceEvent != null) {
            MusicSelectionCheck mus = new MusicSelectionCheck(biome);
        }
        return biome;
    }*/

    public static void clickStoryHandTarget(StoryHandTarget tgt)
    {
        if (!tgt.enabled || !tgt.isValidHandTarget)
            return;
        var goal = tgt.goal;
        if (storyHandEvent != null)
        {
            var deal = new StoryHandCheck(goal, tgt);
            storyHandEvent.Invoke(deal);
            if (!deal.usable)
                return;
            goal = deal.goal;
        }

        goal.Trigger();
        if (tgt.informGameObject)
            tgt.informGameObject.SendMessage("OnStoryHandTarget", SendMessageOptions.DontRequireReceiver);
        Object.Destroy(tgt.destroyGameObject);
    }

    public static float getRadiationLevel(Player p, float orig)
    {
        var ret = orig;
        //SNUtil.writeToChat((radiationCheckEvent != null)+" # "+orig);
        if (radiationCheckEvent != null)
        {
            var ch = new RadiationCheck(p.transform.position, orig);
            radiationCheckEvent.Invoke(ch);
            ret = ch.value;
        }

        return ret;
    }

    public static void onReaperGrabVehicle(ReaperLeviathan r, Vehicle v)
    {
        reaperGrabVehicleEvent?.Invoke(r, v);
    }

    public static void onDockingTriggerCollided(VehicleDockingBay v, Collider other)
    {
        if (other.isTrigger)
            return;
        if (v.GetDockedVehicle())
            return;
        if (GameModeUtils.RequiresPower() && !v.IsPowered())
            return;
        if (v.interpolatingVehicle != null)
            return;
        var componentInHierarchy = UWE.Utils.GetComponentInHierarchy<Vehicle>(other.gameObject);
        if (componentInHierarchy == null || componentInHierarchy.docked || componentInHierarchy.GetRecentlyUndocked())
            return;
        v.timeDockingStarted = Time.time;
        v.interpolatingVehicle = componentInHierarchy;
        v.startPosition = v.interpolatingVehicle.transform.position;
        v.startRotation = v.interpolatingVehicle.transform.rotation;
    }

    public static void onAcidTriggerCollided(AcidicBrineDamageTrigger v, Collider other)
    {
        if (other.isTrigger)
            return;
        var liveMixin = v.GetLiveMixin(other.gameObject);
        if (v.IsValidTarget(liveMixin)) v.AddTarget(liveMixin.gameObject.GetComponent<LiveMixin>());
    }

    public static void onAirlockTouched(PrecursorDoorMotorModeSetter door, Collider col)
    {
        if (col.isTrigger)
            return;
        if (door.setToMotorModeOnEnter == PrecursorDoorMotorMode.None)
            return;
        if (col.gameObject != null && col.gameObject.GetComponentInChildren<IgnoreTrigger>() != null)
            return;
        var gameObject = UWE.Utils.GetEntityRoot(col.gameObject);
        if (!gameObject)
            gameObject = col.gameObject;
        var componentInHierarchy = UWE.Utils.GetComponentInHierarchy<Player>(gameObject);
        if (componentInHierarchy)
        {
            var precursorDoorMotorMode = door.setToMotorModeOnEnter;
            if (precursorDoorMotorMode != PrecursorDoorMotorMode.Auto)
            {
                if (precursorDoorMotorMode == PrecursorDoorMotorMode.ForceWalk)
                    componentInHierarchy.precursorOutOfWater = true;
            }
            else
            {
                componentInHierarchy.precursorOutOfWater = false;
            }
        }

        var componentInHierarchy2 = UWE.Utils.GetComponentInHierarchy<Exosuit>(gameObject);
        if (componentInHierarchy2)
        {
            var precursorDoorMotorMode = door.setToMotorModeOnEnter;
            if (precursorDoorMotorMode == PrecursorDoorMotorMode.Auto)
            {
                componentInHierarchy2.precursorOutOfWater = false;
                return;
            }

            if (precursorDoorMotorMode != PrecursorDoorMotorMode.ForceWalk) return;
            componentInHierarchy2.precursorOutOfWater = true;
        }

        var componentInHierarchy3 = UWE.Utils.GetComponentInHierarchy<SeaMoth>(gameObject);
        if (componentInHierarchy3)
        {
            var precursorDoorMotorMode = door.setToMotorModeOnEnter;
            if (precursorDoorMotorMode == PrecursorDoorMotorMode.Auto)
            {
                componentInHierarchy3.precursorOutOfWater = false;
                return;
            }

            if (precursorDoorMotorMode != PrecursorDoorMotorMode.ForceWalk) return;
            componentInHierarchy3.precursorOutOfWater = true;
            componentInHierarchy3.GetComponent<Rigidbody>().useGravity = true;
        }
    }
    /*
    public static Vector2int getItemDisplaySize(TechType tt, InventoryItem ii) {
        return getItemDisplaySize(tt, ii, ii.container);
    }

    public static Vector2int getItemDisplaySize(InventoryItem ii, TechType tt) {
        return getItemDisplaySize(tt, ii, ii.container);
    }

    public static Vector2int getItemDisplaySize(TechType tt, InventoryItem ii, IItemsContainer con) {
        if (ii != null && ii.item != null && ii.item && ii.item.gameObject != null && ii.item.gameObject) {
            //SNUtil.writeToChat((con != null ? con.label : "nocontainer")+" for "+tt+" in "+ii.item.gameObject.FindAncestor<Constructable>());
            BasicCustomPlant plant = BasicCustomPlant.getPlant(tt);
            if (plant != null && ii.item.gameObject.FindAncestor<Planter>()) {
                return plant.getSize() == Plantable.PlantSize.Large ? new Vector2int(2, 2) : new Vector2int(1, 1);
            }
        }
        return CraftData.GetItemSize(tt);
    }*/

    public static void onFModEmitterPlay(FMOD_CustomEmitter snd)
    {
        onSoundPlayedEvent?.Invoke(snd);
    }

    public static float getMaxPropulsible(float orig, GameObject go, MonoBehaviour gun, bool isMass)
    {
        //SNUtil.writeToChat("Testing "+gun.gameObject.GetFullHierarchyPath()+" grab of "+go.GetFullHierarchyPath());
        if (go.FindAncestor<Constructable>() || go.FindAncestor<SubRoot>() ||
            gun.gameObject.FindAncestor<Vehicle>() == go)
            return -1;
        var val = orig;
        if (propulsibilityEvent != null)
        {
            var e = new PropulsibilityCheck(go, val, gun, isMass);
            propulsibilityEvent.Invoke(e);
            val = e.value;
        }

        if (go.GetComponentInChildren<Vehicle>() || go.GetComponentInChildren<AlwaysPropulsible>())
            val = 999999999F;
        //Bounds aabb = go.GetComponent<FixedBounds>() ? go.GetComponent<FixedBounds>().bounds : UWE.Utils.GetEncapsulatedAABB(go, 20);
        //SNUtil.writeToChat("Modifying ["+isMass+"] propulsibility check of "+go+": "+orig+">"+val+"; mass="+go.GetComponent<Rigidbody>().mass+", AABB="+(aabb.size.x * aabb.size.y * aabb.size.z));
        return val;
    }

    public static Vector3 getPropulsionTargetCenter(Vector3 orig, GameObject go)
    {
        var v = go.GetComponentInChildren<Vehicle>();
        if (v)
        {
            var ret = go.transform.position;
            if (v is SeaMoth)
                ret += go.transform.forward * -1.25F + go.transform.up * -0.125F;
            return ret;
        }

        return orig;
    }

    public static Vector3 getPropulsionMoveToPoint(Vector3 orig, PropulsionCannon gun)
    {
        var v = Player.main.GetVehicle();
        if (v is SeaMoth && gun.gameObject.FindAncestor<Vehicle>() == v)
            return v.transform.position;
        return orig;
    }

    /*
        public static void logDockingVehicle(Vehicle v, bool dock) {
            string s = "Setting vehicle "+v+": dock state (path="+v.gameObject.GetFullHierarchyPath()+")"+" - "+dock;
            SNUtil.writeToChat(s);
            SNUtil.log(s, SNUtil.diDLL);
            SNUtil.log("from trace "+Environment.StackTrace, SNUtil.diDLL);
        }*/

    public static void onVehicleEnter(Vehicle v, Player ep)
    {
        if (vehicleEnterEvent != null && v && ep) vehicleEnterEvent.Invoke(v, ep);
    }

    /*
    public static void getCompassDepth(uGUI_DepthCompass gui, ref int depth) {
        if (depthCompassEvent != null) {
            DepthCompassCheck ch = new DepthCompassCheck(depth);
            depthCompassEvent.Invoke(ch);
            depth = ch.value;
        }
    }
    */
    public static uGUI_DepthCompass.DepthMode getCompassDepth(uGUI_DepthCompass gui, out int depth, out int crush)
    {
        var ret = gui.GetDepthInfo(out depth, out crush);
        if (depthCompassEvent != null)
        {
            var ch = new DepthCompassCheck(depth, crush);
            depthCompassEvent.Invoke(ch);
            depth = ch.value;
            crush = ch.crushValue;
        }

        return ret;
    }

    public static void onRespawnPre(Survival s, Player ep)
    {
        if (respawnEvent != null && s && ep)
            respawnEvent.Invoke(s, ep, false);
    }

    public static void onRespawnPost(Survival s, Player ep)
    {
        if (respawnEvent != null && s && ep)
            respawnEvent.Invoke(s, ep, true);
    }

    public static void onDrillableDrilled(Drillable dr, Vector3 pos, Exosuit driller)
    {
        if (drillableDrillTickEvent != null && dr)
            drillableDrillTickEvent.Invoke(dr, pos, driller);
    }

    public static void onMapRoomTick(MapRoomFunctionality map)
    {
        if (scannerRoomTickEvent != null && map)
            scannerRoomTickEvent.Invoke(map);
    }

    public static void onItemsLost()
    {
        itemsLostEvent?.Invoke();
    }

    public static void onStorageContainerHover(StorageContainer sc, GUIHand hand)
    {
        var lgc = sc.GetComponentInParent<DiscreteOperationalMachineLogic>();
        if (lgc && lgc.isWorking())
        {
            HandReticle.main.SetProgress(lgc.getProgressScalar());
            HandReticle.main.SetIcon(HandReticle.IconType.Progress);
        }

        storageHoverEvent?.Invoke(sc, hand);
    }

    public static float getModuleFireCost(float cost, Vehicle v, TechType module)
    {
        if (moduleFireCostEvent != null)
        {
            var e = new ModuleFireCostCheck(v, module, cost);
            moduleFireCostEvent.Invoke(e);
            cost = e.value;
        }

        return cost;
    }

    public static void onSelfScan()
    {
        selfScanEvent?.Invoke();
    }

    public static void filterScannerRoomResourceList(uGUI_MapRoomScanner gui)
    {
        scannerRoomTechTypeListingEvent?.Invoke(gui);
    }

    public static void tickWorldForces(WorldForces wf)
    {
        if (skipWorldForces)
            return;
        if (wf == null || wf.gameObject == null || !wf.gameObject.activeInHierarchy || !wf.enabled)
            //WorldForcesManager.instance.RemoveWorldForces(wf);
            //SNUtil.log("Disabling invalid WF tick in "+wf);
            return;
        wf.DoFixedUpdate();
    }

    public static void updateSkyApplier(SkyApplier wf)
    {
        if (skipSkyApplier)
            return;
        if (!wf || !wf.gameObject || !wf.transform) return;
        wf.UpdateSkyIfNecessary();
    }
    /*
    public static bool isRightHandDownForLightToggle(Player p) {
     return p.GetRightHandDown();
    }*/

    public static bool onStasisFreeze(StasisSphere s, Collider c, ref Rigidbody target)
    {
        target = c.GetComponentInParent<Rigidbody>();
        if (!target)
            return false;
        if (target.GetComponent<BlueprintHandTarget>())
            return false;
        if (s.targets.Contains(target))
            return true;
        var ch = new StasisEffectCheck(s, target);
        onStasisRifleFreezeEvent?.Invoke(ch);
        var name = target.name.ToLowerInvariant();
        if (name.StartsWith("explorablewreck", StringComparison.InvariantCultureIgnoreCase))
            return false;
        if (name.Contains("biodome"))
            return false;
        if (name.Contains("precursor") && (name.Contains("room") || name.Contains("base")))
            return false;
        if (c.GetComponentInParent<Player>() || c.GetComponentInParent<Vehicle>())
            return false;
        if (ch.addToTargetList)
            s.targets.Add(target);
        if (ch.applyKinematicChange)
            target.isKinematic = true;
        if (ch.sendMessage)
            target.SendMessage("OnFreeze", SendMessageOptions.DontRequireReceiver);
        if (ch.doFX)
        {
            Utils.PlayOneShotPS(s.vfxFreeze, target.GetComponent<Transform>().position, Quaternion.identity);
            FMODUWE.PlayOneShot(s.soundEnter, s.tr.position);
        }

        return !target.isKinematic;
    }

    public static void onStasisUnfreeze(StasisSphere s, Rigidbody target)
    {
        if (!target)
            return;
        var ch = new StasisEffectCheck(s, target);
        onStasisRifleUnfreezeEvent?.Invoke(ch);
        if (ch.doFX)
            Utils.PlayOneShotPS(s.vfxUnfreeze, target.GetComponent<Transform>().position, Quaternion.identity);
        if (ch.applyKinematicChange)
            target.isKinematic = false;
        if (ch.sendMessage)
            target.SendMessage("OnUnfreeze", SendMessageOptions.DontRequireReceiver);
    }

    public static void onRedundantFragmentScan()
    {
        var tgt = PDAScanner.scanTarget;
        SNUtil.writeToChat(Language.main.Get(PDAScanner.GetEntryData(tgt.techType).blueprint) + " already known");
        var r = new RedundantScanEvent();
        onRedundantScanEvent?.Invoke(r);
        if (!r.preventNormalDrop)
            CraftData.AddToInventory(TechType.Titanium, 2);
    }
    /*
    [Obsolete]
    public static bool isEquipmentApplicable(EquipmentType itemType, EquipmentType slotType, Equipment box, Pickupable item) {
         bool ret = Equipment.IsCompatible(itemType, slotType);
         if (equipmentCompatibilityCheckEvent != null) {
             EquipmentCompatibilityCheck ch = new EquipmentCompatibilityCheck(box, item, itemType, slotType, ret);
             equipmentCompatibilityCheckEvent.Invoke(ch);
             ret = ch.allow;
         }
         return ret;
    }*/

    public static EquipmentType getOverriddenEquipmentType(EquipmentType ret, TechType item)
    {
        if (equipmentTypeCheckEvent != null)
        {
            var ch = new EquipmentTypeCheck(item, ret);
            equipmentTypeCheckEvent.Invoke(ch);
            ret = ch.type;
        }

        return ret;
    }

    public static bool tryEat(Survival s, GameObject go)
    {
        var ea = new EatAttempt(s, go);
        tryEatEvent?.Invoke(ea);

        if (ea.allowEat && s.Eat(go))
        {
            onEatEvent?.Invoke(s, go);
            return true;
        }

        SoundManager.playSoundAt(SoundManager.buildSound("event:/interface/select"), Player.main.transform.position,
            false, -1);
        return false;
    }

    public static float getSwimSpeed(float f)
    {
        foreach (var m in Player.main.gameObject.GetComponents<PlayerMovementSpeedModifier>())
            f *= m.speedModifier;
        if (getSwimSpeedEvent != null)
        {
            var calc = new SwimSpeedCalculation(f);
            getSwimSpeedEvent.Invoke(calc);
            return calc.speed;
        }

        return f;
    }

    public static float getWalkSpeed(float f)
    {
        foreach (var m in Player.main.gameObject.GetComponents<PlayerMovementSpeedModifier>())
            f *= m.speedModifier;
        //SNUtil.writeToChat("Walk speed is "+f.ToString("0.000"));
        return f;
    }

    public static void onVehicleDestroyed(Vehicle v)
    {
        var li = new List<IItemsContainer>();
        v.GetAllStorages(li);
        foreach (ItemsContainer sc in li)
        foreach (var tt in sc.GetItemTypes())
            if (IrreplaceableItemRegistry.instance.isIrreplaceable(tt))
                foreach (var ii in new List<InventoryItem>(sc.GetItems(tt)))
                    if (ii != null && ii.item)
                    {
                        var pp = ii.item;
                        pp.Drop();
                        pp.GetComponent<Rigidbody>().isKinematic = true;
                    }
    }

    public static void onSleep(Bed bed)
    {
        onSleepEvent?.Invoke(bed);
    }

    public static float getFoodWaterConsumptionRate(float f)
    {
        if (getFoodRateEvent != null)
        {
            var calc = new FoodRateCalculation(f);
            getFoodRateEvent.Invoke(calc);
            return calc.rate;
        }

        return f;
    }

    public static Vector3 getPlayerMovementControl(Vector3 orig)
    {
        //used to override player controls
        if (getPlayerInputEvent != null)
        {
            var calc = new PlayerInput(orig);
            getPlayerInputEvent.Invoke(calc);
            return calc.selectedInput;
        }

        return orig;
    }

    public static void doShootTorpedo(Bullet b, Vector3 position, Quaternion rotation, float speed, float lifeTime,
        Vehicle v)
    {
        b.Shoot(position, rotation, speed, lifeTime);
        onTorpedoFireEvent?.Invoke(b, v);
    }

    public static Transform onTorpedoExploded(Transform result, SeamothTorpedo sm)
    {
        result.position = sm.tr.position;
        result.rotation = sm.tr.rotation;
        onTorpedoExplodeEvent?.Invoke(sm, result);
        return result;
    }

    private static GameObject teleportWithPlayer;
    private static PropulsionCannon activePropulsionGun;
    private static Vector3 relativeGrabPosition;
    private static int selectedSlot;

    private static void startTeleport()
    {
        if (!Player.main.GetVehicle() && !Player.main.currentSub)
        {
            var pp = Inventory.main.GetHeld();
            if (pp)
            {
                var pc = pp.GetComponent<PropulsionCannon>();
                if (pc && pc.grabbedObject)
                {
                    selectedSlot = Inventory.main.quickSlots.activeSlot;
                    activePropulsionGun = pc;
                    teleportWithPlayer = pc.grabbedObject;
                    relativeGrabPosition = teleportWithPlayer.transform.position - Player.main.transform.position;
                    teleportWithPlayer.transform.position =
                        WorldUtil.getClosest<PrecursorTeleporter>(Player.main.transform.position).warpToPos;
                    //SNUtil.writeToChat("Teleporting "+teleportWithPlayer+" with player, pre");
                }
            }
        }
    }

    private static void stopTeleport()
    {
        if (activePropulsionGun)
            if (teleportWithPlayer)
            {
                //InventoryItem ii = Inventory.main.container.GetItems(activePropulsionGun.GetComponent<Pickupable>().GetTechType()).First();
                Inventory.main.quickSlots.SelectImmediate(selectedSlot);
                teleportWithPlayer.transform.position = Player.main.transform.position + relativeGrabPosition;
                activePropulsionGun.GrabObject(teleportWithPlayer);
                //SNUtil.writeToChat("Teleporting "+teleportWithPlayer+" with player, post");
            }

        //SNUtil.writeToChat("Object to teleport with player does not yet exist");
        teleportWithPlayer = null;
        activePropulsionGun = null;
    }
}