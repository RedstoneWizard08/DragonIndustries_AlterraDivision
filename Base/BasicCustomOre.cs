﻿using System;
using System.IO;
using System.Reflection;
using System.Collections.Generic;

using UnityEngine;

using SMLHelper.V2.Handlers;
using SMLHelper.V2.Assets;
using SMLHelper.V2.Utility;

using ReikaKalseki.DIAlterra;

namespace ReikaKalseki.DIAlterra
{
	public class BasicCustomOre : Spawnable, DIPrefab<VanillaResources> {
			
		public readonly bool isLargeResource;
		
		public string collectSound = CraftData.defaultPickupSound;
		
		public float glowIntensity {get; set;}		
		public VanillaResources baseTemplate {get; set;}
		
		private readonly Assembly ownerMod;
		
		public BasicCustomOre(XMLLocale.LocaleEntry e, VanillaResources template) : this(e.key, e.name, e.desc, template) {
			
		}
			
		public BasicCustomOre(string id, string name, string desc, VanillaResources template) : base(id, name, desc) {
			ownerMod = SNUtil.tryGetModDLL();
			baseTemplate = template;
						
			if (collectSound != null)
				OnFinishedPatching += () => {CraftData.pickupSoundList[TechType] = collectSound;};
		}
		
		public void registerWorldgen(BiomeType biome, int amt, float chance) {
			SNUtil.log("Adding worldgen "+biome+" x"+amt+" @ "+chance+"% to "+this, 0, ownerMod);
			GenUtil.registerOreWorldgen(this, biome, amt, chance);
		}
		
		public void addPDAEntry(string text, float scanTime = 2, string header = null) {
			SNUtil.addPDAEntry(this, scanTime, "PlanetaryGeology", text, header, null);
		}
		
		protected sealed override Atlas.Sprite GetItemSprite() {
			return TextureManager.getSprite(ownerMod, "Textures/Items/"+ObjectUtil.formatFileName(this));
		}
		
		public virtual void prepareGameObject(GameObject go, Renderer r) {
			
		}
		
		public sealed override string ToString() {
			return base.ToString()+" ["+TechType+"] / "+ClassID+" / "+PrefabFileName;
		}
			
		public sealed override GameObject GetGameObject() {
			return ObjectUtil.getModPrefabBaseObject(this);
		}
		
		public bool isResource() {
			return true;
		}
		
		public Assembly getOwnerMod() {
			return ownerMod;
		}
		
		public string getTextureFolder() {
			return "Resources";
		}
		
		public Atlas.Sprite getIcon() {
			return GetItemSprite();
		}
		
	}
}