/*
 * Created by SharpDevelop.
 * User: Reika
 * Date: 11/04/2022
 * Time: 4:11 PM
 *
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System.Xml;
using ReikaKalseki.DIAlterra.Api.Util;
using UnityEngine;

namespace ReikaKalseki.DIAlterra.BuildSystem.ObjectManipulation;

public class DeleteChildObject : ManipulationBase
{
    private string path;

    public override void applyToObject(GameObject go)
    {
        ObjectUtil.removeChildObject(go, path);
    }

    public override void applyToObject(PlacedObject go)
    {
        applyToObject(go.obj);
    }

    public override void loadFromXML(XmlElement e)
    {
        path = e.InnerText;
    }

    public override void saveToXML(XmlElement e)
    {
        e.InnerText = path;
    }
}