using UnityEngine;

namespace ReikaKalseki.DIAlterra.Api.Auxiliary;

public interface CustomHarvestBehavior
{
    bool canBeAutoharvested();
    GameObject tryHarvest(GameObject go);
}