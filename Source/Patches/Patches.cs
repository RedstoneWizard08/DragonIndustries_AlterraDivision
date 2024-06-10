using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using HarmonyLib;
using ReikaKalseki.DIAlterra.Api.Util;
using UnityEngine;
// ReSharper disable UnusedMember.Local
// ReSharper disable UnusedParameter.Local

//For data read/write methods
//Working with Lists and Collections
//Working with Lists and Collections
//More advanced manipulation of lists/collections
//Needed for most Unity Enginer manipulations: Vectors, GameObjects, Audio, etc.

namespace ReikaKalseki.DIAlterra.Patches;

[HarmonyPatch(typeof(DayNightCycle))]
[HarmonyPatch("Update")]
public static class UpdateLoopHook
{
    private static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
    {
        var codes = new List<CodeInstruction>(instructions);
        try
        {
            InstructionHandlers.patchInitialHook(codes, new CodeInstruction(OpCodes.Ldarg_0),
                InstructionHandlers.createMethodCall(nameof(DIHooks), "onTick", false,
                    typeof(DayNightCycle)));
            FileLog.Log("Done patch " + MethodBase.GetCurrentMethod()?.DeclaringType);
            //FileLog.Log("Codes are "+InstructionHandlers.toString(codes));
        }
        catch (Exception e)
        {
            FileLog.Log("Caught exception when running patch " + MethodBase.GetCurrentMethod()?.DeclaringType + "!");
            FileLog.Log(e.Message);
            FileLog.Log(e.StackTrace);
            FileLog.Log(e.ToString());
        }

        return codes.AsEnumerable();
    }
}

[HarmonyPatch(typeof(SNCameraRoot))]
[HarmonyPatch("SonarPing")]
public static class SonarHook
{
    private static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
    {
        var codes = new List<CodeInstruction>(instructions);
        try
        {
            InstructionHandlers.patchInitialHook(codes, new CodeInstruction(OpCodes.Ldarg_0),
                InstructionHandlers.createMethodCall(nameof(DIHooks), "pingSonar", false,
                    typeof(SNCameraRoot)));
            //FileLog.Log("Codes are "+InstructionHandlers.toString(codes));
            FileLog.Log("Done patch " + MethodBase.GetCurrentMethod()?.DeclaringType);
        }
        catch (Exception e)
        {
            FileLog.Log("Caught exception when running patch " + MethodBase.GetCurrentMethod()?.DeclaringType + "!");
            FileLog.Log(e.Message);
            FileLog.Log(e.StackTrace);
            FileLog.Log(e.ToString());
        }

        return codes.AsEnumerable();
    }
}

[HarmonyPatch(typeof(SeaMoth))]
[HarmonyPatch("OnUpgradeModuleUse")]
public static class SeamothSonarHook
{
    private static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
    {
        var codes = new List<CodeInstruction>(instructions);
        try
        {
            var idx = InstructionHandlers.getInstruction(codes, 0, 0, OpCodes.Callvirt, "SNCameraRoot", "SonarPing",
                true, new Type[0]);
            codes.Insert(idx + 1,
                InstructionHandlers.createMethodCall(nameof(DIHooks), "pingSeamothSonar", false,
                    typeof(SeaMoth)));
            codes.Insert(idx + 1, new CodeInstruction(OpCodes.Ldarg_0));
            //FileLog.Log("Codes are "+InstructionHandlers.toString(codes));
            FileLog.Log("Done patch " + MethodBase.GetCurrentMethod()?.DeclaringType);
        }
        catch (Exception e)
        {
            FileLog.Log("Caught exception when running patch " + MethodBase.GetCurrentMethod()?.DeclaringType + "!");
            FileLog.Log(e.Message);
            FileLog.Log(e.StackTrace);
            FileLog.Log(e.ToString());
        }

        return codes.AsEnumerable();
    }
}

[HarmonyPatch(typeof(CyclopsSonarButton))]
[HarmonyPatch("SonarPing")]
public static class CyclopsSonarHook
{
    private static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
    {
        var codes = new List<CodeInstruction>(instructions);
        try
        {
            var idx = InstructionHandlers.getInstruction(codes, 0, 0, OpCodes.Callvirt, "SNCameraRoot", "SonarPing",
                true, new Type[0]);
            codes.Insert(idx + 1,
                InstructionHandlers.createMethodCall(nameof(DIHooks), "pingCyclopsSonar", false,
                    typeof(CyclopsSonarButton)));
            codes.Insert(idx + 1, new CodeInstruction(OpCodes.Ldarg_0));
            //FileLog.Log("Codes are "+InstructionHandlers.toString(codes));
            FileLog.Log("Done patch " + MethodBase.GetCurrentMethod()?.DeclaringType);
        }
        catch (Exception e)
        {
            FileLog.Log("Caught exception when running patch " + MethodBase.GetCurrentMethod()?.DeclaringType + "!");
            FileLog.Log(e.Message);
            FileLog.Log(e.StackTrace);
            FileLog.Log(e.ToString());
        }

        return codes.AsEnumerable();
    }
}

[HarmonyPatch(typeof(StoryGoalCustomEventHandler))]
[HarmonyPatch("NotifyGoalComplete")]
public static class StoryHook
{
    private static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
    {
        var codes = new List<CodeInstruction>(instructions);
        try
        {
            InstructionHandlers.patchInitialHook(codes, new CodeInstruction(OpCodes.Ldarg_1),
                InstructionHandlers.createMethodCall(nameof(DIHooks), "onStoryGoalCompleted", false,
                    typeof(string)));
            FileLog.Log("Done patch " + MethodBase.GetCurrentMethod()?.DeclaringType);
        }
        catch (Exception e)
        {
            FileLog.Log("Caught exception when running patch " + MethodBase.GetCurrentMethod()?.DeclaringType + "!");
            FileLog.Log(e.Message);
            FileLog.Log(e.StackTrace);
            FileLog.Log(e.ToString());
        }

        return codes.AsEnumerable();
    }
}

[HarmonyPatch(typeof(SeaMoth))]
[HarmonyPatch("OnUpgradeModuleChange")]
public static class SeamothModuleHook
{
    private static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
    {
        var codes = new List<CodeInstruction>(instructions);
        try
        {
            InstructionHandlers.patchEveryReturnPre(codes, injectSMModuleHook);
            //FileLog.Log("Codes are "+InstructionHandlers.toString(codes));
            FileLog.Log("Done patch " + MethodBase.GetCurrentMethod()?.DeclaringType);
        }
        catch (Exception e)
        {
            FileLog.Log("Caught exception when running patch " + MethodBase.GetCurrentMethod()?.DeclaringType + "!");
            FileLog.Log(e.Message);
            FileLog.Log(e.StackTrace);
            FileLog.Log(e.ToString());
        }

        return codes.AsEnumerable();
    }

    private static void injectSMModuleHook(List<CodeInstruction> codes, int idx)
    {
        codes.Insert(idx,
            InstructionHandlers.createMethodCall(nameof(DIHooks), "updateSeamothModules", false,
                typeof(SeaMoth), typeof(int), typeof(TechType), typeof(bool)));
        codes.Insert(idx, new CodeInstruction(OpCodes.Ldarg_3));
        codes.Insert(idx, new CodeInstruction(OpCodes.Ldarg_2));
        codes.Insert(idx, new CodeInstruction(OpCodes.Ldarg_1));
        codes.Insert(idx, new CodeInstruction(OpCodes.Ldarg_0));
    }
}

[HarmonyPatch(typeof(SubRoot))]
[HarmonyPatch("UpdateSubModules")]
public static class CyclopsModuleHook
{
    private static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
    {
        var codes = new List<CodeInstruction>(instructions);
        try
        {
            InstructionHandlers.patchEveryReturnPre(codes, injectModuleHook);
            //FileLog.Log("Codes are "+InstructionHandlers.toString(codes));
            FileLog.Log("Done patch " + MethodBase.GetCurrentMethod()?.DeclaringType);
        }
        catch (Exception e)
        {
            FileLog.Log("Caught exception when running patch " + MethodBase.GetCurrentMethod()?.DeclaringType + "!");
            FileLog.Log(e.Message);
            FileLog.Log(e.StackTrace);
            FileLog.Log(e.ToString());
        }

        return codes.AsEnumerable();
    }

    private static void injectModuleHook(List<CodeInstruction> codes, int idx)
    {
        codes.Insert(idx,
            InstructionHandlers.createMethodCall(nameof(DIHooks), "updateCyclopsModules", false,
                typeof(SubRoot)));
        codes.Insert(idx, new CodeInstruction(OpCodes.Ldarg_0));
    }
}

[HarmonyPatch(typeof(Exosuit))]
[HarmonyPatch("OnUpgradeModuleChange")]
public static class PrawnModuleHook
{
    private static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
    {
        var codes = new List<CodeInstruction>(instructions);
        try
        {
            InstructionHandlers.patchEveryReturnPre(codes, injectModuleHook);
            //FileLog.Log("Codes are "+InstructionHandlers.toString(codes));
            FileLog.Log("Done patch " + MethodBase.GetCurrentMethod()?.DeclaringType);
        }
        catch (Exception e)
        {
            FileLog.Log("Caught exception when running patch " + MethodBase.GetCurrentMethod()?.DeclaringType + "!");
            FileLog.Log(e.Message);
            FileLog.Log(e.StackTrace);
            FileLog.Log(e.ToString());
        }

        return codes.AsEnumerable();
    }

    private static void injectModuleHook(List<CodeInstruction> codes, int idx)
    {
        codes.Insert(idx,
            InstructionHandlers.createMethodCall(nameof(DIHooks), "updatePrawnModules", false,
                typeof(Exosuit), typeof(int), typeof(TechType), typeof(bool)));
        codes.Insert(idx, new CodeInstruction(OpCodes.Ldarg_3));
        codes.Insert(idx, new CodeInstruction(OpCodes.Ldarg_2));
        codes.Insert(idx, new CodeInstruction(OpCodes.Ldarg_1));
        codes.Insert(idx, new CodeInstruction(OpCodes.Ldarg_0));
    }
}

[HarmonyPatch(typeof(SeaMoth))]
[HarmonyPatch("OnUpgradeModuleUse")]
public static class SeamothModuleUseHook
{
    private static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
    {
        var codes = new List<CodeInstruction>(instructions);
        try
        {
            InstructionHandlers.patchInitialHook(codes, injectModuleHook());
            //FileLog.Log("Codes are "+InstructionHandlers.toString(codes));
            FileLog.Log("Done patch " + MethodBase.GetCurrentMethod()?.DeclaringType);
        }
        catch (Exception e)
        {
            FileLog.Log("Caught exception when running patch " + MethodBase.GetCurrentMethod()?.DeclaringType + "!");
            FileLog.Log(e.Message);
            FileLog.Log(e.StackTrace);
            FileLog.Log(e.ToString());
        }

        return codes.AsEnumerable();
    }

    private static CodeInstruction[] injectModuleHook()
    {
        var codes = new List<CodeInstruction>();
        codes.Add(new CodeInstruction(OpCodes.Ldarg_0));
        codes.Add(new CodeInstruction(OpCodes.Ldarg_1));
        codes.Add(new CodeInstruction(OpCodes.Ldarg_2));
        codes.Add(InstructionHandlers.createMethodCall(nameof(DIHooks), "useSeamothModule", false,
            typeof(SeaMoth), typeof(TechType), typeof(int)));
        return codes.ToArray();
    }
}

[HarmonyPatch(typeof(CellManager))]
[HarmonyPatch("RegisterEntity", typeof(LargeWorldEntity))]
public static class EntityRegisterBypass
{
    private static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
    {
        var codes = new List<CodeInstruction>(instructions);
        try
        {
            InstructionHandlers.patchInitialHook(codes, new CodeInstruction(OpCodes.Ldarg_0),
                new CodeInstruction(OpCodes.Ldarg_1),
                InstructionHandlers.createMethodCall(nameof(DIHooks), "onEntityRegister", false,
                    typeof(CellManager), typeof(LargeWorldEntity)));
            FileLog.Log("Done patch " + MethodBase.GetCurrentMethod()?.DeclaringType);
        }
        catch (Exception e)
        {
            FileLog.Log("Caught exception when running patch " + MethodBase.GetCurrentMethod()?.DeclaringType + "!");
            FileLog.Log(e.Message);
            FileLog.Log(e.StackTrace);
            FileLog.Log(e.ToString());
        }

        return codes.AsEnumerable();
    }
}

[HarmonyPatch(typeof(Player))]
[HarmonyPatch("Update")]
public static class PlayerTick
{
    private static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
    {
        var codes = new List<CodeInstruction>(instructions);
        try
        {
            PatchLib.injectTickHook(codes, "tickPlayer", typeof(Player));
            FileLog.Log("Done patch " + MethodBase.GetCurrentMethod()?.DeclaringType);
        }
        catch (Exception e)
        {
            FileLog.Log("Caught exception when running patch " + MethodBase.GetCurrentMethod()?.DeclaringType + "!");
            FileLog.Log(e.Message);
            FileLog.Log(e.StackTrace);
            FileLog.Log(e.ToString());
        }

        return codes.AsEnumerable();
    }
}

[HarmonyPatch(typeof(SeaMoth))]
[HarmonyPatch("Update")]
public static class SeaMothTick
{
    private static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
    {
        var codes = new List<CodeInstruction>(instructions);
        try
        {
            PatchLib.injectTickHook(codes, "tickSeamoth", typeof(SeaMoth));
            FileLog.Log("Done patch " + MethodBase.GetCurrentMethod()?.DeclaringType);
        }
        catch (Exception e)
        {
            FileLog.Log("Caught exception when running patch " + MethodBase.GetCurrentMethod()?.DeclaringType + "!");
            FileLog.Log(e.Message);
            FileLog.Log(e.StackTrace);
            FileLog.Log(e.ToString());
        }

        return codes.AsEnumerable();
    }
}

[HarmonyPatch(typeof(Exosuit))]
[HarmonyPatch("Update")]
public static class ExosuitTick
{
    private static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
    {
        var codes = new List<CodeInstruction>(instructions);
        try
        {
            PatchLib.injectTickHook(codes, "tickPrawn", typeof(Exosuit));
            FileLog.Log("Done patch " + MethodBase.GetCurrentMethod()?.DeclaringType);
        }
        catch (Exception e)
        {
            FileLog.Log("Caught exception when running patch " + MethodBase.GetCurrentMethod()?.DeclaringType + "!");
            FileLog.Log(e.Message);
            FileLog.Log(e.StackTrace);
            FileLog.Log(e.ToString());
        }

        return codes.AsEnumerable();
    }
}

[HarmonyPatch(typeof(SubRoot))]
[HarmonyPatch("Update")]
public static class SubTick
{
    private static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
    {
        var codes = new List<CodeInstruction>(instructions);
        try
        {
            PatchLib.injectTickHook(codes, "tickSub", typeof(SubRoot));
            FileLog.Log("Done patch " + MethodBase.GetCurrentMethod()?.DeclaringType);
        }
        catch (Exception e)
        {
            FileLog.Log("Caught exception when running patch " + MethodBase.GetCurrentMethod()?.DeclaringType + "!");
            FileLog.Log(e.Message);
            FileLog.Log(e.StackTrace);
            FileLog.Log(e.ToString());
        }

        return codes.AsEnumerable();
    }
}

[HarmonyPatch(typeof(WaterTemperatureSimulation), "GetTemperature", typeof(Vector3))]
public static class WaterTempOverride
{
    private static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
    {
        var codes = new List<CodeInstruction>(instructions);
        try
        {
            InstructionHandlers.patchEveryReturnPre(codes, injectHook);
            FileLog.Log("Done patch " + MethodBase.GetCurrentMethod()?.DeclaringType);
        }
        catch (Exception e)
        {
            FileLog.Log("Caught exception when running patch " + MethodBase.GetCurrentMethod()?.DeclaringType + "!");
            FileLog.Log(e.Message);
            FileLog.Log(e.StackTrace);
            FileLog.Log(e.ToString());
        }

        return codes.AsEnumerable();
    }

