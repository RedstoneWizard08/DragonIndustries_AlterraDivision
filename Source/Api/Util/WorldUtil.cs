using System;
using System.Collections.Generic;
using mset;
using ReikaKalseki.DIAlterra.Api.Auxiliary;
using ReikaKalseki.DIAlterra.Api.Base;
using ReikaKalseki.DIAlterra.Api.Registry.VanillaData;
using UnityEngine;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;

namespace ReikaKalseki.DIAlterra.Api.Util;

public static class WorldUtil
{
    private static readonly Int3 batchOffset = new(13, 19, 13);
    private static readonly Int3 batchOffsetM = new(32, 0, 32);
    private static readonly int batchSize = 160;

    public static readonly Vector3 DUNES_METEOR = new(-1125, -380, 1130);
    public static readonly Vector3 LAVA_DOME = new(-273, -1355, -152);

    public static readonly Vector3 lavaCastleCenter = new(-49, -1242, 118);
    public static readonly float lavaCastleInnerRadius = 65; //75;

    public static readonly float lavaCastleRadius =
        Vector3.Distance(new Vector3(-116, -1194, 126), lavaCastleCenter) + 32;

    private static readonly Vector3 auroraPoint1 = new(746, 0, -362 - 50);
    private static readonly Vector3 auroraPoint2 = new(1295, 0, 110 - 50);
    private static readonly float auroraPointRadius = 275;

    private static readonly Vector3[] geysers =
    {
    };

    //private static readonly Dictionary<string, string> biomeNames = new Dictionary<string, string>();

    static WorldUtil()
    {
    }
    /*
    private static void mapBiomeName(string name, params string[] keys) {
        foreach (string s in keys) {
            biomeNames[s] = name;
        }
    }*/

    public static Int3 getBatch(Vector3 pos)
    {
        //"Therefore e.g. batch (12, 18, 12) covers the voxels from (-128, -160, -128) to (32, 0, 32)."
        var coord = pos.roundToInt3();
        coord = coord - batchOffsetM;
        coord.x = (int) Math.Floor(coord.x / (float) batchSize);
        coord.y = (int) Math.Floor(coord.y / (float) batchSize);
        coord.z = (int) Math.Floor(coord.z / (float) batchSize);
        return coord + batchOffset;
    }

    /**
     * Returns the min XYZ corner
     */
    public static Int3 getWorldCoord(Int3 batch)
    {
        //TODO https://i.imgur.com/sbXjIpq.png
        batch = batch - batchOffset;
        return batch * batchSize + batchOffsetM;
    }

    /*
batch_id = ((1117, -268, 568) + (2048.0,3040.0,2048.0)) / 160
batch_id = (3165.0, 2772.0, 2616.0) / 160
batch_id = (19.78125, 17.325, 16.35)
batch_id = (19, 17, 16)
     */

    public static GameObject dropItem(Vector3 pos, TechType item)
    {
        var id = CraftData.GetClassIdForTechType(item);
        if (id != null)
        {
            var go = ObjectUtil.createWorldObject(id);
            if (go != null)
                go.transform.position = pos;
            return go;
        }

        SNUtil.log("NO SUCH ITEM TO DROP: " + item);
        return null;
    }

    public static Sky getSkybox(string biome, bool allowNotFoundError = true)
    {
        var bb = BiomeBase.getBiome(biome);
        if (bb is CustomBiome)
            return ((CustomBiome) bb).getSky();
        var idx = WaterBiomeManager.main.GetBiomeIndex(biome);
        if (idx < 0)
        {
            if (allowNotFoundError)
            {
                SNUtil.writeToChat("Biome '" + biome + "' had no sky lookup. See log for biome table.");
                SNUtil.log(WaterBiomeManager.main.biomeLookup.toDebugString());
            }

            return null;
        }

        return idx < WaterBiomeManager.main.biomeSkies.Count ? WaterBiomeManager.main.biomeSkies[idx] : null;
    }

    public static C getClosest<C>(GameObject go) where C : Component
    {
        return getClosest<C>(go.transform.position);
    }

    public static C getClosest<C>(Vector3 pos) where C : Component
    {
        double distsq = -1;
        C ret = null;
        foreach (var obj in Object.FindObjectsOfType<C>())
        {
            if (!obj)
                continue;
            double dd = (pos - obj.transform.position).sqrMagnitude;
            if (dd < distsq || ret == null)
            {
                ret = obj;
                distsq = dd;
            }
        }

        return ret;
    }

