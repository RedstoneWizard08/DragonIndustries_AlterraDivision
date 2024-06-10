using System;
using System.Collections.Generic;
using ReikaKalseki.DIAlterra.Api.Auxiliary;
using ReikaKalseki.DIAlterra.Api.Base;
using ReikaKalseki.DIAlterra.Api.Util;
using UnityEngine;

namespace ReikaKalseki.DIAlterra.Api.Instantiable;

public abstract class WorldGenerator : ObjectTemplate
{
    public static readonly string TAGNAME = "generator";

    public readonly Vector3 position;

    public Func<string, GameObject> spawner = s => ObjectUtil.createWorldObject(s);

    static WorldGenerator()
    {
        registerType(TAGNAME, e =>
        {
            var typeName = e.getProperty("type");
            var pos = e.getVector("position").Value;
            var scatt = e.getVector("scatter", true);
            if (scatt != null && scatt.HasValue)
                pos += MathUtil.getRandomVectorBetween(-scatt.Value, scatt.Value);
            var tt = InstructionHandlers.getTypeBySimpleName(typeName);
            if (tt == null)
                throw new Exception("No class found for '" + typeName + "'!");
            var gen = (WorldGenerator) Activator.CreateInstance(tt, pos);
            return gen;
        });
    }

    protected WorldGenerator(Vector3 pos)
    {
        position = pos;
    }

    public abstract void generate(List<GameObject> generated);

    public sealed override string getTagName()
    {
        return TAGNAME;
    }

    public sealed override string getID()
    {
        return GetType().Name;
    }

    protected bool isColliding(Vector3 vec, List<GameObject> li)
    {
        foreach (var go in li)
            if (ObjectUtil.objectCollidesPosition(go, vec))
                return true;
        return false;
    }

    public override string ToString()
    {
        return getID() + " @ " + position;
    }
}