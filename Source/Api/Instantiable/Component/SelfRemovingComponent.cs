using UnityEngine;

namespace ReikaKalseki.DIAlterra.Api.Instantiable.Component;

public abstract class SelfRemovingComponent : MonoBehaviour
{
    public float elapseWhen;

    protected virtual void Update()
    {
        if (DayNightCycle.main.timePassedAsFloat >= elapseWhen) Destroy(this);
    }

    private void OnKill()
    {
        Destroy(this);
    }
}