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

internal class CleanupDegasiProp : SwapTexture
{
    private bool removeLight;

    public CleanupDegasiProp()
    {
        init();
    }

    public override void applyToObject(GameObject go)
    {
        base.applyToObject(go);

        ObjectUtil.removeChildObject(go, "BaseCell/Coral");
        ObjectUtil.removeChildObject(go, "BaseCell/Decals");

        if (removeLight)
            ObjectUtil.removeChildObject(go, "tech_light_deco");
    }

    private void init()
    {
        addSwap("Base_abandoned_Foundation_Platform_01", "Base_Foundation_Platform_01");
        addSwap("Base_abandoned_Foundation_Platform_01_normal", "Base_Foundation_Platform_01_normal");
        addSwap("Base_abandoned_Foundation_Platform_01_illum", "Base_Foundation_Platform_01_illum");
    }

    public override void loadFromXML(XmlElement e)
    {
        base.loadFromXML(e);

        bool.TryParse(e.InnerText, out removeLight);

        init();
    }

    protected override Texture2D getTexture(string name, string texType)
    {
        var go = Base.pieces[(int) Base.Piece.Foundation].prefab.gameObject;
        go = ObjectUtil.getChildObject(go, "models/BaseFoundationPlatform");
        return (Texture2D) RenderUtil.extractTexture(go, texType);
    }
}