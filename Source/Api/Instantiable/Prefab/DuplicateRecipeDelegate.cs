using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using Nautilus.Assets;
using Nautilus.Assets.Gadgets;
using Nautilus.Handlers;
using ReikaKalseki.DIAlterra.Api.Auxiliary;
using ReikaKalseki.DIAlterra.Api.Util;
using UnityEngine;

namespace ReikaKalseki.DIAlterra.Api.Instantiable.Prefab;

public class DuplicateRecipeDelegate : DICustomPrefab, DuplicateItemDelegate
{
    private static readonly Dictionary<TechType, List<DuplicateItemDelegate>> delegates = new();
    private static readonly Dictionary<TechType, DuplicateItemDelegate> delegateItems = new();
    public readonly TechType basis;
    public readonly string nameSuffix;

    public readonly ICustomPrefab prefab;
    public bool allowUnlockPopups = false;
    public TechCategory category = TechCategory.Misc;
    public TechGroup group = TechGroup.Uncategorized;
    public Assembly ownerMod;

    public Atlas.Sprite sprite;
    public TechType unlock = TechType.None;

    [SetsRequiredMembers]
    public DuplicateRecipeDelegate(CustomPrefab s, string suff = "") : base(
        s.Info.ClassID + "_delegate" + getIndexSuffix(s.Info.TechType), s.Info.PrefabFileName + suff, "")
    {
        basis = s.Info.TechType;
        prefab = s;
        unlock = s.GetGadget<ScanningGadget>().RequiredForUnlock;
        group = s.GetGadget<ScanningGadget>().GroupForPda;
        category = s.GetGadget<ScanningGadget>().CategoryForPda;
        nameSuffix = suff;
        if (s is DIPrefab<PrefabReference>)
            ownerMod = ((DIPrefab<PrefabReference>) s).getOwnerMod();
        onPatched();
    }

    [SetsRequiredMembers]
    public DuplicateRecipeDelegate(TechType from, string suff = "") : base(
        from.AsString() + "_delegate" + getIndexSuffix(from), "", "")
    {
        basis = from;
        prefab = null;
        sprite = SpriteManager.Get(from);
        nameSuffix = suff;
        onPatched();
    }

    public string getTooltip()
    {
        return Language.main.Get("Tooltip_" + basis.AsString());
    }

    public string getNameSuffix()
    {
        return nameSuffix;
    }

    public ICustomPrefab getPrefab()
    {
        return prefab;
    }

    public TechType getBasis()
    {
        return basis;
    }

    public Assembly getOwnerMod()
    {
        return ownerMod;
    }

    public bool allowTechUnlockPopups()
    {
        return allowUnlockPopups;
    }

    private void onPatched()
    {
        prefab.SetPdaGroupCategory(group, category);
        prefab.SetUnlock(unlock);
        prefab.Info.WithSizeInInventory(CraftData.GetItemSize(basis));

        SetGameObject(ObjectUtil.createWorldObject(CraftData.GetClassIdForTechType(basis), true, false));
        addDelegate(this);

        if (ownerMod == null)
            throw new Exception("Delegate item " + basis + "/" + Info.ClassID + " has no source mod!");
        if (sprite == null)
            throw new Exception("Delegate item " + basis + "/" + Info.ClassID + " has no sprite!");
    }

    private static string getIndexSuffix(TechType tt)
    {
        var count = delegates.ContainsKey(tt) ? delegates[tt].Count : 0;
        return count <= 0 ? "" : "_" + (count + 1);
    }

    public static void addDelegate(DuplicateItemDelegate d)
    {
        // TODO: Implement, but first understand wtf this is doing

        // var tt = d.getBasis();
        // var fi = typeof(CustomPrefab).GetField("Mod", BindingFlags.Instance | BindingFlags.NonPublic);
        // CustomPrefab pfb = SNUtil.getModPrefabByTechType(tt);
        // var a = pfb == null
        //     ? /*SNUtil.gameDLL*/null
        //     : (Assembly) fi
        //         .GetValue(pfb); //SML does not recognize game DLL and looks for a mod with that DLL, fails, and says error
        // if (a == null)
        //     a = d.getOwnerMod();
        // fi.SetValue(d, a);
        // fi = typeof(TechType).GetField("TechTypesAddedBy", BindingFlags.Static | BindingFlags.NonPublic);
        // var dict = (Dictionary<TechType, Assembly>) fi.GetValue(null);
        // TechType ttsrc = d.getPrefab().Info.TechType;
        // dict[ttsrc] = a;
        // var li = delegates.ContainsKey(tt) ? delegates[tt] : new List<DuplicateItemDelegate>();
        // li.Add(d);
        // delegates[tt] = li;
        // delegateItems.Add(ttsrc, d);
        // SNUtil.log("Registering delegate item " + d + " ref pfb=" + pfb + " in " + a.GetName().Name, d.getOwnerMod());
    }

    public static IEnumerable<DuplicateItemDelegate> getDelegates(TechType of)
    {
        return delegates.ContainsKey(of) ? delegates[of].AsReadOnly() : new List<DuplicateItemDelegate>();
    }

    public static bool isDelegateItem(TechType tt)
    {
        return delegateItems.ContainsKey(tt);
    }

    public static DuplicateItemDelegate getDelegateFromTech(TechType tt)
    {
        return delegateItems[tt];
    }

    public static void updateLocale()
    {
        foreach (var li in delegates.Values)
        foreach (var d in li)
            if (d.getPrefab() == null || !string.IsNullOrEmpty(d.getNameSuffix()))
            {
                var tt = d.getBasis();
                var dt = ((CustomPrefab) d).Info.TechType;
                LanguageHandler.SetLanguageLine(dt.AsString(), Language.main.Get(tt) + d.getNameSuffix());
                LanguageHandler.SetLanguageLine("Tooltip_" + dt.AsString(), d.getTooltip());
                SNUtil.log("Relocalized " + d + " > " + dt.AsString() + " > " + Language.main.Get(dt), d.getOwnerMod());
            }
    }

    public Atlas.Sprite getIcon()
    {
        return sprite;
    }

    public sealed override string ToString()
    {
        return base.ToString() + " [" + Info.TechType + "] / " + Info.ClassID + " / " + Info.PrefabFileName + " in " +
               GetGadget<ScanningGadget>().GroupForPda +
               "/" + GetGadget<ScanningGadget>().CategoryForPda;
    }
}

public interface DuplicateItemDelegate
{
    string getNameSuffix();

    ICustomPrefab getPrefab();

    TechType getBasis();

    string getTooltip();

    Assembly getOwnerMod();

    bool allowTechUnlockPopups();
}