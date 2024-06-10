using System.Collections.Generic;
using ReikaKalseki.DIAlterra.Api.Util;
using UnityEngine;

namespace ReikaKalseki.DIAlterra.Api.Instantiable.Component;

public class DynamicBubbler : MonoBehaviour
{
    public Vector3 scatter = Vector3.one * 0.05F;

    public float currentIntensity;
    private readonly List<ParticleSystem> bubbles = new();

    private int bubbleCount;

    private void Update()
    {
        while (bubbles.Count < bubbleCount)
        {
            var go = ObjectUtil.createWorldObject("0dbd3431-62cc-4dd2-82d5-7d60c71a9edf");
            go.transform.SetParent(transform);
            go.transform.localPosition = MathUtil.getRandomVectorAround(Vector3.zero, scatter);
            go.transform.rotation = Quaternion.Euler(270, 0, 0); //not local - force to always be up
            var ps = go.GetComponent<ParticleSystem>();
            ps.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
            go.SetActive(true);
            bubbles.Add(ps);
        }

        var bubN = Mathf.CeilToInt(bubbles.Count * currentIntensity);
        for (var i = 0; i < bubbles.Count; i++)
        {
            if (i < bubN)
                bubbles[i].Play();
            else
                bubbles[i].Stop(true, ParticleSystemStopBehavior.StopEmitting);
            bubbles[i].transform.rotation = Quaternion.Euler(270, 0, 0); //not local - force to always be up
        }
    }

    public DynamicBubbler setBubbleCount(int amt)
    {
        if (amt != bubbleCount)
        {
            foreach (var p in bubbles)
                DestroyImmediate(p.gameObject);
            bubbles.Clear();
            bubbleCount = amt;
        }

        return this;
    }

    public void clear()
    {
        foreach (var ps in bubbles) ps.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
    }
}