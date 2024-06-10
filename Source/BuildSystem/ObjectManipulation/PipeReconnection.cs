﻿/*
 * Created by SharpDevelop.
 * User: Reika
 * Date: 11/04/2022
 * Time: 4:11 PM
 *
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System.Collections.Generic;
using System.Linq;
using System.Xml;
using ReikaKalseki.DIAlterra.Api.Util;
using UnityEngine;

namespace ReikaKalseki.DIAlterra.BuildSystem.ObjectManipulation;

internal class PipeReconnection : ManipulationBase
{
    private readonly Vector3 data;

    internal PipeReconnection(Vector3 vec)
    {
        data = vec;
    }

    public override void applyToObject(GameObject go)
    {
        go.EnsureComponent<PipeReconnector>().position = data;
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
        return true;
    }
}

internal class PipeReconnector : MonoBehaviour
{
    private IPipeConnection connection;

    private IPipeConnection pipe;
    internal Vector3 position;

    private void Update()
    {
        if (pipe == null)
            pipe = gameObject.GetComponent<IPipeConnection>();

        if (connection == null)
        {
            double dist = 9999;
            var li = new List<IPipeConnection>();
            li.AddRange(FindObjectsOfType<OxygenPipe>());
            li.AddRange(FindObjectsOfType<BasePipeConnector>());
            SNUtil.log(string.Join(",", li.Select(p => p + " @ " + ((MonoBehaviour) p).transform.position)));
            foreach (var conn in li)
            {
                var pos = ((MonoBehaviour) conn).transform.position;
                double dd = Vector3.Distance(pos, position);
                SNUtil.log("Pipe " + gameObject.transform.position + " check against " + pos + " @ dist=" + dd);
                if (connection == null || dd < dist)
                {
                    connection = conn;
                    dist = dd;
                    SNUtil.log("Reconnected");
                }
            }

            if (connection != null)
                pipe.SetParent(connection);
        }
    }
}