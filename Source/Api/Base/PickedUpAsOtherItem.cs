using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Nautilus.Assets;
using Nautilus.Handlers;
using ReikaKalseki.DIAlterra.Api.Instantiable;
using ReikaKalseki.DIAlterra.Api.Util;
using UnityEngine;

namespace ReikaKalseki.DIAlterra.Api.Base;

public class PickedUpAsOtherItem : DICustomPrefab
{
    private static readonly Dictionary<TechType, List<PickedUpAsOtherItem>> items = new();
    private static readonly Dictionary<TechType, PickedUpAsOtherItem> techMap = new();

    protected readonly TechType template;

    [SetsRequiredMembers]
    public PickedUpAsOtherItem(string classID, string baseTemplate) : this(classID,
        CraftData.entClassTechTable[baseTemplate])
    {
    }

    [SetsRequiredMembers]
    public PickedUpAsOtherItem(string classID, TechType tt) : base(classID, "", "")
    {
        template = tt;

        var li = items.ContainsKey(tt) ? items[tt] : new List<PickedUpAsOtherItem>();
        li.Add(this);
        items[tt] = li;

        techMap[Info.TechType] = this;

        var world = ObjectUtil.createWorldObject(template);
        world.EnsureComponent<TechTag>().type = Info.TechType;
        world.EnsureComponent<PrefabIdentifier>().ClassId = Info.ClassID;
        var pp = world.EnsureComponent<Pickupable>();
        pp.SetTechTypeOverride(template);
        prepareGameObject(world);
        SetGameObject(world);
    }

    protected virtual void prepareGameObject(GameObject go)
    {
    }

    public override string ToString()
    {
        return string.Format("[PickedUpAsOtherItem Template={0}x{1}]", template, getNumberCollectedAs());
    }


    public TechType getTemplate()
    {
        return template;
    }

    public virtual int getNumberCollectedAs()
    {
        return 1;
    }

    public static PickedUpAsOtherItem getPickedUpAsOther(TechType tt)
    {
        return techMap.ContainsKey(tt) ? techMap[tt] : null;
    }

    public static void updateLocale()
    {
        foreach (var li in items.Values)
        foreach (var d in li)
        {
            LanguageHandler.SetLanguageLine(d.Info.TechType.AsString(), Language.main.Get(d.template));
            LanguageHandler.SetLanguageLine("Tooltip_" + d.Info.TechType.AsString(),
                Language.main.Get("Tooltip_" + d.template.AsString()));
            SNUtil.log(
                "Relocalized otherpickup " + d + " > " + d.Info.TechType.AsString() + " > " +
                Language.main.Get(d.Info.TechType),
                SNUtil.diDLL);
        }
    }
}