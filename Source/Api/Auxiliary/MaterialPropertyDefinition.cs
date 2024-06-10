﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Xml;
using ReikaKalseki.DIAlterra.Api.Registry;
using ReikaKalseki.DIAlterra.Api.Util;
using UnityEngine;

namespace ReikaKalseki.DIAlterra.Api.Auxiliary;

public class MaterialPropertyDefinition
{
    private static readonly Dictionary<string, ShaderPropertyDefinition> shaderPropTypes = new();
    public readonly HashSet<string> shaderFlags = new();
    public readonly Dictionary<string, ShaderProperty> shaderProperties = new();

    public readonly Dictionary<string, TextureDefinition> textures = new();

    public Color color;
    public MaterialGlobalIlluminationFlags illumFlags;

    public string name;
    public int renderQueue;

    static MaterialPropertyDefinition()
    {
        //this is not exhaustive but it covers most of the commonly used ones
        addShaderProperty(new ShaderPropertyDefinition("_Fresnel", typeof(float)));
        addShaderProperty(new ShaderPropertyDefinition("_Shininess", typeof(float)));
        addShaderProperty(new ShaderPropertyDefinition("_SpecInt", typeof(float)));
        addShaderProperty(new ShaderPropertyDefinition("_Mode", typeof(float)));

        addShaderProperty(new ShaderPropertyDefinition("_Color", typeof(Color)));
        addShaderProperty(new ShaderPropertyDefinition("_Color2", typeof(Color)));
        addShaderProperty(new ShaderPropertyDefinition("_Color3", typeof(Color)));

        addShaderProperty(new ShaderPropertyDefinition("_SpecColor", typeof(Color)));
        addShaderProperty(new ShaderPropertyDefinition("_GlowColor", typeof(Color)));
        addShaderProperty(new ShaderPropertyDefinition("_SquaresColor", typeof(Color)));

        addShaderProperty(new ShaderPropertyDefinition("_GlowStrength", typeof(float)));
        addShaderProperty(new ShaderPropertyDefinition("_GlowStrengthNight", typeof(float)));
        addShaderProperty(new ShaderPropertyDefinition("_EmissionLM", typeof(float)));
        addShaderProperty(new ShaderPropertyDefinition("__EmissionLMNight", typeof(float)));

        addShaderProperty(new ShaderPropertyDefinition("_EnableGlow", typeof(int)));
        addShaderProperty(new ShaderPropertyDefinition("_EnableLighting", typeof(int)));
        addShaderProperty(new ShaderPropertyDefinition("_EnableLightmap", typeof(int)));

        addShaderProperty(new ShaderPropertyDefinition("_ZWrite", typeof(int)));
        addShaderProperty(new ShaderPropertyDefinition("_Cutoff", typeof(int)));

        addShaderProperty(new ShaderPropertyDefinition("_SrcBlend", typeof(float)));
        addShaderProperty(new ShaderPropertyDefinition("_DstBlend", typeof(float)));
        addShaderProperty(new ShaderPropertyDefinition("_SrcBlend2", typeof(float)));
        addShaderProperty(new ShaderPropertyDefinition("_DstBlend2", typeof(float)));
        addShaderProperty(new ShaderPropertyDefinition("_AddSrcBlend", typeof(float)));
        addShaderProperty(new ShaderPropertyDefinition("_AddDstBlend", typeof(float)));
        addShaderProperty(new ShaderPropertyDefinition("_AddSrcBlend2", typeof(float)));
        addShaderProperty(new ShaderPropertyDefinition("_AddDstBlend2", typeof(float)));

        addShaderProperty(new ShaderPropertyDefinition("_FillSack", typeof(float)));
        addShaderProperty(new ShaderPropertyDefinition("_OverlayStrength", typeof(float)));
        addShaderProperty(new ShaderPropertyDefinition("_Hypnotize", typeof(float)));
        addShaderProperty(new ShaderPropertyDefinition("_SquaresTile", typeof(float)));
        addShaderProperty(new ShaderPropertyDefinition("_SquaresSpeed", typeof(float)));
        addShaderProperty(new ShaderPropertyDefinition("_SquaresIntensityPow", typeof(float)));
        addShaderProperty(new ShaderPropertyDefinition("_Built", typeof(float)));
        addShaderProperty(new ShaderPropertyDefinition("_BuildLinear", typeof(float)));
        addShaderProperty(new ShaderPropertyDefinition("_NoiseThickness", typeof(float)));
        addShaderProperty(new ShaderPropertyDefinition("_NoiseStr", typeof(float)));
        addShaderProperty(new ShaderPropertyDefinition("_WaveUpMin", typeof(float)));
        addShaderProperty(new ShaderPropertyDefinition("_Fallof", typeof(float))); //missing f 
        addShaderProperty(new ShaderPropertyDefinition("_RopeGravity", typeof(float)));
        addShaderProperty(new ShaderPropertyDefinition("_minYpos", typeof(float)));
        addShaderProperty(new ShaderPropertyDefinition("_maxYpos", typeof(float)));
        addShaderProperty(new ShaderPropertyDefinition("_Displacement", typeof(float)));
        addShaderProperty(new ShaderPropertyDefinition("_BurstStrength", typeof(float)));
        addShaderProperty(new ShaderPropertyDefinition("_ClipRange", typeof(float)));

        addShaderProperty(new ShaderPropertyDefinition("_DetailIntensities", typeof(Vector4)));
        addShaderProperty(new ShaderPropertyDefinition("_LightmapStrength", typeof(Vector4)));
        addShaderProperty(new ShaderPropertyDefinition("_ColorStrength", typeof(Vector4)));
        addShaderProperty(new ShaderPropertyDefinition("_GlowMaskSpeed", typeof(Vector4)));
        addShaderProperty(new ShaderPropertyDefinition("_ScrollSpeed", typeof(Vector4)));
        addShaderProperty(new ShaderPropertyDefinition("_NoiseSpeed", typeof(Vector4)));
        addShaderProperty(new ShaderPropertyDefinition("_FakeSSSparams", typeof(Vector4)));
        addShaderProperty(new ShaderPropertyDefinition("_FakeSSSSpeed", typeof(Vector4)));
        addShaderProperty(new ShaderPropertyDefinition("_BuildParams", typeof(Vector4)));
        addShaderProperty(new ShaderPropertyDefinition("_Scale", typeof(Vector4)));
        addShaderProperty(new ShaderPropertyDefinition("_Frequency", typeof(Vector4)));
        addShaderProperty(new ShaderPropertyDefinition("_Speed", typeof(Vector4)));
        addShaderProperty(new ShaderPropertyDefinition("_ObjectUp", typeof(Vector4)));
        addShaderProperty(new ShaderPropertyDefinition("_Range", typeof(Vector4)));
    }

