/*
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

namespace ReikaKalseki.DIAlterra.BuildSystem.ObjectManipulation;

internal class SetACUStack : ManipulationBase
{
    private bool glassTop;

    private bool isBottomOfStack;
    private bool isTopOfStack;

    public override void applyToObject(GameObject go)
    {
        var floor = ObjectUtil.getChildObject(go, "BaseWaterParkFloorBottom");
        var middleBottom = ObjectUtil.getChildObject(go, "BaseWaterParkFloorMiddle");
        var middleTop = ObjectUtil.getChildObject(go, "BaseWaterParkCeilingMiddle");
        var ceiling = ObjectUtil.getChildObject(go, "BaseWaterParkCeilingTop");
        var gt = ObjectUtil.getChildObject(go, "BaseWaterParkCeilingGlass");
        floor.SetActive(isBottomOfStack);
        middleBottom.SetActive(!isBottomOfStack);
        ceiling.SetActive(isTopOfStack);
        middleTop.SetActive(!isTopOfStack);
        gt.SetActive(isTopOfStack && glassTop);
    }

    public override void applyToObject(PlacedObject go)
    {
        applyToObject(go.obj);
    }

    public override void loadFromXML(XmlElement e)
    {
        isBottomOfStack = e.getBoolean("Bottom");
        isTopOfStack = e.getBoolean("Top");
        glassTop = e.getBoolean("GlassTop");
    }

    public override void saveToXML(XmlElement e)
    {
        e.addProperty("Bottom", isBottomOfStack);
        e.addProperty("Top", isTopOfStack);
        e.addProperty("GlassTop", glassTop);
    }
}