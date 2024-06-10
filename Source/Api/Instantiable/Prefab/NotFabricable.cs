using System.Diagnostics.CodeAnalysis;
using Nautilus.Assets.Gadgets;
using ReikaKalseki.DIAlterra.Api.Base;
using UnityEngine;

namespace ReikaKalseki.DIAlterra.Api.Instantiable.Prefab;

public class NotFabricable : BasicCraftingItem
{
    [SetsRequiredMembers]
    public NotFabricable(XMLLocale.LocaleEntry e, string template) : base(e, template)
    {
    }

    [SetsRequiredMembers]
    public NotFabricable(string id, string name, string desc, string template) : base(id, name, desc, template)
    {
        prefab.SetRecipe(getRecipe()).WithFabricatorType(CraftTree.Type.None).WithCraftingTime(craftingTime)
            .WithStepsToFabricatorTab("Resources", craftingSubCategory);
        prefab.SetPdaGroupCategory(TechGroup.Uncategorized, TechCategory.Misc);
    }
}