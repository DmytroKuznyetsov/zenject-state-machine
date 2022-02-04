using System;
using UnityEngine;
using Zenject;
using Object = UnityEngine.Object;

namespace Services
{
    public class InjectedPrefabsService : IInjectedPrefabsService
    {
        private DiContainer _container;
        
        public InjectedPrefabsService(DiContainer diContainer) =>
            _container = diContainer;

        public void Set(DiContainer container) => _container = container;

        public GameObject InstantiatePrefab(Object prefab)
        {
            return _container.InstantiatePrefab(prefab);
        }

        public GameObject InstantiatePrefab(Object prefab, Transform parentTransform) => 
            _container.InstantiatePrefab(prefab, parentTransform);

        public GameObject InstantiatePrefab(Object prefab, Vector3 position, Quaternion rotation, Transform parentTransform) => 
            _container.InstantiatePrefab(prefab, position, rotation, parentTransform);

        public GameObject InstantiatePrefab(Object prefab, Vector3 position, Quaternion rotation) => 
            _container.InstantiatePrefab(prefab, position, rotation, null);

        public T InstantiatePrefab<T>(Object prefab, Transform parentTransform) => 
            _container.InstantiatePrefabForComponent<T>(prefab, parentTransform);

        public T InstantiatePrefab<T>(T prefab) where T : Object
        {
            return _container.InstantiatePrefabForComponent<T>(prefab);
        }

        public T InstantiatePrefab<T>(Object prefab, Vector3 position, Quaternion rotation, Transform parentTransform) => 
            _container.InstantiatePrefabForComponent<T>(prefab, position, rotation, parentTransform);

        // public T InstantiateComponent<T>(GameObject gameObject) where T : Component, IViewController => 
        //     _container.InstantiateComponent<T>(gameObject);

        public Component InstantiateComponent(Type type, GameObject gameObject) => 
            _container.InstantiateComponent(type, gameObject);
    }
}