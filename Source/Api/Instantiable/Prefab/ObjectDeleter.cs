using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using Nautilus.Assets;
using ReikaKalseki.DIAlterra.Api.Util;
using UnityEngine;

namespace ReikaKalseki.DIAlterra.Api.Instantiable.Prefab;

public sealed class ObjectDeleter : DICustomPrefab
{
    private readonly Assembly ownerMod;

    [SetsRequiredMembers]
    public ObjectDeleter() : base("ObjectDeleter", "", "")
    {
        ownerMod = SNUtil.tryGetModDLL(true);
        var world = new GameObject();
        world.EnsureComponent<ObjectDeleterTag>();
        world.EnsureComponent<LargeWorldEntity>().cellLevel = LargeWorldEntity.CellLevel.Medium;
        SetGameObject(world);
    }

    private class ObjectDeleterTag : MonoBehaviour
    {
        private void Start()
        {
            foreach (var go in WorldUtil.getObjectsNearWithComponent<PrefabIdentifier>(transform.position,
                         transform.localScale.x))
                //if (go != this) //delete self too
                Destroy(go.gameObject);
        }
    }
}