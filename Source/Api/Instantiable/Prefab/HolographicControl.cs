using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using Nautilus.Assets;
using Nautilus.Handlers;
using ReikaKalseki.DIAlterra.Api.Registry;
using ReikaKalseki.DIAlterra.Api.Util;
using UnityEngine;
using UnityEngine.UI;

namespace ReikaKalseki.DIAlterra.Api.Instantiable.Prefab;

public sealed class HolographicControl : DICustomPrefab
{
    internal static readonly Dictionary<string, Action<HolographicControlTag>> actionData = new();
    internal static readonly Dictionary<string, Func<HolographicControlTag, bool>> validityData = new();
    internal static readonly Dictionary<string, Sprite[]> icons = new();

    internal static readonly Sprite defaultOffIcon =
        Sprite.Create(TextureManager.getTexture(SNUtil.diDLL, "Textures/HoloButton_false"), new Rect(0, 0, 200, 200),
            new Vector2(0, 0));

    internal static readonly Sprite defaultOnIcon =
        Sprite.Create(TextureManager.getTexture(SNUtil.diDLL, "Textures/HoloButton_true"), new Rect(0, 0, 200, 200),
            new Vector2(0, 0));

    private readonly Assembly ownerMod;

    private Sprite[] spr;

    [SetsRequiredMembers]
    public HolographicControl(string name, string desc, Action<HolographicControlTag> a,
        Func<HolographicControlTag, bool> f) : base("HoloControl_" + name, "Holographic Control - " + name, desc)
    {
        ownerMod = SNUtil.tryGetModDLL();

        LanguageHandler.SetLanguageLine("holocontrol_" + Info.ClassID, desc);
        actionData[Info.ClassID] = a;
        validityData[Info.ClassID] = f;
        if (spr != null)
            icons[Info.ClassID] = spr;
        else
            icons[Info.ClassID] = new[] {defaultOffIcon, defaultOnIcon};
        SaveSystem.addSaveHandler(Info.ClassID,
            new SaveSystem.ComponentFieldSaveHandler<HolographicControlTag>().addField("isToggled"));
        SetGameObject(GetGameObject());
    }

    public HolographicControl setIcons(string pathAndName, int size)
    {
        var off = Sprite.Create(TextureManager.getTexture(ownerMod, pathAndName + "_false"), new Rect(0, 0, size, size),
            new Vector2(0, 0));
        var on = Sprite.Create(TextureManager.getTexture(ownerMod, pathAndName + "_true"), new Rect(0, 0, size, size),
            new Vector2(0, 0));
        return setIcons(off, on);
    }

    public HolographicControl setIcons(Sprite off, Sprite on)
    {
        spr = new[] {off, on};
        return this;
    }

    public GameObject GetGameObject()
    {
        var world = new GameObject(Info.ClassID);
        world.EnsureComponent<TechTag>().type = Info.TechType;
        world.EnsureComponent<PrefabIdentifier>().ClassId = Info.ClassID;
        world.EnsureComponent<LargeWorldEntity>().cellLevel = LargeWorldEntity.CellLevel.Near;
        var c = world.EnsureComponent<Canvas>();
        c.renderMode = RenderMode.WorldSpace;
        c.scaleFactor = 1;
        c.planeDistance = 100;
        c.referencePixelsPerUnit = 100;
        c.normalizedSortingGridSize = 0.1F;
        c.pixelPerfect = false;
        c.overrideSorting = false;
        c.overridePixelPerfect = false;
        world.EnsureComponent<CanvasScaler>().scaleFactor = 1;
        world.EnsureComponent<GraphicRaycaster>();
        var gph = new GameObject("graphic");
        var cr = gph.EnsureComponent<CanvasRenderer>();
        gph.transform.SetParent(world.transform);
        gph.transform.localScale = new Vector3(0.0025F, 0.0025F, 1F);
        var img = gph.EnsureComponent<Image>();
        img.sprite = icons[Info.ClassID][0];
        var box = gph.EnsureComponent<SphereCollider>();
        box.center = Vector3.zero;
        box.radius = 0.5F;
        box.isTrigger = true;
        gph.layer = LayerID.Useable;
        world.layer = LayerID.Useable;
        gph.EnsureComponent<HolographicControlTag>();
        return world;
    }

    public class HolographicControlTag : MonoBehaviour, IHandTarget
    {
        private bool isToggled;

        public void OnHandHover(GUIHand hand)
        {
            HandReticle.main.SetText(HandReticle.TextType.Use,
                "holocontrol_" + GetComponentInParent<PrefabIdentifier>().ClassId, true);
            HandReticle.main.SetIcon(HandReticle.IconType.Interact);
        }

        public void OnHandClick(GUIHand hand)
        {
            actionData[GetComponentInParent<PrefabIdentifier>().ClassId].Invoke(this);
            SoundManager.playSoundAt(SoundManager.buildSound("event:/sub_module/fabricator/fabricator_click"),
                gameObject.transform.position);
        }

        public void setState(bool toggle)
        {
            if (toggle != isToggled)
                GetComponent<Image>().sprite = icons[GetComponentInParent<PrefabIdentifier>().ClassId][toggle ? 1 : 0];
            isToggled = toggle;
            SendMessageUpwards("SetHolographicControlState", this, SendMessageOptions.DontRequireReceiver);
        }

        public bool getState()
        {
            return isToggled;
        }

        public void disable()
        {
            setState(false);
        }

        public void enableForDuration(float time)
        {
            setState(true);
            Invoke("disable", time);
        }

        public bool isStillValid()
        {
            return validityData[GetComponentInParent<PrefabIdentifier>().ClassId].Invoke(this);
        }

        public void destroy()
        {
            DestroyImmediate(GetComponentInParent<PrefabIdentifier>().gameObject);
        }
    }
}