    private static void injectHook(List<CodeInstruction> codes, int idx)
    {
        codes.Insert(idx,
            InstructionHandlers.createMethodCall(nameof(DIHooks), "getWaterTemperature", false,
                typeof(float), typeof(WaterTemperatureSimulation), typeof(Vector3)));
        codes.Insert(idx, new CodeInstruction(OpCodes.Ldarg_1));
        codes.Insert(idx, new CodeInstruction(OpCodes.Ldarg_0));
    }
}

[HarmonyPatch(typeof(Pickupable))]
[HarmonyPatch("Pickup")]
public static class OnPlayerPickup
{
    private static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
    {
        var codes = new List<CodeInstruction>(instructions);
        try
        {
            var idx = InstructionHandlers.getInstruction(codes, 0, 0, OpCodes.Call, "Pickupable", "PlayPickupSound",
                true, new Type[0]);
            codes.Insert(idx, new CodeInstruction(OpCodes.Ldarg_0));
            codes.Insert(idx,
                InstructionHandlers.createMethodCall(nameof(DIHooks), "onItemPickedUp", false,
                    typeof(Pickupable)));
            FileLog.Log("Done patch " + MethodBase.GetCurrentMethod()?.DeclaringType);
        }
        catch (Exception e)
        {
            FileLog.Log("Caught exception when running patch " + MethodBase.GetCurrentMethod()?.DeclaringType + "!");
            FileLog.Log(e.Message);
            FileLog.Log(e.StackTrace);
            FileLog.Log(e.ToString());
        }

        return codes.AsEnumerable();
    }
}

[HarmonyPatch(typeof(ExosuitClawArm))]
[HarmonyPatch("OnPickup")]
public static class OnPrawnPickup
{
    private static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
    {
        var codes = new List<CodeInstruction>(instructions);
        try
        {
            var idx = InstructionHandlers.getInstruction(codes, 0, 0, OpCodes.Callvirt, "ItemsContainer", "UnsafeAdd",
                true, new[] {typeof(InventoryItem)});
            codes.InsertRange(idx + 1,
                new List<CodeInstruction>
                {
                    new(OpCodes.Ldloc_1),
                    InstructionHandlers.createMethodCall(nameof(DIHooks), "onPrawnItemPickedUp", false,
                        typeof(Pickupable))
                });
            FileLog.Log("Done patch " + MethodBase.GetCurrentMethod()?.DeclaringType);
        }
        catch (Exception e)
        {
            FileLog.Log("Caught exception when running patch " + MethodBase.GetCurrentMethod()?.DeclaringType + "!");
            FileLog.Log(e.Message);
            FileLog.Log(e.StackTrace);
            FileLog.Log(e.ToString());
        }

        return codes.AsEnumerable();
    }
}

[HarmonyPatch(typeof(Player))]
[HarmonyPatch("CanBreathe")]
public static class PlayerBreathabilityHook
{
    private static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
    {
        var codes = new List<CodeInstruction>(instructions);
        try
        {
            InstructionHandlers.patchEveryReturnPre(codes, injectCallback);
            //FileLog.Log("Codes are "+InstructionHandlers.toString(codes));
            FileLog.Log("Done patch " + MethodBase.GetCurrentMethod()?.DeclaringType);
        }
        catch (Exception e)
        {
            FileLog.Log("Caught exception when running patch " + MethodBase.GetCurrentMethod()?.DeclaringType + "!");
            FileLog.Log(e.Message);
            FileLog.Log(e.StackTrace);
            FileLog.Log(e.ToString());
        }

        return codes.AsEnumerable();
    }

    private static void injectCallback(List<CodeInstruction> codes, int idx)
    {
        codes.Insert(idx,
            InstructionHandlers.createMethodCall(nameof(DIHooks), "canPlayerBreathe", false,
                typeof(bool), typeof(Player)));
        codes.Insert(idx, new CodeInstruction(OpCodes.Ldarg_0));
    }
}

[HarmonyPatch(typeof(DamageSystem))]
[HarmonyPatch("CalculateDamage")]
public static class DamageCalcHook
{
    private static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
    {
        var codes = new List<CodeInstruction>(instructions);
        try
        {
            var idx = InstructionHandlers.getInstruction(codes, 0, 0, OpCodes.Ret);
            codes.Insert(idx,
                InstructionHandlers.createMethodCall(nameof(DIHooks), "recalculateDamage", false,
                    typeof(float), typeof(DamageType), typeof(GameObject), typeof(GameObject)));
            codes.Insert(idx, new CodeInstruction(OpCodes.Ldarg_3));
            codes.Insert(idx, new CodeInstruction(OpCodes.Ldarg_2));
            codes.Insert(idx, new CodeInstruction(OpCodes.Ldarg_1));
            //already present//codes.Insert(idx, new CodeInstruction(OpCodes.Ldarg_0));
            FileLog.Log("Done patch " + MethodBase.GetCurrentMethod()?.DeclaringType);
        }
        catch (Exception e)
        {
            FileLog.Log("Caught exception when running patch " + MethodBase.GetCurrentMethod()?.DeclaringType + "!");
            FileLog.Log(e.Message);
            FileLog.Log(e.StackTrace);
            FileLog.Log(e.ToString());
        }

        return codes.AsEnumerable();
    }
}

[HarmonyPatch(typeof(SkyApplier))]
[HarmonyPatch("Awake")]
public static class SkyApplierSpawnHook
{
    private static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
    {
        var codes = new List<CodeInstruction>(instructions);
        try
        {
            InstructionHandlers.patchInitialHook(codes, new CodeInstruction(OpCodes.Ldarg_0),
                InstructionHandlers.createMethodCall(nameof(DIHooks), "onSkyApplierSpawn", false,
                    typeof(SkyApplier)));
            FileLog.Log("Done patch " + MethodBase.GetCurrentMethod()?.DeclaringType);
        }
        catch (Exception e)
        {
            FileLog.Log("Caught exception when running patch " + MethodBase.GetCurrentMethod()?.DeclaringType + "!");
            FileLog.Log(e.Message);
            FileLog.Log(e.StackTrace);
            FileLog.Log(e.ToString());
        }

        return codes.AsEnumerable();
    }
}

[HarmonyPatch(typeof(VehicleDockingBay))]
[HarmonyPatch("Start")]
public static class VehicleDockingBaySpawnHook
{
    private static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
    {
        var codes = new List<CodeInstruction>(instructions);
        try
        {
            InstructionHandlers.patchInitialHook(codes, new CodeInstruction(OpCodes.Ldarg_0),
                InstructionHandlers.createMethodCall(nameof(DIHooks), "onDockingBaySpawn", false,
                    typeof(VehicleDockingBay)));
            FileLog.Log("Done patch " + MethodBase.GetCurrentMethod()?.DeclaringType);
        }
        catch (Exception e)
        {
            FileLog.Log("Caught exception when running patch " + MethodBase.GetCurrentMethod()?.DeclaringType + "!");
            FileLog.Log(e.Message);
            FileLog.Log(e.StackTrace);
            FileLog.Log(e.ToString());
        }

        return codes.AsEnumerable();
    }
}

[HarmonyPatch(typeof(GrowingPlant))]
[HarmonyPatch("SpawnGrownModel")]
public static class PlantFinishedGrowingHook
{
    private static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
    {
        var codes = new List<CodeInstruction>(instructions);
        try
        {
            InstructionHandlers.patchEveryReturnPre(codes, injectCallback);
            //FileLog.Log("Codes are "+InstructionHandlers.toString(codes));
            FileLog.Log("Done patch " + MethodBase.GetCurrentMethod()?.DeclaringType);
        }
        catch (Exception e)
        {
            FileLog.Log("Caught exception when running patch " + MethodBase.GetCurrentMethod()?.DeclaringType + "!");
            FileLog.Log(e.Message);
            FileLog.Log(e.StackTrace);
            FileLog.Log(e.ToString());
        }

        return codes.AsEnumerable();
    }

    private static void injectCallback(List<CodeInstruction> codes, int idx)
    {
        codes.Insert(idx,
            InstructionHandlers.createMethodCall(nameof(DIHooks), "onFarmedPlantGrowDone", false,
                typeof(GrowingPlant), typeof(GameObject)));
        codes.Insert(idx, new CodeInstruction(OpCodes.Ldloc_0));
        codes.Insert(idx, new CodeInstruction(OpCodes.Ldarg_0));
    }
}

[HarmonyPatch(typeof(Plantable))]
[HarmonyPatch("Spawn")]
public static class PlantSpawnsGrowingHook
{
    private static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
    {
        var codes = new List<CodeInstruction>(instructions);
        try
        {
            var idx = InstructionHandlers.getInstruction(codes, 0, 0, OpCodes.Stloc_0) + 1;
            codes.Insert(idx,
                InstructionHandlers.createMethodCall(nameof(DIHooks), "onFarmedPlantGrowingSpawn",
                    false, typeof(Plantable), typeof(GameObject)));
            codes.Insert(idx, new CodeInstruction(OpCodes.Ldloc_0));
            codes.Insert(idx, new CodeInstruction(OpCodes.Ldarg_0));
            //FileLog.Log("Codes are "+InstructionHandlers.toString(codes));
            FileLog.Log("Done patch " + MethodBase.GetCurrentMethod()?.DeclaringType);
        }
        catch (Exception e)
        {
            FileLog.Log("Caught exception when running patch " + MethodBase.GetCurrentMethod()?.DeclaringType + "!");
            FileLog.Log(e.Message);
            FileLog.Log(e.StackTrace);
            FileLog.Log(e.ToString());
        }

        return codes.AsEnumerable();
    }

    private static void injectCallback(List<CodeInstruction> codes, int idx)
    {
        codes.Insert(idx,
            InstructionHandlers.createMethodCall(nameof(DIHooks), "onFarmedPlantGrowDone", false,
                typeof(GrowingPlant), typeof(GameObject)));
        codes.Insert(idx, new CodeInstruction(OpCodes.Ldloc_0));
        codes.Insert(idx, new CodeInstruction(OpCodes.Ldarg_0));
    }
}

[HarmonyPatch(typeof(Survival))]
[HarmonyPatch("Use")]
public static class ItemUseReimplementation
{
    private static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
    {
        var codes = new List<CodeInstruction>();
        try
        {
            codes.Add(new CodeInstruction(OpCodes.Ldarg_0));
            codes.Add(new CodeInstruction(OpCodes.Ldarg_1));
            codes.Add(InstructionHandlers.createMethodCall(nameof(DIHooks), "useItem", false,
                typeof(Survival), typeof(GameObject)));
            codes.Add(new CodeInstruction(OpCodes.Ret));
            FileLog.Log("Done patch " + MethodBase.GetCurrentMethod()?.DeclaringType);
        }
        catch (Exception e)
        {
            FileLog.Log("Caught exception when running patch " + MethodBase.GetCurrentMethod()?.DeclaringType + "!");
            FileLog.Log(e.Message);
            FileLog.Log(e.StackTrace);
            FileLog.Log(e.ToString());
        }

        return codes.AsEnumerable();
    }
}

[HarmonyPatch(typeof(CraftData))]
[HarmonyPatch("IsInvUseable")]
public static class ItemUsabilityHook
{
    private static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
    {
        var codes = new List<CodeInstruction>();
        try
        {
            codes.Add(new CodeInstruction(OpCodes.Ldarg_0));
            codes.Add(InstructionHandlers.createMethodCall(nameof(DIHooks), "isItemUsable", false,
                typeof(TechType)));
            codes.Add(new CodeInstruction(OpCodes.Ret));
            FileLog.Log("Done patch " + MethodBase.GetCurrentMethod()?.DeclaringType);
        }
        catch (Exception e)
        {
            FileLog.Log("Caught exception when running patch " + MethodBase.GetCurrentMethod()?.DeclaringType + "!");
            FileLog.Log(e.Message);
            FileLog.Log(e.StackTrace);
            FileLog.Log(e.ToString());
        }

        return codes.AsEnumerable();
    }
}

[HarmonyPatch(typeof(Inventory))]
[HarmonyPatch("InternalDropItem")]
public static class ItemDroppabilityHook
{
    private static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
    {
        var codes = new List<CodeInstruction>(instructions);
        try
        {
            var idx = InstructionHandlers.getInstruction(codes, 0, 0, OpCodes.Call, "Inventory", "CanDropItemHere",
                false, new[] {typeof(Pickupable), typeof(bool)});
            codes[idx] = InstructionHandlers.createMethodCall(nameof(DIHooks), "isItemDroppable",
                false, typeof(Pickupable), typeof(bool));
            FileLog.Log("Done patch " + MethodBase.GetCurrentMethod()?.DeclaringType);
        }
        catch (Exception e)
        {
            FileLog.Log("Caught exception when running patch " + MethodBase.GetCurrentMethod()?.DeclaringType + "!");
            FileLog.Log(e.Message);
            FileLog.Log(e.StackTrace);
            FileLog.Log(e.ToString());
        }

        return codes.AsEnumerable();
    }
}

[HarmonyPatch(typeof(PDAScanner))]
[HarmonyPatch("Unlock")]
public static class ScanHook
{
    private static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
    {
        var codes = new List<CodeInstruction>(instructions);
        try
        {
            InstructionHandlers.patchInitialHook(codes, new CodeInstruction(OpCodes.Ldarg_0),
                InstructionHandlers.createMethodCall(nameof(DIHooks), "onScanComplete", false,
                    typeof(PDAScanner.EntryData)));
            FileLog.Log("Done patch " + MethodBase.GetCurrentMethod()?.DeclaringType);
        }
        catch (Exception e)
        {
            FileLog.Log("Caught exception when running patch " + MethodBase.GetCurrentMethod()?.DeclaringType + "!");
            FileLog.Log(e.Message);
            FileLog.Log(e.StackTrace);
            FileLog.Log(e.ToString());
        }

        return codes.AsEnumerable();
    }
}

[HarmonyPatch(typeof(Sealed))]
[HarmonyPatch("Weld")]
public static class SealedOverhaul
{
    private static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
    {
        var codes = new List<CodeInstruction>();
        try
        {
            codes.Add(new CodeInstruction(OpCodes.Ldarg_0));
            codes.Add(new CodeInstruction(OpCodes.Ldarg_1));
            codes.Add(InstructionHandlers.createMethodCall(nameof(DIHooks), "tickLaserCutting", false,
                typeof(Sealed), typeof(float)));
            codes.Add(new CodeInstruction(OpCodes.Ret));
            FileLog.Log("Done patch " + MethodBase.GetCurrentMethod()?.DeclaringType);
        }
        catch (Exception e)
        {
            FileLog.Log("Caught exception when running patch " + MethodBase.GetCurrentMethod()?.DeclaringType + "!");
            FileLog.Log(e.Message);
            FileLog.Log(e.StackTrace);
            FileLog.Log(e.ToString());
        }

        return codes.AsEnumerable();
    }
}

