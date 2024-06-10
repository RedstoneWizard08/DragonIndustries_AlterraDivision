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
using ReikaKalseki.DIAlterra.Api.Util;
using UnityEngine;

namespace ReikaKalseki.DIAlterra.BuildSystem.ObjectManipulation.Global.LocalFilters;

internal sealed class PrefabCheck : LocalCheck
{
    private string id;

    internal override bool apply(GameObject go)
    {
        return ObjectUtil.getPrefabID(go) == id;
    }

    internal override void loadFromXML(XmlElement e)
    {
        id = e.getProperty("id");
    }

    internal override void saveToXML(XmlElement e)
    {
        e.addProperty("id", id);
    }
}