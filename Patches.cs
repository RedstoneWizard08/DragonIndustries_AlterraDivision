﻿using System;
using System.IO;    //For data read/write methods
using System.Collections;   //Working with Lists and Collections
using System.Collections.Generic;   //Working with Lists and Collections
using System.Linq;   //More advanced manipulation of lists/collections
using System.Reflection;
using System.Reflection.Emit;
using HarmonyLib;
using UnityEngine;  //Needed for most Unity Enginer manipulations: Vectors, GameObjects, Audio, etc.
using ReikaKalseki.DIAlterra;

namespace ReikaKalseki.DIAlterra {
	
	[HarmonyPatch(typeof(DayNightCycle))]
	[HarmonyPatch("Update")]
	public static class UpdateLoopHook {
		
		static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions) {
			List<CodeInstruction> codes = new List<CodeInstruction>(instructions);
			try {
				InstructionHandlers.patchInitialHook(codes, new CodeInstruction(OpCodes.Ldarg_0), InstructionHandlers.createMethodCall("ReikaKalseki.DIAlterra.DIHooks", "onTick", false, typeof(DayNightCycle)));
				FileLog.Log("Done patch "+MethodBase.GetCurrentMethod().DeclaringType);
				//FileLog.Log("Codes are "+InstructionHandlers.toString(codes));
			}
			catch (Exception e) {
				FileLog.Log("Caught exception when running patch "+MethodBase.GetCurrentMethod().DeclaringType+"!");
				FileLog.Log(e.Message);
				FileLog.Log(e.StackTrace);
				FileLog.Log(e.ToString());
			}
			return codes.AsEnumerable();
		}
	}
	
	[HarmonyPatch(typeof(SNCameraRoot))]
	[HarmonyPatch("SonarPing")]
	public static class SonarHook {
		
		static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions) {
			List<CodeInstruction> codes = new List<CodeInstruction>(instructions);
			try {
				InstructionHandlers.patchInitialHook(codes, new CodeInstruction(OpCodes.Ldarg_0), InstructionHandlers.createMethodCall("ReikaKalseki.DIAlterra.DIHooks", "pingSonar", false, typeof(SNCameraRoot)));
				//FileLog.Log("Codes are "+InstructionHandlers.toString(codes));
				FileLog.Log("Done patch "+MethodBase.GetCurrentMethod().DeclaringType);
			}
			catch (Exception e) {
				FileLog.Log("Caught exception when running patch "+MethodBase.GetCurrentMethod().DeclaringType+"!");
				FileLog.Log(e.Message);
				FileLog.Log(e.StackTrace);
				FileLog.Log(e.ToString());
			}
			return codes.AsEnumerable();
		}
	}
	
	[HarmonyPatch(typeof(SeaMoth))]
	[HarmonyPatch("OnUpgradeModuleUse")]
	public static class SeamothSonarHook {
		
		static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions) {
			List<CodeInstruction> codes = new List<CodeInstruction>(instructions);
			try {
				int idx = InstructionHandlers.getInstruction(codes, 0, 0, OpCodes.Callvirt, "SNCameraRoot", "SonarPing", true, new Type[0]);
				codes.Insert(idx+1, InstructionHandlers.createMethodCall("ReikaKalseki.DIAlterra.DIHooks", "pingSeamothSonar", false, typeof(SeaMoth)));
				codes.Insert(idx+1, new CodeInstruction(OpCodes.Ldarg_0));
				//FileLog.Log("Codes are "+InstructionHandlers.toString(codes));
				FileLog.Log("Done patch "+MethodBase.GetCurrentMethod().DeclaringType);
			}
			catch (Exception e) {
				FileLog.Log("Caught exception when running patch "+MethodBase.GetCurrentMethod().DeclaringType+"!");
				FileLog.Log(e.Message);
				FileLog.Log(e.StackTrace);
				FileLog.Log(e.ToString());
			}
			return codes.AsEnumerable();
		}
	}
	
	[HarmonyPatch(typeof(CyclopsSonarButton))]
	[HarmonyPatch("SonarPing")]
	public static class CyclopsSonarHook {
		
		static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions) {
			List<CodeInstruction> codes = new List<CodeInstruction>(instructions);
			try {
				int idx = InstructionHandlers.getInstruction(codes, 0, 0, OpCodes.Callvirt, "SNCameraRoot", "SonarPing", true, new Type[0]);
				codes.Insert(idx+1, InstructionHandlers.createMethodCall("ReikaKalseki.DIAlterra.DIHooks", "pingCyclopsSonar", false, typeof(CyclopsSonarButton)));
				codes.Insert(idx+1, new CodeInstruction(OpCodes.Ldarg_0));
				//FileLog.Log("Codes are "+InstructionHandlers.toString(codes));
				FileLog.Log("Done patch "+MethodBase.GetCurrentMethod().DeclaringType);
			}
			catch (Exception e) {
				FileLog.Log("Caught exception when running patch "+MethodBase.GetCurrentMethod().DeclaringType+"!");
				FileLog.Log(e.Message);
				FileLog.Log(e.StackTrace);
				FileLog.Log(e.ToString());
			}
			return codes.AsEnumerable();
		}
	}
	
	[HarmonyPatch(typeof(StoryGoalCustomEventHandler))]
	[HarmonyPatch("NotifyGoalComplete")]
	public static class StoryHook {
		
		static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions) {
			List<CodeInstruction> codes = new List<CodeInstruction>(instructions);
			try {
				InstructionHandlers.patchInitialHook(codes, new CodeInstruction(OpCodes.Ldarg_1), InstructionHandlers.createMethodCall("ReikaKalseki.DIAlterra.DIHooks", "onStoryGoalCompleted", false, typeof(string)));
				FileLog.Log("Done patch "+MethodBase.GetCurrentMethod().DeclaringType);
			}
			catch (Exception e) {
				FileLog.Log("Caught exception when running patch "+MethodBase.GetCurrentMethod().DeclaringType+"!");
				FileLog.Log(e.Message);
				FileLog.Log(e.StackTrace);
				FileLog.Log(e.ToString());
			}
			return codes.AsEnumerable();
		}
	}
	
	[HarmonyPatch(typeof(SeaMoth))]
	[HarmonyPatch("OnUpgradeModuleChange")]
	public static class SeamothModuleHook {
		
		static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions) {
			List<CodeInstruction> codes = new List<CodeInstruction>(instructions);
			try {
				InstructionHandlers.patchEveryReturnPre(codes, injectSMModuleHook);				
				//FileLog.Log("Codes are "+InstructionHandlers.toString(codes));
				FileLog.Log("Done patch "+MethodBase.GetCurrentMethod().DeclaringType);
			}
			catch (Exception e) {
				FileLog.Log("Caught exception when running patch "+MethodBase.GetCurrentMethod().DeclaringType+"!");
				FileLog.Log(e.Message);
				FileLog.Log(e.StackTrace);
				FileLog.Log(e.ToString());
			}
			return codes.AsEnumerable();
		}
	
		private static void injectSMModuleHook(List<CodeInstruction> codes, int idx) {
			codes.Insert(idx, InstructionHandlers.createMethodCall("ReikaKalseki.DIAlterra.DIHooks", "updateSeamothModules", false, typeof(SeaMoth), typeof(int), typeof(TechType), typeof(bool)));
			codes.Insert(idx, new CodeInstruction(OpCodes.Ldarg_3));
			codes.Insert(idx, new CodeInstruction(OpCodes.Ldarg_2));
			codes.Insert(idx, new CodeInstruction(OpCodes.Ldarg_1));
			codes.Insert(idx, new CodeInstruction(OpCodes.Ldarg_0));
		}
	}
	
	[HarmonyPatch(typeof(SubRoot))]
	[HarmonyPatch("UpdateSubModules")]
	public static class CyclopsModuleHook {
		
		static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions) {
			List<CodeInstruction> codes = new List<CodeInstruction>(instructions);
			try {
				InstructionHandlers.patchEveryReturnPre(codes, injectModuleHook);				
				//FileLog.Log("Codes are "+InstructionHandlers.toString(codes));
				FileLog.Log("Done patch "+MethodBase.GetCurrentMethod().DeclaringType);
			}
			catch (Exception e) {
				FileLog.Log("Caught exception when running patch "+MethodBase.GetCurrentMethod().DeclaringType+"!");
				FileLog.Log(e.Message);
				FileLog.Log(e.StackTrace);
				FileLog.Log(e.ToString());
			}
			return codes.AsEnumerable();
		}
	
		private static void injectModuleHook(List<CodeInstruction> codes, int idx) {
			codes.Insert(idx, InstructionHandlers.createMethodCall("ReikaKalseki.DIAlterra.DIHooks", "updateCyclopsModules", false, typeof(SubRoot)));
			codes.Insert(idx, new CodeInstruction(OpCodes.Ldarg_0));
		}
	}
	
	[HarmonyPatch(typeof(Exosuit))]
	[HarmonyPatch("OnUpgradeModuleChange")]
	public static class PrawnModuleHook {
		
		static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions) {
			List<CodeInstruction> codes = new List<CodeInstruction>(instructions);
			try {
				InstructionHandlers.patchEveryReturnPre(codes, injectModuleHook);				
				//FileLog.Log("Codes are "+InstructionHandlers.toString(codes));
				FileLog.Log("Done patch "+MethodBase.GetCurrentMethod().DeclaringType);
			}
			catch (Exception e) {
				FileLog.Log("Caught exception when running patch "+MethodBase.GetCurrentMethod().DeclaringType+"!");
				FileLog.Log(e.Message);
				FileLog.Log(e.StackTrace);
				FileLog.Log(e.ToString());
			}
			return codes.AsEnumerable();
		}
	
		private static void injectModuleHook(List<CodeInstruction> codes, int idx) {
			codes.Insert(idx, InstructionHandlers.createMethodCall("ReikaKalseki.DIAlterra.DIHooks", "updatePrawnModules", false, typeof(Exosuit), typeof(int), typeof(TechType), typeof(bool)));
			codes.Insert(idx, new CodeInstruction(OpCodes.Ldarg_3));
			codes.Insert(idx, new CodeInstruction(OpCodes.Ldarg_2));
			codes.Insert(idx, new CodeInstruction(OpCodes.Ldarg_1));
			codes.Insert(idx, new CodeInstruction(OpCodes.Ldarg_0));
		}
	}
	
	[HarmonyPatch(typeof(SeaMoth))]
	[HarmonyPatch("OnUpgradeModuleUse")]
	public static class SeamothModuleUseHook {
		
		static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions) {
			List<CodeInstruction> codes = new List<CodeInstruction>(instructions);
			try {
				InstructionHandlers.patchInitialHook(codes, injectModuleHook());
				//FileLog.Log("Codes are "+InstructionHandlers.toString(codes));
				FileLog.Log("Done patch "+MethodBase.GetCurrentMethod().DeclaringType);
			}
			catch (Exception e) {
				FileLog.Log("Caught exception when running patch "+MethodBase.GetCurrentMethod().DeclaringType+"!");
				FileLog.Log(e.Message);
				FileLog.Log(e.StackTrace);
				FileLog.Log(e.ToString());
			}
			return codes.AsEnumerable();
		}
	
		private static CodeInstruction[] injectModuleHook() {
			List<CodeInstruction> codes = new List<CodeInstruction>();
			codes.Add(new CodeInstruction(OpCodes.Ldarg_0));
			codes.Add(new CodeInstruction(OpCodes.Ldarg_1));
			codes.Add(new CodeInstruction(OpCodes.Ldarg_2));
			codes.Add(InstructionHandlers.createMethodCall("ReikaKalseki.DIAlterra.DIHooks", "useSeamothModule", false, typeof(SeaMoth), typeof(TechType), typeof(int)));
			return codes.ToArray();
		}
	}
	
	[HarmonyPatch(typeof(CellManager))]
	[HarmonyPatch("RegisterEntity", typeof(LargeWorldEntity))]
	public static class EntityRegisterBypass {
		
		static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions) {
			List<CodeInstruction> codes = new List<CodeInstruction>(instructions);
			try {
				InstructionHandlers.patchInitialHook(codes, new CodeInstruction(OpCodes.Ldarg_0), new CodeInstruction(OpCodes.Ldarg_1), InstructionHandlers.createMethodCall("ReikaKalseki.DIAlterra.DIHooks", "onEntityRegister", false, typeof(CellManager), typeof(LargeWorldEntity)));
				FileLog.Log("Done patch "+MethodBase.GetCurrentMethod().DeclaringType);
			}
			catch (Exception e) {
				FileLog.Log("Caught exception when running patch "+MethodBase.GetCurrentMethod().DeclaringType+"!");
				FileLog.Log(e.Message);
				FileLog.Log(e.StackTrace);
				FileLog.Log(e.ToString());
			}
			return codes.AsEnumerable();
		}
	}
	
	[HarmonyPatch(typeof(Player))]
	[HarmonyPatch("Update")]
	public static class PlayerTick {
		
		static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions) {
			List<CodeInstruction> codes = new List<CodeInstruction>(instructions);
			try {
				PatchLib.injectTickHook(codes, "tickPlayer", typeof(Player));
				FileLog.Log("Done patch "+MethodBase.GetCurrentMethod().DeclaringType);
			}
			catch (Exception e) {
				FileLog.Log("Caught exception when running patch "+MethodBase.GetCurrentMethod().DeclaringType+"!");
				FileLog.Log(e.Message);
				FileLog.Log(e.StackTrace);
				FileLog.Log(e.ToString());
			}
			return codes.AsEnumerable();
		}
	}
	
	[HarmonyPatch(typeof(SeaMoth))]
	[HarmonyPatch("Update")]
	public static class SeaMothTick {
		
		static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions) {
			List<CodeInstruction> codes = new List<CodeInstruction>(instructions);
			try {
				PatchLib.injectTickHook(codes, "tickSeamoth", typeof(SeaMoth));
				FileLog.Log("Done patch "+MethodBase.GetCurrentMethod().DeclaringType);
			}
			catch (Exception e) {
				FileLog.Log("Caught exception when running patch "+MethodBase.GetCurrentMethod().DeclaringType+"!");
				FileLog.Log(e.Message);
				FileLog.Log(e.StackTrace);
				FileLog.Log(e.ToString());
			}
			return codes.AsEnumerable();
		}
	}
	
	[HarmonyPatch(typeof(Exosuit))]
	[HarmonyPatch("Update")]
	public static class ExosuitTick {
		
		static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions) {
			List<CodeInstruction> codes = new List<CodeInstruction>(instructions);
			try {
				PatchLib.injectTickHook(codes, "tickPrawn", typeof(Exosuit));
				FileLog.Log("Done patch "+MethodBase.GetCurrentMethod().DeclaringType);
			}
			catch (Exception e) {
				FileLog.Log("Caught exception when running patch "+MethodBase.GetCurrentMethod().DeclaringType+"!");
				FileLog.Log(e.Message);
				FileLog.Log(e.StackTrace);
				FileLog.Log(e.ToString());
			}
			return codes.AsEnumerable();
		}
	}
	
	[HarmonyPatch(typeof(SubRoot))]
	[HarmonyPatch("Update")]
	public static class SubTick {
		
		static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions) {
			List<CodeInstruction> codes = new List<CodeInstruction>(instructions);
			try {
				PatchLib.injectTickHook(codes, "tickSub", typeof(SubRoot));
				FileLog.Log("Done patch "+MethodBase.GetCurrentMethod().DeclaringType);
			}
			catch (Exception e) {
				FileLog.Log("Caught exception when running patch "+MethodBase.GetCurrentMethod().DeclaringType+"!");
				FileLog.Log(e.Message);
				FileLog.Log(e.StackTrace);
				FileLog.Log(e.ToString());
			}
			return codes.AsEnumerable();
		}
	}
	
	[HarmonyPatch(typeof(WaterTemperatureSimulation), "GetTemperature", new Type[]{typeof(Vector3)})]
	public static class WaterTempOverride {
		
		static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions) {
			List<CodeInstruction> codes = new List<CodeInstruction>(instructions);
			try {
				InstructionHandlers.patchEveryReturnPre(codes, injectHook);
				FileLog.Log("Done patch "+MethodBase.GetCurrentMethod().DeclaringType);
			}
			catch (Exception e) {
				FileLog.Log("Caught exception when running patch "+MethodBase.GetCurrentMethod().DeclaringType+"!");
				FileLog.Log(e.Message);
				FileLog.Log(e.StackTrace);
				FileLog.Log(e.ToString());
			}
			return codes.AsEnumerable();
		}
	
		private static void injectHook(List<CodeInstruction> codes, int idx) {
			codes.Insert(idx, InstructionHandlers.createMethodCall("ReikaKalseki.DIAlterra.DIHooks", "getWaterTemperature", false, typeof(float), typeof(WaterTemperatureSimulation), typeof(Vector3)));
			codes.Insert(idx, new CodeInstruction(OpCodes.Ldarg_1));
			codes.Insert(idx, new CodeInstruction(OpCodes.Ldarg_0));
		}
	}
	
	[HarmonyPatch(typeof(Pickupable))]
	[HarmonyPatch("Pickup")]
	public static class OnPlayerPickup {
		
		static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions) {
			List<CodeInstruction> codes = new List<CodeInstruction>(instructions);
			try {
				int idx = InstructionHandlers.getInstruction(codes, 0, 0, OpCodes.Call, "Pickupable", "PlayPickupSound", true, new Type[0]);
				codes.Insert(idx, new CodeInstruction(OpCodes.Ldarg_0));
				codes.Insert(idx, InstructionHandlers.createMethodCall("ReikaKalseki.DIAlterra.DIHooks", "onItemPickedUp", false, typeof(Pickupable)));
				FileLog.Log("Done patch "+MethodBase.GetCurrentMethod().DeclaringType);
			}
			catch (Exception e) {
				FileLog.Log("Caught exception when running patch "+MethodBase.GetCurrentMethod().DeclaringType+"!");
				FileLog.Log(e.Message);
				FileLog.Log(e.StackTrace);
				FileLog.Log(e.ToString());
			}
			return codes.AsEnumerable();
		}
	}
	
	[HarmonyPatch(typeof(DamageSystem))]
	[HarmonyPatch("CalculateDamage")]
	public static class DamageCalcHook {
		
		static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions) {
			List<CodeInstruction> codes = new List<CodeInstruction>(instructions);
			try {
				int idx = InstructionHandlers.getInstruction(codes, 0, 0, OpCodes.Ret);
				codes.Insert(idx, InstructionHandlers.createMethodCall("ReikaKalseki.DIAlterra.DIHooks", "recalculateDamage", false, typeof(float), typeof(DamageType), typeof(GameObject), typeof(GameObject)));
				codes.Insert(idx, new CodeInstruction(OpCodes.Ldarg_3));
				codes.Insert(idx, new CodeInstruction(OpCodes.Ldarg_2));
				codes.Insert(idx, new CodeInstruction(OpCodes.Ldarg_1));
				//already present//codes.Insert(idx, new CodeInstruction(OpCodes.Ldarg_0));
				FileLog.Log("Done patch "+MethodBase.GetCurrentMethod().DeclaringType);
			}
			catch (Exception e) {
				FileLog.Log("Caught exception when running patch "+MethodBase.GetCurrentMethod().DeclaringType+"!");
				FileLog.Log(e.Message);
				FileLog.Log(e.StackTrace);
				FileLog.Log(e.ToString());
			}
			return codes.AsEnumerable();
		}
	}
	
	[HarmonyPatch(typeof(SkyApplier))]
	[HarmonyPatch("Awake")]
	public static class SkyApplierSpawnHook {
		
		static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions) {
			List<CodeInstruction> codes = new List<CodeInstruction>(instructions);
			try {
				InstructionHandlers.patchInitialHook(codes, new CodeInstruction(OpCodes.Ldarg_0), InstructionHandlers.createMethodCall("ReikaKalseki.DIAlterra.DIHooks", "onSkyApplierSpawn", false, typeof(SkyApplier)));
				FileLog.Log("Done patch "+MethodBase.GetCurrentMethod().DeclaringType);
			}
			catch (Exception e) {
				FileLog.Log("Caught exception when running patch "+MethodBase.GetCurrentMethod().DeclaringType+"!");
				FileLog.Log(e.Message);
				FileLog.Log(e.StackTrace);
				FileLog.Log(e.ToString());
			}
			return codes.AsEnumerable();
		}
	}
	
	[HarmonyPatch(typeof(GrowingPlant))]
	[HarmonyPatch("SpawnGrownModel")]
	public static class PlantFinishedGrowingHook {
		
		static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions) {
			List<CodeInstruction> codes = new List<CodeInstruction>(instructions);
			try {
				InstructionHandlers.patchEveryReturnPre(codes, injectCallback);
				//FileLog.Log("Codes are "+InstructionHandlers.toString(codes));
				FileLog.Log("Done patch "+MethodBase.GetCurrentMethod().DeclaringType);
			}
			catch (Exception e) {
				FileLog.Log("Caught exception when running patch "+MethodBase.GetCurrentMethod().DeclaringType+"!");
				FileLog.Log(e.Message);
				FileLog.Log(e.StackTrace);
				FileLog.Log(e.ToString());
			}
			return codes.AsEnumerable();
		}
	
		private static void injectCallback(List<CodeInstruction> codes, int idx) {
			codes.Insert(idx, InstructionHandlers.createMethodCall("ReikaKalseki.DIAlterra.DIHooks", "onFarmedPlantGrowDone", false, typeof(GrowingPlant), typeof(GameObject)));
			codes.Insert(idx, new CodeInstruction(OpCodes.Ldloc_0));
			codes.Insert(idx, new CodeInstruction(OpCodes.Ldarg_0));
		}
	}
	
	[HarmonyPatch(typeof(Plantable))]
	[HarmonyPatch("Spawn")]
	public static class PlantSpawnsGrowingHook {
		
		static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions) {
			List<CodeInstruction> codes = new List<CodeInstruction>(instructions);
			try {
				int idx = InstructionHandlers.getInstruction(codes, 0, 0, OpCodes.Stloc_0)+1;
				codes.Insert(idx, InstructionHandlers.createMethodCall("ReikaKalseki.DIAlterra.DIHooks", "onFarmedPlantGrowingSpawn", false, typeof(Plantable), typeof(GameObject)));
				codes.Insert(idx, new CodeInstruction(OpCodes.Ldloc_0));
				codes.Insert(idx, new CodeInstruction(OpCodes.Ldarg_0));
				//FileLog.Log("Codes are "+InstructionHandlers.toString(codes));
				FileLog.Log("Done patch "+MethodBase.GetCurrentMethod().DeclaringType);
			}
			catch (Exception e) {
				FileLog.Log("Caught exception when running patch "+MethodBase.GetCurrentMethod().DeclaringType+"!");
				FileLog.Log(e.Message);
				FileLog.Log(e.StackTrace);
				FileLog.Log(e.ToString());
			}
			return codes.AsEnumerable();
		}
	
		private static void injectCallback(List<CodeInstruction> codes, int idx) {
			codes.Insert(idx, InstructionHandlers.createMethodCall("ReikaKalseki.DIAlterra.DIHooks", "onFarmedPlantGrowDone", false, typeof(GrowingPlant), typeof(GameObject)));
			codes.Insert(idx, new CodeInstruction(OpCodes.Ldloc_0));
			codes.Insert(idx, new CodeInstruction(OpCodes.Ldarg_0));
		}
	}
	
	[HarmonyPatch(typeof(Survival))]
	[HarmonyPatch("Use")]
	public static class ItemUseReimplementation {
		
		static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions) {
			List<CodeInstruction> codes = new List<CodeInstruction>();
			try {
				codes.Add(new CodeInstruction(OpCodes.Ldarg_0));
				codes.Add(new CodeInstruction(OpCodes.Ldarg_1));
				codes.Add(InstructionHandlers.createMethodCall("ReikaKalseki.DIAlterra.DIHooks", "useItem", false, typeof(Survival), typeof(GameObject)));
				codes.Add(new CodeInstruction(OpCodes.Ret));
				FileLog.Log("Done patch "+MethodBase.GetCurrentMethod().DeclaringType);
			}
			catch (Exception e) {
				FileLog.Log("Caught exception when running patch "+MethodBase.GetCurrentMethod().DeclaringType+"!");
				FileLog.Log(e.Message);
				FileLog.Log(e.StackTrace);
				FileLog.Log(e.ToString());
			}
			return codes.AsEnumerable();
		}
	}
	
	[HarmonyPatch(typeof(CraftData))]
	[HarmonyPatch("IsInvUseable")]
	public static class ItemUsabilityHook {
		
		static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions) {
			List<CodeInstruction> codes = new List<CodeInstruction>();
			try {
				codes.Add(new CodeInstruction(OpCodes.Ldarg_0));
				codes.Add(InstructionHandlers.createMethodCall("ReikaKalseki.DIAlterra.DIHooks", "isItemUsable", false, typeof(TechType)));
				codes.Add(new CodeInstruction(OpCodes.Ret));
				FileLog.Log("Done patch "+MethodBase.GetCurrentMethod().DeclaringType);
			}
			catch (Exception e) {
				FileLog.Log("Caught exception when running patch "+MethodBase.GetCurrentMethod().DeclaringType+"!");
				FileLog.Log(e.Message);
				FileLog.Log(e.StackTrace);
				FileLog.Log(e.ToString());
			}
			return codes.AsEnumerable();
		}
	}
	
	[HarmonyPatch(typeof(PDAScanner))]
	[HarmonyPatch("Unlock")]
	public static class ScanHook {
		
		static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions) {
			List<CodeInstruction> codes = new List<CodeInstruction>(instructions);
			try {
				InstructionHandlers.patchInitialHook(codes, new CodeInstruction(OpCodes.Ldarg_0), InstructionHandlers.createMethodCall("ReikaKalseki.DIAlterra.DIHooks", "onScanComplete", false, typeof(PDAScanner.EntryData)));
				FileLog.Log("Done patch "+MethodBase.GetCurrentMethod().DeclaringType);
			}
			catch (Exception e) {
				FileLog.Log("Caught exception when running patch "+MethodBase.GetCurrentMethod().DeclaringType+"!");
				FileLog.Log(e.Message);
				FileLog.Log(e.StackTrace);
				FileLog.Log(e.ToString());
			}
			return codes.AsEnumerable();
		}
	}
	
	[HarmonyPatch(typeof(Sealed))]
	[HarmonyPatch("Weld")]
	public static class SealedOverhaul {
		
		static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions) {
			List<CodeInstruction> codes = new List<CodeInstruction>();
			try {
				codes.Add(new CodeInstruction(OpCodes.Ldarg_0));
				codes.Add(new CodeInstruction(OpCodes.Ldarg_1));
				codes.Add(InstructionHandlers.createMethodCall("ReikaKalseki.DIAlterra.DIHooks", "tickLaserCutting", false, typeof(Sealed), typeof(float)));
				codes.Add(new CodeInstruction(OpCodes.Ret));
				FileLog.Log("Done patch "+MethodBase.GetCurrentMethod().DeclaringType);
			}
			catch (Exception e) {
				FileLog.Log("Caught exception when running patch "+MethodBase.GetCurrentMethod().DeclaringType+"!");
				FileLog.Log(e.Message);
				FileLog.Log(e.StackTrace);
				FileLog.Log(e.ToString());
			}
			return codes.AsEnumerable();
		}
	}
	
	[HarmonyPatch(typeof(BulkheadDoor))]
	[HarmonyPatch("OnHandHover")]
	public static class BulkheadLaserCutterNotice {
		
		static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions) {
			List<CodeInstruction> codes = new List<CodeInstruction>();
			try {/*
				int idx = InstructionHandlers.getInstruction(codes, 0, 0, OpCodes.Callvirt, "HandReticle", "SetInteractText", true, new Type[]{typeof(string)});
				codes.Insert(idx, new CodeInstruction(OpCodes.Ldarg_0));
				codes.Insert(idx, InstructionHandlers.createMethodCall("ReikaKalseki.DIAlterra.DIHooks", "getBulkheadMouseoverText", false, typeof(string), typeof(BulkheadDoor)));
				FileLog.Log("Codes are "+InstructionHandlers.toString(codes));*/
				codes.Add(new CodeInstruction(OpCodes.Ldarg_0));
				codes.Add(InstructionHandlers.createMethodCall("ReikaKalseki.DIAlterra.DIHooks", "getBulkheadMouseoverText", false, typeof(BulkheadDoor)));
				codes.Add(new CodeInstruction(OpCodes.Ret));
				FileLog.Log("Done patch "+MethodBase.GetCurrentMethod().DeclaringType);
			}
			catch (Exception e) {
				FileLog.Log("Caught exception when running patch "+MethodBase.GetCurrentMethod().DeclaringType+"!");
				FileLog.Log(e.Message);
				FileLog.Log(e.StackTrace);
				FileLog.Log(e.ToString());
			}
			return codes.AsEnumerable();
		}
	}
	
	[HarmonyPatch(typeof(BulkheadDoor))]
	[HarmonyPatch("OnHandClick")]
	public static class BulkheadDoorClickIntercept {
		
		static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions) {
			List<CodeInstruction> codes = new List<CodeInstruction>();
			try {
				codes.Add(new CodeInstruction(OpCodes.Ldarg_0));
				codes.Add(InstructionHandlers.createMethodCall("ReikaKalseki.DIAlterra.DIHooks", "onBulkheadClick", false, typeof(BulkheadDoor)));
				codes.Add(new CodeInstruction(OpCodes.Ret));
				//FileLog.Log("Codes are "+InstructionHandlers.toString(codes));
				FileLog.Log("Done patch "+MethodBase.GetCurrentMethod().DeclaringType);
			}
			catch (Exception e) {
				FileLog.Log("Caught exception when running patch "+MethodBase.GetCurrentMethod().DeclaringType+"!");
				FileLog.Log(e.Message);
				FileLog.Log(e.StackTrace);
				FileLog.Log(e.ToString());
			}
			return codes.AsEnumerable();
		}
	}
	
	[HarmonyPatch(typeof(SeaMoth))]
	[HarmonyPatch("OnHoverTorpedoStorage")]
	public static class SeamothTorpedoHoverHooks {
		
		static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions) {
			List<CodeInstruction> codes = new List<CodeInstruction>();
			try {
				codes.Add(new CodeInstruction(OpCodes.Ldarg_0));
				codes.Add(new CodeInstruction(OpCodes.Ldarg_1));
				codes.Add(InstructionHandlers.createMethodCall("ReikaKalseki.DIAlterra.DIHooks", "hoverSeamothTorpedoStorage", false, typeof(SeaMoth), typeof(HandTargetEventData)));
				codes.Add(new CodeInstruction(OpCodes.Ret));
				FileLog.Log("Done patch "+MethodBase.GetCurrentMethod().DeclaringType);
			}
			catch (Exception e) {
				FileLog.Log("Caught exception when running patch "+MethodBase.GetCurrentMethod().DeclaringType+"!");
				FileLog.Log(e.Message);
				FileLog.Log(e.StackTrace);
				FileLog.Log(e.ToString());
			}
			return codes.AsEnumerable();
		}
	}
	
	[HarmonyPatch(typeof(SeaMoth))]
	[HarmonyPatch("OpenTorpedoStorage")]
	public static class SeamothTorpedoClickHooks {
		
		static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions) {
			List<CodeInstruction> codes = new List<CodeInstruction>();
			try {
				codes.Add(new CodeInstruction(OpCodes.Ldarg_0));
				codes.Add(new CodeInstruction(OpCodes.Ldarg_1));
				codes.Add(InstructionHandlers.createMethodCall("ReikaKalseki.DIAlterra.DIHooks", "openSeamothTorpedoStorage", false, typeof(SeaMoth), typeof(Transform)));
				codes.Add(new CodeInstruction(OpCodes.Ret));
				FileLog.Log("Done patch "+MethodBase.GetCurrentMethod().DeclaringType);
			}
			catch (Exception e) {
				FileLog.Log("Caught exception when running patch "+MethodBase.GetCurrentMethod().DeclaringType+"!");
				FileLog.Log(e.Message);
				FileLog.Log(e.StackTrace);
				FileLog.Log(e.ToString());
			}
			return codes.AsEnumerable();
		}
	}
	
	[HarmonyPatch(typeof(TemperatureDamage))]
	[HarmonyPatch("GetTemperature")]
	public static class TemperatureDamageGetOverride {
		
		static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions) {
			List<CodeInstruction> codes = new List<CodeInstruction>();
			try {
				codes.Add(new CodeInstruction(OpCodes.Ldarg_0));
				codes.Add(InstructionHandlers.createMethodCall("ReikaKalseki.DIAlterra.DIHooks", "getTemperatureForDamage", false, typeof(TemperatureDamage)));
				codes.Add(new CodeInstruction(OpCodes.Ret));
				FileLog.Log("Done patch "+MethodBase.GetCurrentMethod().DeclaringType);
			}
			catch (Exception e) {
				FileLog.Log("Caught exception when running patch "+MethodBase.GetCurrentMethod().DeclaringType+"!");
				FileLog.Log(e.Message);
				FileLog.Log(e.StackTrace);
				FileLog.Log(e.ToString());
			}
			return codes.AsEnumerable();
		}
	}
	
	[HarmonyPatch(typeof(UseableDiveHatch))]
	[HarmonyPatch("IsInside")]
	public static class HatchInsideHook {
		
		static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions) {
			List<CodeInstruction> codes = new List<CodeInstruction>();
			try {
				codes.Add(new CodeInstruction(OpCodes.Ldarg_0));
				codes.Add(InstructionHandlers.createMethodCall("ReikaKalseki.DIAlterra.DIHooks", "isInsideForHatch", false, typeof(UseableDiveHatch)));
				codes.Add(new CodeInstruction(OpCodes.Ret));
				FileLog.Log("Done patch "+MethodBase.GetCurrentMethod().DeclaringType);
			}
			catch (Exception e) {
				FileLog.Log("Caught exception when running patch "+MethodBase.GetCurrentMethod().DeclaringType+"!");
				FileLog.Log(e.Message);
				FileLog.Log(e.StackTrace);
				FileLog.Log(e.ToString());
			}
			return codes.AsEnumerable();
		}
	}
	
	[HarmonyPatch(typeof(LargeWorld), "GetBiome", new Type[]{typeof(Vector3)})]
	public static class BiomeFetchHook {
		
		static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions) {
			List<CodeInstruction> codes = new List<CodeInstruction>(instructions);
			try {		
				InstructionHandlers.patchEveryReturnPre(codes, injectHook);
				FileLog.Log("Done patch "+MethodBase.GetCurrentMethod().DeclaringType);
			}
			catch (Exception e) {
				FileLog.Log("Caught exception when running patch "+MethodBase.GetCurrentMethod().DeclaringType+"!");
				FileLog.Log(e.Message);
				FileLog.Log(e.StackTrace);
				FileLog.Log(e.ToString());
			}
			return codes.AsEnumerable();
		}
	
		private static void injectHook(List<CodeInstruction> codes, int idx) {
			codes.Insert(idx, InstructionHandlers.createMethodCall("ReikaKalseki.DIAlterra.DIHooks", "getBiomeAt", false, typeof(string), typeof(Vector3)));
			codes.Insert(idx, new CodeInstruction(OpCodes.Ldarg_1));
		}
	}
	
	[HarmonyPatch(typeof(Constructable))]
	[HarmonyPatch("SetState")]
	public static class ConstructionHook {
		
		static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions) {
			List<CodeInstruction> codes = new List<CodeInstruction>(instructions);
			try {
				int idx = InstructionHandlers.getInstruction(codes, 0, 0, OpCodes.Call, "Story.ItemGoalTracker", "OnConstruct", false, new Type[]{typeof(TechType)});
				codes[idx].operand = InstructionHandlers.convertMethodOperand("ReikaKalseki.DIAlterra.DIHooks", "onConstructionComplete", false, new Type[]{typeof(TechType), typeof(Constructable)});
				codes.Insert(idx, new CodeInstruction(OpCodes.Ldarg_0));
				FileLog.Log("Done patch "+MethodBase.GetCurrentMethod().DeclaringType);
			}
			catch (Exception e) {
				FileLog.Log("Caught exception when running patch "+MethodBase.GetCurrentMethod().DeclaringType+"!");
				FileLog.Log(e.Message);
				FileLog.Log(e.StackTrace);
				FileLog.Log(e.ToString());
			}
			return codes.AsEnumerable();
		}
	}
	
	[HarmonyPatch(typeof(Knife))]
	[HarmonyPatch("OnToolUseAnim")]
	public static class KnifeHook {
		
		static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions) {
			List<CodeInstruction> codes = new List<CodeInstruction>(instructions);
			try {
				int idx = InstructionHandlers.getInstruction(codes, 0, 0, OpCodes.Call, "Utils", "PlayFMODAsset", false, new Type[]{typeof(FMODAsset), typeof(Transform), typeof(float)});
				codes.Insert(idx+1, InstructionHandlers.createMethodCall("ReikaKalseki.DIAlterra.DIHooks", "onKnifed", false, typeof(GameObject)));
				codes.Insert(idx+1, new CodeInstruction(OpCodes.Ldloc_1));
				FileLog.Log("Done patch "+MethodBase.GetCurrentMethod().DeclaringType);
			}
			catch (Exception e) {
				FileLog.Log("Caught exception when running patch "+MethodBase.GetCurrentMethod().DeclaringType+"!");
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
				InstructionHandlers.patchInitialHook(codes, new CodeInstruction(OpCodes.Ldarg_0), InstructionHandlers.createMethodCall("ReikaKalseki.DIAlterra.DIHooks", "onPopup", false, typeof(uGUI_PopupNotification)));
				FileLog.Log("Done patch "+MethodBase.GetCurrentMethod().DeclaringType);
			}
			catch (Exception e) {
				FileLog.Log("Caught exception when running patch "+MethodBase.GetCurrentMethod().DeclaringType+"!");
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
	public static class WaterParkFix {
		
		static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions) {
			List<CodeInstruction> codes = new List<CodeInstruction>(instructions);
			try {
				int idx = InstructionHandlers.getInstruction(codes, 0, 0, OpCodes.Callvirt, "UnityEngine.GameObject", "SetActive", true, new Type[]{typeof(bool)});
				codes.Insert(idx+1, InstructionHandlers.createMethodCall("ReikaKalseki.DIAlterra.DIHooks", "onEggHatched", false, typeof(GameObject)));
				codes.Insert(idx+1, new CodeInstruction(OpCodes.Ldloc_0));
				FileLog.Log("Done patch "+MethodBase.GetCurrentMethod().DeclaringType);
			}
			catch (Exception e) {
				FileLog.Log("Caught exception when running patch "+MethodBase.GetCurrentMethod().DeclaringType+"!");
				FileLog.Log(e.Message);
				FileLog.Log(e.StackTrace);
				FileLog.Log(e.ToString());
			}
			return codes.AsEnumerable();
		}
	}
	
	[HarmonyPatch(typeof(TooltipFactory))]
	[HarmonyPatch("ItemCommons")]
	public static class CustomTooltipHooks {
		
		static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions) {
			List<CodeInstruction> codes = new List<CodeInstruction>(instructions);
			try {
				InstructionHandlers.patchEveryReturnPre(codes, new CodeInstruction(OpCodes.Ldarg_0), new CodeInstruction(OpCodes.Ldarg_1), new CodeInstruction(OpCodes.Ldarg_2), InstructionHandlers.createMethodCall("ReikaKalseki.DIAlterra.DIHooks", "appendItemTooltip", false, typeof(System.Text.StringBuilder), typeof(TechType), typeof(GameObject)));
				int idx = codes.Count-1;
				codes[idx].MoveLabelsTo(codes[idx-4]);
				//FileLog.Log("Codes are "+InstructionHandlers.toString(codes));
				FileLog.Log("Done patch "+MethodBase.GetCurrentMethod().DeclaringType);
			}
			catch (Exception e) {
				FileLog.Log("Caught exception when running patch "+MethodBase.GetCurrentMethod().DeclaringType+"!");
				FileLog.Log(e.Message);
				FileLog.Log(e.StackTrace);
				FileLog.Log(e.ToString());
			}
			return codes.AsEnumerable();
		}
	}
	
	[HarmonyPatch(typeof(EMPBlast))]
	[HarmonyPatch("OnTouch")]
	public static class EMPBlastHooks {
		
		static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions) {
			List<CodeInstruction> codes = new List<CodeInstruction>(instructions);
			try {
				for (int i = codes.Count-1; i >= 0; i--) {
					if (codes[i].opcode == OpCodes.Callvirt) {
						MethodInfo mi = (MethodInfo)codes[i].operand;
						if (mi.Name == "DisableElectronicsForTime") {
							PatchLib.injectEMPHook(codes, i);
						}
					}
				}
				InstructionHandlers.patchInitialHook(codes, new CodeInstruction(OpCodes.Ldarg_0), new CodeInstruction(OpCodes.Ldarg_1), InstructionHandlers.createMethodCall("ReikaKalseki.DIAlterra.DIHooks", "onEMPTouch", false, typeof(EMPBlast), typeof(Collider)));
				FileLog.Log("Done patch "+MethodBase.GetCurrentMethod().DeclaringType);
			}
			catch (Exception e) {
				FileLog.Log("Caught exception when running patch "+MethodBase.GetCurrentMethod().DeclaringType+"!");
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
				codes[idx].operand = InstructionHandlers.convertMethodOperand("ReikaKalseki.DIAlterra.DIHooks", "interceptConstructability", false, typeof(Collider));
				FileLog.Log("Done patch "+MethodBase.GetCurrentMethod().DeclaringType);
			}
			catch (Exception e) {
				FileLog.Log("Caught exception when running patch "+MethodBase.GetCurrentMethod().DeclaringType+"!");
				FileLog.Log(e.Message);
				FileLog.Log(e.StackTrace);
				FileLog.Log(e.ToString());
			}
			return codes.AsEnumerable();
		}
	}*/
	[HarmonyPatch(typeof(Builder))]
	[HarmonyPatch("Update")]
	public static class ConstructableBuildabilityHook {
		
		static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions) {
			List<CodeInstruction> codes = new List<CodeInstruction>(instructions);
			try {
				int idx = InstructionHandlers.getInstruction(codes, 0, 0, OpCodes.Call, "Builder", "UpdateAllowed", false, new Type[0]);
				codes[idx].operand = InstructionHandlers.convertMethodOperand("ReikaKalseki.DIAlterra.DIHooks", "interceptConstructability", false, new Type[0]);
				FileLog.Log("Done patch "+MethodBase.GetCurrentMethod().DeclaringType);
			}
			catch (Exception e) {
				FileLog.Log("Caught exception when running patch "+MethodBase.GetCurrentMethod().DeclaringType+"!");
				FileLog.Log(e.Message);
				FileLog.Log(e.StackTrace);
				FileLog.Log(e.ToString());
			}
			return codes.AsEnumerable();
		}
	}
	
	[HarmonyPatch(typeof(WaterscapeVolume))]
	[HarmonyPatch("PreRender")]
	public static class WaterFogShaderHook {
		
		static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions) {
			List<CodeInstruction> codes = new List<CodeInstruction>(instructions);
			try {
				InstructionHandlers.patchEveryReturnPre(codes, new CodeInstruction(OpCodes.Ldarg_0), new CodeInstruction(OpCodes.Ldarg_1), InstructionHandlers.createMethodCall("ReikaKalseki.DIAlterra.DIHooks", "interceptChosenFog", false, typeof(WaterscapeVolume), typeof(Camera)));
				FileLog.Log("Done patch "+MethodBase.GetCurrentMethod().DeclaringType);
			}
			catch (Exception e) {
				FileLog.Log("Caught exception when running patch "+MethodBase.GetCurrentMethod().DeclaringType+"!");
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
				codes.Insert(idx, InstructionHandlers.createMethodCall("ReikaKalseki.DIAlterra.DIHooks", "getPowerRelayCapacity", false, typeof(float), typeof(PowerRelay)));
				codes.Insert(idx, new CodeInstruction(OpCodes.Ldarg_0));
				FileLog.Log("Done patch "+MethodBase.GetCurrentMethod().DeclaringType);
				//FileLog.Log("Codes are "+InstructionHandlers.toString(codes));
			}
			catch (Exception e) {
				FileLog.Log("Caught exception when running patch "+MethodBase.GetCurrentMethod().DeclaringType+"!");
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
	public static class SolarPanelPowerRedirect {
		
		static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions) {
			List<CodeInstruction> codes = new List<CodeInstruction>();
			try {/* BZ code
				int idx = InstructionHandlers.getInstruction(codes, 0, 0, OpCodes.Callvirt, "PowerRelay", "ModifyPower", true, new Type[]{typeof(float), typeof(float).MakeByRefType()});
				codes[idx].operand = InstructionHandlers.convertMethodOperand("ReikaKalseki.DIAlterra.DIHooks", "addPowerToSeabaseDelegate", false, typeof(IPowerInterface), typeof(float), typeof(float).MakeByRefType(), typeof(MonoBehaviour));
				codes.Insert(idx, new CodeInstruction(OpCodes.Ldarg_0));
				*/
				/*
				int idx = InstructionHandlers.getInstruction(codes, 0, 0, OpCodes.Stfld, "PowerSource", "power");
				codes[idx] = InstructionHandlers.createMethodCall("ReikaKalseki.DIAlterra.DIHooks", "addPowerToSeabaseDelegateViaPowerSourceSet", false, typeof(PowerSource), typeof(float), typeof(MonoBehaviour));
				codes.Insert(idx, new CodeInstruction(OpCodes.Ldarg_0));
				*/
				codes.Add(new CodeInstruction(OpCodes.Ldarg_0));
				codes.Add(InstructionHandlers.createMethodCall("ReikaKalseki.DIAlterra.DIHooks", "updateSolarPanel", false, typeof(SolarPanel)));
				codes.Add(new CodeInstruction(OpCodes.Ret));
				FileLog.Log("Done patch "+MethodBase.GetCurrentMethod().DeclaringType);
				//FileLog.Log("Codes are "+InstructionHandlers.toString(codes));
			}
			catch (Exception e) {
				FileLog.Log("Caught exception when running patch "+MethodBase.GetCurrentMethod().DeclaringType+"!");
				FileLog.Log(e.Message);
				FileLog.Log(e.StackTrace);
				FileLog.Log(e.ToString());
			}
			return codes.AsEnumerable();
		}
	}
	
	[HarmonyPatch(typeof(ThermalPlant))]
	[HarmonyPatch("AddPower")]
	public static class ThermalPlantPowerRedirect {
		
		static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions) {
			List<CodeInstruction> codes = new List<CodeInstruction>(instructions);
			try {
				PatchLib.redirectPowerHook(codes);
				FileLog.Log("Done patch "+MethodBase.GetCurrentMethod().DeclaringType);
				//FileLog.Log("Codes are "+InstructionHandlers.toString(codes));
			}
			catch (Exception e) {
				FileLog.Log("Caught exception when running patch "+MethodBase.GetCurrentMethod().DeclaringType+"!");
				FileLog.Log(e.Message);
				FileLog.Log(e.StackTrace);
				FileLog.Log(e.ToString());
			}
			return codes.AsEnumerable();
		}
	}
	
	[HarmonyPatch(typeof(BaseBioReactor))]
	[HarmonyPatch("Update")]
	public static class BioreactorPowerRedirect {
		
		static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions) {
			List<CodeInstruction> codes = new List<CodeInstruction>(instructions);
			try {
				PatchLib.redirectPowerHook(codes);
				FileLog.Log("Done patch "+MethodBase.GetCurrentMethod().DeclaringType);
				//FileLog.Log("Codes are "+InstructionHandlers.toString(codes));
			}
			catch (Exception e) {
				FileLog.Log("Caught exception when running patch "+MethodBase.GetCurrentMethod().DeclaringType+"!");
				FileLog.Log(e.Message);
				FileLog.Log(e.StackTrace);
				FileLog.Log(e.ToString());
			}
			return codes.AsEnumerable();
		}
	}
	
	[HarmonyPatch(typeof(BaseNuclearReactor))]
	[HarmonyPatch("Update")]
	public static class NucReactorPowerRedirect {
		
		static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions) {
			List<CodeInstruction> codes = new List<CodeInstruction>(instructions);
			try {
				PatchLib.redirectPowerHook(codes);
				FileLog.Log("Done patch "+MethodBase.GetCurrentMethod().DeclaringType);
				//FileLog.Log("Codes are "+InstructionHandlers.toString(codes));
			}
			catch (Exception e) {
				FileLog.Log("Caught exception when running patch "+MethodBase.GetCurrentMethod().DeclaringType+"!");
				FileLog.Log(e.Message);
				FileLog.Log(e.StackTrace);
				FileLog.Log(e.ToString());
			}
			return codes.AsEnumerable();
		}
	}
	
	[HarmonyPatch(typeof(StoryHandTarget))]
	[HarmonyPatch("OnHandClick")]
	public static class StoryHandIntercept {
		
		static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions) {
			List<CodeInstruction> codes = new List<CodeInstruction>();
			try {
				codes.Add(new CodeInstruction(OpCodes.Ldarg_0));
				codes.Add(InstructionHandlers.createMethodCall("ReikaKalseki.DIAlterra.DIHooks", "clickStoryHandTarget", false, typeof(StoryHandTarget)));
				codes.Add(new CodeInstruction(OpCodes.Ret));
				FileLog.Log("Done patch "+MethodBase.GetCurrentMethod().DeclaringType);
				//FileLog.Log("Codes are "+InstructionHandlers.toString(codes));
			}
			catch (Exception e) {
				FileLog.Log("Caught exception when running patch "+MethodBase.GetCurrentMethod().DeclaringType+"!");
				FileLog.Log(e.Message);
				FileLog.Log(e.StackTrace);
				FileLog.Log(e.ToString());
			}
			return codes.AsEnumerable();
		}
	}
	
	[HarmonyPatch(typeof(Player))]
	[HarmonyPatch("SetRadiationAmount")]
	public static class RadiationAmountIntercept {
		
		static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions) {
			List<CodeInstruction> codes = new List<CodeInstruction>(instructions);
			try {
				int idx = InstructionHandlers.getFirstOpcode(codes, 0, OpCodes.Stfld);
				codes.Insert(idx, InstructionHandlers.createMethodCall("ReikaKalseki.DIAlterra.DIHooks", "getRadiationLevel", false, typeof(Player), typeof(float)));
				codes.Insert(0, new CodeInstruction(OpCodes.Ldarg_0));
				FileLog.Log("Done patch "+MethodBase.GetCurrentMethod().DeclaringType);
				//FileLog.Log("Codes are "+InstructionHandlers.toString(codes));
			}
			catch (Exception e) {
				FileLog.Log("Caught exception when running patch "+MethodBase.GetCurrentMethod().DeclaringType+"!");
				FileLog.Log(e.Message);
				FileLog.Log(e.StackTrace);
				FileLog.Log(e.ToString());
			}
			return codes.AsEnumerable();
		}
	}
	
	[HarmonyPatch(typeof(Knife))]
	[HarmonyPatch("OnToolUseAnim")]
	public static class KnifeHarvestingHook {
		
		static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions) {
			List<CodeInstruction> codes = new List<CodeInstruction>(instructions);
			try {
				int idx = InstructionHandlers.getInstruction(codes, 0, 0, OpCodes.Call, "Knife", "GiveResourceOnDamage", false, new Type[]{typeof(GameObject), typeof(bool), typeof(bool)});
				codes[idx].operand = InstructionHandlers.convertMethodOperand("ReikaKalseki.DIAlterra.DIHooks", "doKnifeHarvest", false, typeof(Knife), typeof(GameObject), typeof(bool), typeof(bool));
				FileLog.Log("Done patch "+MethodBase.GetCurrentMethod().DeclaringType);
			}
			catch (Exception e) {
				FileLog.Log("Caught exception when running patch "+MethodBase.GetCurrentMethod().DeclaringType+"!");
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
				FileLog.Log("Done patch "+MethodBase.GetCurrentMethod().DeclaringType);
			}
			catch (Exception e) {
				FileLog.Log("Caught exception when running patch "+MethodBase.GetCurrentMethod().DeclaringType+"!");
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
				FileLog.Log("Done patch "+MethodBase.GetCurrentMethod().DeclaringType);
			}
			catch (Exception e) {
				FileLog.Log("Caught exception when running patch "+MethodBase.GetCurrentMethod().DeclaringType+"!");
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
				FileLog.Log("Done patch "+MethodBase.GetCurrentMethod().DeclaringType);
			}
			catch (Exception e) {
				FileLog.Log("Caught exception when running patch "+MethodBase.GetCurrentMethod().DeclaringType+"!");
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
				FileLog.Log("Done patch "+MethodBase.GetCurrentMethod().DeclaringType);
			}
			catch (Exception e) {
				FileLog.Log("Caught exception when running patch "+MethodBase.GetCurrentMethod().DeclaringType+"!");
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
				FileLog.Log("Done patch "+MethodBase.GetCurrentMethod().DeclaringType);
			}
			catch (Exception e) {
				FileLog.Log("Caught exception when running patch "+MethodBase.GetCurrentMethod().DeclaringType+"!");
				FileLog.Log(e.Message);
				FileLog.Log(e.StackTrace);
				FileLog.Log(e.ToString());
			}
			return codes.AsEnumerable();
		}
	}*/
	
	[HarmonyPatch(typeof(ReaperLeviathan))]
	[HarmonyPatch("GrabVehicle")]
	public static class ReaperGrabHook {
		
		static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions) {
			List<CodeInstruction> codes = new List<CodeInstruction>(instructions);
			try {
				InstructionHandlers.patchInitialHook(codes, new CodeInstruction(OpCodes.Ldarg_0), new CodeInstruction(OpCodes.Ldarg_1), InstructionHandlers.createMethodCall("ReikaKalseki.DIAlterra.DIHooks", "onReaperGrabVehicle", false, typeof(ReaperLeviathan), typeof(Vehicle)));
				FileLog.Log("Done patch "+MethodBase.GetCurrentMethod().DeclaringType);
			}
			catch (Exception e) {
				FileLog.Log("Caught exception when running patch "+MethodBase.GetCurrentMethod().DeclaringType+"!");
				FileLog.Log(e.Message);
				FileLog.Log(e.StackTrace);
				FileLog.Log(e.ToString());
			}
			return codes.AsEnumerable();
		}
	}
	
	[HarmonyPatch(typeof(VehicleDockingBay))]
	[HarmonyPatch("OnTriggerEnter")]
	public static class MoonpoolGrabDetection {
		
		static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions) {
			List<CodeInstruction> codes = new List<CodeInstruction>();
			try {
				codes.Add(new CodeInstruction(OpCodes.Ldarg_0));
				codes.Add(new CodeInstruction(OpCodes.Ldarg_1));
				codes.Add(InstructionHandlers.createMethodCall("ReikaKalseki.DIAlterra.DIHooks", "onDockingTriggerCollided", false, typeof(VehicleDockingBay), typeof(Collider)));
				codes.Add(new CodeInstruction(OpCodes.Ret));
				FileLog.Log("Done patch "+MethodBase.GetCurrentMethod().DeclaringType);
			}
			catch (Exception e) {
				FileLog.Log("Caught exception when running patch "+MethodBase.GetCurrentMethod().DeclaringType+"!");
				FileLog.Log(e.Message);
				FileLog.Log(e.StackTrace);
				FileLog.Log(e.ToString());
			}
			return codes.AsEnumerable();
		}
	}
	
	[HarmonyPatch(typeof(AcidicBrineDamageTrigger))]
	[HarmonyPatch("OnTriggerEnter")]
	public static class BrineTouchDetection {
		
		static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions) {
			List<CodeInstruction> codes = new List<CodeInstruction>();
			try {
				codes.Add(new CodeInstruction(OpCodes.Ldarg_0));
				codes.Add(new CodeInstruction(OpCodes.Ldarg_1));
				codes.Add(InstructionHandlers.createMethodCall("ReikaKalseki.DIAlterra.DIHooks", "onAcidTriggerCollided", false, typeof(AcidicBrineDamageTrigger), typeof(Collider)));
				codes.Add(new CodeInstruction(OpCodes.Ret));
				FileLog.Log("Done patch "+MethodBase.GetCurrentMethod().DeclaringType);
			}
			catch (Exception e) {
				FileLog.Log("Caught exception when running patch "+MethodBase.GetCurrentMethod().DeclaringType+"!");
				FileLog.Log(e.Message);
				FileLog.Log(e.StackTrace);
				FileLog.Log(e.ToString());
			}
			return codes.AsEnumerable();
		}
	}
	
	[HarmonyPatch(typeof(PrecursorDoorMotorModeSetter))]
	[HarmonyPatch("OnTriggerEnter")]
	public static class AirlockTouchDetection {
		
		static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions) {
			List<CodeInstruction> codes = new List<CodeInstruction>();
			try {
				codes.Add(new CodeInstruction(OpCodes.Ldarg_0));
				codes.Add(new CodeInstruction(OpCodes.Ldarg_1));
				codes.Add(InstructionHandlers.createMethodCall("ReikaKalseki.DIAlterra.DIHooks", "onAirlockTouched", false, typeof(PrecursorDoorMotorModeSetter), typeof(Collider)));
				codes.Add(new CodeInstruction(OpCodes.Ret));
				FileLog.Log("Done patch "+MethodBase.GetCurrentMethod().DeclaringType);
			}
			catch (Exception e) {
				FileLog.Log("Caught exception when running patch "+MethodBase.GetCurrentMethod().DeclaringType+"!");
				FileLog.Log(e.Message);
				FileLog.Log(e.StackTrace);
				FileLog.Log(e.ToString());
			}
			return codes.AsEnumerable();
		}
	}
	
	[HarmonyPatch(typeof(FMOD_CustomEmitter))]
	[HarmonyPatch("OnPlay")]
	public static class SoundHook {
		
		static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions) {
			List<CodeInstruction> codes = new List<CodeInstruction>(instructions);
			try {
				//FileLog.Log("Codes are "+InstructionHandlers.toString(codes));
				//int idx = InstructionHandlers.getInstruction(codes, 0, 0, OpCodes.Callvirt, "FMOD_CustomEmitter", "OnPlay", true, new Type[0]);
				CodeInstruction ci = InstructionHandlers.createMethodCall("ReikaKalseki.DIAlterra.DIHooks", "onFModEmitterPlay", false, typeof(FMOD_CustomEmitter));
				InstructionHandlers.patchInitialHook(codes, new CodeInstruction(OpCodes.Ldarg_0), ci);
				FileLog.Log("Done patch "+MethodBase.GetCurrentMethod().DeclaringType);
			}
			catch (Exception e) {
				FileLog.Log("Caught exception when running patch "+MethodBase.GetCurrentMethod().DeclaringType+"!");
				FileLog.Log(e.Message);
				FileLog.Log(e.StackTrace);
				FileLog.Log(e.ToString());
			}
			return codes.AsEnumerable();
		}
	}
	
	[HarmonyPatch(typeof(PropulsionCannon))]
	[HarmonyPatch("ValidateNewObject")]
	public static class PropulsabilityHook {
		
		static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions) {
			List<CodeInstruction> codes = new List<CodeInstruction>(instructions);
			try {
				int idx = InstructionHandlers.getInstruction(codes, 0, 0, OpCodes.Ldfld, "PropulsionCannon", "maxAABBVolume", true);
				codes.Insert(idx+1, InstructionHandlers.createMethodCall("ReikaKalseki.DIAlterra.DIHooks", "getMaxPropulsibleAABB", false, typeof(float), typeof(GameObject)));
				codes.Insert(idx+1, new CodeInstruction(OpCodes.Ldarg_1));
				FileLog.Log("Done patch "+MethodBase.GetCurrentMethod().DeclaringType);
			}
			catch (Exception e) {
				FileLog.Log("Caught exception when running patch "+MethodBase.GetCurrentMethod().DeclaringType+"!");
				FileLog.Log(e.Message);
				FileLog.Log(e.StackTrace);
				FileLog.Log(e.ToString());
			}
			return codes.AsEnumerable();
		}
	}
	
	[HarmonyPatch(typeof(RepulsionCannon))]
	[HarmonyPatch("OnToolUseAnim")]
	public static class RepulsabilityHook {
		
		static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions) {
			List<CodeInstruction> codes = new List<CodeInstruction>(instructions);
			try {
				int idx = InstructionHandlers.getInstruction(codes, 0, 0, OpCodes.Ldc_R4, 400F);
				codes.Insert(idx+1, InstructionHandlers.createMethodCall("ReikaKalseki.DIAlterra.DIHooks", "getMaxPropulsibleAABB", false, typeof(float), typeof(GameObject)));
				codes.Insert(idx+1, new CodeInstruction(OpCodes.Ldloc_S, 11));
				FileLog.Log("Done patch "+MethodBase.GetCurrentMethod().DeclaringType);
			}
			catch (Exception e) {
				FileLog.Log("Caught exception when running patch "+MethodBase.GetCurrentMethod().DeclaringType+"!");
				FileLog.Log(e.Message);
				FileLog.Log(e.StackTrace);
				FileLog.Log(e.ToString());
			}
			return codes.AsEnumerable();
		}
	}
	
	[HarmonyPatch(typeof(Vehicle))]
	[HarmonyPatch("EnterVehicle")]
	public static class VehicleEnterHook {
		
		static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions) {
			List<CodeInstruction> codes = new List<CodeInstruction>(instructions);
			try {
				CodeInstruction ci = InstructionHandlers.createMethodCall("ReikaKalseki.DIAlterra.DIHooks", "onVehicleEnter", false, typeof(Vehicle), typeof(Player));
				InstructionHandlers.patchInitialHook(codes, new CodeInstruction(OpCodes.Ldarg_0), new CodeInstruction(OpCodes.Ldarg_1), ci);
				FileLog.Log("Done patch "+MethodBase.GetCurrentMethod().DeclaringType);
			}
			catch (Exception e) {
				FileLog.Log("Caught exception when running patch "+MethodBase.GetCurrentMethod().DeclaringType+"!");
				FileLog.Log(e.Message);
				FileLog.Log(e.StackTrace);
				FileLog.Log(e.ToString());
			}
			return codes.AsEnumerable();
		}
	}
	
	[HarmonyPatch(typeof(uGUI_DepthCompass))]
	[HarmonyPatch("UpdateDepth")]
	public static class OverrideDepthCompass {
		
		static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions) {
			List<CodeInstruction> codes = new List<CodeInstruction>(instructions);
			try {/*
				for (int i = codes.Count-1; i >= 0; i--) {
					if (codes[i].opcode == OpCodes.Call) {
						MethodInfo mi = (MethodInfo)codes[i].operand;
						if (mi.Name == "FloorToInt") {
							codes.Insert(i, InstructionHandlers.createMethodCall("ReikaKalseki.DIAlterra.DIHooks", "getCompassDepth", false, typeof(float)));
						}
					}
				}*/
				int idx = InstructionHandlers.getInstruction(codes, 0, 0, OpCodes.Call, "uGUI_DepthCompass", "GetDepthInfo", true, new Type[]{typeof(int).MakeByRefType(), typeof(int).MakeByRefType()});
				/*
				List<CodeInstruction> li = new List<CodeInstruction>();
				li.Add(new CodeInstruction(OpCodes.Ldarg_0));
				li.Add(new CodeInstruction(OpCodes.Ldloc_S, 0));
				li.Add(InstructionHandlers.createMethodCall("ReikaKalseki.DIAlterra.DIHooks", "getCompassDepth", false, typeof(uGUI_DepthCompass), typeof(int).MakeByRefType()));
				//li.Add(new CodeInstruction(OpCodes.Stloc_S, 0));
				codes.InsertRange(idx+2, li);*/
				
				codes[idx].operand = InstructionHandlers.convertMethodOperand("ReikaKalseki.DIAlterra.DIHooks", "getCompassDepth", false, typeof(uGUI_DepthCompass), typeof(int).MakeByRefType(), typeof(int).MakeByRefType());
				FileLog.Log("Done patch "+MethodBase.GetCurrentMethod().DeclaringType);
				//FileLog.Log("Codes are "+InstructionHandlers.toString(codes));
			}
			catch (Exception e) {
				FileLog.Log("Caught exception when running patch "+MethodBase.GetCurrentMethod().DeclaringType+"!");
				FileLog.Log(e.Message);
				FileLog.Log(e.StackTrace);
				FileLog.Log(e.ToString());
			}
			return codes.AsEnumerable();
		}
	}
	
	[HarmonyPatch(typeof(Survival))]
	[HarmonyPatch("OnRespawn")]
	public static class RespawnHook {
		
		static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions) {
			List<CodeInstruction> codes = new List<CodeInstruction>(instructions);
			try {
				InstructionHandlers.patchInitialHook(codes, new List<CodeInstruction>(){
					new CodeInstruction(OpCodes.Ldarg_0), new CodeInstruction(OpCodes.Ldarg_1), InstructionHandlers.createMethodCall("ReikaKalseki.DIAlterra.DIHooks", "onRespawnPre", false, typeof(Survival), typeof(Player))
				});
				InstructionHandlers.patchEveryReturnPre(codes, new List<CodeInstruction>(){
					new CodeInstruction(OpCodes.Ldarg_0), new CodeInstruction(OpCodes.Ldarg_1), InstructionHandlers.createMethodCall("ReikaKalseki.DIAlterra.DIHooks", "onRespawnPost", false, typeof(Survival), typeof(Player))
				});
				//FileLog.Log("Codes are "+InstructionHandlers.toString(codes));
				FileLog.Log("Done patch "+MethodBase.GetCurrentMethod().DeclaringType);
			}
			catch (Exception e) {
				FileLog.Log("Caught exception when running patch "+MethodBase.GetCurrentMethod().DeclaringType+"!");
				FileLog.Log(e.Message);
				FileLog.Log(e.StackTrace);
				FileLog.Log(e.ToString());
			}
			return codes.AsEnumerable();
		}
	}
	
	static class PatchLib {
		
		internal static void patchVisualItemSize(List<CodeInstruction> codes, bool useSelfContainer = false) {
			patchVisualItemSize(codes, useSelfContainer, true, useSelfContainer ? new Type[]{typeof(TechType), typeof(InventoryItem), typeof(IItemsContainer)} : new Type[]{typeof(TechType), typeof(InventoryItem)});
		}
		
		internal static void patchVisualItemSize(List<CodeInstruction> codes, bool ldSelf = false, bool ldArg1 = true, params Type[] args) {
			for (int i = codes.Count-1; i >= 0; i--) {
				if (codes[i].opcode == OpCodes.Call) {
					MethodInfo m = (MethodInfo)codes[i].operand;
					if (m != null && m.DeclaringType.Name == "CraftData" && m.Name == "GetItemSize") {
						MethodInfo call = InstructionHandlers.convertMethodOperand("ReikaKalseki.DIAlterra.DIHooks", "getItemDisplaySize", false, args);
						codes[i].operand = call;
						if (ldSelf)
							codes.Insert(i, new CodeInstruction(OpCodes.Ldarg_0));
						if (ldArg1)
							codes.Insert(i, new CodeInstruction(OpCodes.Ldarg_1));
					}
				}
			}
			//FileLog.Log("Codes are "+InstructionHandlers.toString(codes));
			/*
			int idx = InstructionHandlers.getInstruction(codes, 0, 0, OpCodes.Call, "CraftData", "GetItemSize", false, new Type[]{typeof(TechType)});
			codes[idx].operand = InstructionHandlers.convertMethodOperand("ReikaKalseki.DIAlterra.DIHooks", "getItemDisplaySize", false, typeof(TechType), typeof(InventoryItem));
			codes.Insert(idx, new CodeInstruction(OpCodes.Ldarg_1));*/
		}
		
		internal static void redirectPowerHook(List<CodeInstruction> codes) {
			int idx = InstructionHandlers.getInstruction(codes, 0, 0, OpCodes.Call, "PowerSystem", "AddEnergy", false, new Type[]{typeof(IPowerInterface), typeof(float), typeof(float).MakeByRefType()});
			codes[idx].operand = InstructionHandlers.convertMethodOperand("ReikaKalseki.DIAlterra.DIHooks", "addPowerToSeabaseDelegate", false, typeof(IPowerInterface), typeof(float), typeof(float).MakeByRefType(), typeof(MonoBehaviour));
			codes.Insert(idx, new CodeInstruction(OpCodes.Ldarg_0));
		}
		
		internal static void injectEMPHook(List<CodeInstruction> codes, int idx) {
			CodeInstruction arg = codes[idx-3]; //-1 is getfield time, -2 is loadarg0 to get that field
			idx -= 4;
			codes.Insert(idx+1, InstructionHandlers.createMethodCall("ReikaKalseki.DIAlterra.DIHooks", "onEMPHit", false, typeof(EMPBlast), typeof(MonoBehaviour)));
			codes.Insert(idx+1, new CodeInstruction(arg.opcode, arg.operand));
			codes.Insert(idx+1, new CodeInstruction(OpCodes.Ldarg_0));
		}
		
		internal static void injectTickHook(List<CodeInstruction> codes, string name, Type arg) {
			InstructionHandlers.patchInitialHook(codes, new CodeInstruction(OpCodes.Ldarg_0), InstructionHandlers.createMethodCall("ReikaKalseki.DIAlterra.DIHooks", name, false, arg));	
		}
		
	}
}
