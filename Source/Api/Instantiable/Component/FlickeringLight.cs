using UnityEngine;

namespace ReikaKalseki.DIAlterra.Api.Instantiable.Component;

public class FlickeringLight : MonoBehaviour
{
    public float dutyCycle = 0.5F;
    public float updateRate = 0.5F;

    private float lastUpdate = -1;

    private Light light;

    private void Update()
    {
        if (!light)
            light = GetComponent<Light>();
        var time = DayNightCycle.main.timePassedAsFloat;
        if (time - lastUpdate >= updateRate)
        {
            light.enabled = Random.Range(0F, 1F) <= dutyCycle;
            lastUpdate = time;
        }
    }
}