    public MaterialPropertyDefinition(string n)
    {
        name = n.Replace(" (Instance)", "");
    }

    public MaterialPropertyDefinition(Material m) : this(m.mainTexture.name)
    {
        color = m.color;
        renderQueue = m.renderQueue;
        illumFlags = m.globalIlluminationFlags;
        foreach (var tex in m.GetTexturePropertyNames()) textures[tex] = new TextureDefinition(m, tex);
        foreach (var shd in m.shaderKeywords) shaderFlags.Add(shd);
        foreach (var shd in shaderPropTypes.Values) shaderProperties[shd.name] = new ShaderProperty(shd, m);
    }

    private static void addShaderProperty(ShaderPropertyDefinition def)
    {
        shaderPropTypes[def.name] = def;
    }

    public void readFromFile(Assembly a, string folder)
    {
        var defs = Path.Combine(folder, "defs.xml");
        var doc = new XmlDocument();
        doc.Load(defs);
        var texs = (XmlElement) doc.DocumentElement.GetElementsByTagName("textures")[0];
        var flags = (XmlElement) doc.DocumentElement.GetElementsByTagName("flags")[0];
        var props = (XmlElement) doc.DocumentElement.GetElementsByTagName("properties")[0];
        foreach (var e in texs.getDirectElementsByTagName("entry"))
        {
            var tex = new TextureDefinition();
            tex.readFromFile(e);
            textures[tex.name] = tex;
            tex.texture = TextureManager.getTexture(a, Path.Combine(folder, tex.name));
        }

        foreach (var e in props.getDirectElementsByTagName("entry"))
        {
            var shd = new ShaderProperty(shaderPropTypes[e.getProperty("name")]);
            shd.readFromFile(e);
            shaderProperties[shd.definition.name] = shd;
        }

        foreach (var e in flags.getDirectElementsByTagName("entry")) shaderFlags.Add(e.InnerText);
        color = doc.DocumentElement.getColor("color", true).Value;
        renderQueue = doc.DocumentElement.getInt("renderQueue", 0, false);
        illumFlags = (MaterialGlobalIlluminationFlags) doc.DocumentElement.getInt("illumFlags", 0, false);
    }

    public void writeToFile(string folder)
    {
        Directory.CreateDirectory(folder);
        var defs = Path.Combine(folder, "defs.xml");
        var doc = new XmlDocument();
        var rootnode = doc.CreateElement("Root");
        doc.AppendChild(rootnode);
        var texs = doc.CreateElement("textures");
        var flags = doc.CreateElement("flags");
        var props = doc.CreateElement("properties");
        foreach (var tex in textures.Values)
        {
            var e = doc.CreateElement("entry");
            tex.writeToFile(e);
            texs.AppendChild(e);
            RenderUtil.dumpTexture(SNUtil.diDLL, tex.name, (Texture2D) tex.texture, folder);
        }

        foreach (var s in shaderFlags) flags.addProperty("entry", s);
        foreach (var shd in shaderProperties.Values)
        {
            var e = doc.CreateElement("entry");
            shd.writeToFile(e);
            props.AppendChild(e);
        }

        doc.DocumentElement.addProperty("color", color);
        doc.DocumentElement.addProperty("renderQueue", renderQueue);
        doc.DocumentElement.addProperty("illumFlags", (int) illumFlags);
        doc.DocumentElement.AppendChild(texs);
        doc.DocumentElement.AppendChild(flags);
        doc.DocumentElement.AppendChild(props);
        doc.Save(defs);
    }

