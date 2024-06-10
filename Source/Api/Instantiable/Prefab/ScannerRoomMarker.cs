using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using Nautilus.Assets;
using Nautilus.Handlers;
using ReikaKalseki.DIAlterra.Api.Registry;
using ReikaKalseki.DIAlterra.Api.Util;
using UnityEngine;

namespace ReikaKalseki.DIAlterra.Api.Instantiable.Prefab;

public sealed class ScannerRoomMarker : DICustomPrefab
{
    public readonly TechType markerType;

    private readonly Assembly ownerMod;

    [SetsRequiredMembers]
    public ScannerRoomMarker(TechType markAs) : base("ScannerRoomMarker_" + markAs.AsString(), "", "")
    {
        markerType = markAs;
        ownerMod = SNUtil.tryGetModDLL();
        SpriteHandler.RegisterSprite(markerType,
            TextureManager.getSprite(ownerMod, "Textures/" + markerType.AsString()));
        var world = new GameObject("ScannerRoomMarker(Clone)");
        world.EnsureComponent<TechTag>().type = Info.TechType;
        var pi = world.EnsureComponent<PrefabIdentifier>();
        pi.ClassId = Info.ClassID;
        var tgt = world.EnsureComponent<ResourceTracker>();
        tgt.techType = markerType;
        tgt.overrideTechType = markerType;
        tgt.prefabIdentifier = pi;
        SetGameObject(world);
    }
}