[HarmonyPatch(typeof(BulkheadDoor))]
[HarmonyPatch("OnHandHover")]
public static class BulkheadLaserCutterNotice
{
    private static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
    {
        var codes = new List<CodeInstruction>();
        try
        {
            /*
                int idx = InstructionHandlers.getInstruction(codes, 0, 0, OpCodes.Callvirt, "HandReticle", "SetInteractText", true, new Type[]{typeof(string)});
                codes.Insert(idx, new CodeInstruction(OpCodes.Ldarg_0));
                codes.Insert(idx, InstructionHandlers.createMethodCall(nameof(DIHooks), "getBulkheadMouseoverText", false, typeof(string), typeof(BulkheadDoor)));
                FileLog.Log("Codes are "+InstructionHandlers.toString(codes));*/
            codes.Add(new CodeInstruction(OpCodes.Ldarg_0));
            codes.Add(InstructionHandlers.createMethodCall(nameof(DIHooks), "getBulkheadMouseoverText",
                false, typeof(BulkheadDoor)));
            codes.Add(new CodeInstruction(OpCodes.Ret));
            FileLog.Log("Done patch " + MethodBase.GetCurrentMethod()?.DeclaringType);
        }
        catch (Exception e)
        {
            FileLog.Log("Caught exception when running patch " + MethodBase.GetCurrentMethod()?.DeclaringType + "!");
            FileLog.Log(e.Message);
            FileLog.Log(e.StackTrace);
            FileLog.Log(e.ToString());
        }

        return codes.AsEnumerable();
    }
}

[HarmonyPatch(typeof(BulkheadDoor))]
[HarmonyPatch("OnHandClick")]
public static class BulkheadDoorClickIntercept
{
    private static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
    {
        var codes = new List<CodeInstruction>();
        try
        {
            codes.Add(new CodeInstruction(OpCodes.Ldarg_0));
            codes.Add(InstructionHandlers.createMethodCall(nameof(DIHooks), "onBulkheadClick", false,
                typeof(BulkheadDoor)));
            codes.Add(new CodeInstruction(OpCodes.Ret));
            //FileLog.Log("Codes are "+InstructionHandlers.toString(codes));
            FileLog.Log("Done patch " + MethodBase.GetCurrentMethod()?.DeclaringType);
        }
        catch (Exception e)
        {
            FileLog.Log("Caught exception when running patch " + MethodBase.GetCurrentMethod()?.DeclaringType + "!");
            FileLog.Log(e.Message);
            FileLog.Log(e.StackTrace);
            FileLog.Log(e.ToString());
        }

        return codes.AsEnumerable();
    }
}

[HarmonyPatch(typeof(SeaMoth))]
[HarmonyPatch("OnHoverTorpedoStorage")]
public static class SeamothTorpedoHoverHooks
{
    private static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
    {
        var codes = new List<CodeInstruction>();
        try
        {
            codes.Add(new CodeInstruction(OpCodes.Ldarg_0));
            codes.Add(new CodeInstruction(OpCodes.Ldarg_1));
            codes.Add(InstructionHandlers.createMethodCall(nameof(DIHooks),
                "hoverSeamothTorpedoStorage", false, typeof(SeaMoth), typeof(HandTargetEventData)));
            codes.Add(new CodeInstruction(OpCodes.Ret));
            FileLog.Log("Done patch " + MethodBase.GetCurrentMethod()?.DeclaringType);
        }
        catch (Exception e)
        {
            FileLog.Log("Caught exception when running patch " + MethodBase.GetCurrentMethod()?.DeclaringType + "!");
            FileLog.Log(e.Message);
            FileLog.Log(e.StackTrace);
            FileLog.Log(e.ToString());
        }

        return codes.AsEnumerable();
    }
}

[HarmonyPatch(typeof(SeaMoth))]
[HarmonyPatch("OpenTorpedoStorage")]
public static class SeamothTorpedoClickHooks
{
    private static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
    {
        var codes = new List<CodeInstruction>();
        try
        {
            codes.Add(new CodeInstruction(OpCodes.Ldarg_0));
            codes.Add(new CodeInstruction(OpCodes.Ldarg_1));
            codes.Add(InstructionHandlers.createMethodCall(nameof(DIHooks),
                "openSeamothTorpedoStorage", false, typeof(SeaMoth), typeof(Transform)));
            codes.Add(new CodeInstruction(OpCodes.Ret));
            FileLog.Log("Done patch " + MethodBase.GetCurrentMethod()?.DeclaringType);
        }
        catch (Exception e)
        {
            FileLog.Log("Caught exception when running patch " + MethodBase.GetCurrentMethod()?.DeclaringType + "!");
            FileLog.Log(e.Message);
            FileLog.Log(e.StackTrace);
            FileLog.Log(e.ToString());
        }

        return codes.AsEnumerable();
    }
}

[HarmonyPatch(typeof(TemperatureDamage))]
[HarmonyPatch("GetTemperature")]
public static class TemperatureDamageGetOverride
{
    private static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
    {
        var codes = new List<CodeInstruction>();
        try
        {
            codes.Add(new CodeInstruction(OpCodes.Ldarg_0));
            codes.Add(InstructionHandlers.createMethodCall(nameof(DIHooks), "getTemperatureForDamage",
                false, typeof(TemperatureDamage)));
            codes.Add(new CodeInstruction(OpCodes.Ret));
            FileLog.Log("Done patch " + MethodBase.GetCurrentMethod()?.DeclaringType);
        }
        catch (Exception e)
        {
            FileLog.Log("Caught exception when running patch " + MethodBase.GetCurrentMethod()?.DeclaringType + "!");
            FileLog.Log(e.Message);
            FileLog.Log(e.StackTrace);
            FileLog.Log(e.ToString());
        }

        return codes.AsEnumerable();
    }
}

[HarmonyPatch(typeof(UseableDiveHatch))]
[HarmonyPatch("IsInside")]
public static class HatchInsideHook
{
    private static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
    {
        var codes = new List<CodeInstruction>();
        try
        {
            codes.Add(new CodeInstruction(OpCodes.Ldarg_0));
            codes.Add(InstructionHandlers.createMethodCall(nameof(DIHooks), "isInsideForHatch", false,
                typeof(UseableDiveHatch)));
            codes.Add(new CodeInstruction(OpCodes.Ret));
            FileLog.Log("Done patch " + MethodBase.GetCurrentMethod()?.DeclaringType);
        }
        catch (Exception e)
        {
            FileLog.Log("Caught exception when running patch " + MethodBase.GetCurrentMethod()?.DeclaringType + "!");
            FileLog.Log(e.Message);
            FileLog.Log(e.StackTrace);
            FileLog.Log(e.ToString());
        }

        return codes.AsEnumerable();
    }
}

[HarmonyPatch(typeof(LargeWorld), "GetBiome", typeof(Vector3))]
public static class BiomeFetchHook
{
    private static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
    {
        var codes = new List<CodeInstruction>(instructions);
        try
        {
            InstructionHandlers.patchEveryReturnPre(codes, injectHook);
            FileLog.Log("Done patch " + MethodBase.GetCurrentMethod()?.DeclaringType);
        }
        catch (Exception e)
        {
            FileLog.Log("Caught exception when running patch " + MethodBase.GetCurrentMethod()?.DeclaringType + "!");
            FileLog.Log(e.Message);
            FileLog.Log(e.StackTrace);
            FileLog.Log(e.ToString());
        }

        return codes.AsEnumerable();
    }

    private static void injectHook(List<CodeInstruction> codes, int idx)
    {
        codes.Insert(idx,
            InstructionHandlers.createMethodCall(nameof(DIHooks), "getBiomeAt", false, typeof(string),
                typeof(Vector3)));
        codes.Insert(idx, new CodeInstruction(OpCodes.Ldarg_1));
    }
}

[HarmonyPatch(typeof(Constructable))]
[HarmonyPatch("NotifyConstructedChanged")]
public static class ConstructionHook
{
    private static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
    {
        var codes = new List<CodeInstruction>(instructions);
        try
        {
            InstructionHandlers.patchInitialHook(codes, new CodeInstruction(OpCodes.Ldarg_0),
                new CodeInstruction(OpCodes.Ldarg_1),
                InstructionHandlers.createMethodCall(nameof(DIHooks), "onConstructionComplete", false,
                    typeof(Constructable), typeof(bool)));
            FileLog.Log("Done patch " + MethodBase.GetCurrentMethod()?.DeclaringType);
        }
        catch (Exception e)
        {
            FileLog.Log("Caught exception when running patch " + MethodBase.GetCurrentMethod()?.DeclaringType + "!");
            FileLog.Log(e.Message);
            FileLog.Log(e.StackTrace);
            FileLog.Log(e.ToString());
        }

        return codes.AsEnumerable();
    }
}

[HarmonyPatch(typeof(Knife))]
[HarmonyPatch("OnToolUseAnim")]
public static class KnifeHook
{
    private static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
    {
        var codes = new List<CodeInstruction>(instructions);
        try
        {
            var idx = InstructionHandlers.getInstruction(codes, 0, 0, OpCodes.Call, "Utils", "PlayFMODAsset", false,
                new[] {typeof(FMODAsset), typeof(Transform), typeof(float)});
            codes.Insert(idx + 1,
                InstructionHandlers.createMethodCall(nameof(DIHooks), "onKnifed", false,
                    typeof(GameObject)));
            codes.Insert(idx + 1, new CodeInstruction(OpCodes.Ldloc_1));
            FileLog.Log("Done patch " + MethodBase.GetCurrentMethod()?.DeclaringType);
        }
        catch (Exception e)
        {
            FileLog.Log("Caught exception when running patch " + MethodBase.GetCurrentMethod()?.DeclaringType + "!");
            FileLog.Log(e.Message);
            FileLog.Log(e.StackTrace);
            FileLog.Log(e.ToString());
        }

        return codes.AsEnumerable();
    }
}

[HarmonyPatch(typeof(Knife))]
[HarmonyPatch("IsValidTarget")]
public static class KnifeabilityHook
{
    private static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
    {
        var codes = new List<CodeInstruction>();
        try
        {
            codes.Add(new CodeInstruction(OpCodes.Ldarg_0));
            codes.Add(InstructionHandlers.createMethodCall(nameof(DIHooks), "isObjectKnifeable", false,
                typeof(LiveMixin)));
            codes.Add(new CodeInstruction(OpCodes.Ret));
            FileLog.Log("Done patch " + MethodBase.GetCurrentMethod()?.DeclaringType);
        }
        catch (Exception e)
        {
            FileLog.Log("Caught exception when running patch " + MethodBase.GetCurrentMethod()?.DeclaringType + "!");
            FileLog.Log(e.Message);
            FileLog.Log(e.StackTrace);
            FileLog.Log(e.ToString());
        }

        return codes.AsEnumerable();
    }
}
/*
[HarmonyPatch(typeof(uGUI_PopupNotification))]
[HarmonyPatch("Set")]
public static class DebugTechPopup {

    static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions) {
        List<CodeInstruction> codes = new List<CodeInstruction>(instructions);
        try {
            InstructionHandlers.patchInitialHook(codes, new CodeInstruction(OpCodes.Ldarg_0), InstructionHandlers.createMethodCall(nameof(DIHooks), "onPopup", false, typeof(uGUI_PopupNotification)));
            FileLog.Log("Done patch "+MethodBase.GetCurrentMethod()?.DeclaringType);
        }
        catch (Exception e) {
            FileLog.Log("Caught exception when running patch "+MethodBase.GetCurrentMethod()?.DeclaringType+"!");
            FileLog.Log(e.Message);
            FileLog.Log(e.StackTrace);
            FileLog.Log(e.ToString());
        }
        return codes.AsEnumerable();
    }
}
*/

[HarmonyPatch(typeof(WaterParkCreature))]
[HarmonyPatch("Born")]
public static class WaterParkFix
{
    private static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
    {
        var codes = new List<CodeInstruction>(instructions);
        try
        {
            var idx = InstructionHandlers.getInstruction(codes, 0, 0, OpCodes.Callvirt, "UnityEngine.GameObject",
                "SetActive", true, new[] {typeof(bool)});
            codes.Insert(idx + 1,
                InstructionHandlers.createMethodCall(nameof(DIHooks), "onEggHatched", false,
                    typeof(GameObject)));
            codes.Insert(idx + 1, new CodeInstruction(OpCodes.Ldloc_0));
            FileLog.Log("Done patch " + MethodBase.GetCurrentMethod()?.DeclaringType);
        }
        catch (Exception e)
        {
            FileLog.Log("Caught exception when running patch " + MethodBase.GetCurrentMethod()?.DeclaringType + "!");
            FileLog.Log(e.Message);
            FileLog.Log(e.StackTrace);
            FileLog.Log(e.ToString());
        }

        return codes.AsEnumerable();
    }
}

[HarmonyPatch(typeof(TooltipFactory))]
[HarmonyPatch("ItemCommons")]
public static class CustomTooltipHooks
{
    private static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
    {
        var codes = new List<CodeInstruction>(instructions);
        try
        {
            InstructionHandlers.patchEveryReturnPre(codes, new CodeInstruction(OpCodes.Ldarg_0),
                new CodeInstruction(OpCodes.Ldarg_1), new CodeInstruction(OpCodes.Ldarg_2),
                InstructionHandlers.createMethodCall(nameof(DIHooks), "appendItemTooltip", false,
                    typeof(StringBuilder), typeof(TechType), typeof(GameObject)));
            var idx = codes.Count - 1;
            codes[idx].MoveLabelsTo(codes[idx - 4]);
            //FileLog.Log("Codes are "+InstructionHandlers.toString(codes));
            FileLog.Log("Done patch " + MethodBase.GetCurrentMethod()?.DeclaringType);
        }
        catch (Exception e)
        {
            FileLog.Log("Caught exception when running patch " + MethodBase.GetCurrentMethod()?.DeclaringType + "!");
            FileLog.Log(e.Message);
            FileLog.Log(e.StackTrace);
            FileLog.Log(e.ToString());
        }

        return codes.AsEnumerable();
    }
}

[HarmonyPatch(typeof(EMPBlast))]
[HarmonyPatch("OnTouch")]
public static class EMPBlastHooks
{
    private static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
    {
        var codes = new List<CodeInstruction>(instructions);
        try
        {
            for (var i = codes.Count - 1; i >= 0; i--)
                if (codes[i].opcode == OpCodes.Callvirt)
                {
                    var mi = (MethodInfo) codes[i].operand;
                    if (mi.Name == "DisableElectronicsForTime") PatchLib.injectEMPHook(codes, i);
                }

            InstructionHandlers.patchInitialHook(codes, new CodeInstruction(OpCodes.Ldarg_0),
                new CodeInstruction(OpCodes.Ldarg_1),
                InstructionHandlers.createMethodCall(nameof(DIHooks), "onEMPTouch", false,
                    typeof(EMPBlast), typeof(Collider)));
            FileLog.Log("Done patch " + MethodBase.GetCurrentMethod()?.DeclaringType);
        }
        catch (Exception e)
        {
            FileLog.Log("Caught exception when running patch " + MethodBase.GetCurrentMethod()?.DeclaringType + "!");
            FileLog.Log(e.Message);
            FileLog.Log(e.StackTrace);
            FileLog.Log(e.ToString());
        }

        return codes.AsEnumerable();
    }
}

/*
[HarmonyPatch(typeof(Builder))]
[HarmonyPatch("CheckAsSubModule")]
public static class ConstructableBuildabilityHook {

    static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions) {
        List<CodeInstruction> codes = new List<CodeInstruction>(instructions);
        try {
            int idx = InstructionHandlers.getInstruction(codes, 0, 0, OpCodes.Call, "Builder", "CheckTag", false, new Type[]{typeof(Collider)});
            codes[idx].operand = InstructionHandlers.convertMethodOperand(nameof(DIHooks), "interceptConstructability", false, typeof(Collider));
            FileLog.Log("Done patch "+MethodBase.GetCurrentMethod()?.DeclaringType);
        }
        catch (Exception e) {
            FileLog.Log("Caught exception when running patch "+MethodBase.GetCurrentMethod()?.DeclaringType+"!");
            FileLog.Log(e.Message);
            FileLog.Log(e.StackTrace);
            FileLog.Log(e.ToString());
        }
        return codes.AsEnumerable();
    }
}*/
[HarmonyPatch(typeof(Builder))]
[HarmonyPatch("Update")]
public static class ConstructableBuildabilityHook
{
    private static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
    {
        var codes = new List<CodeInstruction>(instructions);
        try
        {
            var idx = InstructionHandlers.getInstruction(codes, 0, 0, OpCodes.Call, "Builder", "UpdateAllowed", false,
                new Type[0]);
            codes[idx].operand = InstructionHandlers.convertMethodOperand(nameof(DIHooks),
                "interceptConstructability", false, new Type[0]);
            FileLog.Log("Done patch " + MethodBase.GetCurrentMethod()?.DeclaringType);
        }
        catch (Exception e)
        {
            FileLog.Log("Caught exception when running patch " + MethodBase.GetCurrentMethod()?.DeclaringType + "!");
            FileLog.Log(e.Message);
            FileLog.Log(e.StackTrace);
            FileLog.Log(e.ToString());
        }

        return codes.AsEnumerable();
    }
}

