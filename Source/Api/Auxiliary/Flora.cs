using ReikaKalseki.DIAlterra.Api.Base;
using UnityEngine;

namespace ReikaKalseki.DIAlterra.Api.Auxiliary;

public interface Flora
{
    string getPrefabID();
    bool isNativeToBiome(Vector3 pos);
    bool isNativeToBiome(BiomeBase b, bool cave);
}