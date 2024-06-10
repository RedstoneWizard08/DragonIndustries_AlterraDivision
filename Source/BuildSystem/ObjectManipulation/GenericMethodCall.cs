﻿/*
 * Created by SharpDevelop.
 * User: Reika
 * Date: 11/04/2022
 * Time: 4:11 PM
 *
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System.Reflection;
using System.Xml;
using ReikaKalseki.DIAlterra.Api.Auxiliary;
using ReikaKalseki.DIAlterra.Api.Util;
using UnityEngine;

namespace ReikaKalseki.DIAlterra.BuildSystem.ObjectManipulation;

internal abstract class GenericMethodCall : ManipulationBase
{
    private MethodInfo call;

    public override void applyToObject(GameObject go)
    {
        call.Invoke(null, new object[] {go});
    }

    public override void applyToObject(PlacedObject go)
    {
        applyToObject(go.obj);
    }

    public override void loadFromXML(XmlElement e)
    {
        var tn = e.getProperty("typeName");
        var name = e.getProperty("name");
        var t = InstructionHandlers.getTypeBySimpleName(tn);
        //call = t.GetMethod(name, unchecked((System.Reflection.BindingFlags)0x7fffffff));
        call = t.GetMethod(name, new[] {typeof(GameObject)});
    }

    public override void saveToXML(XmlElement e)
    {
        e.addProperty("typeName", call.DeclaringType.Name);
        e.addProperty("name", call.Name);
    }
}