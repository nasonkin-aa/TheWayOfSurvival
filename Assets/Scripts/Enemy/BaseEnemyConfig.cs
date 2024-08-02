using UnityEngine;

namespace Enemy
{
    [CreateAssetMenu(fileName = "New BaseEnemyConfig", menuName = "Enemy/Create BaseEnemyConfig")]
    public class BaseEnemyConfig : ScriptableObject
    {
        [SerializeField] private int maxHealth;
        [SerializeField] private int soulPoints;
        [SerializeField] private int scorePoints;

        public int MaxHealth => maxHealth;
        public int SoulPoints => soulPoints;
        public int ScorePoints => scorePoints;

        public const string DefaultConfigPath = "Config/BaseEnemyConfig/DefaultConfig";
    }
}