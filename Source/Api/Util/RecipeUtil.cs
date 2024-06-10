﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Nautilus.Crafting;
using Nautilus.Handlers;
using ReikaKalseki.DIAlterra.Api.Auxiliary;
using ReikaKalseki.DIAlterra.Api.Instantiable;

namespace ReikaKalseki.DIAlterra.Api.Util;

public static class RecipeUtil
{
    private static readonly Dictionary<TechType, RecipeNode> nodes = new();

    private static readonly Dictionary<TechType, Dictionary<TechType, int>> originalRecipes = new();

    public static bool shouldLogChanges;

    public static void startLoggingRecipeChanges()
    {
        originalRecipes.Clear();
        shouldLogChanges = true;
    }

    public static void logChangedRecipes()
    {
        SNUtil.log("Collated recipe changes: ");
        var oldR = new List<string>();
        var newR = new List<string>();
        foreach (var kvp in originalRecipes)
        {
            var rec = getRecipe(kvp.Key);
            SNUtil.log("Recipe for " + kvp.Key + " was changed. Previous recipe:");

            if (kvp.Value.Count > 0)
            {
                var s = ("" + kvp.Key).ToUpper();
                foreach (var kvp2 in kvp.Value)
                {
                    SNUtil.log(kvp2.Key + " x" + kvp2.Value);
                    s = s + ".addIngredient(" + (kvp2.Key + "").ToUpper() + ", " + kvp2.Value + ")";
                }

                s += ";";
                oldR.Add(s);
            }

            if (rec == null)
            {
                SNUtil.log("Recipe was removed");
            }
            else
            {
                SNUtil.log("New recipe:");
                var s = ("" + kvp.Key).ToUpper();
                foreach (var i in rec.Ingredients)
                {
                    SNUtil.log(i.techType + " x" + i.amount);
                    s = s + ".addIngredient(" + (i.techType + "").ToUpper() + ", " + i.amount + ")";
                }

                s += ";";
                newR.Add(s);
            }
        }

        var lines = new List<string>();
        lines.AddRange(oldR);
        lines.Add("=============");
        lines.AddRange(newR);
        File.WriteAllLines(
            "E:/My Documents/Desktop Stuff/Game Stuff/Modding/Minecraft/Mods Website - Generator/exported/snrecipe.txt",
            lines.ToArray());
        originalRecipes.Clear();
        shouldLogChanges = false;
    }

    private static void cacheOriginalRecipe(TechType item, RecipeData rec)
    {
        if (originalRecipes.ContainsKey(item))
            return;
        var dict = new Dictionary<TechType, int>();
        foreach (var i in rec.Ingredients) dict[i.techType] = i.amount;
        originalRecipes[item] = dict;
    }

    public static void addIngredient(TechType recipe, TechType add, int amt)
    {
        var rec = getRecipe(recipe);
        cacheOriginalRecipe(recipe, rec);
        SNUtil.log("Adding " + add + "x" + amt + " to recipe " + recipe);
        foreach (var i in rec.Ingredients)
            if (i.techType == add)
            {
                i._amount += amt;
                return;
            }

        rec.Ingredients.Add(new CraftData.Ingredient(add, amt));
    }

    public static void ensureIngredient(TechType recipe, TechType item, int amt)
    {
        var rec = getRecipe(recipe);
        cacheOriginalRecipe(recipe, rec);
        SNUtil.log("Ensuring " + item + "x" + amt + " in recipe " + recipe);
        var has = 0;
        foreach (var i in rec.Ingredients)
            if (i.techType == item)
                has += i.amount;
        if (has < amt)
            addIngredient(recipe, item, amt - has);
    }

    public static CraftData.Ingredient removeIngredient(TechType recipe, TechType item)
    {
        CraftData.Ingredient ret = null;
        modifyIngredients(recipe, i =>
        {
            if (i.techType == item)
            {
                ret = i;
                return true;
            }

            return false;
        });
        return ret;
    }

    /**
     * Return true in the func to delete the ingredient.
     */
    public static void modifyIngredients(TechType recipe, Func<CraftData.Ingredient, bool> a)
    {
        var rec = getRecipe(recipe);
        cacheOriginalRecipe(recipe, rec);
        for (var idx = rec.Ingredients.Count - 1; idx >= 0; idx--)
        {
            var i = rec.Ingredients[idx];
            if (a(i)) rec.Ingredients.RemoveAt(idx);
        }
    }

    public static void clearIngredients(TechType recipe)
    {
        var rec = getRecipe(recipe);
        cacheOriginalRecipe(recipe, rec);
        rec.Ingredients.Clear();
    }

