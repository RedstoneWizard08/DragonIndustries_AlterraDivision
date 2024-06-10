using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using ECCLibrary.Data;
using Nautilus.Assets;
using Nautilus.Handlers;
using Nautilus.Utility;
using ReikaKalseki.DIAlterra.Api.Auxiliary;
using ReikaKalseki.DIAlterra.Api.Instantiable.Component;
using ReikaKalseki.DIAlterra.Api.Registry;
using Story;
using UnityEngine;
using Debug = UnityEngine.Debug;
using Object = UnityEngine.Object;

namespace ReikaKalseki.DIAlterra.Api.Util;

public static class SNUtil
{
    private static FMODAsset unlockSound;

    public static readonly Assembly diDLL = Assembly.GetExecutingAssembly();
    public static readonly Assembly smlDLL = Assembly.GetAssembly(typeof(CustomPrefab));
    public static readonly Assembly gameDLL = Assembly.GetAssembly(typeof(BoneShark));
    public static readonly Assembly gameDLL2 = Assembly.GetAssembly(typeof(FMODAsset));

    internal static bool allowDIDLL = false;

    private static readonly HashSet<Assembly> assembliesToSkip = new()
    {
        diDLL,
        smlDLL,
        gameDLL,
        gameDLL2
    };

    public static void checkModHash(Assembly mod)
    {
        using (var md5 = MD5.Create())
        {
            using (var stream = File.OpenRead(mod.Location))
            {
                var hash = md5.ComputeHash(stream);
                var hashfile = Path.Combine(Path.GetDirectoryName(mod.Location), "mod.hash");
                //if (!File.Exists(hashfile))
                //	File.WriteAllBytes(hashfile, hash);
                var stored = File.ReadAllBytes(hashfile);
                if (stored.SequenceEqual(hash))
                    log("Mod " + mod.Location + " hash check passed with hash " + hash.toDebugString(), mod);
                else
                    throw new Exception("Your mod assembly has been modified! Redownload it.\nExpected: " +
                                        stored.toDebugString() + "\nActual: " + hash.toDebugString());
            }
        }
    }

    internal static Assembly tryGetModDLL(bool acceptDI = false)
    {
        var di = Assembly.GetExecutingAssembly();
        var sf = new StackTrace().GetFrames();
        if (sf == null || sf.Length == 0)
            return Assembly.GetCallingAssembly();
        foreach (var f in sf)
        {
            var a = f.GetMethod().DeclaringType.Assembly;
            if ((a != di || acceptDI || allowDIDLL) && a != smlDLL && a != gameDLL && a != gameDLL2 &&
                a.Location.Contains("plugins"))
                return a;
        }

        log(
            "Could not find valid mod assembly: " + string.Join("\n",
                sf.Select(s => s.GetMethod() + " in " + s.GetMethod().DeclaringType)), diDLL);
        return Assembly.GetCallingAssembly();
    }

    public static void log(string s, Assembly a = null, int indent = 0)
    {
        while (s.Length > 4096)
        {
            var part = s.Substring(0, 4096);
            log(part, a);
            s = s.Substring(4096);
        }

        var id = (a != null ? a : tryGetModDLL()).GetName().Name.ToUpperInvariant().Replace("PLUGIN_", "");
        if (indent > 0) s = s.PadLeft(s.Length + indent, ' ');
        Debug.Log(id + ": " + s);
    }

    public static int getInstallSeed()
    {
        var seed = diDLL.Location.GetHashCode();
        seed &= ~(1 << Environment.ProcessorCount);
        var n = Environment.MachineName;
        if (string.IsNullOrEmpty(n))
            n = Environment.UserName;
        seed ^= n != null ? n.GetHashCode() : 0;
        seed ^= Environment.OSVersion.VersionString.GetHashCode();
        return seed;
    }

    public static int getWorldSeedInt()
    {
        var seed = getWorldSeed();
        return unchecked((int) ((seed & 0xFFFFFFFFL) ^ (seed >> 32)));
    }

    public static long getWorldSeed()
    {
        var path = SaveUtils.GetCurrentSaveDataDir();
        var seed = SaveLoadManager._main.firstStart;
        seed ^= path.GetHashCode();
        seed ^= (long) diDLL.Location.GetHashCode() << 32;
        return seed;
    }

    public static TechType getTechType(string tech)
    {
        TechType ret;
        if (!Enum.TryParse(tech, false, out ret))
        {
            if (EnumHandler.TryGetValue(tech, out ret)) return ret;

            log("TechType '" + tech + "' not found!");
            //log("Tech list: "+string.Join(", ", Enum.GetNames(typeof(TechType))));

            return TechType.None;
        }

        return ret;
    }