    public void applyToMaterial(Material m, bool useTex = true, bool vars = true)
    {
        m.name = name;
        m.color = color;
        if (vars)
        {
            m.renderQueue = renderQueue;
            m.globalIlluminationFlags = illumFlags;
        }

        if (useTex)
            foreach (var tex in textures.Values)
                tex.applyToMaterial(m);
        if (vars)
        {
            foreach (var shd in shaderProperties.Values) shd.applyToMaterial(m);
            foreach (var flag in m.shaderKeywords) m.DisableKeyword(flag);
            foreach (var flag in shaderFlags) m.EnableKeyword(flag);
        }
    }

    public class ShaderPropertyDefinition
    {
        public readonly string name;
        public readonly Type valueType;

        public ShaderPropertyDefinition(string n, Type tt)
        {
            name = n;
            valueType = tt;
        }

        internal object loadValue(XmlElement e)
        {
            if (valueType == typeof(int))
                return e.getInt(name, 0, false);
            if (valueType == typeof(float))
                return e.getFloat(name, float.NaN);
            //if (valueType == typeof(float[]))
            //	return e.GetFloatArray(name);
            if (valueType == typeof(Vector4))
                return e.getVector4(name);
            if (valueType == typeof(Color))
                return e.getColor(name, true);
            return null;
        }

        internal void saveValue(XmlElement e, object val)
        {
            if (valueType == typeof(int))
                e.addProperty(name, (int) val);
            if (valueType == typeof(float))
                e.addProperty(name, (float) val);
            //if (valueType == typeof(float[]))
            //e.addProperty(name, val);
            if (valueType == typeof(Vector4))
                e.addProperty(name, (Vector4) val);
            if (valueType == typeof(Color))
                e.addProperty(name, (Color) val);
        }

        internal object getValue(Material m)
        {
            if (valueType == typeof(int))
                return m.GetInt(name);
            if (valueType == typeof(float))
                return m.GetFloat(name);
            if (valueType == typeof(float[]))
                return m.GetFloatArray(name);
            if (valueType == typeof(Vector4))
                return m.GetVector(name);
            if (valueType == typeof(Color))
                return m.GetColor(name);
            return null;
        }

        internal void applyValue(Material m, object val)
        {
            if (valueType == typeof(int))
                m.SetInt(name, Convert.ToInt32(val));
            if (valueType == typeof(float))
                m.SetFloat(name, Convert.ToSingle(val));
            if (valueType == typeof(float[]))
                m.SetFloatArray(name, (float[]) val);
            if (valueType == typeof(Vector4))
                m.SetVector(name, (Vector4) val);
            if (valueType == typeof(Color))
                m.SetColor(name, (Color) val);
        }
    }

    public class ShaderProperty
    {
        public readonly ShaderPropertyDefinition definition;

        public object value;

        public ShaderProperty(ShaderPropertyDefinition n)
        {
            definition = n;
        }

        public ShaderProperty(ShaderPropertyDefinition n, Material m) : this(n)
        {
            value = definition.getValue(m);
        }

        public void applyToMaterial(Material m)
        {
            try
            {
                definition.applyValue(m, value);
            }
            catch (Exception ex)
            {
                SNUtil.log("Could not apply shader property " + definition.name + " [" + value + "]: " + ex);
            }
        }

        public void writeToFile(XmlElement e)
        {
            e.addProperty("name", definition.name);
            definition.saveValue(e, value);
        }

        public void readFromFile(XmlElement e)
        {
            value = definition.loadValue(e);
        }
    }

    public class TextureDefinition
    {
        public string name;
        public Vector2 offset;
        public Vector2 scale;

        public Texture texture;

        public TextureDefinition()
        {
        }

        public TextureDefinition(Material m, string tex)
        {
            name = tex;
            texture = m.GetTexture(tex);
            scale = m.GetTextureScale(tex);
            offset = m.GetTextureOffset(tex);
        }

        public void applyToMaterial(Material m)
        {
            m.SetTexture(name, texture);
            m.SetTextureScale(name, scale);
            m.SetTextureOffset(name, offset);
        }

        public void writeToFile(XmlElement e)
        {
            e.addProperty("name", name);
            e.addProperty("scale", scale.WithZ(0));
            e.addProperty("offset", offset.WithZ(0));
        }

        public void readFromFile(XmlElement e)
        {
            name = e.getProperty("name");
            scale = e.getVector("scale").Value.XY();
            offset = e.getVector("offset").Value.XY();
        }
    }
}