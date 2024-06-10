using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Reflection;
using ReikaKalseki.DIAlterra.Api.Util;
using UnityEngine;

namespace ReikaKalseki.DIAlterra.Api.Registry;

public class TechTypeMappingConfig<E>
{
    private readonly string filename;

    private readonly Assembly ownerMod;
    private readonly Action<TechType, E> valueConsumer;
    private readonly ValueParser<E> valueParsing;

    public TechTypeMappingConfig(string n, ValueParser<E> parser, Action<TechType, E> consumer)
    {
        ownerMod = SNUtil.tryGetModDLL();
        filename = n;
        valueParsing = parser;
        valueConsumer = consumer;
    }

    public static Action<TechType, E> dictionaryAssign(Dictionary<TechType, E> dict)
    {
        return (tt, e) => dict[tt] = e;
    }

    public static void loadInline(string n, ValueParser<E> parser, Action<TechType, E> consumer)
    {
        new TechTypeMappingConfig<E>(n, parser, consumer).load();
    }

    public void load()
    {
        var path = Path.Combine(Path.GetDirectoryName(ownerMod.Location), Path.Combine("Config", filename + ".txt"));
        if (File.Exists(path))
        {
            SNUtil.log("Loading TechType mapping file '" + filename + "'.", ownerMod);
            foreach (var raw in File.ReadAllLines(path))
            {
                var line = raw.Trim();
                if (line.Length == 0 || line.StartsWith("//", StringComparison.InvariantCultureIgnoreCase))
                    continue;
                var split = line.Split(new[] {'='}, StringSplitOptions.RemoveEmptyEntries);
                if (split.Length == 2)
                {
                    var find = SNUtil.getTechType(split[0]);
                    if (find != TechType.None)
                    {
                        E parsed;
                        if (valueParsing.tryParse(split[1], out parsed))
                        {
                            valueConsumer.Invoke(find, parsed);
                            SNUtil.log("Setting TechType mapping: " + find + " = " + parsed);
                        }
                        else
                        {
                            SNUtil.log("TechType mapping format was invalid; no value parsed for '" + parsed + "'");
                        }
                    }
                    else
                    {
                        SNUtil.log("TechType found no matching TechType for '" + split[0] + "'", ownerMod);
                    }
                }
                else
                {
                    SNUtil.log("Incorrectly formatted TechType mapping: " + line, ownerMod);
                }
            }
        }
        else
        {
            Directory.CreateDirectory(Path.GetDirectoryName(path));
            SNUtil.log("TechType mapping file '" + filename + "' not found. Generating default.", ownerMod);
            string[] lines =
            {
                "//This file contains a list of TechTypes in a key=value format, used to assign them custom mappings.",
                "//TechType names are case-sensitive, and in the case of modded TechTypes equal to their ClassID names.",
                "//To see the TechType used for a given object, you can use the Runtime Editor mod to inspect it and see the TechType on the TechTag, Pickupable, or ResourceTracker component.",
                "//Lines beginning with '//' are comments and will be ignored, as will empty lines.",
                "//There should be one mapping per line, and the value should be in the same format as the following example line:",
                "//SAMPLE_TECH_TYPE=" + valueParsing.getSample(),
                ""
            };
            File.WriteAllLines(path, lines);
        }
    }

    public abstract class ValueParser<V>
    {
        public abstract bool tryParse(string s, out V val);

        public abstract string getSample();
    }

    public class ColorParser : ValueParser<Color>
    {
        public static readonly ColorParser instance = new();

        private ColorParser()
        {
        }

        public override bool tryParse(string s, out Color val)
        {
            var red = 0;
            var green = 0;
            var blue = 0;
            var parts = s.Split(new[] {','}, StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length >= 3 && int.TryParse(parts[0], out red) && int.TryParse(parts[1], out green) &&
                int.TryParse(parts[2], out blue))
            {
                val = new Color(red / 255F, green / 255F, blue / 255F, 1);
                return true;
            }

            val = Color.white;
            return false;
        }

        public override string getSample()
        {
            return "255,0,0";
        }
    }

    public class IntParser : ValueParser<int>
    {
        public static readonly IntParser instance = new();

        private IntParser()
        {
        }

        public override bool tryParse(string s, out int val)
        {
            if (!string.IsNullOrEmpty(s) && s[0] == '0' && s[1] == 'x')
                return int.TryParse(s.Substring(2), NumberStyles.HexNumber, CultureInfo.InvariantCulture, out val);
            return int.TryParse(s, out val);
        }

        public override string getSample()
        {
            return "1";
        }
    }

    public class FloatParser : ValueParser<float>
    {
        public static readonly FloatParser instance = new();

        private FloatParser()
        {
        }

        public override bool tryParse(string s, out float val)
        {
            if (!string.IsNullOrEmpty(s) && char.ToUpperInvariant(s[s.Length - 1]) == 'F')
                s = s.Substring(0, s.Length - 1);
            return float.TryParse(s, out val);
        }

        public override string getSample()
        {
            return "1.0";
        }
    }
}