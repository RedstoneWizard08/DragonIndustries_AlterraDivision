using System.Collections.Generic;
using UnityEngine;

namespace ReikaKalseki.DIAlterra.Api.Instantiable.Component;

public class SonarOnlyRenderer : MonoBehaviour
{
    public List<SonarRender> renderers = new();

    private SonarScreenFX sonar;

    protected virtual void Update()
    {
        if (!sonar && Camera.main)
            sonar = Camera.main.GetComponent<SonarScreenFX>();
        var sonarDist = computeSonarDistance();
        var dT = Time.deltaTime;
        foreach (var r in renderers)
        {
            if (!r.renderer)
                continue;
            if (isBlobVisible(r.renderer, sonarDist))
                r.intensity = Mathf.Min(1, r.intensity + dT * r.fadeInSpeed);
            else
                r.intensity = Mathf.Max(0, r.intensity - dT * r.fadeOutSpeed);
            r.renderer.enabled = r.intensity > 0; //;
        }
    }

    public float computeSonarDistance()
    {
        return sonar && sonar.enabled ? sonar.pingDistance * 350 : -1;
    }

    public bool isBlobVisible(Renderer r, float sonarDist, float tolerance = 1)
    {
        if (!sonar || sonarDist < 0)
            return false;
        var dist = Vector3.Distance(r.transform.position, sonar.transform.position);
        var near = dist > sonarDist;
        return near ? dist - sonarDist <= 15 * tolerance : sonarDist - dist <= 120 * tolerance;
    }

    public class SonarRender
    {
        public readonly Renderer renderer;
        public float fadeInSpeed = 999;
        public float fadeOutSpeed = 999;
        public float intensity;

        public SonarRender(Renderer r)
        {
            renderer = r;
        }
    }
}