/*
[HarmonyPatch(typeof(WaterscapeVolume))]
[HarmonyPatch("PreRender")]
public static class WaterFogShaderHook {

    static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions) {
        List<CodeInstruction> codes = new List<CodeInstruction>();
        try {
            //int idx = InstructionHandlers.getInstruction(codes, 0, 0, OpCodes.Callvirt, "uSkyManager", "GetLightColor", true, new Type[0]);
            //codes.InsertRange(idx+1, new List<CodeInstruction>{new CodeInstruction(OpCodes.Ldarg_0), new CodeInstruction(OpCodes.Ldarg_1), InstructionHandlers.createMethodCall(nameof(DIHooks), "interceptChosenColor", false, typeof(Color), typeof(WaterscapeVolume), typeof(Camera))});
            codes.Add(new CodeInstruction(OpCodes.Ldarg_0));
            codes.Add(new CodeInstruction(OpCodes.Ldarg_1));
            codes.Add(InstructionHandlers.createMethodCall(nameof(DIHooks), "interceptChosenFog", false, typeof(WaterscapeVolume), typeof(Camera)));
            codes.Add(new CodeInstruction(OpCodes.Ret));
            FileLog.Log("Done patch "+MethodBase.GetCurrentMethod()?.DeclaringType);
        }
        catch (Exception e) {
            FileLog.Log("Caught exception when running patch "+MethodBase.GetCurrentMethod()?.DeclaringType+"!");
            FileLog.Log(e.Message);
            FileLog.Log(e.StackTrace);
            FileLog.Log(e.ToString());
        }
        return codes.AsEnumerable();
    }
}*/
/*
[HarmonyPatch(typeof(WaterBiomeManager))]
[HarmonyPatch("RasterizeAtmosphereVolumes")]
public static class WaterFogShaderHook {

    static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions) {
        List<CodeInstruction> codes = new List<CodeInstruction>(instructions);
        try {/*
            int idx = InstructionHandlers.getInstruction(codes, 0, 0, OpCodes.Call, "WaterBiomeManager", "GetEmissiveTextureValue", true, new Type[]{typeof(WaterscapeVolume.Settings)});
            CodeInstruction settings = codes[idx-1];
            List<CodeInstruction> add = new List<CodeInstruction>{
                new CodeInstruction(OpCodes.Ldarg_0), new CodeInstruction(OpCodes.Ldarg_1), new CodeInstruction(OpCodes.Ldarg_2), new CodeInstruction(settings.opcode, settings.operand),
                InstructionHandlers.createMethodCall(nameof(DIHooks), "overrideFog", false, typeof(WaterBiomeManager), typeof(Vector3), typeof(bool), typeof(WaterscapeVolume.Settings))
            };
            codes.InsertRange(idx+2, add);*/ /*
            List<CodeInstruction> add = new List<CodeInstruction>{
                new CodeInstruction(OpCodes.Ldarg_0), new CodeInstruction(OpCodes.Ldarg_1), new CodeInstruction(OpCodes.Ldarg_2),
                InstructionHandlers.createMethodCall(nameof(DIHooks), "onFogRasterized", false, typeof(WaterBiomeManager), typeof(Vector3), typeof(bool))
            };
            InstructionHandlers.patchInitialHook(add);
            FileLog.Log("Done patch "+MethodBase.GetCurrentMethod()?.DeclaringType);
        }
        catch (Exception e) {
            FileLog.Log("Caught exception when running patch "+MethodBase.GetCurrentMethod()?.DeclaringType+"!");
            FileLog.Log(e.Message);
            FileLog.Log(e.StackTrace);
            FileLog.Log(e.ToString());
        }
        return codes.AsEnumerable();
    }
}
*/
[HarmonyPatch(typeof(WaterBiomeManager))]
[HarmonyPatch("GetExtinctionTextureValue")]
public static class ExtinctionTextureHook
{
    private static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
    {
        var codes = new List<CodeInstruction>(instructions);
        try
        {
            InstructionHandlers.patchEveryReturnPre(codes, new CodeInstruction(OpCodes.Ldarg_1),
                InstructionHandlers.createMethodCall(nameof(DIHooks), "interceptExtinction", false,
                    typeof(Vector4), typeof(WaterscapeVolume.Settings)));
            FileLog.Log("Done patch " + MethodBase.GetCurrentMethod()?.DeclaringType);
        }
        catch (Exception e)
        {
            FileLog.Log("Caught exception when running patch " + MethodBase.GetCurrentMethod()?.DeclaringType + "!");
            FileLog.Log(e.Message);
            FileLog.Log(e.StackTrace);
            FileLog.Log(e.ToString());
        }

        return codes.AsEnumerable();
    }
}

[HarmonyPatch(typeof(WaterBiomeManager))]
[HarmonyPatch("GetScatteringTextureValue")]
public static class ScatterTextureHook
{
    private static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
    {
        var codes = new List<CodeInstruction>(instructions);
        try
        {
            InstructionHandlers.patchEveryReturnPre(codes, new CodeInstruction(OpCodes.Ldarg_1),
                InstructionHandlers.createMethodCall(nameof(DIHooks), "interceptScattering", false,
                    typeof(Vector4), typeof(WaterscapeVolume.Settings)));
            FileLog.Log("Done patch " + MethodBase.GetCurrentMethod()?.DeclaringType);
        }
        catch (Exception e)
        {
            FileLog.Log("Caught exception when running patch " + MethodBase.GetCurrentMethod()?.DeclaringType + "!");
            FileLog.Log(e.Message);
            FileLog.Log(e.StackTrace);
            FileLog.Log(e.ToString());
        }

        return codes.AsEnumerable();
    }
}

[HarmonyPatch(typeof(WaterBiomeManager))]
[HarmonyPatch("GetEmissiveTextureValue")]
public static class EmissiveTextureHook
{
    private static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
    {
        var codes = new List<CodeInstruction>(instructions);
        try
        {
            InstructionHandlers.patchEveryReturnPre(codes, new CodeInstruction(OpCodes.Ldarg_1),
                InstructionHandlers.createMethodCall(nameof(DIHooks), "interceptEmissive", false,
                    typeof(Vector4), typeof(WaterscapeVolume.Settings)));
            FileLog.Log("Done patch " + MethodBase.GetCurrentMethod()?.DeclaringType);
        }
        catch (Exception e)
        {
            FileLog.Log("Caught exception when running patch " + MethodBase.GetCurrentMethod()?.DeclaringType + "!");
            FileLog.Log(e.Message);
            FileLog.Log(e.StackTrace);
            FileLog.Log(e.ToString());
        }

        return codes.AsEnumerable();
    }
}

/*
[HarmonyPatch(typeof(PowerRelay))]
[HarmonyPatch("GetMaxPower")]
public static class SeabasePowerCapacityHook {

    static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions) {
        List<CodeInstruction> codes = new List<CodeInstruction>(instructions);
        try {
            int idx = InstructionHandlers.getInstruction(codes, 0, 0, OpCodes.Ret);
            codes.Insert(idx, InstructionHandlers.createMethodCall(nameof(DIHooks), "getPowerRelayCapacity", false, typeof(float), typeof(PowerRelay)));
            codes.Insert(idx, new CodeInstruction(OpCodes.Ldarg_0));
            FileLog.Log("Done patch "+MethodBase.GetCurrentMethod()?.DeclaringType);
            //FileLog.Log("Codes are "+InstructionHandlers.toString(codes));
        }
        catch (Exception e) {
            FileLog.Log("Caught exception when running patch "+MethodBase.GetCurrentMethod()?.DeclaringType+"!");
            FileLog.Log(e.Message);
            FileLog.Log(e.StackTrace);
            FileLog.Log(e.ToString());
        }
        return codes.AsEnumerable();
    }
}
*/
[HarmonyPatch(typeof(SolarPanel))]
[HarmonyPatch("Update")]
public static class SolarPanelPowerRedirect
{
    private static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
    {
        var codes = new List<CodeInstruction>();
        try
        {
            /* BZ code
                int idx = InstructionHandlers.getInstruction(codes, 0, 0, OpCodes.Callvirt, "PowerRelay", "ModifyPower", true, new Type[]{typeof(float), typeof(float).MakeByRefType()});
                codes[idx].operand = InstructionHandlers.convertMethodOperand(nameof(DIHooks), "addPowerToSeabaseDelegate", false, typeof(IPowerInterface), typeof(float), typeof(float).MakeByRefType(), typeof(MonoBehaviour));
                codes.Insert(idx, new CodeInstruction(OpCodes.Ldarg_0));
                */
            /*
            int idx = InstructionHandlers.getInstruction(codes, 0, 0, OpCodes.Stfld, "PowerSource", "power");
            codes[idx] = InstructionHandlers.createMethodCall(nameof(DIHooks), "addPowerToSeabaseDelegateViaPowerSourceSet", false, typeof(PowerSource), typeof(float), typeof(MonoBehaviour));
            codes.Insert(idx, new CodeInstruction(OpCodes.Ldarg_0));
            */
            codes.Add(new CodeInstruction(OpCodes.Ldarg_0));
            codes.Add(InstructionHandlers.createMethodCall(nameof(DIHooks), "updateSolarPanel", false,
                typeof(SolarPanel)));
            codes.Add(new CodeInstruction(OpCodes.Ret));
            FileLog.Log("Done patch " + MethodBase.GetCurrentMethod()?.DeclaringType);
            //FileLog.Log("Codes are "+InstructionHandlers.toString(codes));
        }
        catch (Exception e)
        {
            FileLog.Log("Caught exception when running patch " + MethodBase.GetCurrentMethod()?.DeclaringType + "!");
            FileLog.Log(e.Message);
            FileLog.Log(e.StackTrace);
            FileLog.Log(e.ToString());
        }

        return codes.AsEnumerable();
    }
}

[HarmonyPatch(typeof(ThermalPlant))]
[HarmonyPatch("AddPower")]
public static class ThermalPlantPowerRedirect
{
    private static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
    {
        var codes = new List<CodeInstruction>(instructions);
        try
        {
            PatchLib.redirectPowerHook(codes);
            FileLog.Log("Done patch " + MethodBase.GetCurrentMethod()?.DeclaringType);
            //FileLog.Log("Codes are "+InstructionHandlers.toString(codes));
        }
        catch (Exception e)
        {
            FileLog.Log("Caught exception when running patch " + MethodBase.GetCurrentMethod()?.DeclaringType + "!");
            FileLog.Log(e.Message);
            FileLog.Log(e.StackTrace);
            FileLog.Log(e.ToString());
        }

        return codes.AsEnumerable();
    }
}

[HarmonyPatch(typeof(BaseBioReactor))]
[HarmonyPatch("Update")]
public static class BioreactorPowerRedirect
{
    private static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
    {
        var codes = new List<CodeInstruction>(instructions);
        try
        {
            PatchLib.redirectPowerHook(codes);
            FileLog.Log("Done patch " + MethodBase.GetCurrentMethod()?.DeclaringType);
            //FileLog.Log("Codes are "+InstructionHandlers.toString(codes));
        }
        catch (Exception e)
        {
            FileLog.Log("Caught exception when running patch " + MethodBase.GetCurrentMethod()?.DeclaringType + "!");
            FileLog.Log(e.Message);
            FileLog.Log(e.StackTrace);
            FileLog.Log(e.ToString());
        }

        return codes.AsEnumerable();
    }
}

[HarmonyPatch(typeof(BaseNuclearReactor))]
[HarmonyPatch("Update")]
public static class NucReactorPowerRedirect
{
    private static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
    {
        var codes = new List<CodeInstruction>(instructions);
        try
        {
            PatchLib.redirectPowerHook(codes);
            FileLog.Log("Done patch " + MethodBase.GetCurrentMethod()?.DeclaringType);
            //FileLog.Log("Codes are "+InstructionHandlers.toString(codes));
        }
        catch (Exception e)
        {
            FileLog.Log("Caught exception when running patch " + MethodBase.GetCurrentMethod()?.DeclaringType + "!");
            FileLog.Log(e.Message);
            FileLog.Log(e.StackTrace);
            FileLog.Log(e.ToString());
        }

        return codes.AsEnumerable();
    }
}

[HarmonyPatch(typeof(StoryHandTarget))]
[HarmonyPatch("OnHandClick")]
public static class StoryHandIntercept
{
    private static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
    {
        var codes = new List<CodeInstruction>();
        try
        {
            codes.Add(new CodeInstruction(OpCodes.Ldarg_0));
            codes.Add(InstructionHandlers.createMethodCall(nameof(DIHooks), "clickStoryHandTarget",
                false, typeof(StoryHandTarget)));
            codes.Add(new CodeInstruction(OpCodes.Ret));
            FileLog.Log("Done patch " + MethodBase.GetCurrentMethod()?.DeclaringType);
            //FileLog.Log("Codes are "+InstructionHandlers.toString(codes));
        }
        catch (Exception e)
        {
            FileLog.Log("Caught exception when running patch " + MethodBase.GetCurrentMethod()?.DeclaringType + "!");
            FileLog.Log(e.Message);
            FileLog.Log(e.StackTrace);
            FileLog.Log(e.ToString());
        }

        return codes.AsEnumerable();
    }
}

[HarmonyPatch(typeof(Player))]
[HarmonyPatch("SetRadiationAmount")]
public static class RadiationAmountIntercept
{
    private static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
    {
        var codes = new List<CodeInstruction>(instructions);
        try
        {
            var idx = InstructionHandlers.getFirstOpcode(codes, 0, OpCodes.Stfld);
            codes.Insert(idx,
                InstructionHandlers.createMethodCall(nameof(DIHooks), "getRadiationLevel", false,
                    typeof(Player), typeof(float)));
            codes.Insert(0, new CodeInstruction(OpCodes.Ldarg_0));
            FileLog.Log("Done patch " + MethodBase.GetCurrentMethod()?.DeclaringType);
            //FileLog.Log("Codes are "+InstructionHandlers.toString(codes));
        }
        catch (Exception e)
        {
            FileLog.Log("Caught exception when running patch " + MethodBase.GetCurrentMethod()?.DeclaringType + "!");
            FileLog.Log(e.Message);
            FileLog.Log(e.StackTrace);
            FileLog.Log(e.ToString());
        }

        return codes.AsEnumerable();
    }
}

