using Unity.VisualScripting;
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

        protected override void OnDestroyPoolObject(TFlyweight flyweight)
        {
            base.OnDestroyPoolObject(flyweight);
            
            if (flyweight.IsUnityNull()) return;
            Destroy(flyweight.gameObject);
        }
    }
}