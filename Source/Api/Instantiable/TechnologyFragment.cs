using System;
using ReikaKalseki.DIAlterra.Api.Util;
using UnityEngine;

namespace ReikaKalseki.DIAlterra.Api.Instantiable;

public class TechnologyFragment
{
    public readonly Action<GameObject> objectModify;

    public readonly string template;
    public GenUtil.ContainerPrefab fragmentPrefab;

    public TechType target;

    public TechnologyFragment(string pfb, Action<GameObject> a = null)
    {
        template = pfb;
        objectModify = a;
    }

    public static TechnologyFragment createFragment(string pfb, TechType tech, string name, int needed,
        float scanTime = 2, bool destroyOnScan = true, Action<GameObject> a = null)
    {
        var ret = new TechnologyFragment(pfb, a);
        ret.target = tech;
        createFragment(ret, name, needed, scanTime);
        return ret;
    }

    public static void createFragment(TechnologyFragment tf, string name, int needed, float scanTime = 2,
        bool destroyOnScan = true)
    {
        SNUtil.log("Creating fragments for " + tf.target);
        tf.fragmentPrefab = GenUtil.getOrCreateFragment(tf.target, name, tf.template, tf.objectModify);
        SNUtil.addPDAEntry(tf.fragmentPrefab, scanTime, null, null, null, e =>
        {
            e.blueprint = tf.target;
            e.destroyAfterScan = destroyOnScan;
            e.isFragment = true;
            e.totalFragments = needed;
            e.key = GenUtil.getFragment(tf.target, 0).Info.TechType;
        });
    }
}