[HarmonyPatch(typeof(Knife))]
[HarmonyPatch("OnToolUseAnim")]
public static class KnifeHarvestingHook
{
    private static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
    {
        var codes = new List<CodeInstruction>(instructions);
        try
        {
            var idx = InstructionHandlers.getInstruction(codes, 0, 0, OpCodes.Call, "Knife", "GiveResourceOnDamage",
                false, new[] {typeof(GameObject), typeof(bool), typeof(bool)});
            codes[idx].operand = InstructionHandlers.convertMethodOperand(nameof(DIHooks),
                "doKnifeHarvest", false, typeof(Knife), typeof(GameObject), typeof(bool), typeof(bool));
            FileLog.Log("Done patch " + MethodBase.GetCurrentMethod()?.DeclaringType);
        }
        catch (Exception e)
        {
            FileLog.Log("Caught exception when running patch " + MethodBase.GetCurrentMethod()?.DeclaringType + "!");
            FileLog.Log(e.Message);
            FileLog.Log(e.StackTrace);
            FileLog.Log(e.ToString());
        }

        return codes.AsEnumerable();
    }
}
/*
[HarmonyPatch(typeof(uGUI_ItemsContainer))]
[HarmonyPatch("OnAddItem")]
public static class ItemVisualSizeHook {

    static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions) {
        List<CodeInstruction> codes = new List<CodeInstruction>(instructions);
        try {
            PatchLib.patchVisualItemSize(codes);
            FileLog.Log("Done patch "+MethodBase.GetCurrentMethod()?.DeclaringType);
        }
        catch (Exception e) {
            FileLog.Log("Caught exception when running patch "+MethodBase.GetCurrentMethod()?.DeclaringType+"!");
            FileLog.Log(e.Message);
            FileLog.Log(e.StackTrace);
            FileLog.Log(e.ToString());
        }
        return codes.AsEnumerable();
    }
}

[HarmonyPatch(typeof(uGUI_ItemsContainerView))]
[HarmonyPatch("OnAddItem")]
public static class ItemVisualSizeHookView {

    static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions) {
        List<CodeInstruction> codes = new List<CodeInstruction>(instructions);
        try {
            PatchLib.patchVisualItemSize(codes);
            FileLog.Log("Done patch "+MethodBase.GetCurrentMethod()?.DeclaringType);
        }
        catch (Exception e) {
            FileLog.Log("Caught exception when running patch "+MethodBase.GetCurrentMethod()?.DeclaringType+"!");
            FileLog.Log(e.Message);
            FileLog.Log(e.StackTrace);
            FileLog.Log(e.ToString());
        }
        return codes.AsEnumerable();
    }
}

[HarmonyPatch(typeof(ItemsContainer))]
[HarmonyPatch("UnsafeAdd")]
public static class ItemFunctionalSizeHook {

    static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions) {
        List<CodeInstruction> codes = new List<CodeInstruction>(instructions);
        try {
            PatchLib.patchVisualItemSize(codes, true);
            FileLog.Log("Done patch "+MethodBase.GetCurrentMethod()?.DeclaringType);
        }
        catch (Exception e) {
            FileLog.Log("Caught exception when running patch "+MethodBase.GetCurrentMethod()?.DeclaringType+"!");
            FileLog.Log(e.Message);
            FileLog.Log(e.StackTrace);
            FileLog.Log(e.ToString());
        }
        return codes.AsEnumerable();
    }
}

[HarmonyPatch(typeof(InventoryItem))]
[HarmonyPatch("get_height")]
public static class InvItemHeightHook {

    static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions) {
        List<CodeInstruction> codes = new List<CodeInstruction>(instructions);
        try {
            PatchLib.patchVisualItemSize(codes, true, false, new Type[]{typeof(TechType), typeof(InventoryItem)});
            FileLog.Log("Done patch "+MethodBase.GetCurrentMethod()?.DeclaringType);
        }
        catch (Exception e) {
            FileLog.Log("Caught exception when running patch "+MethodBase.GetCurrentMethod()?.DeclaringType+"!");
            FileLog.Log(e.Message);
            FileLog.Log(e.StackTrace);
            FileLog.Log(e.ToString());
        }
        return codes.AsEnumerable();
    }
}

[HarmonyPatch(typeof(InventoryItem))]
[HarmonyPatch("get_width")]
public static class InvItemWidthHook {

    static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions) {
        List<CodeInstruction> codes = new List<CodeInstruction>(instructions);
        try {
            PatchLib.patchVisualItemSize(codes, true, false, new Type[]{typeof(TechType), typeof(InventoryItem)});
            FileLog.Log("Done patch "+MethodBase.GetCurrentMethod()?.DeclaringType);
        }
        catch (Exception e) {
            FileLog.Log("Caught exception when running patch "+MethodBase.GetCurrentMethod()?.DeclaringType+"!");
            FileLog.Log(e.Message);
            FileLog.Log(e.StackTrace);
            FileLog.Log(e.ToString());
        }
        return codes.AsEnumerable();
    }
}*/

[HarmonyPatch(typeof(ReaperLeviathan))]
[HarmonyPatch("GrabVehicle")]
public static class ReaperGrabHook
{
    private static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
    {
        var codes = new List<CodeInstruction>(instructions);
        try
        {
            InstructionHandlers.patchInitialHook(codes, new CodeInstruction(OpCodes.Ldarg_0),
                new CodeInstruction(OpCodes.Ldarg_1),
                InstructionHandlers.createMethodCall(nameof(DIHooks), "onReaperGrabVehicle", false,
                    typeof(ReaperLeviathan), typeof(Vehicle)));
            FileLog.Log("Done patch " + MethodBase.GetCurrentMethod()?.DeclaringType);
        }
        catch (Exception e)
        {
            FileLog.Log("Caught exception when running patch " + MethodBase.GetCurrentMethod()?.DeclaringType + "!");
            FileLog.Log(e.Message);
            FileLog.Log(e.StackTrace);
            FileLog.Log(e.ToString());
        }

        return codes.AsEnumerable();
    }
}

[HarmonyPatch(typeof(VehicleDockingBay))]
[HarmonyPatch("OnTriggerEnter")]
public static class MoonpoolGrabDetection
{
    private static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
    {
        var codes = new List<CodeInstruction>();
        try
        {
            codes.Add(new CodeInstruction(OpCodes.Ldarg_0));
            codes.Add(new CodeInstruction(OpCodes.Ldarg_1));
            codes.Add(InstructionHandlers.createMethodCall(nameof(DIHooks), "onDockingTriggerCollided",
                false, typeof(VehicleDockingBay), typeof(Collider)));
            codes.Add(new CodeInstruction(OpCodes.Ret));
            FileLog.Log("Done patch " + MethodBase.GetCurrentMethod()?.DeclaringType);
        }
        catch (Exception e)
        {
            FileLog.Log("Caught exception when running patch " + MethodBase.GetCurrentMethod()?.DeclaringType + "!");
            FileLog.Log(e.Message);
            FileLog.Log(e.StackTrace);
            FileLog.Log(e.ToString());
        }

        return codes.AsEnumerable();
    }
}

[HarmonyPatch(typeof(AcidicBrineDamageTrigger))]
[HarmonyPatch("OnTriggerEnter")]
public static class BrineTouchDetection
{
    private static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
    {
        var codes = new List<CodeInstruction>();
        try
        {
            codes.Add(new CodeInstruction(OpCodes.Ldarg_0));
            codes.Add(new CodeInstruction(OpCodes.Ldarg_1));
            codes.Add(InstructionHandlers.createMethodCall(nameof(DIHooks), "onAcidTriggerCollided",
                false, typeof(AcidicBrineDamageTrigger), typeof(Collider)));
            codes.Add(new CodeInstruction(OpCodes.Ret));
            FileLog.Log("Done patch " + MethodBase.GetCurrentMethod()?.DeclaringType);
        }
        catch (Exception e)
        {
            FileLog.Log("Caught exception when running patch " + MethodBase.GetCurrentMethod()?.DeclaringType + "!");
            FileLog.Log(e.Message);
            FileLog.Log(e.StackTrace);
            FileLog.Log(e.ToString());
        }

        return codes.AsEnumerable();
    }
}

[HarmonyPatch(typeof(PrecursorDoorMotorModeSetter))]
[HarmonyPatch("OnTriggerEnter")]
public static class AirlockTouchDetection
{
    private static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
    {
        var codes = new List<CodeInstruction>();
        try
        {
            codes.Add(new CodeInstruction(OpCodes.Ldarg_0));
            codes.Add(new CodeInstruction(OpCodes.Ldarg_1));
            codes.Add(InstructionHandlers.createMethodCall(nameof(DIHooks), "onAirlockTouched", false,
                typeof(PrecursorDoorMotorModeSetter), typeof(Collider)));
            codes.Add(new CodeInstruction(OpCodes.Ret));
            FileLog.Log("Done patch " + MethodBase.GetCurrentMethod()?.DeclaringType);
        }
        catch (Exception e)
        {
            FileLog.Log("Caught exception when running patch " + MethodBase.GetCurrentMethod()?.DeclaringType + "!");
            FileLog.Log(e.Message);
            FileLog.Log(e.StackTrace);
            FileLog.Log(e.ToString());
        }

        return codes.AsEnumerable();
    }
}

[HarmonyPatch(typeof(FMOD_CustomEmitter))]
[HarmonyPatch("OnPlay")]
public static class SoundHook
{
    private static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
    {
        var codes = new List<CodeInstruction>(instructions);
        try
        {
            //FileLog.Log("Codes are "+InstructionHandlers.toString(codes));
            //int idx = InstructionHandlers.getInstruction(codes, 0, 0, OpCodes.Callvirt, "FMOD_CustomEmitter", "OnPlay", true, new Type[0]);
            var ci = InstructionHandlers.createMethodCall(nameof(DIHooks), "onFModEmitterPlay", false,
                typeof(FMOD_CustomEmitter));
            InstructionHandlers.patchInitialHook(codes, new CodeInstruction(OpCodes.Ldarg_0), ci);
            FileLog.Log("Done patch " + MethodBase.GetCurrentMethod()?.DeclaringType);
        }
        catch (Exception e)
        {
            FileLog.Log("Caught exception when running patch " + MethodBase.GetCurrentMethod()?.DeclaringType + "!");
            FileLog.Log(e.Message);
            FileLog.Log(e.StackTrace);
            FileLog.Log(e.ToString());
        }

        return codes.AsEnumerable();
    }
}

[HarmonyPatch(typeof(PropulsionCannon))]
[HarmonyPatch("ValidateObject")]
public static class PropulsabilityHookMass
{
    private static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
    {
        var codes = new List<CodeInstruction>(instructions);
        try
        {
            PatchLib.patchPropulsability(codes,
                InstructionHandlers.getInstruction(codes, 0, 0, OpCodes.Ldfld, "PropulsionCannon", "maxMass", true),
                true);
            FileLog.Log("Done patch " + MethodBase.GetCurrentMethod()?.DeclaringType);
        }
        catch (Exception e)
        {
            FileLog.Log("Caught exception when running patch " + MethodBase.GetCurrentMethod()?.DeclaringType + "!");
            FileLog.Log(e.Message);
            FileLog.Log(e.StackTrace);
            FileLog.Log(e.ToString());
        }

        return codes.AsEnumerable();
    }
}

[HarmonyPatch(typeof(PropulsionCannon))]
[HarmonyPatch("ValidateNewObject")]
public static class PropulsabilityHook
{
    private static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
    {
        var codes = new List<CodeInstruction>(instructions);
        try
        {
            PatchLib.patchPropulsability(codes,
                InstructionHandlers.getInstruction(codes, 0, 0, OpCodes.Ldfld, "PropulsionCannon", "maxAABBVolume",
                    true), false);
            FileLog.Log("Done patch " + MethodBase.GetCurrentMethod()?.DeclaringType);
        }
        catch (Exception e)
        {
            FileLog.Log("Caught exception when running patch " + MethodBase.GetCurrentMethod()?.DeclaringType + "!");
            FileLog.Log(e.Message);
            FileLog.Log(e.StackTrace);
            FileLog.Log(e.ToString());
        }

        return codes.AsEnumerable();
    }
}

[HarmonyPatch(typeof(PropulsionCannon))]
[HarmonyPatch("TraceForGrabTarget")]
public static class PropulsionGrabPositionFix
{
    private static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
    {
        var codes = new List<CodeInstruction>(instructions);
        try
        {
            var idx = InstructionHandlers.getInstruction(codes, 0, 0, OpCodes.Call, "UWE.Utils",
                "SpherecastIntoSharedBuffer", false,
                new[]
                {
                    typeof(Vector3), typeof(float), typeof(Vector3), typeof(float), typeof(int),
                    typeof(QueryTriggerInteraction)
                });
            codes[idx - 1] = new CodeInstruction(OpCodes.Ldc_I4_1);
            FileLog.Log("Done patch " + MethodBase.GetCurrentMethod()?.DeclaringType);
        }
        catch (Exception e)
        {
            FileLog.Log("Caught exception when running patch " + MethodBase.GetCurrentMethod()?.DeclaringType + "!");
            FileLog.Log(e.Message);
            FileLog.Log(e.StackTrace);
            FileLog.Log(e.ToString());
        }

        return codes.AsEnumerable();
    }
}

[HarmonyPatch(typeof(PropulsionCannon))]
[HarmonyPatch("GetObjectPosition")]
public static class PropulsionGrabPositionFix2
{
    private static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
    {
        var codes = new List<CodeInstruction>(instructions);
        try
        {
            var idx = InstructionHandlers.getInstruction(codes, 0, 0, OpCodes.Stfld, "PropulsionCannon",
                "grabbedObjectCenter");
            codes.Insert(idx,
                InstructionHandlers.createMethodCall(nameof(DIHooks), "getPropulsionTargetCenter",
                    false, typeof(Vector3), typeof(GameObject)));
            codes.Insert(idx, new CodeInstruction(OpCodes.Ldarg_1));
            FileLog.Log("Done patch " + MethodBase.GetCurrentMethod()?.DeclaringType);
        }
        catch (Exception e)
        {
            FileLog.Log("Caught exception when running patch " + MethodBase.GetCurrentMethod()?.DeclaringType + "!");
            FileLog.Log(e.Message);
            FileLog.Log(e.StackTrace);
            FileLog.Log(e.ToString());
        }

        return codes.AsEnumerable();
    }
}

/*
[HarmonyPatch(typeof(PropulsionCannon))]
[HarmonyPatch("UpdateTargetPosition")]
public static class PropulsionGrabPositionFix3 {

    static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions) {
        List<CodeInstruction> codes = new List<CodeInstruction>(instructions);
        try {
            InstructionHandlers.patchEveryReturnPre(codes, new CodeInstruction(OpCodes.Ldarg_0), InstructionHandlers.createMethodCall(nameof(DIHooks), "getPropulsionMoveToPoint", false, typeof(Vector3), typeof(PropulsionCannon)));
            FileLog.Log("Done patch "+MethodBase.GetCurrentMethod()?.DeclaringType);
        }
        catch (Exception e) {
            FileLog.Log("Caught exception when running patch "+MethodBase.GetCurrentMethod()?.DeclaringType+"!");
            FileLog.Log(e.Message);
            FileLog.Log(e.StackTrace);
            FileLog.Log(e.ToString());
        }
        return codes.AsEnumerable();
    }
}
*/
[HarmonyPatch(typeof(RepulsionCannon))]
[HarmonyPatch("OnToolUseAnim")]
public static class RepulsabilityHook
{
    private static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
    {
        var codes = new List<CodeInstruction>(instructions);
        try
        {
            PatchLib.patchPropulsability(codes, InstructionHandlers.getInstruction(codes, 0, 0, OpCodes.Ldc_R4, 1300F),
                true, new CodeInstruction(OpCodes.Ldloc_S, 11));
            PatchLib.patchPropulsability(codes, InstructionHandlers.getInstruction(codes, 0, 0, OpCodes.Ldc_R4, 400F),
                false, new CodeInstruction(OpCodes.Ldloc_S, 11));
            FileLog.Log("Done patch " + MethodBase.GetCurrentMethod()?.DeclaringType);
        }
        catch (Exception e)
        {
            FileLog.Log("Caught exception when running patch " + MethodBase.GetCurrentMethod()?.DeclaringType + "!");
            FileLog.Log(e.Message);
            FileLog.Log(e.StackTrace);
            FileLog.Log(e.ToString());
        }

        return codes.AsEnumerable();
    }
}

