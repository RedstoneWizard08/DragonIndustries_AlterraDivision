/*
 * Created by SharpDevelop.
 * User: Reika
 * Date: 11/04/2022
 * Time: 4:11 PM
 *
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using UnityEngine;

namespace ReikaKalseki.DIAlterra.BuildSystem.ObjectManipulation;

public abstract class ModifyComponent<T> : ManipulationBase where T : Component
{
    public sealed override void applyToObject(PlacedObject go)
    {
        applyToObject(go.obj);
    }

    public sealed override void applyToObject(GameObject go)
    {
        var component = go.GetComponentInChildren<T>();
        if (component != null)
            modifyComponent(component);
    }

    public abstract void modifyComponent(T component);
}