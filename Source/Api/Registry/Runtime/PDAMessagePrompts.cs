using System.Collections.Generic;
using ReikaKalseki.DIAlterra.Api.Instantiable;
using ReikaKalseki.DIAlterra.Api.Util;
using Story;

namespace ReikaKalseki.DIAlterra.Api.Registry.Runtime;

public class PDAMessagePrompts
{
    public static readonly PDAMessagePrompts instance = new();

    private readonly Dictionary<string, StoryGoal> mappings = new();

    private PDAMessagePrompts()
    {
    }

    public void addPDAMessage(XMLLocale.LocaleEntry e)
    {
        addPDAMessage(e.key, e.desc, e.pda);
    }

    public void addPDAMessage(string key, string text, string soundFile)
    {
        SNUtil.log("Constructing PDA message " + key);
        var item = SNUtil.addVOLine(key, Story.GoalType.PDA, text,
            SoundManager.registerPDASound(SNUtil.tryGetModDLL(), "prompt_" + key, soundFile).asset);
        mappings[key] = item;
    }

    public StoryGoal getMessage(string key)
    {
        return mappings[key];
    }

    public bool isTriggered(string m)
    {
        return StoryGoalManager.main.completedGoals.Contains(getMessage(m).key);
    }

    public bool trigger(string m)
    {
        var sg = getMessage(m);
        if (!StoryGoalManager.main.completedGoals.Contains(sg.key))
        {
            StoryGoal.Execute(sg.key, sg.goalType);
            return true;
        }

        return false;
    }
}