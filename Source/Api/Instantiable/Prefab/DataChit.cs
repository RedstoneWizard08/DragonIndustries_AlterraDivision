using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using ReikaKalseki.DIAlterra.Api.Util;
using Story;
using UnityEngine;

namespace ReikaKalseki.DIAlterra.Api.Instantiable.Prefab;

public sealed class DataChit : Nautilus.Assets.CustomPrefab
{
    private static readonly Dictionary<string, SNUtil.PopupData> popupData = new();

    public readonly StoryGoal goal;

    private readonly Assembly ownerMod;

    public Color renderColor = new(229 / 255F, 133 / 255F, 0); //avali aerogel color

    [SetsRequiredMembers]
    public DataChit(string goalKey, string name, string desc, Action<SNUtil.PopupData> a = null) : this(
        new StoryGoal(goalKey, Story.GoalType.Story, 0), name, desc, a)
    {
    }

    [SetsRequiredMembers]
    public DataChit(StoryGoal g, string name, string desc, Action<SNUtil.PopupData> a = null) : base(
        "DataChit_" + g.key, "Data Card - " + name, "Unlocks " + g.key)
    {
        goal = g;
        ownerMod = SNUtil.tryGetModDLL();

        var data = new SNUtil.PopupData("Digital Data Downloaded", desc);
        data.sound = "event:/tools/scanner/scan_complete";
        if (a != null)
            a(data);
        popupData[Info.ClassID] = data;
        SetGameObject(GetGameObject());
    }

    public GameObject GetGameObject()
    {
        var world = ObjectUtil.createWorldObject("1bdbad41-adcb-47db-ab2c-0dc4a7180860");
        world.transform.localScale = new Vector3(0.4F, 1, 1F);
        world.EnsureComponent<TechTag>().type = Info.TechType;
        world.EnsureComponent<PrefabIdentifier>().ClassId = Info.ClassID;
        var tgt = world.EnsureComponent<StoryHandTarget>();
        tgt.goal = goal;
        tgt.primaryTooltip = Info.PrefabFileName;
        tgt.informGameObject = world;
        ObjectUtil.removeComponent<ResourceTracker>(world);
        world.EnsureComponent<DataChitTag>();
        ObjectUtil.removeChildObject(world, "PDALight");
        var r = world.GetComponentInChildren<Renderer>();
        RenderUtil.swapTextures(SNUtil.diDLL, r, "Textures/DataChit/",
            new Dictionary<int, string> {{0, ""}, {1, ""}, {2, ""}});
        foreach (var m in r.materials)
            m.SetColor("_GlowColor", renderColor.WithAlpha(1));
        var l = ObjectUtil.addLight(world);
        l.color = renderColor;
        l.range = 6;
        l.intensity = 0.5F;
        l.transform.localPosition = new Vector3(0.0F, 0.5F, 0.15F);
        l = ObjectUtil.addLight(world);
        l.color = renderColor;
        l.range = 1.2F;
        l.intensity = 1.5F;
        l.transform.localPosition = new Vector3(0.0F, 0.125F, 0.15F);
        return world;
    }

    private class DataChitTag : MonoBehaviour
    {
        private void OnStoryHandTarget()
        {
            SNUtil.triggerUnlockPopup(popupData[GetComponent<PrefabIdentifier>().ClassId]);
        }
    }
}