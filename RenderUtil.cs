﻿using System;
using System.Reflection;
using System.IO;
using System.Collections.Generic;

using SMLHelper.V2.Handlers;
using SMLHelper.V2.Assets;
using SMLHelper.V2.Utility;

using UnityEngine;

namespace ReikaKalseki.DIAlterra
{
	public static class RenderUtil {
		
		private static readonly string[] texTypes = new string[]{"_MainTex", "_SpecTex", "_BumpMap", "_Illum"};
		
		public static void setEmissivity(Renderer r, float amt, string type) {
			r.materials[0].SetFloat("_"+type, amt);
			r.sharedMaterial.SetFloat("_"+type, amt);
			r.materials[0].SetFloat("_"+type+"Night", amt);
			r.sharedMaterial.SetFloat("_"+type+"Night", amt);
		}
		
		public static void makeTransparent(Renderer r) {
			foreach (Material m in r.materials) {
				m.EnableKeyword("_ZWRITE_ON");
	  			m.EnableKeyword("WBOIT");
				m.SetInt("_ZWrite", 0);
				m.SetInt("_Cutoff", 0);
				m.SetFloat("_SrcBlend", 1f);
				m.SetFloat("_DstBlend", 1f);
				m.SetFloat("_SrcBlend2", 0f);
				m.SetFloat("_DstBlend2", 10f);
				m.SetFloat("_AddSrcBlend", 1f);
				m.SetFloat("_AddDstBlend", 1f);
				m.SetFloat("_AddSrcBlend2", 0f);
				m.SetFloat("_AddDstBlend2", 10f);
				m.globalIlluminationFlags = MaterialGlobalIlluminationFlags.EmissiveIsBlack | MaterialGlobalIlluminationFlags.RealtimeEmissive;
				m.renderQueue = 3101;
				m.enableInstancing = true;
			}
		}
		
		public static Texture extractTexture(GameObject go, string texType) {
			return go.GetComponentInChildren<Renderer>().materials[0].GetTexture(texType);
		}
		
		public static bool swapTextures(Renderer r, string path, Dictionary<int,string> textureLayers = null)  {
			bool flag = false;
			foreach (String type in texTypes) {
				for (int i = 0; i < r.materials.Length; i++) {
					if (r.materials[i] == null)
						continue;
					if ((textureLayers == null && i == 0) || (textureLayers != null && textureLayers.ContainsKey(i))) {
						string suffix = textureLayers != null ? (string.IsNullOrEmpty(textureLayers[i]) ? "" : "_"+textureLayers[i]) : "";
						if (path.EndsWith("/", StringComparison.InvariantCultureIgnoreCase) && suffix.StartsWith("_", StringComparison.InvariantCultureIgnoreCase)) {
							suffix = suffix.Substring(1);
						}
						Texture2D newTex = TextureManager.getTexture(path+suffix+type);
						if (newTex != null) {
							r.materials[i].SetTexture(type, newTex);
							flag = true;
							//SNUtil.writeToChat("Found "+type+" texture @ "+path);
						}
						else {
							//SNUtil.writeToChat("No texture found at "+path);
						}
					}
				}
			}
			return flag;
		}
		
		public static void swapToModdedTextures<T>(Renderer r, DIPrefab<T> pfb) where T : PrefabReference {
			string path = "Textures/"+pfb.getTextureFolder()+"/"+ObjectUtil.formatFileName((ModPrefab)pfb);
			if (!swapTextures(r, path))
				SNUtil.log("NO CUSTOM TEXTURES FOUND: "+pfb);
			
			if (pfb.glowIntensity > 0) {
				setEmissivity(r, pfb.glowIntensity, "GlowStrength");
				
				r.materials[0].EnableKeyword("MARMO_EMISSION");
				r.sharedMaterial.EnableKeyword("MARMO_EMISSION");
			}
		}
		
		public static GameObject setModel(GameObject go, string localModelName, GameObject modelObj) { //FIXME duplicate models
			GameObject prev = ObjectUtil.removeChildObject(go, localModelName);
			modelObj = UnityEngine.Object.Instantiate(modelObj);
			modelObj.name = localModelName;
			modelObj.transform.parent = go.transform;
			modelObj.transform.localPosition = Vector3.zero;
			modelObj.transform.localEulerAngles = Vector3.zero;
			modelObj.transform.localRotation = Quaternion.identity;
			modelObj.transform.localScale = Vector3.one;
			foreach (Component c in modelObj.GetComponentsInChildren<Component>()) {
				if (c is Transform || c is Renderer || c is MeshFilter || c is Collider || c is VFXFabricating || c is PrefabIdentifier || c is ChildObjectIdentifier) {
					continue;
				}
				UnityEngine.Object.DestroyImmediate(c);
			}
			return modelObj;
		}
		
		public static void setMesh(GameObject go, Mesh m) {
			if (m == null) {
				SNUtil.writeToChat("Cannot set a GO mesh to null!");
				return;
			}
			Color[] c = m.colors;
			for (int i = 0; i < c.Length; i++) {
				c[i] = new Color(c[i].r, c[i].g, c[i].b, 1);
			}
			m.colors = c;
			foreach (MeshFilter mf in go.GetComponentsInChildren<MeshFilter>(true)) {
				mf.mesh = m;
			}
			foreach (SkinnedMeshRenderer smr in go.GetComponentsInChildren<SkinnedMeshRenderer>(true)) {
				smr.sharedMesh = m;
				smr.enabled = true;
			}
		}
		
		public static Texture2D duplicateTexture(Texture2D source) {
		    RenderTexture renderTex = RenderTexture.GetTemporary(source.width, source.height, 0, RenderTextureFormat.Default, RenderTextureReadWrite.Linear);		
		    Graphics.Blit(source, renderTex);
		    RenderTexture previous = RenderTexture.active;
		    RenderTexture.active = renderTex;
		    Texture2D copy = new Texture2D(source.width, source.height);
		    copy.ReadPixels(new Rect(0, 0, renderTex.width, renderTex.height), 0, 0);
		    copy.Apply();
		    RenderTexture.active = previous;
		    RenderTexture.ReleaseTemporary(renderTex);
		    return copy;
		}
		
		public static void dumpTextures(Renderer r) {
			foreach (Material m in r.materials) {
				dumpTextures(m, r.gameObject.name+"_$_");
			}
		}
		
		public static void dumpTextures(Material m, string prefix = "") {
			foreach (string tex in m.GetTexturePropertyNames()) {
				string fn = prefix+m.name+"_-_"+tex;
				Texture2D img = (Texture2D)m.GetTexture(tex);
				dumpTexture(fn, img);
			}
		}
		
		public static void dumpTexture(string fn, Texture2D img) {
			if (img != null) {
				byte[] raw = duplicateTexture(img).EncodeToPNG();
				File.WriteAllBytes(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "TextureDump", fn+".png"), raw);
			}
		}
		
	}
}