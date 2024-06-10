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
using UnityEngine;

namespace ReikaKalseki.DIAlterra.BuildSystem.ObjectManipulation;

public sealed class ModifyLight : ModifyComponent<Light>
{
    private Color? color = Color.white;
    private double intensity = 1;

    private double range = 1;

    public override void modifyComponent(Light c)
    {
        c.range = (float) range;
        c.intensity = (float) intensity;
        if (color != null && color.HasValue)
            c.color = color.Value;
    }

    public override void loadFromXML(XmlElement e)
    {
        range = e.getFloat("range", double.NaN);
        intensity = e.getFloat("intensity", double.NaN);
        color = e.getColor("color", true, true);
    }

    public override void saveToXML(XmlElement e)
    {
        e.addProperty("intensity", intensity);
        e.addProperty("range", range);
        if (color != null && color.HasValue)
            e.addProperty("color", color.Value);
    }
}