    /**
     * Will not find things without colliders!
     * Avoid using this with components that will result in many findings, as you then end up iterating a large list. Use the getter version instead.
     */
    public static HashSet<C> getObjectsNearWithComponent<C>(Vector3 pos, float r) where C : MonoBehaviour
    {
        return getObjectsNear(pos, r, go => go.GetComponentInChildren<C>());
    }

    /**
     * Will not find things without colliders!
     */
    public static HashSet<GameObject> getObjectsNearMatching(Vector3 pos, float r, Predicate<GameObject> check)
    {
        return getObjectsNear(pos, r, go => check(go) ? go : null);
    }

    /**
     * Will not find things without colliders!
     */
    public static HashSet<GameObject> getObjectsNear(Vector3 pos, float r)
    {
        return getObjectsNear<GameObject>(pos, r);
    }

    /**
     * Will not find things without colliders!
     */
    public static HashSet<R> getObjectsNear<R>(Vector3 pos, float r, Func<GameObject, R> converter = null)
        where R : Object
    {
        var set = new HashSet<R>();
        getObjectsNear(pos, r, obj => set.Add(obj), converter);
        return set;
    }

    /**
     * Will not find things without colliders!
     */
    public static void getGameObjectsNear(Vector3 pos, float r, Action<GameObject> getter)
    {
        getObjectsNear(pos, r, getter);
    }

    /**
     * Will not find things without colliders!
     */
    public static void getObjectsNear<R>(Vector3 pos, float r, Action<R> getter, Func<GameObject, R> converter = null)
        where R : Object
    {
        getObjectsNear(pos, r, obj =>
        {
            getter(obj);
            return false;
        }, converter);
    }

    /**
     * Will not find things without colliders!
     */
    public static void getObjectsNear<R>(Vector3 pos, float r, Func<R, bool> getter,
        Func<GameObject, R> converter = null) where R : Object
    {
        foreach (var hit in Physics.SphereCastAll(pos, r, Vector3.up, 0.1F))
            if (hit.transform)
            {
                var go = UWE.Utils.GetEntityRoot(hit.transform.gameObject);
                if (!go)
                    go = hit.transform.gameObject;
                if (!go)
                    continue;
                Object obj = converter == null ? go : converter(go);
                if (obj)
                    if (getter((R) obj))
                        return;
            }
    }

    /**
     * Will not find things without colliders!
     */
    public static GameObject areAnyObjectsNear(Vector3 pos, float r, Predicate<GameObject> check)
    {
        GameObject ret = null;
        getObjectsNear(pos, r, go =>
        {
            ret = go;
            return true;
        }, go => check(go) ? go : null);
        return ret;
    }

    public static bool isPlantInNativeBiome(GameObject go)
    {
        if (!go)
            return false;
        var pi = go.FindAncestor<PrefabIdentifier>();
        var tt = CraftData.GetTechType(go);
        if (tt == TechType.None)
        {
            var p = go.FindAncestor<Plantable>();
            if (p)
                tt = p.plantTechType;
        }

        var vf = VanillaFlora.getFromID(pi ? pi.ClassId : CraftData.GetClassIdForTechType(tt));
        if (vf != null && vf.isNativeToBiome(go.transform.position))
            return true;
        var plant = BasicCustomPlant.getPlant(tt);
        if (plant != null && plant.isNativeToBiome(go.transform.position))
            return true;
        return false;
    }

    public static bool isInCave(Vector3 pos)
    {
        if (BiomeBase.getBiome(pos).isCaveBiome())
            return true;
        var b = WaterBiomeManager.main.GetBiome(pos, false);
        return !string.IsNullOrEmpty(b) && b.ToLowerInvariant().Contains("_cave");
    }

    public static bool isInWreck(Vector3 pos)
    {
        var biome = WaterBiomeManager.main.GetBiome(pos, false);
        return !string.IsNullOrEmpty(biome) && biome.ToLowerInvariant().Contains("wreck");
    }

    public static bool lineOfSight(GameObject o1, GameObject o2, Func<RaycastHit, bool> filter = null)
    {
        return lineOfSight(o1, o2, o1.transform.position, o2.transform.position, filter);
    }