    public static RecipeData addRecipe(TechType item, TechGroup grp, TechCategory cat, string[] path = null,
        int amt = 1,
        CraftTree.Type fab = CraftTree.Type.Fabricator)
    {
        var rec = new RecipeData
        {
            Ingredients = new List<CraftData.Ingredient>(),
            craftAmount = amt
        };
        CraftDataHandler.SetRecipeData(item, rec);
        if (grp != TechGroup.Uncategorized)
            CraftDataHandler.AddToGroup(grp, cat, item);
        if (fab != CraftTree.Type.None)
            CraftTreeHandler.AddCraftingNode(fab, item, path == null ? new string[0] : path);
        return rec;
    }

    public static bool recipeExists(TechType item)
    {
        return CraftDataHandler.GetRecipeData(item) != null;
    }

    public static RecipeData getRecipe(TechType item, bool errorIfNone = true)
    {
        var rec = CraftDataHandler.GetRecipeData(item);
        if (rec == null && errorIfNone)
            throw new Exception("No such recipe '" + item + "'!");
        if (rec != null)
            CraftDataHandler.SetRecipeData(item, rec);
        return rec;
    }

    public static RecipeData removeRecipe(TechType item, bool removeCategories = false)
    {
        var rec = CraftDataHandler.GetRecipeData(item);
        var node = getRecipeNode(item);
        if (node == null)
            throw new Exception("No node found for recipe " + item + "\n\n" + nodes.toDebugString());
        if (node.path == null)
            throw new Exception("Invalid pathless node " + node);
        CraftTreeHandler.RemoveNode(node.recipeType, node.path.Split('\\'));
        nodes.Remove(item);
        //CraftTree.craftableTech.Remove(item);
        if (removeCategories)
            foreach (TechGroup grp in Enum.GetValues(typeof(TechGroup)))
            foreach (TechCategory cat in Enum.GetValues(typeof(TechCategory)))
                CraftDataHandler.RemoveFromGroup(grp, cat, item);
        //CraftDataHandler.AddToGroup(TechGroup.Uncategorized, TechCategory.Misc, item);
        SNUtil.log("Removing recipe " + item);
        return rec;
    }

    public static void changeRecipePath(TechType item, params string[] path)
    {
        var node = getRecipeNode(item);
        if (node == null)
            throw new Exception("No node found for recipe " + item + "\n\n" + nodes.toDebugString());
        if (node.path == null)
            throw new Exception("Invalid pathless node " + node);
        CraftTreeHandler.RemoveNode(node.recipeType, node.path.Split('\\'));
        nodes.Remove(item);
        CraftTreeHandler.AddCraftingNode(node.recipeType, item, path);
        SNUtil.log("Repathing recipe " + item + ": " + node.path + " > " + string.Join("\\", path));
    }

    public static void setItemCategory(TechType item, TechGroup tg, TechCategory tc)
    {
        foreach (TechGroup grp in Enum.GetValues(typeof(TechGroup)))
        foreach (TechCategory cat in Enum.GetValues(typeof(TechCategory)))
            CraftDataHandler.RemoveFromGroup(grp, cat, item);
        CraftDataHandler.AddToGroup(tg, tc, item);
    }

    public static RecipeNode getRecipeNode(TechType item)
    {
        if (nodes.Count == 0)
            foreach (CraftTree.Type t in Enum.GetValues(typeof(CraftTree.Type)))
                cacheRecipeNode(getRootNode(t), t);
        return nodes[item];
    }

    private static void cacheRecipeNode(CraftNode node, CraftTree.Type type)
    {
        if (node == null)
            return;
        if (node.techType0 != TechType.None)
            nodes[node.techType0] = new RecipeNode(node.techType0, type, node.GetPathString('\\', true));
        if (node.nodes != null)
            foreach (CraftNode child in node.nodes)
                cacheRecipeNode(child, type);
    }

    public static CraftNode getRootNode(CraftTree.Type type)
    {
        switch (type)
        {
            case CraftTree.Type.Fabricator:
                return CraftTree.FabricatorScheme();
            case CraftTree.Type.Constructor:
                return CraftTree.ConstructorScheme();
            case CraftTree.Type.Workbench:
                return CraftTree.WorkbenchScheme();
            case CraftTree.Type.SeamothUpgrades:
                return CraftTree.SeamothUpgradesScheme();
            case CraftTree.Type.MapRoom:
                return CraftTree.MapRoomSheme();
            case CraftTree.Type.Centrifuge:
                return CraftTree.CentrifugeScheme();
            case CraftTree.Type.CyclopsFabricator:
                return CraftTree.CyclopsFabricatorScheme();
            case CraftTree.Type.Rocket:
                return CraftTree.RocketScheme();
        }

        return null;
    }

    public static void dumpCraftTree(CraftTree.Type type)
    {
        SNUtil.log("Tree " + type + ":", SNUtil.diDLL);
        var root = getRootNode(type);
        dumpCraftTreeFromNode(root);
    }

    public static void dumpCraftTreeFromNode(CraftNode root)
    {
        dumpCraftTreeFromNode(root, new List<string>());
    }

