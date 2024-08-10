using System;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using Object = UnityEngine.Object;

public static class GameObjectExtensions
{
    public static void Enable(this GameObject gameObject) => gameObject.SetActive(true);
    public static void Disable(this GameObject gameObject) => gameObject.SetActive(false);

    public static T GetOrAddComponent<T>(this GameObject gameObject) where T : Component
    {
        if (!gameObject.TryGetComponent(out T component))
            component = gameObject.AddComponent<T>();

        return component;
    }

    public static bool HasComponent<T>(this GameObject gameObject) where T : Component => 
        gameObject.GetComponent<T>();

    public static bool RemoveComponent<T>(this GameObject gameObject) where T : Component
    {
        if (!gameObject.TryGetComponent(out T component))
            return false;
            
        Object.Destroy(component);
        return true;
    }
        
    public static void RemoveAllComponents<T>(this GameObject gameObject) where T : Component
    {
        var components = gameObject.GetComponents<T>();
        components.ForEach(Object.Destroy);
    }
    public static void AssignIfUnityNull<T>(
        this GameObject gameObject, 
        ref T component,
        Func<T> func) 
        where T : Object
    {
        if (component.IsUnityNull())
            component = func();
    }

    public static void AssignComponentIfUnityNull<T>(
        this GameObject gameObject,
        ref T component)
        where T : Object =>
        gameObject.AssignIfUnityNull(ref component, gameObject.GetComponent<T>);


    public static void AssignComponentInChildrenIfUnityNull<T>(
        this GameObject gameObject,
        ref T component)
        where T : Object =>
        gameObject.AssignIfUnityNull(ref component, gameObject.GetComponentInChildren<T>);

    public static string GetPath(this GameObject gameObject) =>
        '/' + string.Join('/', gameObject
            .GetComponentsInParent<Transform>()
            .Select(t => t.name)
            .Reverse());

    public static string GetFullPath(this GameObject gameObject) =>
        $"{gameObject.GetPath()}/{gameObject.name}";
}