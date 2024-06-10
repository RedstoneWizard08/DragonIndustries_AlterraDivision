﻿/*
 * Created by SharpDevelop.
 * User: Reika
 * Date: 11/04/2022
 * Time: 4:11 PM
 *
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System.Xml;
using ReikaKalseki.DIAlterra.Api.Auxiliary;
using ReikaKalseki.DIAlterra.Api.Instantiable;
using ReikaKalseki.DIAlterra.Api.Util;
using UnityEngine;

namespace ReikaKalseki.DIAlterra.BuildSystem.ObjectManipulation;

internal sealed class AddChild : ManipulationBase
{
    private string objName;

    private DIPositionedPrefab prefab;

    public override void applyToObject(GameObject go)
    {
        if (!string.IsNullOrEmpty(objName))
            if (ObjectUtil.getChildObject(go, objName) != null)
                return;
        var add = ObjectUtil.createWorldObject(prefab.prefabName);
        add.transform.parent = go.transform;
        add.transform.localPosition = prefab.position;
        add.transform.localRotation = prefab.rotation;
        add.transform.localScale = prefab.scale;
        if (!string.IsNullOrEmpty(objName))
            add.name = objName;
        foreach (var mb in prefab.manipulations) mb.applyToObject(add);
    }

    public override void applyToObject(PlacedObject go)
    {
        applyToObject(go.obj);
    }

    public override void loadFromXML(XmlElement e)
    {
        objName = e.getProperty("name", true);
        prefab = new DIPositionedPrefab(e.getProperty("prefab"));
        prefab.loadFromXML(e);
    }

    public override void saveToXML(XmlElement e)
    {
        e.addProperty("prefab", prefab.prefabName);
        prefab.saveToXML(e);
        if (!string.IsNullOrEmpty(objName))
            e.addProperty("name", objName);
    }

    public override bool needsReapplication()
    {
        foreach (var mb in prefab.manipulations)
            if (mb.needsReapplication())
                return true;
        return false;
    }
}