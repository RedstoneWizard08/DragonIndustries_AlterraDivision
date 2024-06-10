﻿/*
 * Created by SharpDevelop.
 * User: Reika
 * Date: 11/04/2022
 * Time: 4:11 PM
 *
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Xml;
using ReikaKalseki.DIAlterra.Api.Util;
using UnityEngine;

namespace ReikaKalseki.DIAlterra.BuildSystem.ObjectManipulation;

[Obsolete]
public sealed class RemoveComponent : ManipulationBase
{
    private Type type;

    public override void applyToObject(PlacedObject go)
    {
        applyToObject(go.obj);
    }

    public override void applyToObject(GameObject go)
    {
        ObjectUtil.removeComponent(go, type);
    }

    public override void loadFromXML(XmlElement e)
    {
        type = InstructionHandlers.getTypeBySimpleName(e.InnerText);
    }

    public override void saveToXML(XmlElement e)
    {
        e.InnerText = type.Name;
    }
}