/*
 * Created by SharpDevelop.
 * User: Reika
 * Date: 11/04/2022
 * Time: 4:11 PM
 *
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System.Xml;
using Story;
using UnityEngine;

namespace ReikaKalseki.DIAlterra.BuildSystem.ObjectManipulation;

internal sealed class SetStory : ManipulationBase
{
    private string goalKey;

    public override void applyToObject(GameObject go)
    {
        var sh = go.EnsureComponent<StoryHandTarget>();
        sh.goal = new StoryGoal(goalKey, Story.GoalType.Encyclopedia, 0);
    }

    public override void applyToObject(PlacedObject go)
    {
        applyToObject(go.obj);
    }

    public override void loadFromXML(XmlElement e)
    {
        goalKey = e.InnerText;
    }

    public override void saveToXML(XmlElement e)
    {
        e.InnerText = goalKey;
    }
}