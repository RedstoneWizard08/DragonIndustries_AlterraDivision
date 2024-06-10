﻿using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;
using Nautilus.Assets;
using Nautilus.Handlers;
using ReikaKalseki.DIAlterra.Api.Auxiliary;
using ReikaKalseki.DIAlterra.Api.Instantiable;
using ReikaKalseki.DIAlterra.Api.Registry.VanillaData;
using ReikaKalseki.DIAlterra.Api.Util;
using Story;
using UnityEngine;
using UnityEngine.UI;

namespace ReikaKalseki.DIAlterra.Api.Registry;

public static class PDAManager
{
    private static readonly Dictionary<string, PDAPage> pages = new();

    static PDAManager()
    {
    }

    public static PDAPage getPage(string id)
    {
        return pages.ContainsKey(id) ? pages[id] : null;
    }

    public static PDAPage createPage(XMLLocale.LocaleEntry text)
    {
        return createPage(text.key, text.name, text.pda, text.getField<string>("category"));
    }

    public static PDAPage createPage(string id, string name, string text, string cat)
    {
        if (pages.ContainsKey(id))
            throw new Exception("PDA page ID '" + id + "' already in use! " + pages[id]);
        var sig = new PDAPage(id, name, text, cat);
        pages[sig.id] = sig;
        SNUtil.log("Registered PDA page " + sig);
        return sig;
    }

    public class PDAPage
    {
        //public readonly string text;
        public readonly string category;

        public readonly string id;
        public readonly string name;

        public readonly Assembly ownerMod;

        private readonly PDAEncyclopedia.EntryData pageData = new();

        private readonly PDAPrefab prefabID;

        private string text;

        private readonly List<string> tree = new();

        internal PDAPage(string id, string n, string text, string cat)
        {
            this.id = id;
            name = n;
            this.text = text;
            category = cat;

            tree.AddRange(cat.Split('/'));

            pageData.audio = null;
            pageData.key = id;
            pageData.unlocked = false;

            prefabID = new PDAPrefab(this);

            ownerMod = SNUtil.tryGetModDLL();
        }

        public PDAPage addSubcategory(string s)
        {
            tree.Add(s);
            return this;
        }

        public PDAPage setVoiceover(string path)
        {
            var sid = VanillaSounds.getID(path);
            if (sid == null)
            {
                SNUtil.log("Sound path " + path + " did not find an ID. Registering as custom.");
                pageData.audio = SoundManager.registerPDASound(SNUtil.tryGetModDLL(), "pda_vo_" + id, path).asset;
            }
            else
            {
                pageData.audio = SoundManager.buildSound(path, sid);
            }

            SNUtil.log("Setting " + this + " sound to " + pageData.audio.id + "=" + pageData.audio.path);
            return this;
        }

        public PDAPage setHeaderImage(Texture2D img)
        {
            pageData.image = img;
            return this;
        }

        public void register()
        {
            pageData.nodes = tree.ToArray();
            pageData.path = string.Join("/", tree);
            PDAHandler.AddEncyclopediaEntry(pageData);
            LanguageHandler.SetLanguageLine("Ency_" + pageData.key, name);
            injectString();

            prefabID.Register();
        }

        public string getText()
        {
            return text;
        }

        public void append(string s, bool force = false)
        {
            text = text + s;
            injectString(force);
        }

        public void update(string text, bool force = false, bool allowNotification = true)
        {
            if (this.text == text)
                return;
            this.text = text;
            injectString(force, allowNotification);
        }

        public void setPlaceholderValues(string template, Dictionary<string, object> values, bool force = false,
            bool allowNotification = true)
        {
            update(
                values.Aggregate(template,
                    (placeholder, value) => placeholder.Replace("$" + value.Key, value.Value.ToString())), force,
                allowNotification);
        }

