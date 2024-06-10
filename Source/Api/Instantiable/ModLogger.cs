﻿using System.Reflection;
using UnityEngine;

namespace ReikaKalseki.DIAlterra.Api.Instantiable;

public class ModLogger
{
    private readonly Assembly ownerMod;
    private readonly string prefixString;

    public ModLogger(string pfx = null)
    {
        ownerMod = Assembly.GetCallingAssembly();
        prefixString = pfx != null ? pfx : ownerMod.GetName().Name.ToUpperInvariant().Replace("PLUGIN_", "");
    }

    public void log(string s, int indent = 0)
    {
        while (s.Length > 4096)
        {
            var part = s.Substring(0, 4096);
            log(part);
            s = s.Substring(4096);
        }

        if (indent > 0) s = s.PadLeft(s.Length + indent, ' ');
        Debug.Log(prefixString + ": " + s);
    }
}