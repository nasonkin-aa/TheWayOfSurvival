using UnityEngine;

namespace AlexTools.Flyweight
{
    public abstract class MonoFlyweightSettings<TFlyweight, TSettings> : 
        FlyweightSettings<TFlyweight, TSettings>
        where TFlyweight : MonoFlyweight<TFlyweight, TSettings>
        where TSettings : MonoFlyweightSettings<TFlyweight, TSettings>
    {
        [SerializeField]
        private GameObject prefab;

        public GameObject Prefab => prefab;

        protected override TFlyweight Create()
        {
            var go = Instantiate(prefab);
            go.name = prefab.name;

            var flyweight = go.GetOrAddComponent<TFlyweight>();
            flyweight.Initialize(this);

            return flyweight;
        }

        protected override void OnGet(TFlyweight flyweight)
        {
            flyweight.gameObject.Enable();
            base.OnGet(flyweight);
        }

        protected override void OnRelease(TFlyweight flyweight)
        {
            base.OnRelease(flyweight);
            flyweight.gameObject.Disable();
        }
        
        protected override void OnDestroyPoolObject(TFlyweight flyweight) => Destroy(flyweight.gameObject);
    }
}