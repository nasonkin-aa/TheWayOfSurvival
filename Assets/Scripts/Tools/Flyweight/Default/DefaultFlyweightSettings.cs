namespace AlexTools.Flyweight.Default
{
    public abstract class DefaultFlyweightSettings<TFlyweight, TSettings> : 
        FlyweightSettings<TFlyweight, TSettings>
        where TFlyweight : DefaultFlyweight<TFlyweight, TSettings>, new()
        where TSettings : DefaultFlyweightSettings<TFlyweight, TSettings>
    {
        protected override TFlyweight Create()
        {
            var flyweight = new TFlyweight();
            flyweight.Initialize(this);
            return flyweight;
        }
    }
}