﻿using System;
using System.Collections.Generic;
using ReikaKalseki.DIAlterra.Api.Util;
using UnityEngine;

namespace ReikaKalseki.DIAlterra.Api.Registry.Runtime;

public class UsableItemRegistry
{
    public static readonly UsableItemRegistry instance = new();

    private readonly Dictionary<TechType, Func<Survival, GameObject, bool>> actions = new();

    private float lastUse = -1;

    private UsableItemRegistry()
    {
        /*
            addUsableItem(TechType.Bladderfish, (s, go) => {
                Player.main.GetComponent<OxygenManager>().AddOxygen(15f);
                return true;
            });*/
        addUsableItem(TechType.FirstAidKit, (s, go) =>
        {
            if (Player.main.GetComponent<LiveMixin>().AddHealth(50f) > 0.1f) return true;
            return false;
        });
        addUsableItem(TechType.EnzymeCureBall, (s, go) =>
        {
            Debug.LogWarningFormat(s, "Code should be unreachable for the time being.", Array.Empty<object>());
            var component2 = Utils.GetLocalPlayer().gameObject.GetComponent<InfectedMixin>();
            if (component2.IsInfected())
            {
                component2.RemoveInfection();
                Utils.PlayFMODAsset(s.curedSound, s.transform);
                return true;
            }

            return false;
        });
    }

    public void addUsableItem(TechType item, Func<Survival, GameObject, bool> onUse)
    {
        actions[item] = onUse;
    }

    public bool isUsable(TechType tt)
    {
        return actions.ContainsKey(tt);
    }

    public bool use(TechType tt, Survival s, GameObject go)
    {
        if (DayNightCycle.main.timePassedAsFloat - lastUse < 0.5)
        {
            SNUtil.writeToChat("Prevented duplicate use of item " + tt);
            return false;
        }

        lastUse = DayNightCycle.main.timePassedAsFloat;
        var ret = actions[tt](s, go);
        if (ret)
            Inventory.main.container.DestroyItem(tt);
        return ret;
    }
}