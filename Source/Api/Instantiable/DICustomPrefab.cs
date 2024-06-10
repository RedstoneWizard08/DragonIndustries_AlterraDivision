using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Nautilus.Assets;
using Nautilus.Assets.Gadgets;
using Nautilus.Assets.PrefabTemplates;
using Nautilus.Handlers;
using UnityEngine;

namespace ReikaKalseki.DIAlterra.Api.Instantiable;

/// <summary>
/// Represents a class with everything needed to make a custom prefab work.
/// </summary>
public abstract class DICustomPrefab : ICustomPrefab
{
    private readonly Dictionary<Type, Gadget> _gadgets = new();
    private readonly List<Action> _onRegister = new();
    private readonly List<Action> _onUnregister = new();

    // Very simple way of preventing Unity from unloading asset bundle prefabs via Resources.UnloadUnusedAssets.
    private GameObject _prefab;
    
    private bool _registered;

    /// <inheritdoc/>
    public required PrefabInfo Info { get; set; }
    
    /// <inheritdoc/>
    public PrefabFactoryAsync Prefab { get; protected set; }

    /// <inheritdoc/>
    public PrefabPostProcessorAsync OnPrefabPostProcess { get; protected set; }

    /// <summary>
    /// Constructs a custom prefab object.
    /// </summary>
    public DICustomPrefab() { }
    
    /// <summary>
    /// Constructs a custom prefab object.
    /// </summary>
    /// <param name="info">The information this prefab will be registered as.</param>
    [SetsRequiredMembers]
    public DICustomPrefab(PrefabInfo info)
    {
        Info = info;
    }

    /// <summary>
    /// Constructs a custom prefab object with the <see cref="Info"/> assigned appropriately.
    /// </summary>
    /// <param name="classId">The class identifier used for the PrefabIdentifier component whenever applicable.</param>
    /// <param name="displayName">The display name for this item.</param>
    /// <param name="description">The description for this item.</param>
    [SetsRequiredMembers]
    public DICustomPrefab(string classId, string displayName, string description)
    {
        Info = PrefabInfo.WithTechType(classId, displayName, description);
    }
    
    /// <summary>
    /// Constructs a custom prefab object with the <see cref="Info"/> assigned appropriately.
    /// </summary>
    /// <param name="classId">The class identifier used for the PrefabIdentifier component whenever applicable.</param>
    /// <param name="displayName">The display name for this item.</param>
    /// <param name="description">The description for this item.</param>
    /// <param name="icon">The icon for this item.</param>
    [SetsRequiredMembers]
    public DICustomPrefab(string classId, string displayName, string description, Atlas.Sprite icon) : this(classId, displayName, description)
    {
        Info.WithIcon(icon);
    }
    
    /// <summary>
    /// Constructs a custom prefab object with the <see cref="Info"/> assigned appropriately.
    /// </summary>
    /// <param name="classId">The class identifier used for the PrefabIdentifier component whenever applicable.</param>
    /// <param name="displayName">The display name for this item.</param>
    /// <param name="description">The description for this item.</param>
    /// <param name="icon">The icon for this item.</param>
    [SetsRequiredMembers]
    public DICustomPrefab(string classId, string displayName, string description, Sprite icon) : this(classId, displayName, description)
    {
        Info.WithIcon(icon);
    }
    
    /// <inheritdoc/>
    public TGadget AddGadget<TGadget>(TGadget gadget) where TGadget : Gadget
    {
        if (_gadgets.ContainsKey(gadget.GetType()))
            throw new DuplicateGadgetException(string.IsNullOrEmpty(Info.ClassID) ? "Uninitialized" : Info.ClassID, gadget);
        _gadgets[gadget.GetType()] = gadget;
        return gadget;
    }

    /// <inheritdoc/>
    public Gadget GetGadget(Type gadgetType)
    {
        return _gadgets.TryGetValue(gadgetType, out var gadget) ? gadget : null;
    }

    /// <inheritdoc/>
    public TGadget GetGadget<TGadget>() where TGadget : Gadget
    {
        return GetGadget(typeof(TGadget)) as TGadget;
    }

    /// <inheritdoc/>
    public bool TryGetGadget<TGadget>(out TGadget gadget) where TGadget : Gadget
    {
        var result = _gadgets.TryGetValue(typeof(TGadget), out var g);
        gadget = (TGadget)g;
        return result;
    }

    /// <inheritdoc/>
    public bool TryAddGadget<TGadget>(TGadget gadget) where TGadget : Gadget
    {
        if (_gadgets.ContainsKey(typeof(TGadget)))
            return false;
        _gadgets.Add(typeof(TGadget), gadget);
        return true;
    }

    /// <inheritdoc/>
    public bool RemoveGadget(Type gadget)
    {
        return _gadgets.Remove(gadget);
    }

    /// <inheritdoc/>
    public bool RemoveGadget<TGadget>() where TGadget : Gadget
    {
        return _gadgets.Remove(typeof(TGadget));
    }

