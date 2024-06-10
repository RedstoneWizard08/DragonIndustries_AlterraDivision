﻿using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using System.Text;
using Nautilus.Handlers;
using ReikaKalseki.DIAlterra.Api.Instantiable;
using ReikaKalseki.DIAlterra.Api.Util;
using Story;
using UnityEngine;

namespace ReikaKalseki.DIAlterra.Api.Registry;

public static class SignalManager
{
    private static readonly Dictionary<string, ModSignal> signals = new();
    private static readonly Dictionary<PingType, string> types = new();

    static SignalManager()
    {
    }

    public static ModSignal getSignal(string id)
    {
        return signals.ContainsKey(id) ? signals[id] : null;
    }

    public static ModSignal createSignal(XMLLocale.LocaleEntry text)
    {
        return createSignal(text.key, text.name, text.desc, text.pda, text.getField<string>("radio"));
    }

    public static ModSignal createSignal(string id, string name, string desc, string pda, string prompt)
    {
        if (signals.ContainsKey(id))
            throw new Exception("Signal ID '" + id + "' already in use!");
        var sig = new ModSignal(id, name, desc, pda, prompt);
        signals[sig.id] = sig;
        SNUtil.log("Constructed signal " + sig);
        return sig;
    }

    public class ModSignal
    {
        public readonly string id;
        public readonly string longName;
        public readonly string name;

        public readonly Assembly ownerMod;

        public readonly PDAManager.PDAPage pdaEntry;
        public readonly string radioText;
        internal SignalInitializer initializer;

        private StoryGoal radioMessage;

        internal PingInstance signalInstance;

        internal ModSignal(string id, string n, string desc, string pda, string prompt)
        {
            this.id = "signal_" + id;
            name = n;
            longName = desc;
            radioText = prompt;

            pdaEntry = string.IsNullOrEmpty(pda)
                ? null
                : PDAManager.createPage("signal_" + id, longName, pda, "DownloadedData");

            ownerMod = SNUtil.tryGetModDLL();
        }

        public string storyGate { get; private set; }

        public Atlas.Sprite icon { get; private set; }

        public Vector3 initialPosition { get; private set; }
        public float maxDistance { get; private set; }

        public PingType signalType { get; private set; }
        internal SignalHolder signalHolder { get; private set; }

        public ModSignal addRadioTrigger(string soundPath)
        {
            return addRadioTrigger(SoundManager.registerPDASound(SNUtil.tryGetModDLL(), "radio_" + id, soundPath)
                .asset);
        }

        public ModSignal addRadioTrigger(FMODAsset sound)
        {
            setStoryGate("radio_" + id);
            radioMessage = SNUtil.addRadioMessage(storyGate, radioText, sound);
            return this;
        }

        public ModSignal setStoryGate(string key)
        {
            storyGate = key;
            return this;
        }

        public ModSignal move(Vector3 pos)
        {
            initialPosition = pos;
            return this;
        }

        public void register(string pfb, Vector3 pos, float maxDist = -1)
        {
            register(pfb, SpriteManager.Get(SpriteManager.Group.Pings, "Signal"), pos, maxDist);
        }

        public void register(string pfb, Atlas.Sprite icon, Vector3 pos, float maxDist = -1)
        {
            if (icon == null || icon == SpriteManager.defaultSprite)
                throw new Exception("Null icon is not allowed");
            signalType = EnumHandler.AddEntry<PingType>(id).WithIcon(icon);
            types[signalType] = id;
            LanguageHandler.SetLanguageLine(id, "Signal");
            this.icon = icon;

            initialPosition = pos;
            maxDistance = maxDist;

            signalHolder = new SignalHolder(pfb, this).registerPrefab();

            if (pdaEntry != null)
                pdaEntry.register();
            SNUtil.log("Registered signal " + this);
        }

        public void addWorldgen(Quaternion? rot = null)
        {
            GenUtil.registerWorldgen(signalHolder.Info.ClassID, initialPosition, rot);
        }

