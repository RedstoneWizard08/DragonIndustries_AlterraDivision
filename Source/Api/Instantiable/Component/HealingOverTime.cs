using UnityEngine;

namespace ReikaKalseki.DIAlterra.Api.Instantiable.Component;

public class HealingOverTime : MonoBehaviour
{
    private static readonly float TICK_RATE = 0.25F;
    private float healingRemaining;

    private float healRate;
    private float startTime;
    private float totalDuration;

    private float totalToHeal;

    public HealingOverTime setValues(float total, float seconds)
    {
        totalToHeal = total;
        totalDuration = seconds;
        healingRemaining = total;
        healRate = totalToHeal / seconds * TICK_RATE;
        return this;
    }

    public void activate()
    {
        CancelInvoke("tick");
        startTime = Time.time;
        InvokeRepeating("tick", 0f, TICK_RATE);
    }

    internal void tick()
    {
        var amt = Mathf.Min(healingRemaining, healRate);
        Player.main.GetComponent<LiveMixin>().AddHealth(amt);
        healingRemaining -= amt;
        if (healingRemaining <= 0)
            Destroy(this);
    }

    private void OnKill()
    {
        Destroy(this);
    }
}