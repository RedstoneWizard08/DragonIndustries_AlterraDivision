using System;
using System.Xml;
using ReikaKalseki.DIAlterra.Api.Auxiliary;
using ReikaKalseki.DIAlterra.Api.Base;
using ReikaKalseki.DIAlterra.Api.Util;
using UnityEngine;

namespace ReikaKalseki.DIAlterra.Api.Instantiable;

public class PositionedPrefab : ObjectTemplate
{
    [SerializeField] public Vector3 position;

    [SerializeField] public string prefabName;

    [SerializeField] public Quaternion rotation;

    [SerializeField] public Vector3 scale = Vector3.one;

    protected Guid? xmlID;

    public PositionedPrefab(string pfb, Vector3? pos = null, Quaternion? rot = null, Vector3? sc = null)
    {
        prefabName = pfb;
        position = GenUtil.getOrZero(pos);
        rotation = GenUtil.getOrIdentity(rot);
        if (sc != null && sc.HasValue)
            scale = sc.Value;
    }

    public PositionedPrefab(PrefabIdentifier pi)
    {
        prefabName = pi.classId;
        position = pi.transform.position;
        rotation = pi.transform.rotation;
        scale = pi.transform.localScale;
    }

    public PositionedPrefab(PositionedPrefab pfb)
    {
        prefabName = pfb.prefabName;
        position = pfb.position;
        rotation = pfb.rotation;
        scale = pfb.scale;
    }

    public override string getTagName()
    {
        return "basicprefab";
    }

    public sealed override string getID()
    {
        return prefabName;
    }

    public string getXMLID()
    {
        return xmlID.HasValue ? xmlID.Value.ToString() : null;
    }

    public virtual void replaceObject(string pfb)
    {
        prefabName = pfb;
    }

    public string getPrefab()
    {
        return prefabName;
    }

    public virtual GameObject createWorldObject()
    {
        var ret = ObjectUtil.createWorldObject(prefabName);
        if (ret != null)
        {
            ret.transform.position = position;
            ret.transform.rotation = rotation;
            ret.transform.localScale = scale;
        }

        return ret;
    }

    public Vector3 getPosition()
    {
        return new Vector3(position.x, position.y, position.z);
    }

    public Quaternion getRotation()
    {
        return new Quaternion(rotation.x, rotation.y, rotation.z, rotation.w);
    }

    public Vector3 getScale()
    {
        return new Vector3(scale.x, scale.y, scale.z);
    }

    public override void saveToXML(XmlElement n)
    {
        n.addProperty("prefab", prefabName);
        n.addProperty("position", position);
        var rot = n.addProperty("rotation", rotation.eulerAngles);
        rot.addProperty("quaternion", rotation);
        n.addProperty("scale", scale);

        if (xmlID != null && xmlID.HasValue)
            n.addProperty("xmlID", xmlID.Value.ToString());
    }

    public override string ToString()
    {
        return prefabName + " @ " + position + " / " + rotation.eulerAngles + " / " + scale;
    }

    public override void loadFromXML(XmlElement e)
    {
        setPrefabName(e.getProperty("prefab"));
        position = e.getVector("position").Value;
        XmlElement elem;
        var rot = e.getVector("rotation", out elem, true);
        //SBUtil.log("rot: "+rot);
        var quat = rotation;
        if (rot != null && rot.HasValue)
        {
            var specify = elem.getQuaternion("quaternion", true);
            //SBUtil.log("quat: "+specify);
            if (specify != null && specify.HasValue)
                quat = specify.Value;
            else
                quat = Quaternion.Euler(rot.Value.x, rot.Value.y, rot.Value.z);
        }

        rotation = quat;
        //SBUtil.log("use rot: "+rotation+" / "+rotation.eulerAngles);
        var sc = e.getVector("scale", true);
        if (sc != null && sc.HasValue)
            scale = sc.Value;

        var xmlid = e.getProperty("xmlID", true);
        if (!string.IsNullOrEmpty(xmlid)) xmlID = new Guid(xmlid);
    }

    protected virtual void setPrefabName(string name)
    {
        prefabName = name;
    }
}