[HarmonyPatch(typeof(Vehicle))]
[HarmonyPatch("EnterVehicle")]
public static class VehicleEnterHook
{
    private static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
    {
        var codes = new List<CodeInstruction>(instructions);
        try
        {
            var ci = InstructionHandlers.createMethodCall(nameof(DIHooks), "onVehicleEnter", false,
                typeof(Vehicle), typeof(Player));
            InstructionHandlers.patchInitialHook(codes, new CodeInstruction(OpCodes.Ldarg_0),
                new CodeInstruction(OpCodes.Ldarg_1), ci);
            FileLog.Log("Done patch " + MethodBase.GetCurrentMethod()?.DeclaringType);
        }
        catch (Exception e)
        {
            FileLog.Log("Caught exception when running patch " + MethodBase.GetCurrentMethod()?.DeclaringType + "!");
            FileLog.Log(e.Message);
            FileLog.Log(e.StackTrace);
            FileLog.Log(e.ToString());
        }

        return codes.AsEnumerable();
    }
}

[HarmonyPatch(typeof(uGUI_DepthCompass))]
[HarmonyPatch("UpdateDepth")]
public static class OverrideDepthCompass
{
    private static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
    {
        var codes = new List<CodeInstruction>(instructions);
        try
        {
            /*
                for (int i = codes.Count-1; i >= 0; i--) {
                    if (codes[i].opcode == OpCodes.Call) {
                        MethodInfo mi = (MethodInfo)codes[i].operand;
                        if (mi.Name == "FloorToInt") {
                            codes.Insert(i, InstructionHandlers.createMethodCall(nameof(DIHooks), "getCompassDepth", false, typeof(float)));
                        }
                    }
                }*/
            var idx = InstructionHandlers.getInstruction(codes, 0, 0, OpCodes.Call, "uGUI_DepthCompass", "GetDepthInfo",
                true, new[] {typeof(int).MakeByRefType(), typeof(int).MakeByRefType()});
            /*
            List<CodeInstruction> li = new List<CodeInstruction>();
            li.Add(new CodeInstruction(OpCodes.Ldarg_0));
            li.Add(new CodeInstruction(OpCodes.Ldloc_S, 0));
            li.Add(InstructionHandlers.createMethodCall(nameof(DIHooks), "getCompassDepth", false, typeof(uGUI_DepthCompass), typeof(int).MakeByRefType()));
            //li.Add(new CodeInstruction(OpCodes.Stloc_S, 0));
            codes.InsertRange(idx+2, li);*/

            codes[idx].operand = InstructionHandlers.convertMethodOperand(nameof(DIHooks),
                "getCompassDepth", false, typeof(uGUI_DepthCompass), typeof(int).MakeByRefType(),
                typeof(int).MakeByRefType());
            FileLog.Log("Done patch " + MethodBase.GetCurrentMethod()?.DeclaringType);
            //FileLog.Log("Codes are "+InstructionHandlers.toString(codes));
        }
        catch (Exception e)
        {
            FileLog.Log("Caught exception when running patch " + MethodBase.GetCurrentMethod()?.DeclaringType + "!");
            FileLog.Log(e.Message);
            FileLog.Log(e.StackTrace);
            FileLog.Log(e.ToString());
        }

        return codes.AsEnumerable();
    }
}

[HarmonyPatch(typeof(Survival))]
[HarmonyPatch("OnRespawn")]
public static class RespawnHook
{
    private static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
    {
        var codes = new List<CodeInstruction>(instructions);
        try
        {
            InstructionHandlers.patchInitialHook(codes, new List<CodeInstruction>
            {
                new(OpCodes.Ldarg_0), new(OpCodes.Ldarg_1),
                InstructionHandlers.createMethodCall(nameof(DIHooks), "onRespawnPre", false,
                    typeof(Survival), typeof(Player))
            });
            InstructionHandlers.patchEveryReturnPre(codes, new List<CodeInstruction>
            {
                new(OpCodes.Ldarg_0), new(OpCodes.Ldarg_1),
                InstructionHandlers.createMethodCall(nameof(DIHooks), "onRespawnPost", false,
                    typeof(Survival), typeof(Player))
            });
            //FileLog.Log("Codes are "+InstructionHandlers.toString(codes));
            FileLog.Log("Done patch " + MethodBase.GetCurrentMethod()?.DeclaringType);
        }
        catch (Exception e)
        {
            FileLog.Log("Caught exception when running patch " + MethodBase.GetCurrentMethod()?.DeclaringType + "!");
            FileLog.Log(e.Message);
            FileLog.Log(e.StackTrace);
            FileLog.Log(e.ToString());
        }

        return codes.AsEnumerable();
    }
}

[HarmonyPatch(typeof(Inventory))]
[HarmonyPatch("LoseItems")]
public static class ItemLossHook
{
    private static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
    {
        var codes = new List<CodeInstruction>(instructions);
        try
        {
            InstructionHandlers.patchInitialHook(codes,
                InstructionHandlers.createMethodCall(nameof(DIHooks), "onItemsLost", false,
                    new Type[0]));
            //FileLog.Log("Codes are "+InstructionHandlers.toString(codes));
            var idx = InstructionHandlers.getFirstOpcode(codes, 0, OpCodes.Sub);
            codes.RemoveAt(idx);
            codes.RemoveAt(idx - 1);
            FileLog.Log("Done patch " + MethodBase.GetCurrentMethod()?.DeclaringType);
        }
        catch (Exception e)
        {
            FileLog.Log("Caught exception when running patch " + MethodBase.GetCurrentMethod()?.DeclaringType + "!");
            FileLog.Log(e.Message);
            FileLog.Log(e.StackTrace);
            FileLog.Log(e.ToString());
        }

        return codes.AsEnumerable();
    }
}
/* DO NOT ENABLE, CAUSES ALL GUI PINGS TO DISAPPEAR WHEN THEIR CAUSAL GO DERENDERS/UNLOADS AT DISTANCE
[HarmonyPatch(typeof(ResourceTracker))]
[HarmonyPatch("OnDestroy")]
public static class ResourceTrackerDestroyUnregisterFix {

    static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions) {
        List<CodeInstruction> codes = new List<CodeInstruction>(instructions);
        try {
            InstructionHandlers.patchInitialHook(codes, new List<CodeInstruction>(){
                                                    new CodeInstruction(OpCodes.Ldarg_0), InstructionHandlers.createMethodCall("ResourceTracker", "Unregister", true, new Type[0])
            });
            FileLog.Log("Done patch "+MethodBase.GetCurrentMethod()?.DeclaringType);
        }
        catch (Exception e) {
            FileLog.Log("Caught exception when running patch "+MethodBase.GetCurrentMethod()?.DeclaringType+"!");
            FileLog.Log(e.Message);
            FileLog.Log(e.StackTrace);
            FileLog.Log(e.ToString());
        }
        return codes.AsEnumerable();
    }
}*/
/*
[HarmonyPatch(typeof(Vehicle))]
[HarmonyPatch("set_docked")]
public static class DockingDebug {

    static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions) {
        List<CodeInstruction> codes = new List<CodeInstruction>(instructions);
        try {
            InstructionHandlers.patchInitialHook(codes, new CodeInstruction(OpCodes.Ldarg_0), new CodeInstruction(OpCodes.Ldarg_1), InstructionHandlers.createMethodCall(nameof(DIHooks), "logDockingVehicle", false, typeof(Vehicle), typeof(bool)));
            FileLog.Log("Done patch "+MethodBase.GetCurrentMethod()?.DeclaringType);
        }
        catch (Exception e) {
            FileLog.Log("Caught exception when running patch "+MethodBase.GetCurrentMethod()?.DeclaringType+"!");
            FileLog.Log(e.Message);
            FileLog.Log(e.StackTrace);
            FileLog.Log(e.ToString());
        }
        return codes.AsEnumerable();
    }
}
*/

[HarmonyPatch(typeof(Drillable))]
[HarmonyPatch("OnDrill")]
public static class DrillableCallHook
{
    private static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
    {
        var codes = new List<CodeInstruction>(instructions);
        try
        {
            InstructionHandlers.patchInitialHook(codes, new CodeInstruction(OpCodes.Ldarg_0),
                new CodeInstruction(OpCodes.Ldarg_1), new CodeInstruction(OpCodes.Ldarg_2),
                InstructionHandlers.createMethodCall(nameof(DIHooks), "onDrillableDrilled", false,
                    typeof(Drillable), typeof(Vector3), typeof(Exosuit)));
            FileLog.Log("Done patch " + MethodBase.GetCurrentMethod()?.DeclaringType);
        }
        catch (Exception e)
        {
            FileLog.Log("Caught exception when running patch " + MethodBase.GetCurrentMethod()?.DeclaringType + "!");
            FileLog.Log(e.Message);
            FileLog.Log(e.StackTrace);
            FileLog.Log(e.ToString());
        }

        return codes.AsEnumerable();
    }
}

[HarmonyPatch(typeof(uGUI_MainMenu))]
[HarmonyPatch("Awake")]
public static class MainMenuLoadHook
{
    private static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
    {
        var codes = new List<CodeInstruction>(instructions);
        try
        {
            InstructionHandlers.patchInitialHook(codes,
                InstructionHandlers.createMethodCall(nameof(DIHooks), "onMainMenuLoaded", false,
                    new Type[0]));
            FileLog.Log("Done patch " + MethodBase.GetCurrentMethod()?.DeclaringType);
        }
        catch (Exception e)
        {
            FileLog.Log("Caught exception when running patch " + MethodBase.GetCurrentMethod()?.DeclaringType + "!");
            FileLog.Log(e.Message);
            FileLog.Log(e.StackTrace);
            FileLog.Log(e.ToString());
        }

        return codes.AsEnumerable();
    }
}

[HarmonyPatch(typeof(MapRoomFunctionality))]
[HarmonyPatch("UpdateBlips")]
public static class MapRoomUpdateHook
{
    private static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
    {
        var codes = new List<CodeInstruction>(instructions);
        try
        {
            InstructionHandlers.patchInitialHook(codes, new List<CodeInstruction>
            {
                new(OpCodes.Ldarg_0),
                InstructionHandlers.createMethodCall(nameof(DIHooks), "onMapRoomTick", false,
                    typeof(MapRoomFunctionality))
            });
            FileLog.Log("Done patch " + MethodBase.GetCurrentMethod()?.DeclaringType);
        }
        catch (Exception e)
        {
            FileLog.Log("Caught exception when running patch " + MethodBase.GetCurrentMethod()?.DeclaringType + "!");
            FileLog.Log(e.Message);
            FileLog.Log(e.StackTrace);
            FileLog.Log(e.ToString());
        }

        return codes.AsEnumerable();
    }
}

[HarmonyPatch(typeof(StorageContainer))]
[HarmonyPatch("OnHandHover")]
public static class StorageContainerMouseoverHook
{
    private static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
    {
        var codes = new List<CodeInstruction>(instructions);
        try
        {
            InstructionHandlers.patchEveryReturnPre(codes, new List<CodeInstruction>
            {
                new(OpCodes.Ldarg_0), new(OpCodes.Ldarg_1),
                InstructionHandlers.createMethodCall(nameof(DIHooks), "onStorageContainerHover", false,
                    typeof(StorageContainer), typeof(GUIHand))
            });
            FileLog.Log("Done patch " + MethodBase.GetCurrentMethod()?.DeclaringType);
        }
        catch (Exception e)
        {
            FileLog.Log("Caught exception when running patch " + MethodBase.GetCurrentMethod()?.DeclaringType + "!");
            FileLog.Log(e.Message);
            FileLog.Log(e.StackTrace);
            FileLog.Log(e.ToString());
        }

        return codes.AsEnumerable();
    }
}

[HarmonyPatch(typeof(Vehicle))]
[HarmonyPatch("ConsumeEnergy", typeof(TechType))]
public static class ModuleFireCostHook
{
    private static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
    {
        var codes = new List<CodeInstruction>(instructions);
        try
        {
            var idx = InstructionHandlers.getInstruction(codes, 0, 0, OpCodes.Call, "Vehicle", "ConsumeEnergy", false,
                new[] {typeof(float)});
            codes.InsertRange(idx,
                new List<CodeInstruction>
                {
                    new(OpCodes.Ldarg_0), new(OpCodes.Ldarg_1),
                    InstructionHandlers.createMethodCall(nameof(DIHooks), "getModuleFireCost", false,
                        typeof(float), typeof(Vehicle), typeof(TechType))
                });
            FileLog.Log("Done patch " + MethodBase.GetCurrentMethod()?.DeclaringType);
        }
        catch (Exception e)
        {
            FileLog.Log("Caught exception when running patch " + MethodBase.GetCurrentMethod()?.DeclaringType + "!");
            FileLog.Log(e.Message);
            FileLog.Log(e.StackTrace);
            FileLog.Log(e.ToString());
        }

        return codes.AsEnumerable();
    }
}

[HarmonyPatch(typeof(PDAScanner))]
[HarmonyPatch("Scan")]
public static class SelfScanHook
{
    private static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
    {
        var codes = new List<CodeInstruction>(instructions);
        try
        {
            var idx = InstructionHandlers.getInstruction(codes, 0, 0, OpCodes.Callvirt, "Story.StoryGoal", "Trigger",
                false, new Type[0]);
            codes.Insert(idx + 1,
                InstructionHandlers.createMethodCall(nameof(DIHooks), "onSelfScan", false,
                    new Type[0]));
            FileLog.Log("Done patch " + MethodBase.GetCurrentMethod()?.DeclaringType);
        }
        catch (Exception e)
        {
            FileLog.Log("Caught exception when running patch " + MethodBase.GetCurrentMethod()?.DeclaringType + "!");
            FileLog.Log(e.Message);
            FileLog.Log(e.StackTrace);
            FileLog.Log(e.ToString());
        }

        return codes.AsEnumerable();
    }
}

[HarmonyPatch(typeof(uGUI_MapRoomScanner))]
[HarmonyPatch("RebuildResourceList")]
public static class ScannerTypeFilteringHook
{
    private static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
    {
        var codes = new List<CodeInstruction>(instructions);
        try
        {
            var call = InstructionHandlers.createMethodCall(nameof(DIHooks),
                "filterScannerRoomResourceList", false, typeof(uGUI_MapRoomScanner));
            InstructionHandlers.patchInitialHook(codes, new CodeInstruction(OpCodes.Ldarg_0), call);
            FileLog.Log("Done patch " + MethodBase.GetCurrentMethod()?.DeclaringType);
        }
        catch (Exception e)
        {
            FileLog.Log("Caught exception when running patch " + MethodBase.GetCurrentMethod()?.DeclaringType + "!");
            FileLog.Log(e.Message);
            FileLog.Log(e.StackTrace);
            FileLog.Log(e.ToString());
        }

        return codes.AsEnumerable();
    }
}

[HarmonyPatch(typeof(WorldForcesManager))]
[HarmonyPatch("FixedUpdate")]
public static class CleanupWorldForcesManager
{
    private static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
    {
        var codes = new List<CodeInstruction>(instructions);
        try
        {
            var idx = InstructionHandlers.getInstruction(codes, 0, 0, OpCodes.Callvirt, "WorldForces", "DoFixedUpdate",
                true, new Type[0]);
            codes[idx] = InstructionHandlers.createMethodCall(nameof(DIHooks), "tickWorldForces",
                false, typeof(WorldForces));
            FileLog.Log("Done patch " + MethodBase.GetCurrentMethod()?.DeclaringType);
        }
        catch (Exception e)
        {
            FileLog.Log("Caught exception when running patch " + MethodBase.GetCurrentMethod()?.DeclaringType + "!");
            FileLog.Log(e.Message);
            FileLog.Log(e.StackTrace);
            FileLog.Log(e.ToString());
        }

        return codes.AsEnumerable();
    }
}

