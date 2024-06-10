/*
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

internal class ChangePrecursorDoor : ManipulationBase
{
    private PrecursorKeyTerminal.PrecursorKeyType targetType;

    public override void applyToObject(GameObject go)
    {
        var pk = go.GetComponentInChildren<PrecursorKeyTerminal>();
        if (pk == null)
            foreach (var c in go.GetComponentsInChildren<Component>())
                SNUtil.log("extra Component " + c + "/" + c.GetType() + " in " + c.gameObject);
        pk.acceptKeyType = targetType;
    }

    public override void applyToObject(PlacedObject go)
    {
        applyToObject(go.obj);
    }

    public override void loadFromXML(XmlElement e)
    {
        targetType =
            (PrecursorKeyTerminal.PrecursorKeyType) Enum.Parse(typeof(PrecursorKeyTerminal.PrecursorKeyType),
                e.InnerText);
    }

    public override void saveToXML(XmlElement e)
    {
        e.InnerText = Enum.GetName(typeof(PrecursorKeyTerminal.PrecursorKeyType), targetType);
    }
}