    /// <inheritdoc/>
    public void AddOnRegister(Action onRegisterCallback)
    {
        _onRegister.Add(onRegisterCallback);
    }

    /// <inheritdoc/>
    public void AddOnUnregister(Action onUnregisterCallback)
    {
        _onUnregister.Add(onUnregisterCallback);
    }

    /// <summary>
    /// Sets a function as the game object constructor of this custom prefab. This is an asynchronous version.
    /// </summary>
    /// <param name="prefabAsync">The function to set.</param>
    public void SetGameObject(Func<IOut<GameObject>, IEnumerator> prefabAsync) => Prefab = obj => prefabAsync(obj);

    /// <summary>
    /// Sets a prefab template as the game object constructor of this custom prefab.
    /// </summary>
    /// <param name="prefabTemplate">The prefab template object to set.</param>
    public void SetGameObject(PrefabTemplate prefabTemplate)
    {
        Prefab = prefabTemplate.GetPrefabAsync;
        SetPrefabPostProcessor(prefabTemplate.OnPrefabPostProcessor);
    }

    /// <summary>
    /// Sets a game object as the prefab of this custom prefab.
    /// </summary>
    /// <remarks>Only use this overload on GameObjects that are loaded from asset bundles <b>without</b> instantiating them. For objects that could be destroyed on scene load, use <see cref="SetGameObject(System.Func{UnityEngine.GameObject})"/> instead.</remarks>
    /// <param name="prefab">The game object to set.</param>
    public void SetGameObject(GameObject prefab)
    {
        _prefab = prefab;
        Prefab = obj => SyncPrefab(obj, prefab);
    }
    
    /// <summary>
    /// Sets a function as the game object constructor of this custom prefab. This is a synchronous version.
    /// </summary>
    /// <param name="prefab">The function to set.</param>
    public void SetGameObject(Func<GameObject> prefab) => Prefab = obj => SyncPrefab(obj, prefab?.Invoke());

    /// <summary>
    /// Sets a post processor for the <see cref="Prefab"/>. This is an asynchronous version.
    /// </summary>
    /// <param name="postProcessorAsync">The post processor to set.</param>
    public void SetPrefabPostProcessor(Func<GameObject, IEnumerator> postProcessorAsync) => OnPrefabPostProcess += obj => postProcessorAsync(obj);

    /// <summary>
    /// Sets a post processor for the <see cref="Prefab"/>. This is a synchronous version.
    /// </summary>
    /// <param name="postProcessor">The post processor to set.</param>
    public void SetPrefabPostProcessor(Action<GameObject> postProcessor) => OnPrefabPostProcess += obj => SyncPostProcessor(obj, postProcessor);

    /// <summary>
    /// Registers this custom prefab into the game.
    /// </summary>
    public void Register()
    {
        DIMod.LOGGER.LogInfo($"Registering prefab '{Info}'...");
        
        if (_registered)
            return;
        
        // Every prefab must have a class ID and a PrefabFileName, so if they don't exist, registration should be cancelled.
        if (string.IsNullOrEmpty(Info.ClassID) || string.IsNullOrEmpty(Info.PrefabFileName))
        {
            DIMod.LOGGER.LogError($"Prefab '{Info}' does not contain a class ID or a PrefabFileName. Skipping registration.");
            return;
        }

        /*
         * It is fine for some prefabs to not have a tech type (E.G: world decorators, or anything that isn't scannable),
         * so just warn it in-case people forgot to add one.
         */
        if (Info.TechType is TechType.None)
        {
            DIMod.LOGGER.LogWarning($"Prefab '{Info}' does not contain a TechType.");
        }

        foreach (var reg in _onRegister)
        {
            reg?.Invoke();
        }

        foreach (var gadget in _gadgets)
        {
            gadget.Value.Build();
        }
        
        PrefabHandler.Prefabs.RegisterPrefab(this);
        OnRegister();

        _registered = true;
    }
    
    /// <summary>
    /// Called on registration.
    /// </summary>
    protected virtual void OnRegister() {}

    /// <summary>
    /// Unregisters this custom prefab from the game.
    /// </summary>
    /// <remarks>The class ID reference will be completely erased, however, the TechType instance will remain in the game.</remarks>
    public void Unregister()
    {
        if (!_registered)
            return;

        if (string.IsNullOrEmpty(Info.ClassID) || string.IsNullOrEmpty(Info.PrefabFileName))
        {
            DIMod.LOGGER.LogInfo($"Prefab '{Info}' is invalid or unknown. Skipping unregister operation.");
            return;
        }
        
        foreach (var unReg in _onUnregister)
        {
            unReg?.Invoke();
        }
        
        PrefabHandler.Prefabs.UnregisterPrefab(this);

        _registered = false;
    }
    
    private IEnumerator SyncPrefab(IOut<GameObject> obj, GameObject prefab)
    {
        obj.Set(prefab);
        yield break;
    }

    private IEnumerator SyncPostProcessor(GameObject prefab, Action<GameObject> postProcessor)
    {
        postProcessor?.Invoke(prefab);
        yield break;
    }
}