    public static bool lineOfSight(GameObject o1, GameObject o2, Vector3 pos1, Vector3 pos2,
        Func<RaycastHit, bool> filter = null)
    {
        /*
            RaycastHit hit;
            Physics.Linecast(o1.transform.position, o2.transform.position, out hit);
            if (hit) {

            }*/
        var dd = pos2 - pos1;
        var hits = Physics.RaycastAll(pos1, dd.normalized, dd.magnitude);
        foreach (var hit in hits)
        {
            if (!hit.collider || hit.collider.isTrigger)
                continue;
            if (hit.transform == o1.transform || hit.transform == o2.transform)
                continue;
            if (filter != null && !filter.Invoke(hit))
                continue;
            if (Array.IndexOf(o1.GetComponentsInChildren<Collider>(), hit.collider) >= 0)
                continue;
            if (Array.IndexOf(o2.GetComponentsInChildren<Collider>(), hit.collider) >= 0)
                continue;
            //SNUtil.writeToChat("Raytrace from "+o1+" to "+o2+" hit "+hit.transform+" @ "+hit.point+" (D="+hit.distance+")");
            return false;
        }

        return true;
    }
    /*
    public static float getLightAtPosition(Vector3 pos, GameLightType types) {

    }*/

    public static List<RaycastHit> getTerrainMountedPositionsAround(Vector3 pos, float range, int num)
    {
        var ret = new List<RaycastHit>();
        for (var i = 0; i < num; i++)
        {
            var diff =
                new Vector3(Random.Range(-range, range), 0, Random.Range(-range, range)).setLength(Random.Range(0.01F,
                    range));
            var pos2 = (pos + diff).setY(pos.y + 15);
            var hit = getTerrainVectorAt(pos2, 25);
            if (hit.HasValue)
                ret.Add(hit.Value);
        }

        return ret;
    }

    public static RaycastHit? getTerrainVectorAt(Vector3 pos, float maxDown = 1, Vector3? axis = null)
    {
        var ray = new Ray(pos, axis.HasValue ? axis.Value : Vector3.down);
        return UWE.Utils.RaycastIntoSharedBuffer(ray, maxDown, Voxeland.GetTerrainLayerMask()) > 0
            ? UWE.Utils.sharedHitBuffer[0]
            : null;
    }

    public static bool isPrecursorBiome(Vector3 pos)
    {
        var over = AtmosphereDirector.main.GetBiomeOverride();
        return !string.IsNullOrEmpty(over) && over.ToLowerInvariant().Contains("precursor");
    }

    public static bool isInDRF(Vector3 pos)
    {
        return VanillaBiomes.LOSTRIVER.isInBiome(pos) && isPrecursorBiome(pos);
    }

    public static bool isInLavaCastle(Player ep)
    {
        return ep.IsInsideWalkable() && ep.precursorOutOfWater && isInLavaCastle(ep.transform.position);
    }

    public static bool isInLavaCastle(Vector3 pos)
    {
        return VanillaBiomes.ILZ.isInBiome(pos) && isPrecursorBiome(pos);
    }

    public static bool isInsideAurora2D(Vector3 pos, float extra = 0)
    {
        return MathUtil.getDistanceToLineSegment(pos, auroraPoint1, auroraPoint2) <= auroraPointRadius + extra;
    }