    private static void dumpCraftTreeFromNode(CraftNode root, List<string> prefix)
    {
        if (root == null)
        {
            SNUtil.log(string.Join("/", prefix) + " -> null @ root");
            return;
        }

        var nodes = root.nodes;
        for (var i = 0; i < nodes.Count; i++)
        {
            var node = nodes[i];
            if (node == null)
                SNUtil.log(string.Join("/", prefix) + " -> null @ " + i);
            else
                try
                {
                    SNUtil.log(string.Join("/", prefix) + " -> Node #" + i + ": " + node.id);
                    prefix.Add(node.id);
                    dumpCraftTreeFromNode((CraftNode) node, prefix);
                    prefix.RemoveAt(prefix.Count - 1);
                }
                catch (Exception e)
                {
                    SNUtil.log(e.ToString());
                }
        }
    }

    public static void dumpPDATree()
    {
        foreach (var kvp in PDAEncyclopedia.entries) SNUtil.log("PDA entry '" + kvp.Key + "': " + kvp.Value);
        dumpCraftTreeFromNode(PDAEncyclopedia.tree);
    }

    public static List<CraftData.Ingredient> buildRecipeList(List<PlannedIngredient> li)
    {
        List<CraftData.Ingredient> ret = new();
        foreach (var p in li) ret.Add(new CraftData.Ingredient(p.item.getTechType(), p.amount));
        return ret;
    }

    public static List<TechType> buildLinkedItems(params PlannedIngredient[] li)
    {
        return buildLinkedItems(li.ToList());
    }

    public static List<TechType> buildLinkedItems(List<PlannedIngredient> li)
    {
        var ret = new List<TechType>();
        foreach (var p in li)
            for (var i = 0; i < p.amount; i++)
                ret.Add(p.item.getTechType());
        return ret;
    }

    public static RecipeData copyRecipe(RecipeData from)
    {
        var ret = new RecipeData();
        ret.craftAmount = from.craftAmount;
        ret.LinkedItems.AddRange(from.LinkedItems);
        foreach (var i in from.Ingredients) ret.Ingredients.Add(new CraftData.Ingredient(i.techType, i.amount));
        ret.craftAmount = from.craftAmount;
        return ret;
    }

    public static RecipeData createUncrafting(TechType item, TechType primary = TechType.None)
    {
        var rec = getRecipe(item);
        var ret = new RecipeData();
        foreach (var ing in rec.Ingredients)
            if (primary != TechType.None && primary == ing.techType)
                ret.craftAmount = ing.amount;
            else
                for (var i = 0; i < ing.amount; i++)
                    ret.LinkedItems.Add(ing.techType);
        ret.Ingredients.Add(new CraftData.Ingredient(item, rec.craftAmount));
        var counts = new CountMap<TechType>();
        foreach (var tt in rec.LinkedItems) counts.add(tt);
        foreach (var tt in counts.getItems()) rec.Ingredients.Add(new CraftData.Ingredient(tt, counts.getCount(tt)));
        return ret;
    }
    /*
    public static void moveRecipeTab(TechType item) {
        TechData rec = getRecipe(item);
        CraftTreeHandler.RemoveNode(CraftTree.Type.Fabricator, "Personal", "Equipment", "PrecursorKey_Purple");
        CraftTreeHandler.AddCraftingNode(CraftTree.Type.Fabricator, TechType.PrecursorKey_Purple, "Machines");
    }*/

    public static string toString(RecipeData rec)
    {
        return getTotalIngredientSlotCount(rec) + ":" +
               string.Join("+",
                   rec.Ingredients.Select(r => "[" + r.techType.AsString() + " x" + r.amount + "]")
                       .ToArray()) + " = x" + rec.craftAmount + " & " + string.Join("+",
                   rec.LinkedItems.Select(tt => tt.AsString()).ToArray());
    }

    public static int getTotalIngredientSlotCount(RecipeData td)
    {
        var ret = 0;
        foreach (var i in td.Ingredients)
        {
            var size = CraftData.GetItemSize(i.techType);
            ret += size.x * size.y;
        }

        return ret;
    }

    public static List<CraftData.Ingredient> combineIngredients(IEnumerable<CraftData.Ingredient> list,
        IEnumerable<CraftData.Ingredient> add)
    {
        var amt = new CountMap<TechType>();
        foreach (var i in list)
            amt.add(i.techType, i.amount);
        foreach (var i in add)
            amt.add(i.techType, i.amount);
        List<CraftData.Ingredient> ret = new();
        foreach (var tt in amt.getItems()) ret.Add(new CraftData.Ingredient(tt, amt.getCount(tt)));
        return ret;
    }

    public class RecipeNode
    {
        public readonly TechType item;
        public readonly string path;
        public readonly CraftTree.Type recipeType;

        internal RecipeNode(TechType tt, CraftTree.Type t, string s)
        {
            item = tt;
            recipeType = t;
            path = s;
        }

        public override string ToString()
        {
            return item + " @ " + recipeType + " >> " + path;
        }
    }
}