        public PingInstance attachToObject(GameObject go)
        {
            var lw = go.EnsureComponent<LargeWorldEntity>();
            lw.cellLevel = LargeWorldEntity.CellLevel.Global;

            go.SetActive(false);
            go.transform.position = initialPosition;

            signalInstance = go.EnsureComponent<PingInstance>();
            signalInstance.pingType = signalType;
            signalInstance.colorIndex = 0;
            signalInstance.origin = go.transform;
            signalInstance.minDist = 18;
            signalInstance.visitDistance = maxDistance >= 0 ? maxDistance : signalInstance.minDist;
            signalInstance.SetLabel(longName);

            var flag = true;
            if (storyGate != null)
                flag = StoryGoalManager.main.completedGoals.Contains(storyGate);

            signalInstance.displayPingInManager = flag;
            signalInstance.SetVisible(flag);

            initializer = go.EnsureComponent<SignalInitializer>();
            initializer.ping = signalInstance;
            initializer.signal = this;

            SNUtil.log(
                "Initialized GO holder for signal " + id + " [" + flag + "]: " + go + " @ " + go.transform.position,
                SNUtil.diDLL);

            go.SetActive(true);

            return signalInstance;
        }

        public void fireRadio()
        {
            if (radioMessage != null)
                StoryGoal.Execute(storyGate, radioMessage.goalType); //radioMessage.Trigger();
        }

        public bool isRadioFired()
        {
            return !string.IsNullOrEmpty(storyGate) && StoryGoalManager.main.completedGoals.Contains(storyGate);
        }

        public void activate(int delay = 0)
        {
            if (!signalInstance)
            {
                SNUtil.log("Cannot disable mod signal " + this + " because it has no object/instance!", ownerMod);
                return;
            }

            var already = signalInstance.enabled;
            signalInstance.displayPingInManager = true;
            signalInstance.enabled = true;
            signalInstance.SetVisible(true);

            if (already)
                return;

            if (delay > 0)
                initializer.Invoke("triggerFX", delay);
            else
                initializer.triggerFX();

            if (pdaEntry != null)
                pdaEntry.unlock(false);
        }

        public void deactivate()
        {
            //Will not remove the PDA entry!
            if (!signalInstance)
                return;
            //signalInstance.displayPingInManager = false;
            signalInstance.enabled = false;
            signalInstance.SetVisible(false);
        }

        public bool isActive()
        {
            return signalInstance && signalInstance.isActiveAndEnabled;
        }

        public override string ToString()
        {
            return string.Format(
                "[ModSignal Id={0}, Name={1}, LongName={2}, Radio={3}, PdaEntry={4}, Icon={5}, Mod={6}]", id, name,
                longName, radioText, pdaEntry, icon, ownerMod);
        }
    }

    internal class SignalInitializer : MonoBehaviour
    {
        internal PingInstance ping;

        internal ModSignal signal;

        private void Start()
        {
            if (ping == null)
                //SNUtil.log("Ping was null, refetch");
                ping = gameObject.GetComponentInParent<PingInstance>();
            //SNUtil.log("TT is now "+ping.pingType);
            if (ping != null && signal == null)
                //SNUtil.log("Signal was null, refetch");
                signal = getSignal(types[ping.pingType]);
            SNUtil.log("Starting signal init of " + signal + " / " + ping, SNUtil.diDLL);
            signal.signalInstance = ping;
            signal.initializer = this;
            ping.SetLabel(signal.longName);

            var available = signal.storyGate == null || StoryGoalManager.main.completedGoals.Contains(signal.storyGate);
            ping.displayPingInManager = available;
            if (!available)
                ping.SetVisible(false);
        }

        internal void triggerFX()
        {
            SNUtil.log("Firing signal unlock FX: " + signal.id);
            SoundManager.playSound("event:/player/signal_upload"); //"signal location uploaded to PDA"
            Subtitles.AddRawLong(0, new StringBuilder("Signal location uploaded to PDA."), 0, 6);
            //SNUtil.playSound("event:/tools/scanner/new_encyclopediea"); //triple-click	
        }
    }

    internal class SignalHolder : GenUtil.CustomPrefabImpl
    {
        private readonly ModSignal signal;

        [SetsRequiredMembers]
        internal SignalHolder(string template, ModSignal s) : base("signalholder_" + s.id, template)
        {
            signal = s;
        }

        public override void prepareGameObject(GameObject go, Renderer[] r)
        {
            signal.attachToObject(go);
        }

        internal SignalHolder registerPrefab()
        {
            Register();
            return this;
        }
    }
}