[HarmonyPatch(typeof(SkyApplierUpdater))]
[HarmonyPatch("Update")]
public static class CleanupSkyApplierUpdater
{
    private static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
    {
        var codes = new List<CodeInstruction>(instructions);
        try
        {
            var idx = InstructionHandlers.getInstruction(codes, 0, 0, OpCodes.Callvirt, "SkyApplier",
                "UpdateSkyIfNecessary", true, new Type[0]);
            codes[idx] = InstructionHandlers.createMethodCall(nameof(DIHooks), "updateSkyApplier",
                false, typeof(SkyApplier));
            FileLog.Log("Done patch " + MethodBase.GetCurrentMethod()?.DeclaringType);
        }
        catch (Exception e)
        {
            FileLog.Log("Caught exception when running patch " + MethodBase.GetCurrentMethod()?.DeclaringType + "!");
            FileLog.Log(e.Message);
            FileLog.Log(e.StackTrace);
            FileLog.Log(e.ToString());
        }

        return codes.AsEnumerable();
    }
}

[HarmonyPatch(typeof(ToggleLights))]
[HarmonyPatch("CheckLightToggle")]
public static class LightToggleRework
{
    private static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
    {
        var codes = new List<CodeInstruction>(instructions);
        try
        {
            //int idx = InstructionHandlers.getInstruction(codes, 0, 0, OpCodes.Callvirt, "Player", "GetRightHandDown", true, new Type[0]);
            //codes[idx] = InstructionHandlers.createMethodCall(nameof(DIHooks), "isRightHandDownForLightToggle", false, typeof(Player));
            var idx = InstructionHandlers.getInstruction(codes, 0, 0, OpCodes.Ldc_R4, 0.25F);
            codes[idx].operand = -1F;
            FileLog.Log("Done patch " + MethodBase.GetCurrentMethod()?.DeclaringType);
        }
        catch (Exception e)
        {
            FileLog.Log("Caught exception when running patch " + MethodBase.GetCurrentMethod()?.DeclaringType + "!");
            FileLog.Log(e.Message);
            FileLog.Log(e.StackTrace);
            FileLog.Log(e.ToString());
        }

        return codes.AsEnumerable();
    }
}

[HarmonyPatch(typeof(StasisSphere))]
[HarmonyPatch("LateUpdate")]
public static class StasisRifleHook
{
    private static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
    {
        var codes = new List<CodeInstruction>(instructions);
        try
        {
            var idx = InstructionHandlers.getInstruction(codes, 0, 0, OpCodes.Call, "StasisSphere", "Freeze", true,
                new[] {typeof(Collider), typeof(Rigidbody).MakeByRefType()});
            codes[idx] = InstructionHandlers.createMethodCall(nameof(DIHooks), "onStasisFreeze", false,
                typeof(StasisSphere), typeof(Collider), typeof(Rigidbody).MakeByRefType());

            idx = InstructionHandlers.getInstruction(codes, 0, 0, OpCodes.Call, "StasisSphere", "Unfreeze", true,
                new[] {typeof(Rigidbody)});
            codes[idx] = InstructionHandlers.createMethodCall(nameof(DIHooks), "onStasisUnfreeze",
                false, typeof(StasisSphere), typeof(Rigidbody));
            FileLog.Log("Done patch " + MethodBase.GetCurrentMethod()?.DeclaringType);
            //FileLog.Log("Codes are "+InstructionHandlers.toString(codes));
        }
        catch (Exception e)
        {
            FileLog.Log("Caught exception when running patch " + MethodBase.GetCurrentMethod()?.DeclaringType + "!");
            FileLog.Log(e.Message);
            FileLog.Log(e.StackTrace);
            FileLog.Log(e.ToString());
        }

        return codes.AsEnumerable();
    }
}

[HarmonyPatch(typeof(StasisSphere))]
[HarmonyPatch("UnfreezeAll")]
public static class StasisRifleHook2
{
    private static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
    {
        var codes = new List<CodeInstruction>(instructions);
        try
        {
            var idx = InstructionHandlers.getInstruction(codes, 0, 0, OpCodes.Call, "StasisSphere", "Unfreeze", true,
                new[] {typeof(Rigidbody)});
            codes[idx] = InstructionHandlers.createMethodCall(nameof(DIHooks), "onStasisUnfreeze",
                false, typeof(StasisSphere), typeof(Rigidbody));
            FileLog.Log("Done patch " + MethodBase.GetCurrentMethod()?.DeclaringType);
            //FileLog.Log("Codes are "+InstructionHandlers.toString(codes));
        }
        catch (Exception e)
        {
            FileLog.Log("Caught exception when running patch " + MethodBase.GetCurrentMethod()?.DeclaringType + "!");
            FileLog.Log(e.Message);
            FileLog.Log(e.StackTrace);
            FileLog.Log(e.ToString());
        }

        return codes.AsEnumerable();
    }
}

[HarmonyPatch(typeof(PDAScanner))]
[HarmonyPatch("Scan")]
[HarmonyPriority(Priority.Last)]
public static class RedundantScanHook
{
    private static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
    {
        var codes = new List<CodeInstruction>(instructions);
        try
        {
            var idx = InstructionHandlers.getInstruction(codes, 0, 0, OpCodes.Call, "CraftData", "AddToInventory", true,
                new[] {typeof(TechType), typeof(int), typeof(bool), typeof(bool)});
            var idx0 = InstructionHandlers.getLastOpcodeBefore(codes, idx - 1, OpCodes.Call);
            codes.RemoveRange(idx0 + 1, idx - idx0);
            codes.Insert(idx0 + 1,
                InstructionHandlers.createMethodCall(nameof(DIHooks), "onRedundantFragmentScan", false,
                    new Type[0]));
            FileLog.Log("Done patch " + MethodBase.GetCurrentMethod()?.DeclaringType);
            //FileLog.Log("Codes are "+InstructionHandlers.toString(codes));
        }
        catch (Exception e)
        {
            FileLog.Log("Caught exception when running patch " + MethodBase.GetCurrentMethod()?.DeclaringType + "!");
            FileLog.Log(e.Message);
            FileLog.Log(e.StackTrace);
            FileLog.Log(e.ToString());
        }

        return codes.AsEnumerable();
    }
}
/*
[HarmonyPatch(typeof(Equipment))]
[HarmonyPatch("AllowedToAdd")]
public static class EquipmentApplicabilityHook {

    static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions) {
        List<CodeInstruction> codes = new List<CodeInstruction>(instructions);
        try {
            PatchLib.addEquipmentAllowedHook(codes, new CodeInstruction(OpCodes.Ldarg_2));
            FileLog.Log("Done patch "+MethodBase.GetCurrentMethod()?.DeclaringType);
            //FileLog.Log("Codes are "+InstructionHandlers.toString(codes));
        }
        catch (Exception e) {
            FileLog.Log("Caught exception when running patch "+MethodBase.GetCurrentMethod()?.DeclaringType+"!");
            FileLog.Log(e.Message);
            FileLog.Log(e.StackTrace);
            FileLog.Log(e.ToString());
        }
        return codes.AsEnumerable();
    }
}

[HarmonyPatch(typeof(Equipment))]
[HarmonyPatch("GetCompatibleSlotDefault")]
public static class EquipmentApplicabilityHook2 {

    static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions) {
        List<CodeInstruction> codes = new List<CodeInstruction>(instructions);
        try {
            PatchLib.addEquipmentAllowedHook(codes);
            FileLog.Log("Done patch "+MethodBase.GetCurrentMethod()?.DeclaringType);
            //FileLog.Log("Codes are "+InstructionHandlers.toString(codes));
        }
        catch (Exception e) {
            FileLog.Log("Caught exception when running patch "+MethodBase.GetCurrentMethod()?.DeclaringType+"!");
            FileLog.Log(e.Message);
            FileLog.Log(e.StackTrace);
            FileLog.Log(e.ToString());
        }
        return codes.AsEnumerable();
    }
}

[HarmonyPatch(typeof(Equipment))]
[HarmonyPatch("GetFreeSlot")]
public static class EquipmentApplicabilityHook3 {

    static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions) {
        List<CodeInstruction> codes = new List<CodeInstruction>(instructions);
        try {
            PatchLib.addEquipmentAllowedHook(codes);
            FileLog.Log("Done patch "+MethodBase.GetCurrentMethod()?.DeclaringType);
            //FileLog.Log("Codes are "+InstructionHandlers.toString(codes));
        }
        catch (Exception e) {
            FileLog.Log("Caught exception when running patch "+MethodBase.GetCurrentMethod()?.DeclaringType+"!");
            FileLog.Log(e.Message);
            FileLog.Log(e.StackTrace);
            FileLog.Log(e.ToString());
        }
        return codes.AsEnumerable();
    }
}

[HarmonyPatch(typeof(Equipment))]
[HarmonyPatch("GetSlots")]
public static class EquipmentApplicabilityHook4 {

    static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions) {
        List<CodeInstruction> codes = new List<CodeInstruction>(instructions);
        try {
            PatchLib.addEquipmentAllowedHook(codes);
            FileLog.Log("Done patch "+MethodBase.GetCurrentMethod()?.DeclaringType);
            //FileLog.Log("Codes are "+InstructionHandlers.toString(codes));
        }
        catch (Exception e) {
            FileLog.Log("Caught exception when running patch "+MethodBase.GetCurrentMethod()?.DeclaringType+"!");
            FileLog.Log(e.Message);
            FileLog.Log(e.StackTrace);
            FileLog.Log(e.ToString());
        }
        return codes.AsEnumerable();
    }
}
*/

[HarmonyPatch(typeof(CraftData))]
[HarmonyPatch("GetEquipmentType")]
public static class EquipmentTypeHook
{
    private static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
    {
        var codes = new List<CodeInstruction>(instructions);
        try
        {
            InstructionHandlers.patchEveryReturnPre(codes, new CodeInstruction(OpCodes.Ldarg_0),
                InstructionHandlers.createMethodCall(nameof(DIHooks), "getOverriddenEquipmentType",
                    false, typeof(EquipmentType), typeof(TechType)));
            FileLog.Log("Done patch " + MethodBase.GetCurrentMethod()?.DeclaringType);
            //FileLog.Log("Codes are "+InstructionHandlers.toString(codes));
        }
        catch (Exception e)
        {
            FileLog.Log("Caught exception when running patch " + MethodBase.GetCurrentMethod()?.DeclaringType + "!");
            FileLog.Log(e.Message);
            FileLog.Log(e.StackTrace);
            FileLog.Log(e.ToString());
        }

        return codes.AsEnumerable();
    }
}

[HarmonyPatch(typeof(Inventory))]
[HarmonyPatch("ExecuteItemAction")]
public static class EatInterception
{
    private static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
    {
        var codes = new List<CodeInstruction>(instructions);
        try
        {
            var idx = InstructionHandlers.getInstruction(codes, 0, 0, OpCodes.Callvirt, "Survival", "Eat", true,
                new[] {typeof(GameObject)});
            codes[idx].operand = InstructionHandlers.convertMethodOperand(nameof(DIHooks), "tryEat",
                false, typeof(Survival), typeof(GameObject));
            FileLog.Log("Done patch " + MethodBase.GetCurrentMethod()?.DeclaringType);
        }
        catch (Exception e)
        {
            FileLog.Log("Caught exception when running patch " + MethodBase.GetCurrentMethod()?.DeclaringType + "!");
            FileLog.Log(e.Message);
            FileLog.Log(e.StackTrace);
            FileLog.Log(e.ToString());
        }

        return codes.AsEnumerable();
    }
}

[HarmonyPatch(typeof(UnderwaterMotor))]
[HarmonyPatch("UpdateMove")]
public static class AffectSwimSpeed
{
    private static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
    {
        var codes = new List<CodeInstruction>(instructions);
        try
        {
            /*
                int idx = InstructionHandlers.getInstruction(codes, 0, 0, OpCodes.Callvirt, "Inventory", "GetHeldTool", true, new Type[0]);
                while (codes[idx].opcode != OpCodes.Ldloc_1)
                    idx--;
                codes.Insert(idx, new CodeInstruction(OpCodes.Stloc_0));
                codes.Insert(idx, InstructionHandlers.createMethodCall("ReikaKalseki.SeaToSea.C2CHooks", "getSwimSpeed", false, typeof(float)));
                codes.Insert(idx, new CodeInstruction(OpCodes.Ldloc_0));
                */
            var idx = InstructionHandlers.getInstruction(codes, 0, 0, OpCodes.Stloc_S, 9);
            codes.Insert(idx,
                InstructionHandlers.createMethodCall(nameof(DIHooks), "getSwimSpeed", false,
                    typeof(float)));
            //FileLog.Log("Codes are "+InstructionHandlers.toString(codes));
            FileLog.Log("Done patch " + MethodBase.GetCurrentMethod()?.DeclaringType);
        }
        catch (Exception e)
        {
            FileLog.Log("Caught exception when running patch " + MethodBase.GetCurrentMethod()?.DeclaringType + "!");
            FileLog.Log(e.Message);
            FileLog.Log(e.StackTrace);
            FileLog.Log(e.ToString());
        }

        return codes.AsEnumerable();
    }
}

[HarmonyPatch(typeof(GroundMotor))]
[HarmonyPatch("ApplyInputVelocityChange")]
public static class AffectWalkSpeed
{
    private static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
    {
        var codes = new List<CodeInstruction>(instructions);
        try
        {
            var idx = InstructionHandlers.getLastInstructionBefore(codes, codes.Count, OpCodes.Ldloc_S, 11);
            codes.Insert(idx + 1,
                InstructionHandlers.createMethodCall(nameof(DIHooks), "getWalkSpeed", false,
                    typeof(float)));
            //FileLog.Log("Codes are "+InstructionHandlers.toString(codes));
            FileLog.Log("Done patch " + MethodBase.GetCurrentMethod()?.DeclaringType);
        }
        catch (Exception e)
        {
            FileLog.Log("Caught exception when running patch " + MethodBase.GetCurrentMethod()?.DeclaringType + "!");
            FileLog.Log(e.Message);
            FileLog.Log(e.StackTrace);
            FileLog.Log(e.ToString());
        }

        return codes.AsEnumerable();
    }
}

[HarmonyPatch(typeof(Vehicle))]
[HarmonyPatch("OnKill")]
public static class VehicleDeathHook
{
    private static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
    {
        var codes = new List<CodeInstruction>(instructions);
        try
        {
            InstructionHandlers.patchInitialHook(codes, new List<CodeInstruction>
            {
                new(OpCodes.Ldarg_0),
                InstructionHandlers.createMethodCall(nameof(DIHooks), "onVehicleDestroyed", false,
                    typeof(Vehicle))
            });
            FileLog.Log("Done patch " + MethodBase.GetCurrentMethod()?.DeclaringType);
        }
        catch (Exception e)
        {
            FileLog.Log("Caught exception when running patch " + MethodBase.GetCurrentMethod()?.DeclaringType + "!");
            FileLog.Log(e.Message);
            FileLog.Log(e.StackTrace);
            FileLog.Log(e.ToString());
        }

        return codes.AsEnumerable();
    }
}

[HarmonyPatch(typeof(Bed))]
[HarmonyPatch("EnterInUseMode")]
public static class SleepHook
{
    private static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
    {
        var codes = new List<CodeInstruction>(instructions);
        try
        {
            var idx = InstructionHandlers.getLastOpcodeBefore(codes, codes.Count, OpCodes.Ret);
            codes.InsertRange(idx, new List<CodeInstruction>
            {
                new(OpCodes.Ldarg_0),
                InstructionHandlers.createMethodCall(nameof(DIHooks), "onSleep", false, typeof(Bed))
            });
            FileLog.Log("Done patch " + MethodBase.GetCurrentMethod()?.DeclaringType);
        }
        catch (Exception e)
        {
            FileLog.Log("Caught exception when running patch " + MethodBase.GetCurrentMethod()?.DeclaringType + "!");
            FileLog.Log(e.Message);
            FileLog.Log(e.StackTrace);
            FileLog.Log(e.ToString());
        }

        return codes.AsEnumerable();
    }
}