    public static string getRegionalDescription(Vector3 pos, bool includeDepth)
    {
        if ((pos - LAVA_DOME).sqrMagnitude <= 6400)
            return "Lava Dome";
        if ((pos - DUNES_METEOR).sqrMagnitude <= 14400)
            return "Meteor Crater";
        var dist = (pos - lavaCastleCenter).sqrMagnitude;
        if (dist <= lavaCastleInnerRadius * lavaCastleInnerRadius + 225)
            return "Lava Castle (Interior)";
        if (dist <= lavaCastleRadius * lavaCastleRadius + 900)
            return "Lava Castle";
        var bb = BiomeBase.getBiome(pos);
        if (BiomeBase.isUnrecognized(bb))
            return "Unknown Biome @ " + pos;
        if (bb == VanillaBiomes.LOSTRIVER || bb == VanillaBiomes.CRASH)
            switch (DIHooks.getBiomeAt(WaterBiomeManager.main.GetBiome(pos), pos))
            {
                case "LostRiver_BonesField_Corridor":
                case "LostRiver_BonesField_Corridor_Stream":
                case "LostRiver_BonesField":
                case "LostRiver_BonesField_Lake":
                case "LostRiver_BonesField_LakePit":
                    return "Bones Field";
                case "LostRiver_GhostTree_Lower":
                case "LostRiver_GhostTree":
                    return "Ghost Forest";
                case "LostRiver_Junction":
                    return "Lost River Junction";
                case "LostRiver_Canyon":
                case "LostRiver_SkeletonCave":
                    return "Ghost Canyon";
                case "Precursor_LostRiverBase":
                    return "Disease Research Facility";
                case "LostRiver_Corridor":
                    return "Lost River Corridor";
                case "crashZone_Mesa":
                    return "Crash Zone Mesas";
            }

        if (bb == VanillaBiomes.CRASH)
            if (isInsideAurora2D(pos, 100))
            {
                var ret = "The Aurora";
                if (pos.y >= 5 && CrashedShipExploder.main.IsExploded())
                {
                    ret += " (Inside)";
                }
                else
                {
                    //Vector3 ship = (auroraPoint1+auroraPoint2)*0.5F;//CrashedShipExploder.main.transform.position;
                    var point = MathUtil.getClosestPointToLineSegment(pos, auroraPoint1, auroraPoint2);
                    var angle = Vector3.SignedAngle(auroraPoint2 - auroraPoint1, pos - point, Vector3.up);
                    angle = (angle + 360) % 360;
                    if (Mathf.Abs(angle) <= 30)
                        ret += " (Front)";
                    if (Mathf.Abs(angle - 180) <= 30)
                        ret += " (Rear)";
                    if (Mathf.Abs(angle - 90) <= 45)
                        ret += " (Far Side)";
                    if (Mathf.Abs(angle - 270) <= 45)
                        ret += " (Near Side)";
                }

                return ret;
            }

        var biome = bb.displayName;
        var depth = (int) -pos.y;
        var ew = pos.x < 0 ? "West" : "East";
        var ns = pos.z > 0 ? "North" : "South";
        if (!bb.existsInSeveralPlaces() || Math.Abs(pos.x) < 250 || Math.Abs(pos.x) < Math.Abs(pos.z) / 2.5F)
            ew = "";
        if (!bb.existsInSeveralPlaces() || Math.Abs(pos.z) < 250 || Math.Abs(pos.z) < Math.Abs(pos.x) / 2.5F)
            ns = "";
        var pre = !string.IsNullOrEmpty(ew) || !string.IsNullOrEmpty(ns);
        var loc = ns + ew + (pre ? " " : "") + biome;
        if (includeDepth)
            loc += " (" + depth + "m)";
        return loc;
    }

    public static Vector3 getNearestGeyserPosition(Vector3 pos)
    {
        var nearest = new Vector3(0, 8000, 0);
        foreach (var at in geysers)
            if ((at - pos).sqrMagnitude < (nearest - pos).sqrMagnitude)
                nearest = at;
        return nearest;
    }

    /*
    public static bool isScannerRoomInRange(Vector3 position, bool needFunctional = true, float maxRange = 500, TechType scanningFor = TechType.None) {
        foreach (MapRoomFunctionality room in getObjectsNearWithComponent<MapRoomFunctionality>(position, maxRange)) {
            bool working = !needFunctional || room.CheckIsPowered();
            bool finding = scanningFor == TechType.None || room.typeToScan == scanningFor;
            if (working && finding && Vector3.Distance(room.transform.position, position) <= room.GetScanRange())
                return true;
        }
        return false;
    }
    */
    public static void setParticlesTemporary(ParticleSystem p, float dur, float killOffset = 5)
    {
        p.Play(true);
        p.gameObject.EnsureComponent<TransientParticleTag>().Invoke("stop", dur);
        Object.Destroy(p.gameObject, dur + killOffset);
        var pi = p.gameObject.FindAncestor<PrefabIdentifier>();
        if (pi)
            Object.DestroyImmediate(pi);
        var lw = p.gameObject.FindAncestor<LargeWorldEntity>();
        if (lw)
            Object.DestroyImmediate(lw);
    }

    public static ParticleSystem spawnParticlesAt(Vector3 pos, string pfb, float dur, bool forceSpawn = false,
        float killOffset = 5)
    {
        if (!forceSpawn && Vector3.Distance(pos, Player.main.transform.position) >= 200)
            return null;
        var particle = ObjectUtil.createWorldObject(pfb);
        particle.SetActive(true);
        particle.transform.position = pos;
        var p = particle.GetComponent<ParticleSystem>();
        setParticlesTemporary(p, dur, killOffset);
        return p;
    }

    private class TransientParticleTag : MonoBehaviour
    {
        private void OnDisable()
        {
            if (gameObject)
                Destroy(gameObject);
        }

        private void OnDestroy()
        {
            if (gameObject)
                Destroy(gameObject);
        }

        public void stop()
        {
            GetComponent<ParticleSystem>().Stop(true, ParticleSystemStopBehavior.StopEmitting);
        }
    }
}
/*
enum GameLightType {
    FLASHLIGHT,
    SEAGLIDE,
    SEAMOTH,
    EXOSUIT,
    CYCLOPS,
    FLARE,
    SKY,
    OTHER,
}*/