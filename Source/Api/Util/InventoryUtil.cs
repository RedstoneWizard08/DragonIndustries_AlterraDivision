using System.Collections.Generic;
using UnityEngine;

namespace ReikaKalseki.DIAlterra.Api.Util;

public static class InventoryUtil
{
    public static HashSet<TechType> getVehicleUpgrades(Vehicle v)
    {
        var set = new HashSet<TechType>();
        foreach (var idx in v.slotIndexes.Values)
        {
            var ii = v.GetSlotItem(idx);
            if (ii != null && ii.item)
                set.Add(ii.item.GetTechType());
        }

        return set;
    }

    public static bool vehicleHasUpgrade(Vehicle v, TechType tt)
    {
        /*
            foreach (int idx in v.slotIndexes.Values) {
                InventoryItem ii = v.GetSlotItem(idx);
                if (ii != null && ii.item && ii.item.GetTechType() == tt)
                    return true;
            }
            return false;*/
        return v.modules.GetCount(tt) > 0;
    }

    public static bool isVehicleUpgradeSelected(Vehicle v, TechType tt)
    {
        if (!v || v.activeSlot < 0)
            return false;
        var ii = v.GetSlotItem(v.activeSlot);
        return ii != null && ii.item.GetTechType() == tt;
    }

    public static HashSet<TechType> getCyclopsUpgrades(SubRoot sub)
    {
        var set = new HashSet<TechType>();
        var modules = sub.isCyclops && sub.upgradeConsole ? sub.upgradeConsole.modules : null;
        if (modules != null)
            foreach (var slot in SubRoot.slotNames)
            {
                var tt = modules.GetTechTypeInSlot(slot);
                if (tt != TechType.None)
                    set.Add(tt);
            }

        return set;
    }

    public static bool cyclopsHasUpgrade(SubRoot sub, TechType tt)
    {
        var modules = sub.isCyclops && sub.upgradeConsole ? sub.upgradeConsole.modules : null; /*
        if (modules != null) {
            foreach (string slot in SubRoot.slotNames) {
                TechType tt2 = modules.GetTechTypeInSlot(slot);
                if (tt == tt2)
                    return true;
            }
        }
        return false;*/
        return modules != null && modules.GetCount(tt) > 0;
    }

    public static List<Battery> getCyclopsPowerCells(SubRoot sub)
    {
        if (!sub.isCyclops)
            return null;
        var ret = new List<Battery>();
        foreach (BatterySource b in sub.powerRelay.inboundPowerSources) ret.Add((Battery) b.battery);
        return ret;
    }

    public static void addItem(TechType tt)
    {
        var obj = Object.Instantiate(ObjectUtil.lookupPrefab(tt));
        if (!obj)
        {
            SNUtil.writeToChat("Could not spawn item " + tt + ", no prefab");
            return;
        }

        obj.SetActive(false);
        Inventory.main.ForcePickup(obj.GetComponent<Pickupable>());
    }

    public static bool removeItem(StorageContainer sc, InventoryItem ii)
    {
        return sc.container.DestroyItem(ii.item.GetTechType());
    }

    public static bool forceRemoveItem(StorageContainer sc, InventoryItem ii)
    {
        if (sc.container.RemoveItem(ii.item, true))
        {
            Object.Destroy(ii.item.gameObject);
            return true;
        }

        return false;
    }
}