[HarmonyPatch(typeof(Survival))]
[HarmonyPatch("UpdateStats")]
public static class AffectFoodWaterRate
{
    private static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
    {
        var codes = new List<CodeInstruction>(instructions);
        try
        {
            InstructionHandlers.patchInitialHook(codes, new CodeInstruction(OpCodes.Ldarg_1),
                InstructionHandlers.createMethodCall(nameof(DIHooks), "getFoodWaterConsumptionRate",
                    false, typeof(float)), new CodeInstruction(OpCodes.Starg, 1));
            FileLog.Log("Done patch " + MethodBase.GetCurrentMethod()?.DeclaringType);
        }
        catch (Exception e)
        {
            FileLog.Log("Caught exception when running patch " + MethodBase.GetCurrentMethod()?.DeclaringType + "!");
            FileLog.Log(e.Message);
            FileLog.Log(e.StackTrace);
            FileLog.Log(e.ToString());
        }

        return codes.AsEnumerable();
    }
}

[HarmonyPatch(typeof(BaseRoot))]
[HarmonyPatch("Start")]
public static class BaseLoadHook
{
    private static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
    {
        var codes = new List<CodeInstruction>(instructions);
        try
        {
            InstructionHandlers.patchInitialHook(codes, new CodeInstruction(OpCodes.Ldarg_0),
                InstructionHandlers.createMethodCall(nameof(DIHooks), "onBaseLoaded", false,
                    typeof(BaseRoot)));
            FileLog.Log("Done patch " + MethodBase.GetCurrentMethod()?.DeclaringType);
        }
        catch (Exception e)
        {
            FileLog.Log("Caught exception when running patch " + MethodBase.GetCurrentMethod()?.DeclaringType + "!");
            FileLog.Log(e.Message);
            FileLog.Log(e.StackTrace);
            FileLog.Log(e.ToString());
        }

        return codes.AsEnumerable();
    }
}

[HarmonyPatch(typeof(StorageContainer))]
[HarmonyPatch("Open", typeof(Transform))]
public static class InvOpenHook
{
    private static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
    {
        var codes = new List<CodeInstruction>(instructions);
        try
        {
            InstructionHandlers.patchInitialHook(codes, new CodeInstruction(OpCodes.Ldarg_0),
                InstructionHandlers.createMethodCall(nameof(DIHooks), "onInvOpened", false,
                    typeof(StorageContainer)));
            FileLog.Log("Done patch " + MethodBase.GetCurrentMethod()?.DeclaringType);
        }
        catch (Exception e)
        {
            FileLog.Log("Caught exception when running patch " + MethodBase.GetCurrentMethod()?.DeclaringType + "!");
            FileLog.Log(e.Message);
            FileLog.Log(e.StackTrace);
            FileLog.Log(e.ToString());
        }

        return codes.AsEnumerable();
    }
}

[HarmonyPatch(typeof(StorageContainer))]
[HarmonyPatch("OnClosePDA")]
public static class InvCloseHook
{
    private static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
    {
        var codes = new List<CodeInstruction>(instructions);
        try
        {
            InstructionHandlers.patchInitialHook(codes, new CodeInstruction(OpCodes.Ldarg_0),
                InstructionHandlers.createMethodCall(nameof(DIHooks), "onInvClosed", false,
                    typeof(StorageContainer)));
            FileLog.Log("Done patch " + MethodBase.GetCurrentMethod()?.DeclaringType);
        }
        catch (Exception e)
        {
            FileLog.Log("Caught exception when running patch " + MethodBase.GetCurrentMethod()?.DeclaringType + "!");
            FileLog.Log(e.Message);
            FileLog.Log(e.StackTrace);
            FileLog.Log(e.ToString());
        }

        return codes.AsEnumerable();
    }
}

[HarmonyPatch(typeof(GameInput))]
[HarmonyPatch("GetMoveDirection")]
public static class InputDirectionOverrideHook
{
    private static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
    {
        var codes = new List<CodeInstruction>(instructions);
        try
        {
            InstructionHandlers.patchEveryReturnPre(codes,
                InstructionHandlers.createMethodCall(nameof(DIHooks), "getPlayerMovementControl",
                    false, typeof(Vector3)));
            FileLog.Log("Done patch " + MethodBase.GetCurrentMethod()?.DeclaringType);
        }
        catch (Exception e)
        {
            FileLog.Log("Caught exception when running patch " + MethodBase.GetCurrentMethod()?.DeclaringType + "!");
            FileLog.Log(e.Message);
            FileLog.Log(e.StackTrace);
            FileLog.Log(e.ToString());
        }

        return codes.AsEnumerable();
    }
}

[HarmonyPatch(typeof(SeamothTorpedo))]
[HarmonyPatch("Explode")]
public static class TorpedoExplodeHook
{
    private static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
    {
        var codes = new List<CodeInstruction>(instructions);
        try
        {
            var idx = InstructionHandlers.getFirstOpcode(codes, 0, OpCodes.Callvirt);
            codes.InsertRange(idx + 1,
                new List<CodeInstruction>
                {
                    new(OpCodes.Ldarg_0),
                    InstructionHandlers.createMethodCall(nameof(DIHooks), "onTorpedoExploded", false,
                        typeof(Transform), typeof(SeamothTorpedo))
                });
            FileLog.Log("Done patch " + MethodBase.GetCurrentMethod()?.DeclaringType);
        }
        catch (Exception e)
        {
            FileLog.Log("Caught exception when running patch " + MethodBase.GetCurrentMethod()?.DeclaringType + "!");
            FileLog.Log(e.Message);
            FileLog.Log(e.StackTrace);
            FileLog.Log(e.ToString());
        }

        return codes.AsEnumerable();
    }
}

[HarmonyPatch(typeof(Vehicle))]
[HarmonyPatch("TorpedoShot")]
public static class TorpedoFireHook
{
    private static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
    {
        var codes = new List<CodeInstruction>(instructions);
        try
        {
            var idx = InstructionHandlers.getInstruction(codes, 0, 0, OpCodes.Callvirt, "Bullet", "Shoot", true,
                new[] {typeof(Vector3), typeof(Quaternion), typeof(float), typeof(float)});
            codes[idx] = InstructionHandlers.createMethodCall(nameof(DIHooks), "doShootTorpedo", false,
                typeof(Bullet), typeof(Vector3), typeof(Quaternion), typeof(float), typeof(float), typeof(Vehicle));
            codes.Insert(idx, new CodeInstruction(OpCodes.Ldarg_0));
            FileLog.Log("Done patch " + MethodBase.GetCurrentMethod()?.DeclaringType);
        }
        catch (Exception e)
        {
            FileLog.Log("Caught exception when running patch " + MethodBase.GetCurrentMethod()?.DeclaringType + "!");
            FileLog.Log(e.Message);
            FileLog.Log(e.StackTrace);
            FileLog.Log(e.ToString());
        }

        return codes.AsEnumerable();
    }
}

[HarmonyPatch(typeof(Gravsphere))]
[HarmonyPatch("IsValidTarget")]
public static class GravTrapGrabbabilityHook
{
    private static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
    {
        var codes = new List<CodeInstruction>();
        try
        {
            codes.Add(new CodeInstruction(OpCodes.Ldarg_0));
            codes.Add(new CodeInstruction(OpCodes.Ldarg_1));
            codes.Add(InstructionHandlers.createMethodCall(nameof(DIHooks), "canGravTrapGrab", false,
                typeof(Gravsphere), typeof(GameObject)));
            codes.Add(new CodeInstruction(OpCodes.Ret));
            FileLog.Log("Done patch " + MethodBase.GetCurrentMethod()?.DeclaringType);
        }
        catch (Exception e)
        {
            FileLog.Log("Caught exception when running patch " + MethodBase.GetCurrentMethod()?.DeclaringType + "!");
            FileLog.Log(e.Message);
            FileLog.Log(e.StackTrace);
            FileLog.Log(e.ToString());
        }

        return codes.AsEnumerable();
    }
}
/*
[HarmonyPatch(typeof(PrecursorTeleporter))]
[HarmonyPatch("BeginTeleportPlayer")]
public static class ArchTeleportHookPre {

    static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions) {
        List<CodeInstruction> codes = new List<CodeInstruction>();
        try {
            InstructionHandlers.patchInitialHook(codes, new CodeInstruction(OpCodes.Ldarg_0), new CodeInstruction(OpCodes.Ldarg_1), InstructionHandlers.createMethodCall(nameof(DIHooks), "onArchTeleportPre", false, new Type[]{typeof(PrecursorTeleporter), typeof(GameObject)}));
            FileLog.Log("Done patch "+MethodBase.GetCurrentMethod()?.DeclaringType);
        }
        catch (Exception e) {
            FileLog.Log("Caught exception when running patch "+MethodBase.GetCurrentMethod()?.DeclaringType+"!");
            FileLog.Log(e.Message);
            FileLog.Log(e.StackTrace);
            FileLog.Log(e.ToString());
        }
        return codes.AsEnumerable();
    }
}

[HarmonyPatch(typeof(PrecursorTeleporter))]
[HarmonyPatch("BeginTeleportPlayer")]
public static class ArchTeleportHookPre {

    static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions) {
        List<CodeInstruction> codes = new List<CodeInstruction>(instructions);
        try {
            InstructionHandlers.patchInitialHook(codes, new CodeInstruction(OpCodes.Ldarg_0), new CodeInstruction(OpCodes.Ldarg_1), InstructionHandlers.createMethodCall(nameof(DIHooks), "onArchTeleportPre", false, new Type[]{typeof(PrecursorTeleporter), typeof(GameObject)}));
            FileLog.Log("Done patch "+MethodBase.GetCurrentMethod()?.DeclaringType);
        }
        catch (Exception e) {
            FileLog.Log("Caught exception when running patch "+MethodBase.GetCurrentMethod()?.DeclaringType+"!");
            FileLog.Log(e.Message);
            FileLog.Log(e.StackTrace);
            FileLog.Log(e.ToString());
        }
        return codes.AsEnumerable();
    }
}*/

[HarmonyPatch(typeof(Constructor))]
[HarmonyPatch("OnConstructionDone")]
public static class VehicleBayCompletionHook
{
    private static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
    {
        var codes = new List<CodeInstruction>(instructions);
        try
        {
            InstructionHandlers.patchInitialHook(codes, new CodeInstruction(OpCodes.Ldarg_0),
                new CodeInstruction(OpCodes.Ldarg_1),
                InstructionHandlers.createMethodCall(nameof(DIHooks), "onVehicleBayFinish", false,
                    typeof(Constructor), typeof(GameObject)));
            FileLog.Log("Done patch " + MethodBase.GetCurrentMethod()?.DeclaringType);
        }
        catch (Exception e)
        {
            FileLog.Log("Caught exception when running patch " + MethodBase.GetCurrentMethod()?.DeclaringType + "!");
            FileLog.Log(e.Message);
            FileLog.Log(e.StackTrace);
            FileLog.Log(e.ToString());
        }

        return codes.AsEnumerable();
    }
}

internal static class PatchLib
{
    internal static void addEquipmentAllowedHook(List<CodeInstruction> codes, params CodeInstruction[] getItem)
    {
        var idx = InstructionHandlers.getInstruction(codes, 0, 0, OpCodes.Call, "Equipment", "IsCompatible", false,
            new[] {typeof(EquipmentType), typeof(EquipmentType)});
        codes[idx] = InstructionHandlers.createMethodCall(nameof(DIHooks), "isEquipmentApplicable",
            false, typeof(EquipmentType), typeof(EquipmentType), typeof(Equipment), typeof(Pickupable));
        codes.InsertRange(idx, getItem);
        codes.Insert(idx, new CodeInstruction(OpCodes.Ldarg_0));
    }

    internal static void patchPropulsability(List<CodeInstruction> codes, int idx, bool mass, CodeInstruction go = null)
    {
        var add = new List<CodeInstruction>();
        add.Add(go == null ? new CodeInstruction(OpCodes.Ldarg_1) : go);
        add.Add(new CodeInstruction(OpCodes.Ldarg_0));
        add.Add(new CodeInstruction(mass ? OpCodes.Ldc_I4_1 : OpCodes.Ldc_I4_0));
        add.Add(InstructionHandlers.createMethodCall(nameof(DIHooks), "getMaxPropulsible", false,
            typeof(float), typeof(GameObject), typeof(MonoBehaviour), typeof(bool)));
        codes.InsertRange(idx + 1, add);
    }

    internal static void patchVisualItemSize(List<CodeInstruction> codes, bool useSelfContainer = false)
    {
        patchVisualItemSize(codes, useSelfContainer, true,
            useSelfContainer
                ? new[] {typeof(TechType), typeof(InventoryItem), typeof(IItemsContainer)}
                : new[] {typeof(TechType), typeof(InventoryItem)});
    }

    internal static void patchVisualItemSize(List<CodeInstruction> codes, bool ldSelf = false, bool ldArg1 = true,
        params Type[] args)
    {
        for (var i = codes.Count - 1; i >= 0; i--)
            if (codes[i].opcode == OpCodes.Call)
            {
                var m = (MethodInfo) codes[i].operand;
                if (m == null || m.DeclaringType?.Name != "CraftData" || m.Name != "GetItemSize") continue;
                var call = InstructionHandlers.convertMethodOperand(nameof(DIHooks),
                    "getItemDisplaySize", false, args);
                codes[i].operand = call;
                if (ldSelf)
                    codes.Insert(i, new CodeInstruction(OpCodes.Ldarg_0));
                if (ldArg1)
                    codes.Insert(i, new CodeInstruction(OpCodes.Ldarg_1));
            }
        //FileLog.Log("Codes are "+InstructionHandlers.toString(codes));
        /*
        int idx = InstructionHandlers.getInstruction(codes, 0, 0, OpCodes.Call, "CraftData", "GetItemSize", false, new Type[]{typeof(TechType)});
        codes[idx].operand = InstructionHandlers.convertMethodOperand(nameof(DIHooks), "getItemDisplaySize", false, typeof(TechType), typeof(InventoryItem));
        codes.Insert(idx, new CodeInstruction(OpCodes.Ldarg_1));*/
    }

    internal static void redirectPowerHook(List<CodeInstruction> codes)
    {
        var idx = InstructionHandlers.getInstruction(codes, 0, 0, OpCodes.Call, "PowerSystem", "AddEnergy", false,
            new[] {typeof(IPowerInterface), typeof(float), typeof(float).MakeByRefType()});
        codes[idx].operand = InstructionHandlers.convertMethodOperand(nameof(DIHooks),
            "addPowerToSeabaseDelegate", false, typeof(IPowerInterface), typeof(float), typeof(float).MakeByRefType(),
            typeof(MonoBehaviour));
        codes.Insert(idx, new CodeInstruction(OpCodes.Ldarg_0));
    }

    internal static void injectEMPHook(List<CodeInstruction> codes, int idx)
    {
        var arg = codes[idx - 3]; //-1 is getfield time, -2 is loadarg0 to get that field
        idx -= 4;
        codes.Insert(idx + 1,
            InstructionHandlers.createMethodCall(nameof(DIHooks), "onEMPHit", false, typeof(EMPBlast),
                typeof(MonoBehaviour)));
        codes.Insert(idx + 1, new CodeInstruction(arg.opcode, arg.operand));
        codes.Insert(idx + 1, new CodeInstruction(OpCodes.Ldarg_0));
    }

    internal static void injectTickHook(List<CodeInstruction> codes, string name, Type arg)
    {
        InstructionHandlers.patchInitialHook(codes, new CodeInstruction(OpCodes.Ldarg_0),
            InstructionHandlers.createMethodCall(nameof(DIHooks), name, false, arg));
    }
}