    public static void writeToChat(string s)
    {
        while (s.Length >= 4096)
        {
            var part = s.Substring(0, 4096);
            ErrorMessage.AddMessage(part);
            s = s.Substring(4096);
        }

        ErrorMessage.AddMessage(s);
    }

    public static void showPDANotification(string text, string soundPath)
    {
        var pda = Player.main.gameObject.AddComponent<PDANotification>();
        pda.enabled = true;
        pda.text = text;
        pda.sound = SoundManager.getSound(soundPath);
        pda.Play();
        Object.Destroy(pda, 15);
    }

    public static void addSelfUnlock(TechType tech, PDAManager.PDAPage page = null)
    {
        KnownTechHandler.SetAnalysisTechEntry(tech, new List<TechType> {tech});
        if (page != null)
        {
            var e = new PDAScanner.EntryData();
            e.key = tech;
            e.scanTime = 5;
            e.locked = true;
            page.register();
            e.encyclopedia = page.id;
            PDAHandler.AddCustomScannerEntry(e);
        }
    }

    public static StoryGoal addRadioMessage(string key, string text, string soundPath)
    {
        return addRadioMessage(key, text,
            SoundManager.registerPDASound(tryGetModDLL(), "radio_" + key, soundPath).asset);
    }

    public static StoryGoal addRadioMessage(string key, string text, FMODAsset sound)
    {
        return addVOLine(key, Story.GoalType.Radio, text, sound);
    }

    public static StoryGoal addVOLine(string key, Story.GoalType type, string text, FMODAsset sound)
    {
        var sg = new StoryGoal(key, type, 0);
        PDAHandler.AddLogEntry(key, key, sound);
        LanguageHandler.SetLanguageLine(key, text);
        return sg;
    }

    public static void teleportPlayer(Player ep, Vector3 to)
    {
        if (ep.currentMountedVehicle != null)
            ep.currentMountedVehicle.transform.position =
                to + (ep.currentMountedVehicle.transform.position - ep.transform.position);
        ep.transform.position = to;
    }

    public static void addPDAEntry(ICustomPrefab pfb, float scanTime, string pageCategory = null,
        string pageText = null,
        string pageHeader = null, Action<PDAScanner.EntryData> modify = null)
    {
        addPDAEntry(pfb.Info.TechType, pfb.Info.ClassID, pfb.Info.PrefabFileName, scanTime, pageCategory, pageText,
            pageHeader, modify);
    }

    public static void addPDAEntry(TechType pfb, string id, string desc, float scanTime, string pageCategory = null,
        string pageText = null, string pageHeader = null, Action<PDAScanner.EntryData> modify = null)
    {
        PDAManager.PDAPage page = null;
        if (pageCategory != null && !string.IsNullOrEmpty(pageText))
        {
            page = PDAManager.createPage("ency_" + id, desc, pageText, pageCategory);
            if (pageHeader != null)
                page.setHeaderImage(TextureManager.getTexture(tryGetModDLL(), "Textures/PDA/" + pageHeader));
            page.register();
        }

        if (scanTime >= 0)
            addScanUnlock(pfb, desc, scanTime, page, modify);
    }

    public static void addScanUnlock(TechType pfb, string desc, float scanTime, PDAManager.PDAPage page = null,
        Action<PDAScanner.EntryData> modify = null)
    {
        var e = new PDAScanner.EntryData();
        e.key = pfb;
        e.scanTime = scanTime;
        e.locked = true;
        if (modify != null) modify(e);
        if (page != null)
        {
            e.encyclopedia = page.id;
            log("Bound scanner entry for " + desc + " to " + page.id);
        }
        else
        {
            log("Scanner entry for " + desc + " had no ency page.");
        }

        PDAHandler.AddCustomScannerEntry(e);
    }

    public static void addMultiScanUnlock(TechType toScan, float scanTime, TechType unlock, int total, bool remove)
    {
        var e = new PDAScanner.EntryData();
        e.key = toScan;
        e.scanTime = scanTime;
        e.locked = true;
        e.blueprint = unlock;
        e.isFragment = true;
        e.totalFragments = total;
        e.destroyAfterScan = remove;
        PDAHandler.AddCustomScannerEntry(e);
    }

