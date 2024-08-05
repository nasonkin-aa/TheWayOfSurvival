namespace AlexTools.Flyweight
{
    public interface IFlyweight<TFlyweight, TSettings>
        where TFlyweight : class, IFlyweight<TFlyweight, TSettings>
        where TSettings : FlyweightSettings<TFlyweight, TSettings>
    {
        TSettings Settings { get; }
        
        void Initialize(TSettings settings);
        void OnGet();
        void OnRelease();
        void OnDestroy();
        
        void ReleaseSelf();
    }
}