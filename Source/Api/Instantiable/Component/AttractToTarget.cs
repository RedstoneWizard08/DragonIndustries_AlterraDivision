using ReikaKalseki.DIAlterra.Api.Registry;
using UnityEngine;

namespace ReikaKalseki.DIAlterra.Api.Instantiable.Component;

public class AttractToTarget : MonoBehaviour
{
    private MeleeAttack[] attacks;
    private AttackCyclops cyclopsAttacker;

    private float delete;
    private bool isHorn;

    private float lastTick;
    private StayAtLeashPosition leash;

    private Creature owner;
    private SwimBehaviour swimmer;

    private MonoBehaviour target;
    private LastTarget targeter;
    private AggressiveWhenSeeTarget[] targeting;

    private void Update()
    {
        if (!owner)
            owner = GetComponent<Creature>();
        if (!swimmer)
            swimmer = GetComponent<SwimBehaviour>();
        if (!leash)
            leash = GetComponent<StayAtLeashPosition>();
        if (!cyclopsAttacker)
            cyclopsAttacker = GetComponent<AttackCyclops>();
        if (!targeter)
            targeter = GetComponent<LastTarget>();
        if (attacks == null)
            attacks = GetComponents<MeleeAttack>();
        if (targeting == null)
            targeting = GetComponents<AggressiveWhenSeeTarget>();

        var time = DayNightCycle.main.timePassedAsFloat;
        if (time >= delete)
        {
            DestroyImmediate(this);
            return;
        }

        if (time - lastTick <= 0.5)
            return;
        lastTick = time;

        if (owner is Reefback && isHorn)
        {
            var r = (Reefback) owner;
            swimmer.SwimTo(target.transform.position, r.maxMoveSpeed);
            r.friendlyToPlayer = target.gameObject;
            return;
        }

        if (target is SubRoot && !(cyclopsAttacker && cyclopsAttacker.isActiveAndEnabled))
            return;

        if (Vector3.Distance(transform.position, target.transform.position) >= 40)
            swimmer.SwimTo(target.transform.position, 10);

        owner.Aggression.Add(isHorn ? 0.5F : 0.05F);
        if (cyclopsAttacker)
            cyclopsAttacker.SetCurrentTarget(target.gameObject, false);
        if (targeter)
            targeter.SetTarget(target.gameObject);
        if (owner is CrabSnake)
        {
            var cs = (CrabSnake) owner;
            if (cs.IsInMushroom()) cs.ExitMushroom(target.transform.position);
        }

        //if (leash)
        //	leash.
        foreach (var a in attacks)
            a.lastTarget.SetTarget(target.gameObject);
        foreach (var a in targeting)
            a.lastTarget.SetTarget(target.gameObject);
    }

    public static AttractToTarget attractCreatureToTarget(Creature c, MonoBehaviour obj, bool isHorn)
    {
        if (obj is BaseRoot)
            obj = obj.GetComponentsInChildren<BaseCell>().GetRandom().GetComponent<LiveMixin>();
        var ac = c.gameObject.EnsureComponent<AttractToTarget>();
        //SNUtil.writeToChat("Attracted "+c+" @ "+c.transform.position+" to "+obj+" @ "+obj.transform.position);
        ac.fire(obj, isHorn);
        if (c is Reefback && isHorn)
            SoundManager.playSoundAt(c.GetComponent<FMOD_CustomLoopingEmitter>().asset, c.transform.position, false,
                -1);
        return ac;
    }

    private void fire(MonoBehaviour from, bool horn)
    {
        target = from;
        isHorn |= horn;
        delete = Mathf.Max(delete, DayNightCycle.main.timePassedAsFloat + 20);
    }

    public bool isTargeting(GameObject go)
    {
        return target.gameObject == go;
    }
}