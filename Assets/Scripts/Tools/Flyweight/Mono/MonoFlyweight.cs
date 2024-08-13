using System;
using UnityEngine;

namespace AlexTools.Flyweight
{
    public abstract class MonoFlyweight<TFlyweight, TSettings> :
        MonoBehaviour, IFlyweight<TFlyweight, TSettings>
        where TFlyweight : MonoFlyweight<TFlyweight, TSettings>
        where TSettings : MonoFlyweightSettings<TFlyweight, TSettings>
    {
        [field: SerializeField]
        public TSettings Settings { get; private set; }
        
        public virtual void Initialize(TSettings settings) => Settings = settings;
        
        public virtual void OnGet() {}
        public virtual void OnRelease() {}
        public virtual void OnDestroyPoolObject() {}

        public virtual void ReleaseSelf() => Settings.Release(this);

        public static implicit operator TFlyweight(MonoFlyweight<TFlyweight, TSettings> flyweight)
            => (TFlyweight)flyweight;
    }
}