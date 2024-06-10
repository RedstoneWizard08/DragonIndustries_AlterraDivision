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

internal class SeabaseLegLengthPreservation : ManipulationBase
{
    private readonly XmlElement data;

    internal SeabaseLegLengthPreservation(XmlElement e)
    {
        data = e;
    }

    public override void applyToObject(GameObject go)
    {
        var bf = go.GetComponent<BaseFoundationPiece>();
        if (bf)
        {
            if (data == null)
            {
                Object.DestroyImmediate(bf.gameObject);
            }
            else
            {
                bf.maxPillarHeight = (float) data.getFloat("maxHeight", double.NaN);
                bf.extraHeight = (float) data.getFloat("extra", double.NaN);
                bf.minHeight = (float) data.getFloat("minHeight", double.NaN);
                var li = data.getDirectElementsByTagName("pillar");
                foreach (var p in bf.pillars)
                {
                    var l = p.adjustable;
                    if (l)
                    {
                        var matched = false;
                        foreach (var e3 in li)
                        {
                            var pos = e3.getVector("position").Value;
                            //SNUtil.log("Comparing xml pos "+pos+" to "+l.position+" = "+Vector3.Distance(pos, l.position));
                            if (Vector3.Distance(pos, l.position) <= 0.25)
                            {
                                l.rotation = e3.getQuaternion("rotation").Value;
                                l.localScale = e3.getVector("scale").Value;
                                SNUtil.log("Applied pillar match " + e3.OuterXml, SNUtil.diDLL);
                                matched = true;
                            }
                        }

                        if (!matched || (!p.bottom && p.adjustable.localScale == Vector3.one))
                        {
                            //SNUtil.log("Destroying base leg @ "+l.position);
                            if (p.bottom)
                                Object.DestroyImmediate(p.bottom.gameObject);
                            if (p.adjustable)
                                Object.DestroyImmediate(p.adjustable.gameObject);
                            Object.DestroyImmediate(p.root);
                        }

                        if (l)
                            foreach (var s in Object.FindObjectsOfType<Shocker>())
                                if (s && s.gameObject)
                                    ObjectUtil.ignoreCollisions(s.gameObject, l.gameObject);
                    }
                }
            }
        }
    }

    public override void applyToObject(PlacedObject go)
    {
        applyToObject(go.obj);
    }

    public override void loadFromXML(XmlElement e)
    {
    }

    public override void saveToXML(XmlElement e)
    {
    }

    public override bool needsReapplication()
    {
        return false;
    }
}