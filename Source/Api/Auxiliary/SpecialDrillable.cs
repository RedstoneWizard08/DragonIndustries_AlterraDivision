using UnityEngine;

namespace ReikaKalseki.DIAlterra.Api.Auxiliary;

public abstract class SpecialDrillable : MonoBehaviour
{
    public abstract bool canBeMoved();
    public abstract bool allowAutomatedGrinding();
}