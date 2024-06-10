/*
 * Created by SharpDevelop.
 * User: Reika
 * Date: 11/04/2022
 * Time: 4:11 PM
 *
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System.Collections.Generic;
using System.Xml;
using ReikaKalseki.DIAlterra.Api.Auxiliary;
using ReikaKalseki.DIAlterra.Api.Util;
using UnityEngine;

namespace ReikaKalseki.DIAlterra.BuildSystem.ObjectManipulation;

public class WreckDoorSwaps : ManipulationBase
{
    private readonly List<DoorSwap> swaps = new();

    public override void applyToObject(GameObject go)
    {
        foreach (var d in swaps)
        {
            var found = false;
            foreach (Transform t in ObjectUtil.getChildObject(go, "Doors").transform)
            {
                if (!t || !t.gameObject)
                    continue;
                var pos = t.position;
                //SNUtil.log("Checking door "+t.position);
                if (Vector3.Distance(d.position, pos) <= 0.5)
                {
                    found = true;
                    d.applyTo(t.gameObject);
                    //SNUtil.log("Matched to door "+pos+", converted to "+d.doorType, SNUtil.diDLL);
                }
            }

            if (!found)
                SNUtil.log("Door swap @ " + d.position + " found no match!!", SNUtil.diDLL);
        }
    }

    public override void applyToObject(PlacedObject go)
    {
        applyToObject(go.obj);
    }

    public override void loadFromXML(XmlElement e)
    {
        swaps.Clear();
        foreach (var e2 in e.getDirectElementsByTagName("door"))
        {
            var d = new DoorSwap(e2.getVector("position").Value, e2.getProperty("type"));
            swaps.Add(d);
        }
    }

    public override void saveToXML(XmlElement e)
    {
        foreach (var d in swaps)
        {
            var e2 = e.OwnerDocument.CreateElement("door");
            e2.addProperty("position", d.position);
            e2.addProperty("type", d.doorType);
            e.AppendChild(e2);
        }
    }

    public class DoorSwap
    {
        internal static readonly Dictionary<string, string> doorPrefabs = new()
        {
            {"Blocked", "d79ab37f-23b6-42b9-958c-9a1f4fc64cfd"},
            {"Handle", "d9524ffa-11cf-4265-9f61-da6f0fe84a3f"},
            {"Laser", "6f01d2df-03b8-411f-808f-b3f0f37b0d5c"},
            {"Repair", "b86d345e-0517-4f6e-bea4-2c5b40f623b4"},
            {"Openable", "b86d345e-0517-4f6e-bea4-2c5b40f623b4"},
            {"Delete", "b86d345e-0517-4f6e-bea4-2c5b40f623b4"}
        };

        internal readonly string doorType;

        internal readonly Vector3 position;

        public DoorSwap(Vector3 pos, string t)
        {
            position = pos;
            doorType = t;
        }

        public void applyTo(GameObject go)
        {
            var par = go.transform.parent;
            var put = ObjectUtil.createWorldObject(doorPrefabs[doorType]);
            if (put == null)
            {
                SNUtil.writeToChat("Could not find prefab for door type " + doorType);
                return;
            }

            put.transform.position = go.transform.position;
            put.transform.rotation = go.transform.rotation;
            put.transform.parent = par;
            Object.DestroyImmediate(go);
            var d = put.GetComponent<StarshipDoor>();
            if (d)
            {
                if (doorType == "Delete")
                {
                    ObjectUtil.removeChildObject(put, "Starship_doors_manual_01/Starship_doors_automatic");
                }
                else if (doorType == "Openable")
                {
                    d.UnlockDoor();
                }
                else if (doorType == "Repair")
                {
                    d.LockDoor();
                    var panel = ObjectUtil.createWorldObject("bb16d2bf-bc85-4bfa-a90e-ddc7343b0ac2");
                    panel.transform.position = put.transform.position;
                    panel.transform.rotation = put.transform.rotation;
                    var weld = panel.EnsureComponent<WeldableWallPanelGeneric>();
                    //FIXME finish
                }
            }
        }
    }
}