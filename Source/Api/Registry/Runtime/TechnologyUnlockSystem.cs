using System.Collections.Generic;
using System.Linq;
using ReikaKalseki.DIAlterra.Api.Instantiable.Prefab;
using ReikaKalseki.DIAlterra.Api.Util;

namespace ReikaKalseki.DIAlterra.Api.Registry.Runtime;

public class TechnologyUnlockSystem
{
    public static readonly TechnologyUnlockSystem instance = new();

    private readonly Dictionary<TechType, List<TechType>> directUnlocks = new();
    private readonly Dictionary<TechType, PDAManager.PDAPage> techPages = new();

    private TechnologyUnlockSystem()
    {
    }

    public void addDirectUnlock(TechType from, TechType to)
    {
        var li = directUnlocks.ContainsKey(from) ? directUnlocks[from] : new List<TechType>();
        li.Add(to);
        directUnlocks[from] = li;
    }

    public void registerPage(TechType from, PDAManager.PDAPage page)
    {
        techPages[from] = page;
    }

    public void onLogin()
    {
        foreach (var kvp in directUnlocks.Keys)
            if (PDAScanner.complete.Contains(kvp))
                triggerDirectUnlock(kvp);
    }

    public void triggerDirectUnlock(TechType tt, bool allowPopups = true)
    {
        if (techPages.ContainsKey(tt)) techPages[tt].unlock(false);
        if (!directUnlocks.ContainsKey(tt))
            return;
        var li = directUnlocks[tt];
        if (li == null || li.Count == 0)
            return;
        SNUtil.log(
            "Triggering direct unlock via " + tt + " of " + li.Count + ":[" +
            string.Join(", ", li.Select(tc => "" + tc)) + "]", SNUtil.diDLL);

        if (DIHooks.getWorldAge() > 0.25F)
        {
            var li2 = new List<TechType>();
            foreach (var tt2 in li)
            {
                if (KnownTech.Contains(tt2))
                    continue;
                if (DuplicateRecipeDelegate.isDelegateItem(tt2) &&
                    !DuplicateRecipeDelegate.getDelegateFromTech(tt2).allowTechUnlockPopups())
                    continue;
                SNUtil.log("Raising progression popup for " + tt2, SNUtil.diDLL);
                li2.Add(tt2);
            }

            if (allowPopups)
            {
                if (li2.Count > 1)
                    SNUtil.triggerMultiTechPopup(li2);
                else if (li2.Count == 1)
                    SNUtil.triggerTechPopup(li2[0]);
            }
        }

        foreach (var unlock in li)
            if (!KnownTech.Contains(unlock))
                KnownTech.Add(unlock);
    }
}