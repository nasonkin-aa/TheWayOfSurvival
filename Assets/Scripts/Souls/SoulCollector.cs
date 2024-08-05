using System;
using UnityEngine;

namespace Souls
{
    public class SoulCollector : MonoBehaviour
    {
        public static event Action<int> PickUpEvent;

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (!other.gameObject.TryGetComponent(out Soul soul))
                return;
            
            SoundManager.Instance.PlaySound("SoulPickUp");
            PickUpEvent?.Invoke(soul.Points);
            soul.ReleaseSelf();
        }
    }
}