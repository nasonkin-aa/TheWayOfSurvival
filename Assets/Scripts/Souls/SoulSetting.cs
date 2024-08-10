using System.Collections.Generic;
using AlexTools.Flyweight;
using AYellowpaper.SerializedCollections;
using UnityEngine;

namespace Souls
{
    [CreateAssetMenu(menuName = "Flyweight/Create SoulSetting")]
    public class SoulSetting : MonoFlyweightSettings<Soul, SoulSetting>
    {
        [SerializeField] private float despawnTime;
        [SerializeField] private Color defaultColor;
        [SerializeField] private SerializedDictionary<int, Color> colorDictionary;

        public float DespawnTime => despawnTime;

        public Color GetColor(int key)
        {
            if (!colorDictionary.TryGetValue(key, out var color))
                color = defaultColor;

            return color;
        }

        protected override void OnGet(Soul flyweight)
        {
            flyweight.gameObject.Enable();
            base.OnGet(flyweight);
        }

        protected override void OnRelease(Soul flyweight)
        {
            base.OnRelease(flyweight);
            flyweight.gameObject.Disable();
        }
    }
}