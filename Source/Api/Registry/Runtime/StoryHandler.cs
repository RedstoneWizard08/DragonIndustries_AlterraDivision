﻿using System;
using System.Collections.Generic;
using ReikaKalseki.DIAlterra.Api.Instantiable;
using ReikaKalseki.DIAlterra.Api.Util;
using Story;
using UnityEngine;
using Random = UnityEngine.Random;

namespace ReikaKalseki.DIAlterra.Api.Registry.Runtime;

public class StoryHandler : IStoryGoalListener
{
    public static readonly StoryHandler instance = new();
    private readonly List<IStoryGoalListener> listeners = new();

    private readonly Dictionary<ProgressionTrigger, DelayedProgressionEffect> triggers = new();

    public bool disableStoryHooks = false;

    private StoryHandler()
    {
    }

    public void NotifyGoalComplete(string key)
    {
        SNUtil.log("Completed Story Goal '" + key + "' @ " + DayNightCycle.main.timePassedAsFloat, SNUtil.diDLL);
        foreach (var ig in listeners) ig.NotifyGoalComplete(key);
    }

    public void addListener(Action<string> call)
    {
        listeners.Add(new DelegateGoalListener(call));
    }

    public void addListener(IStoryGoalListener ig)
    {
        listeners.Add(ig);
    }

    public void registerTrigger(ProgressionTrigger pt, DelayedProgressionEffect e)
    {
        triggers[pt] = e;
    }

    public void tick(Player ep)
    {
        if (disableStoryHooks || !DIHooks.isWorldLoaded())
            return;
        foreach (var kvp in triggers)
            if (kvp.Key.isReady(ep))
            {
                var dt = kvp.Value;
                dt.time += Time.deltaTime;
                //if (!dt.isFired())
                //	SNUtil.writeToChat("Trigger "+kvp.Key+" is ready, T="+dt.time.ToString("0.000")+"/"+dt.minDelay.ToString("0.0"));
                if (!dt.isFired() && dt.time >= dt.minDelay && Random.Range(0, 1F) <= dt.chancePerTick * Time.timeScale)
                    //SNUtil.writeToChat("Firing "+dt);
                    dt.fire();
            }
        //SNUtil.writeToChat("Trigger "+kvp.Key+" condition is not met");
    }

    private class DelegateGoalListener : IStoryGoalListener
    {
        private readonly Action<string> callback;

        internal DelegateGoalListener(Action<string> a)
        {
            callback = a;
        }

        public void NotifyGoalComplete(string key)
        {
            callback(key);
        }
    }
}