using System;
using UnityEngine;
using Zenject;
using Object = UnityEngine.Object;

namespace Services
{
    public interface IInjectedPrefabsService
    {
        void Set(DiContainer container);
        GameObject InstantiatePrefab(Object prefab);
        GameObject InstantiatePrefab(Object prefab, Transform parentTransform);
        GameObject InstantiatePrefab(Object prefab, Vector3 position, Quaternion rotation, Transform parentTransform);
        GameObject InstantiatePrefab(Object prefab, Vector3 position, Quaternion rotation);
        T InstantiatePrefab<T>(Object prefab, Transform parentTransform);
        T InstantiatePrefab<T>(T prefab) where T : Object;
        T InstantiatePrefab<T>(Object prefab, Vector3 position, Quaternion rotation, Transform parentTransform);
        // T InstantiateComponent<T>(GameObject gameObject) where T : Component, IViewController;
        Component InstantiateComponent(Type type, GameObject gameObject);
    }
}