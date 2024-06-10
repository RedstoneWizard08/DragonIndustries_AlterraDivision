namespace ReikaKalseki.DIAlterra.Api.Instantiable.Component;

public class PlayerMovementSpeedModifier : SelfRemovingComponent
{
    public float speedModifier = 1;

    public static void add(float modifier, float duration)
    {
        var m = Player.main.gameObject.AddComponent<PlayerMovementSpeedModifier>();
        m.speedModifier = modifier;
        m.elapseWhen = DayNightCycle.main.timePassedAsFloat + duration;
    }
}