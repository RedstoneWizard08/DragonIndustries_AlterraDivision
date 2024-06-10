using System.Diagnostics.CodeAnalysis;
using Nautilus.Assets.Gadgets;
using Nautilus.Handlers;
using ReikaKalseki.DIAlterra.Api.Instantiable;
using ReikaKalseki.DIAlterra.Api.Registry;
using ReikaKalseki.DIAlterra.Api.Util;
using UnityEngine;

namespace ReikaKalseki.DIAlterra.Api.Base;

public class CustomBattery : BasicCraftingItem
{
    public readonly int capacity;

    [SetsRequiredMembers]
    public CustomBattery(XMLLocale.LocaleEntry e, int cap) : this(e.key, e.name, e.desc, cap)
    {
    }

    [SetsRequiredMembers]
    public CustomBattery(string id, string name, string desc, int cap) : base(id, name, desc,
        "d4bfebc0-a5e6-47d3-b4a7-d5e47f614ed6")
    {
        capacity = cap;
        sprite = TextureManager.getSprite(ownerMod, "Textures/Items/" + ObjectUtil.formatFileName(prefab));
        /*CraftDataHandler.SetEquipmentType(TechType, EquipmentType.BatteryCharger);*/
        CraftData.equipmentTypes[prefab.Info.TechType] = EquipmentType.BatteryCharger;
        prefab.SetPdaGroupCategory(TechGroup.Resources, TechCategory.Electronics);
        prefab.SetRecipe(getRecipe()).WithFabricatorType(CraftTree.Type.Fabricator).WithCraftingTime(craftingTime)
            .WithStepsToFabricatorTab("Resources", "Electronics");
    }

    public override void prepareGameObject(GameObject go, Renderer[] r)
    {
        base.prepareGameObject(go, r);
        go.EnsureComponent<Battery>()._capacity = capacity;
        go.EnsureComponent<Battery>().charge = capacity;
        go.SetActive(false);
    }
}