    public static void triggerTechPopup(TechType tt, Sprite spr = null)
    {
        var at = new KnownTech.AnalysisTech();
        at.techType = tt;
        at.unlockMessage = "NotificationBlueprintUnlocked";
        at.unlockSound = getUnlockSound();
        if (spr == null)
            spr = getTechPopupSprite(tt);
        if (spr != null)
            at.unlockPopup = spr;
        uGUI_PopupNotification.main.OnAnalyze(at, true);
    }

    public static void triggerMultiTechPopup(IEnumerable<TechType> tt)
    {
        var pd = new PopupData("New Blueprints Unlocked",
            "<color=#74C8F8FF>" + string.Join(",\n", tt.Select(tc => Language.main.Get(tc.AsString()))) + "</color>");
        pd.sound = getUnlockSound().path;
        triggerUnlockPopup(pd);
    }

    public static FMODAsset getUnlockSound()
    {
        if (unlockSound == null)
            foreach (var kt in KnownTech.analysisTech)
                if (kt.unlockMessage == "NotificationBlueprintUnlocked")
                {
                    unlockSound = kt.unlockSound;
                    break;
                }

        return unlockSound;
    }

    public static Sprite getTechPopupSprite(TechType tt)
    {
        foreach (var kt in KnownTech.analysisTech)
            if (kt.techType == tt)
                return kt.unlockPopup;
        return null;
    }

    public static void triggerUnlockPopup(PopupData data)
    {
        uGUI_PopupNotification.main.Show(new uGUI_PopupNotification.Entry()
        {
            title = data.title.Replace("\\n", "\n"),
            text = data.text.Replace("\\n", "\n"),
            controls = data.controlText?.Replace("\\n", "\n"),
            sprite = data.graphic?.Invoke(),
            data = string.Empty,
            skin = PopupNotificationSkin.Unlock
        });

        log("Showing progression popup " + data, diDLL);

        if (!string.IsNullOrEmpty(data.sound))
            SoundManager.playSound(data.sound);
    }

    public static void shakeCamera(float duration, float intensity, float frequency = 1)
    {
        //Camera.main.gameObject.EnsureComponent<CameraShake>().fire(intensity, duration, falloff);
        var cam = Player.main.GetComponentInChildren<MainCameraControl>();
        cam.ShakeCamera(intensity, duration, MainCameraControl.ShakeMode.BuildUp, frequency);
    }
    /*
    private class CameraShake : MonoBehaviour {

        private float duration;
        private float intensity;
        private float falloff;

        private Vector3 originalPosition;
        private float durationToGo;

        internal void fire(float i, float d, float f) {
            originalPosition = transform.position;
            duration = d;
            durationToGo = d;
            intensity = i;
            falloff = f;
        }

        void Update() {
            if (durationToGo > 0) {
                float i = Mathf.Lerp(0, intensity, durationToGo/duration);
                transform.position = originalPosition+UnityEngine.Random.insideUnitSphere*i;
                durationToGo -= Time.deltaTime*falloff;
            }
            else {
                transform.position = originalPosition;
                UnityEngine.Object.Destroy(this);
            }
        }
    }*/

    public static int getFragmentScanCount(TechType tt)
    {
        PDAScanner.Entry entry;
        if (PDAScanner.GetPartialEntryByKey(tt, out entry))
            return entry == null ? 0 : entry.unlocked;
        return 0;
    }

    public static void addEncyNotification(string id, float duration = 3)
    {
        NotificationManager.main.Add(NotificationManager.Group.Encyclopedia, id, duration);
    }

    public static void addBlueprintNotification(TechType recipe, float duration = 3)
    {
        NotificationManager.main.Add(NotificationManager.Group.Blueprints, recipe.EncodeKey(), duration);
    }

    public static void addInventoryNotification(Pickupable item, float duration = 3)
    {
        NotificationManager.main.Add(NotificationManager.Group.Inventory, item.GetComponent<UniqueIdentifier>().Id,
            duration);
    }

