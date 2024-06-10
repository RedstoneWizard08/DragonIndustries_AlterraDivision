using System.Reflection;
using ReikaKalseki.DIAlterra.Api.Util;

namespace ReikaKalseki.DIAlterra.Api;

public abstract class SNMod
{
    public readonly string displayName;

    public readonly Assembly modDLL = SNUtil.tryGetModDLL();

    protected SNMod(string n)
    {
        displayName = n;
    }

    public abstract void loadConfig();
    public abstract void afterConfig();
    public abstract void doPatches();
    public abstract void addItems();
    public abstract void loadMain();
    public abstract void loadModInteract();
    public abstract void loadFinal();
}
