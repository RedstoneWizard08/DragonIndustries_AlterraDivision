using HarmonyLib;
using Nautilus.Assets;
using Nautilus.Assets.Gadgets;

namespace ReikaKalseki.DIAlterra.Api.Util;

public static class Extensions
{
    public static void SetBattery(this EnergyMixin e, TechType tech, int normalizedCharge)
    {
        // We ignore the value, we just need to set the battery data.
        e.SetBatteryAsync(tech, normalizedCharge, new TaskResult<InventoryItem>()).Reset();
    }

    public static ICustomPrefab prefab(this Gadget gadget)
    {
        return (ICustomPrefab) AccessTools.Property(typeof(ICustomPrefab), "prefab").GetValue(gadget);
    }

    public static void setGrowingPeriod(this WaterParkCreatureData props, float value)
    {
        AccessTools.Property(typeof(float), "growingPeriod").SetValue(props, value);
    }
}