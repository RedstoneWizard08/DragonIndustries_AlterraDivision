using Nautilus.Assets.Gadgets;
using Nautilus.Crafting;
using ReikaKalseki.DIAlterra.Api.Instantiable;

namespace ReikaKalseki.DIAlterra.Api.Base;

public abstract class CyclopsModule : CustomEquipable
{
    protected CyclopsModule(XMLLocale.LocaleEntry e) : this(e.key, e.name, e.desc)
    {
    }

    protected CyclopsModule(string id, string name, string desc) : base(id, name, desc,
        "WorldEntities/Tools/CyclopsHullModule3")
    {
        dependency = TechType.Cyclops;

        prefab.SetRecipe(new RecipeData()).WithFabricatorType(CraftTree.Type.CyclopsFabricator)
            .WithStepsToFabricatorTab();

        prefab.SetEquipment(EquipmentType.CyclopsModule);
        prefab.SetPdaGroupCategory(TechGroup.Cyclops, TechCategory.CyclopsUpgrades);
    }
}