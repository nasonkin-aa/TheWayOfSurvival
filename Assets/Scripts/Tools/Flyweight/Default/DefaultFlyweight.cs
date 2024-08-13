using System;

namespace AlexTools.Flyweight.Default
{
    public abstract class DefaultFlyweight<TFlyweight, TSettings> : 
        IFlyweight<TFlyweight, TSettings>, IDisposable
        where TFlyweight : DefaultFlyweight<TFlyweight, TSettings>, new()
        where TSettings : DefaultFlyweightSettings<TFlyweight, TSettings>
    {
        public TSettings Settings { get; private set; }
        
        public void Initialize(TSettings settings) => Settings = settings;
        public virtual void OnGet() {}
        public virtual void OnRelease() {}
        public virtual void OnDestroyPoolObject() {}
        
        public virtual void ReleaseSelf() => Settings.Release(this);
        
        public virtual void Dispose() => ReleaseSelf();

        public static implicit operator TFlyweight(DefaultFlyweight<TFlyweight, TSettings> flyweight)
            => (TFlyweight)flyweight;
    }
}