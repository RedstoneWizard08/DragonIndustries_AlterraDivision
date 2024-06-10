using Nautilus.Assets.Gadgets;
using Nautilus.Crafting;

namespace ReikaKalseki.DIAlterra.Api.Base;

public sealed class SeamothDepthModule : SeamothModule
{
    public readonly int depthBonus;

    public readonly int maxDepth;

    public SeamothDepthModule(string id, string name, string desc, int d) : base(id, name, desc)
    {
        maxDepth = d;
        depthBonus = maxDepth - 200;
        dependency = TechType.BaseUpgradeConsole;
        prefab.SetRecipe(new RecipeData()).WithFabricatorType(CraftTree.Type.Workbench)
            .WithStepsToFabricatorTab("SeamothMenu");
        prefab.SetEquipment(EquipmentType.SeamothModule).WithQuickSlotType(QuickSlotType.Passive);
        prefab.SetPdaGroupCategory(TechGroup.Workbench, TechCategory.Workbench);
    }
}