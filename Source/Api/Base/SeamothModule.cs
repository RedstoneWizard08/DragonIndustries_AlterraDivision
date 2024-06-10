using System;
using System.Collections.Generic;
using Nautilus.Assets;
using Nautilus.Assets.Gadgets;
using Nautilus.Crafting;
using Nautilus.Handlers;
using ReikaKalseki.DIAlterra.Api.Auxiliary;
using ReikaKalseki.DIAlterra.Api.Instantiable;
using ReikaKalseki.DIAlterra.Api.Util;
using UnityEngine;

namespace ReikaKalseki.DIAlterra.Api.Base;

public abstract class SeamothModule : CustomEquipable
{
    private static readonly Dictionary<TechType, SeamothModuleStorage> storageHandlers = new();

    static SeamothModule()
    {
        storageHandlers[TechType.SeamothTorpedoModule] = new SeamothModuleStorage(null, -1, -1)
            {localeKey = "SeamothTorpedoStorage"};
    }

    protected SeamothModule(XMLLocale.LocaleEntry e, string template = "92b6424f-7635-4e61-990e-3c40bfad6e9a") : this(
        e.key, e.name, e.desc, template)
    {
    }

    protected SeamothModule(string id, string name, string desc,
        string template = "92b6424f-7635-4e61-990e-3c40bfad6e9a") : base(id, name, desc, template)
    {
        //SeamothElectricalDefense
        dependency = TechType.BaseUpgradeConsole;

        if (QuickSlotType == QuickSlotType.Chargeable || QuickSlotType == QuickSlotType.SelectableChargeable)
        {
            CraftData.maxCharges[prefab.Info.TechType] = getMaxCharge();
            CraftData.energyCost[prefab.Info.TechType] = getChargingPowerCost();
        }

        var s = getStorage();
        if (s != null)
        {
            storageHandlers[prefab.Info.TechType] = s;
            s.localeKey = "SeamothModuleStorageAccess_" + id;
            s.localizedHoverText = "Access " + name + " storage";
        }

        prefab.SetEquipment(EquipmentType.SeamothModule);
        prefab.SetPdaGroupCategory(TechGroup.VehicleUpgrades, TechCategory.VehicleUpgrades);
        prefab.SetRecipe(new RecipeData()).WithFabricatorType(CraftTree.Type.SeamothUpgrades)
            .WithStepsToFabricatorTab("SeamothModules");
    }

    internal static SeamothModuleStorage getStorageHandler(TechType item)
    {
        return storageHandlers.ContainsKey(item) ? storageHandlers[item] : null;
    }

    internal static void updateLocale()
    {
        foreach (var kvp in storageHandlers)
            if (!string.IsNullOrEmpty(kvp.Value.localeKey) && !string.IsNullOrEmpty(kvp.Value.localizedHoverText))
            {
                LanguageHandler.SetLanguageLine(kvp.Value.localeKey, kvp.Value.localizedHoverText);
                SNUtil.log(
                    "Relocalized seamoth module tooltip " + kvp.Value.localeKey + " > " + kvp.Value.localizedHoverText,
                    SNUtil.diDLL);
            }
    }

    public override void prepareGameObject(GameObject go, Renderer[] r)
    {
        var s = getStorage();
        if (s != null)
        {
            var storage = go.GetComponent<SeamothStorageContainer>();
            if (storage) s.apply(storage);
        }
    }

    protected virtual float getMaxCharge()
    {
        return CraftData.GetQuickSlotMaxCharge(TechType.SeamothElectricalDefense);
    }

    protected virtual float getChargingPowerCost()
    {
        return 1;
    }

    public virtual float getUsageCooldown()
    {
        return 0;
    }

    public virtual SeamothModuleStorage getStorage()
    {
        return null;
    }

    public virtual void onFired(SeaMoth sm, int slotID, float charge)
    {
        //charge is 0-1
    }

    public class SeamothModuleStorage
    {
        private readonly Action<SeamothStorageContainer> additionalModifications;
        public readonly List<TechType> allowedAmmo = new();
        public readonly int height;

        public readonly string title;
        public readonly int width;

        public SeamothModuleStorage(string s, int w, int h) : this(s, w, h, null)
        {
        }

        public SeamothModuleStorage(string s, int w, int h, Action<SeamothStorageContainer> a)
        {
            title = s;
            width = w;
            height = h;
            additionalModifications = a;
        }

        public string localeKey { get; internal set; }
        public string localizedHoverText { get; internal set; }

        internal void apply(SeamothStorageContainer storage)
        {
            if (title != null)
                storage.storageLabel = title.ToUpperInvariant();
            if (width > 0) storage.width = width;
            //storage.container.sizeX = storage.width;
            if (height > 0) storage.height = height;
            //storage.container.sizeY = storage.height;
            if (height > 0 || width > 0)
                storage.container.Resize(width > 0 ? width : storage.container.sizeX,
                    height > 0 ? height : storage.container.sizeY);
            if (allowedAmmo.Count > 0)
            {
                storage.allowedTech = allowedAmmo.ToArray();
                storage.container.SetAllowedTechTypes(storage.allowedTech);
            }
        }

        public SeamothModuleStorage addAmmo(PrefabReference s)
        {
            return addAmmo(CraftData.entClassTechTable[s.getPrefabID()]);
        }

        public SeamothModuleStorage addAmmo(ICustomPrefab s)
        {
            return addAmmo(s.Info.TechType);
        }

        public SeamothModuleStorage addAmmo(TechType tt)
        {
            allowedAmmo.Add(tt);
            return this;
        }
    }
}