using UnityEngine;

namespace Souls
{
    public class SoulSpawner : MonoBehaviour
    {
        [SerializeField] private SoulSetting soulSetting;

        private void OnEnable()
        {
            BaseEnemy.DeathEvent += OnEnemyDeath;
        }

        private void OnDisable()
        {
            BaseEnemy.DeathEvent -= OnEnemyDeath;
        }

        private void OnEnemyDeath(BaseEnemy.DeathInfo deathInfo)
        {
            var soul = soulSetting.Get();
            soul.Points = deathInfo.Config.SoulPoints;
            soul.transform.position = deathInfo.Position;
        }
    }
}