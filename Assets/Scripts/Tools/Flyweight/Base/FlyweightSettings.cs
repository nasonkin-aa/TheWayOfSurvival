using System;
using UnityEngine;
using UnityEngine.Pool;

namespace AlexTools.Flyweight
{
    public abstract class FlyweightSettings<TFlyweight, TSettings> :
        ScriptableObject, IObjectPool<TFlyweight>
        where TFlyweight : class, IFlyweight<TFlyweight, TSettings>
        where TSettings : FlyweightSettings<TFlyweight, TSettings>
    {
        [SerializeField] private bool collectionCheck = true;
        [SerializeField] private int defaultCapacity = 10;
        [SerializeField] private int maxSize = 10000;
        
        private ObjectPool<TFlyweight> _pool;

        protected virtual void OnEnable()
        {
            _pool ??= new ObjectPool<TFlyweight>(
                Create,
                OnGet,
                OnRelease,
                OnDestroyPoolObject,
                collectionCheck,
                defaultCapacity,
                maxSize
            );
        }

        protected abstract TFlyweight Create();
        
        protected virtual void OnGet(TFlyweight flyweight) => flyweight.OnGet();
        protected virtual void OnRelease(TFlyweight flyweight) => flyweight.OnRelease();
        protected virtual void OnDestroyPoolObject(TFlyweight flyweight) => flyweight.OnDestroyPoolObject();

        public TFlyweight Get() => _pool.Get();
        public PooledObject<TFlyweight> Get(out TFlyweight v) => _pool.Get(out v);
        public void Release(TFlyweight element) => _pool.Release(element);
        public void Clear() => _pool.Clear();
        public int CountInactive => _pool.CountInactive;

        public static implicit operator TSettings(FlyweightSettings<TFlyweight, TSettings> settings)
            => (TSettings)settings;
    }
}