    public static void createPopupWarning(string msg, bool makeBlue)
    {
/*
                QModManager.Patching.Patcher.Dialogs.Add(new Dialog
                {
                    message = text,
                    leftButton = Dialog.Button.SeeLog,
                    rightButton = Dialog.Button.Close,
                    color = Dialog.DialogColor.Red
                });
*/
        var patcher = InstructionHandlers.getTypeBySimpleName("QModManager.Patching.Patcher");
        var dlgType = InstructionHandlers.getTypeBySimpleName("QModManager.Utility.Dialog");
        var btnType = dlgType.GetNestedType("Button", BindingFlags.NonPublic);
        var dialogs = (IList) patcher.GetProperty("Dialogs", BindingFlags.Static | BindingFlags.NonPublic)
            .GetValue(null);
        var dlg = Activator.CreateInstance(dlgType);
        dlgType.GetField("message", BindingFlags.Instance | BindingFlags.NonPublic).SetValue(dlg, msg);
        dlgType.GetField("color", BindingFlags.Instance | BindingFlags.NonPublic).SetValue(dlg, makeBlue ? 1 : 0);
        dlgType.GetField("leftButton", BindingFlags.Instance | BindingFlags.NonPublic).SetValue(dlg,
            btnType.GetField("SeeLog", BindingFlags.Static | BindingFlags.NonPublic).GetValue(null));
        dlgType.GetField("rightButton", BindingFlags.Instance | BindingFlags.NonPublic).SetValue(dlg,
            btnType.GetField("Close", BindingFlags.Static | BindingFlags.NonPublic).GetValue(null));
        dialogs.Add(dlg);
    }

    public static bool checkPiracy()
    {
        var files = new HashSet<string>
        {
            "steam_api64.cdx", "steam_api64.ini", "steam_emu.ini", "valve.ini", "chuj.cdx", "SteamUserID.cfg",
            "Achievements.bin", "steam_settings", "user_steam_id.txt", "account_name.txt", "ScreamAPI.dll",
            "ScreamAPI32.dll", "ScreamAPI64.dll", "SmokeAPI.dll", "SmokeAPI32.dll", "SmokeAPI64.dll",
            "Free Steam Games Pre-installed for PC.url", "Torrent-Igruha.Org.URL", "oalinst.exe"
        };
        foreach (var file in files)
            if (File.Exists(Path.Combine(Environment.CurrentDirectory, file)))
                return true;
        return false;
    }

    public static void vomit(Survival s, float food, float water)
    {
        s.food = Mathf.Max(1, s.food - food);
        s.water = Mathf.Max(1, s.water - water);
        SoundManager.playSoundAt(
            SoundManager.buildSound(Player.main.IsUnderwater()
                ? "event:/player/Puke_underwater"
                : "event:/player/Puke"), Player.main.transform.position, false, 12);
        PlayerMovementSpeedModifier.add(0.15F, 1.25F);
        MainCameraControl.main.ShakeCamera(2F, 1.0F, MainCameraControl.ShakeMode.Linear,
            0.25F); //SNUtil.shakeCamera(1.2F, 0.5F, 0.2F);
    }

    public static CustomPrefab getModPrefabByTechType(TechType tt)
    {
        var dict = (Dictionary<string, CustomPrefab>) typeof(CustomPrefab)
            .GetField("ClassIdDictionary", BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Public)
            .GetValue(null);
        return dict.ContainsKey(tt.AsString()) ? dict[tt.AsString()] : null;
    }

    // public static WaterParkCreatureParameters getModifiedACUParams(TechType basis, float initSizeScale,
    //     float maxSizeScale, float outsideSizeScale, float growTimeScale)
    // {
    //     WaterParkCreatureParameters baseP = WaterParkCreature.GetParameters(basis);
    //     return new WaterParkCreatureParameters(baseP.initialSize * initSizeScale, baseP.maxSize * maxSizeScale,
    //         baseP.outsideSize * outsideSizeScale, baseP.growingPeriod * growTimeScale, baseP.isPickupableOutside);
    // }

    public static string getDescriptiveEncyPageCategoryName(PDAEncyclopedia.EntryData data)
    {
        var lifeform = data.nodes.Length >= 2 && data.nodes[0] == "Lifeforms";
        if (lifeform)
            return Language.main.Get("EncyPath_" + data.nodes[0] + "/" + data.nodes[1]);
        return Language.main.Get("EncyPath_" + data.nodes[0]);
    }

    public static MapRoomCamera getControllingCamera(Player ep)
    {
        return MapRoomCamera.cameras.FirstOrDefault(cam => cam && cam.IsControlled());
    }

    public class PopupData
    {
        public readonly string text;

        public readonly string title;

        public string controlText = null;
        public Func<Sprite> graphic = null;
        public string sound = "event:/tools/scanner/scan_complete";

        public PopupData(string t, string d)
        {
            title = t;
            text = d;
        }

        public override string ToString()
        {
            return string.Format("[PopupData Title='{0}'; Text='{1}'; ControlText='{2}'; Graphic={3}; Sound={4}]",
                title, text, controlText, graphic, sound);
        }
    }
}