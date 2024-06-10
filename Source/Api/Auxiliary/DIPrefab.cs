﻿using System.Collections.Generic;
using System.Reflection;
using Nautilus.Assets;
using UnityEngine;

namespace ReikaKalseki.DIAlterra.Api.Auxiliary;

public interface DIPrefab<E, T> : DIPrefab<T> where T : PrefabReference
{
    // ONLY EVER IMPLEMENT THIS ON MODPREFABS OR SUBCLASSES THEREOF

    E addIngredient(TechType item, int amt);

    E addIngredient(CustomPrefab item, int amt);

    E addIngredient(ItemDef item, int amt);
}

public interface DIPrefab<T> : DIPrefab where T : PrefabReference
{
    T baseTemplate { get; set; }
}

public interface DIPrefab
{
    float glowIntensity { get; set; }

    bool isResource();

    string getTextureFolder();

    void prepareGameObject(GameObject go, Renderer[] r);

    Atlas.Sprite getIcon();

    Assembly getOwnerMod();
}

public interface MultiTexturePrefab : DIPrefab
{
    Dictionary<int, string> getTextureLayers(Renderer r);
}

public sealed class StringPrefabContainer : PrefabReference
{
    public readonly string prefab;

    public StringPrefabContainer(string s)
    {
        prefab = s;
    }

    public string getPrefabID()
    {
        return prefab;
    }
}

public sealed class TechTypePrefabContainer : PrefabReference
{
    public readonly TechType tech;

    public TechTypePrefabContainer(TechType t)
    {
        tech = t;
    }

    public string getPrefabID()
    {
        return CraftData.GetClassIdForTechType(tech);
    }
}

public sealed class ModPrefabTechReference : TechTypeReference
{
    public readonly CustomPrefab prefab;

    public ModPrefabTechReference(CustomPrefab s)
    {
        prefab = s;
    }

    public TechType getTechType()
    {
        return prefab.Info.TechType;
    }
}

public sealed class TechTypeContainer : TechTypeReference
{
    public readonly TechType tech;

    public TechTypeContainer(TechType s)
    {
        tech = s;
    }

    public TechType getTechType()
    {
        return tech;
    }
}

public interface TechTypeReference
{
    TechType getTechType();
}

public sealed class PlannedIngredient
{
    public readonly int amount;

    public readonly TechTypeReference item;

    public PlannedIngredient(TechTypeReference item, int amt)
    {
        this.item = item;
        amount = amt;
    }
}