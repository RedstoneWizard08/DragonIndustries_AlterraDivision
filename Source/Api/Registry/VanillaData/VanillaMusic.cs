﻿using System.Collections.Generic;
using System.Collections.ObjectModel;
using ReikaKalseki.DIAlterra.Api.Util;
using UnityEngine;

namespace ReikaKalseki.DIAlterra.Api.Registry.VanillaData;

public class VanillaMusic
{
    private static readonly Dictionary<string, VanillaMusic> table = new();

    //Where does Crush Depth play?
    public static readonly VanillaMusic KOOSH = new("kooshAmbience", 2, 48); //Islands Beneath The Sea
    public static readonly VanillaMusic BKELP = new("BloodKelpAmbience", 2, 12); //Lava Castle
    public static readonly VanillaMusic DUNES = new("dunes", 1, 41); //Alien Expanse
    public static readonly VanillaMusic GRANDREEF = new("grandReefAmbience", 1, 22); //Lost River
    public static readonly VanillaMusic DEEPGRAND = new("deepGrandReefAmbience", 1, 44); //Blood Crawlers
    public static readonly VanillaMusic UNDERISLANDS = new("UnderwaterIslandsAmbience", 0, 0); //silent?
    public static readonly VanillaMusic SHALLOWS = new("safeShallowsAmbience", 2, 59); //Into The Unknown
    public static readonly VanillaMusic KELP = new("kelpForestAmbience", 2, 10); //In Bloom
    public static readonly VanillaMusic OBSERVATORY = new("observatoryAmbience", 1, 23); //Observatory Zen
    public static readonly VanillaMusic MOUNTAINS = new("mountainsAmbience", 1, 23); //Fear The Reapers
    public static readonly VanillaMusic MUSHROOM = new("mushroomForestAmbience", 0, 0); //?
    public static readonly VanillaMusic REDGRASS = new("grassyPlateausAmbience", 0, 0); //?
    public static readonly VanillaMusic LOSTRIVER = new("lostRiverAmbience", 1, 22); //Lost River
    public static readonly VanillaMusic JELLYSHROOM = new("jellyshroomCaveAmbience", 2, 30); //Crash Site
    public static readonly VanillaMusic FLOATINGISLAND = new("floatingIslandAmbience", 0, 0); //?
    public static readonly VanillaMusic LAVAZONE = new("lavaZoneAmbience", 2, 12); //Lava Castle
    public static readonly VanillaMusic ILZ = new("inactiveLavaZone", 1, 57); //Bring a Medpack
    public static readonly VanillaMusic ALZ = new("alz", 1, 40); //Ahead Slow
    public static readonly VanillaMusic AURORA = new("crashedShipAmbience", 1, 31); //Dark Matter Reactor
    public static readonly VanillaMusic TREADER = new("seaTreaderPath", 2, 48); //Islands Beneath The Sea
    public static readonly VanillaMusic COVE = new("LostRiverTreeCove", 1, 41); //Ghost Tree
    public static readonly VanillaMusic COVETREE = new("LostRiverGhostTree", 0, 0); //silent?
    public static readonly VanillaMusic SPARSE = new("SparseReefAmbience", 2, 48); //Islands Beneath The Sea
    public static readonly VanillaMusic CRASH = new("crashZoneAmbience", 0, 0); //?

    public static readonly VanillaMusic
        WRECK = new("WreckAmbience", 1, 0); //not a music track, just the wreckage near pod 6

    public static readonly VanillaMusic GENERATOR = new("generatorRoomAmbience", 1, 57); //Bring a Medpack
    public static readonly VanillaMusic SCANNER = new("mapRoomAmbience", 0, 5); //Scanner Room Ambient

    private readonly string objectName;

    private string activationBiome;

    private readonly float length;

    private VanillaMusic(string id, int min, int sec)
    {
        objectName = id;
        table[objectName] = this;

        length = min * 60 + sec;
    }

    public override string ToString()
    {
        return objectName;
    }

    private GameObject getObject()
    {
        return ObjectUtil.getChildObject(Player.main.gameObject,
            "SpawnPlayerSounds/PlayerSounds(Clone)/waterAmbience/music/" + objectName);
    }

    public void reset()
    {
        var go = getObject();
        go.SetActive(true);
        if (!string.IsNullOrEmpty(activationBiome))
            go.GetComponent<FMODGameParams>().onlyInBiome = activationBiome;
    }

    public void play()
    {
        enable();
        ; //getObject().GetComponent<FMOD_CustomLoopingEmitter>().Play();
        //SoundManager.playSound(getObject().GetComponent<FMOD_CustomLoopingEmitter>().asset.path);
        FMODUWE.PlayOneShot(getObject().GetComponent<FMOD_CustomLoopingEmitter>().asset,
            Player.main.transform.position);
    }

    public void enable()
    {
        getObject().SetActive(true);
    }

    public void stop()
    {
        //getObject().GetComponent<FMOD_CustomLoopingEmitter>().Stop();
    }

    public float getLength()
    {
        return length; //getObject().GetComponent<FMOD_CustomLoopingEmitter>().length;
    }

    public void disable()
    {
        getObject().SetActive(false);
    }

    public void setToBiome(string biome)
    {
        var par = getObject().GetComponent<FMODGameParams>();
        activationBiome = par.onlyInBiome;
        par.onlyInBiome = biome;
        par.gameObject.SetActive(true);
    }

    public static IEnumerable<VanillaMusic> getAll()
    {
        return new ReadOnlyCollection<VanillaMusic>(new List<VanillaMusic>(table.Values));
    }
    /*
    public static void disableAllMusic() {
        GameObject go = ObjectUtil.getChildObject(Player.main.gameObject, "SpawnPlayerSounds/PlayerSounds(Clone)/waterAmbience/music");
        foreach (FMODGameParams par in go.GetComponentsInChildren<FMODGameParams>(true)) {
            par.gameObject.SetActive(false);
        }
    }*/
}