        private void injectString(bool force = false, bool allowNotification = true)
        {
            /*
                if (force && DIHooks.isWorldLoaded())
                    Language.main.strings["EncyDesc_"+pageData.key] = text;
                else*/
            LanguageHandler.SetLanguageLine("EncyDesc_" + pageData.key, text);
            if (force && DIHooks.isWorldLoaded())
            {
                var tab = (uGUI_EncyclopediaTab) Player.main.GetPDA().ui.tabs[PDATab.Encyclopedia];
                if (tab && tab.activeEntry && tab.activeEntry.key == pageData.key)
                    tab.DisplayEntry(pageData.key); //.SetText(text);
            }

            if (allowNotification)
                markUpdated(5);
        }

        public void markUpdated(float duration = 3F)
        {
            SNUtil.addEncyNotification(id, duration);
        }

        public TreeNode getNode()
        {
            var li = new List<string>(tree);
            li.Add(id);
            return PDAEncyclopedia.tree.FindNodeByPath(li.ToArray());
        }

        public uGUI_ListEntry getListEntry()
        {
            var tab = (uGUI_EncyclopediaTab) Player.main.GetPDA().ui.tabs[PDATab.Encyclopedia];
            foreach (var e in tab.GetComponentsInChildren<uGUI_ListEntry>())
                if (e.GetComponentInChildren<Text>().text == name)
                    return e;
            return null;
        }

        public void show(Action<PDA> onClose = null)
        {
            var pda = Player.main.GetPDA();
            pda.Open(PDATab.Encyclopedia, null, onClose != null ? new PDA.OnClose(onClose) : null);
            var ency = (uGUI_EncyclopediaTab) Player.main.GetPDA().ui.tabs[PDATab.Encyclopedia];
            var node = ency.ExpandTo(id);
            ency.Activate(node);
        }

        public bool unlock(bool doSound = true)
        {
            if (!isUnlocked())
            {
                pageData.unlocked = true;
                PDAEncyclopedia.Add(pageData.key, true);

                if (doSound)
                    SoundManager.playSound("event:/tools/scanner/new_PDA_data"); //music + "integrating PDA data"

                return true;
            }

            return false;
        }
        /*
        public void relock() {
            pageData.unlocked = false;
            PDAEncyclopedia.NotifyRemove((CraftNode)getNode());
            PDAEncyclopedia.entries.Remove(pageData.key);
            //PDAEncyclopedia.mapping.Remove(pageData.key);
        }*/

        public bool isUnlocked()
        {
            return pageData.unlocked || PDAEncyclopedia.entries.ContainsKey(pageData.key);
        }

        public override string ToString()
        {
            return string.Format("[PDAPage Id={0}, Name={1}, Text={2}, Category={3}, Header={4}, Mod={5}]", id, name,
                text.Replace("\n", ""), category, pageData.image, ownerMod.Location);
        }

        public string getPDAClassID()
        {
            return prefabID.Info.ClassID;
        }

        public TechType getTechType()
        {
            return prefabID.Info.TechType;
        }
    }

    private sealed class PDAPrefab : DICustomPrefab, DIPrefab<StringPrefabContainer>
    {
        internal readonly PDAPage page;

        [SetsRequiredMembers]
        internal PDAPrefab(PDAPage p) : base(p.id, p.name, "PDA page " + p.name)
        {
            page = p;
            baseTemplate = new StringPrefabContainer("0f1dd54e-b36e-40ca-aa85-d01df1e3e426"); //blood kelp PDA

            var go = ObjectUtil.getModPrefabBaseObject(this);
            var tgt = go.EnsureComponent<StoryHandTarget>();
            if (tgt.goal == null)
                tgt.goal = new StoryGoal("", Story.GoalType.Story, 0f);
            tgt.goal.goalType = Story.GoalType.Encyclopedia;
            tgt.goal.key = page.id;
            SetGameObject(go);
        }

        public float glowIntensity { get; set; }
        public StringPrefabContainer baseTemplate { get; set; }

        public Assembly getOwnerMod()
        {
            return SNUtil.diDLL;
        }

        public bool isResource()
        {
            return false;
        }

        public string getTextureFolder()
        {
            return null;
        }

        public void prepareGameObject(GameObject go, Renderer[] r)
        {
        }

        public Atlas.Sprite getIcon()
        {
            return SpriteManager.Get(TechType.PDA);
        }
    }
}