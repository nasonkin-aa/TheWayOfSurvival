using UnityEngine;

namespace Enemy
{
    [CreateAssetMenu(fileName = "New BaseEnemyConfig", menuName = "Enemy/Create BaseEnemyConfig")]
    public class BaseEnemyConfig : ScriptableObject
    {
        [SerializeField] private int maxHealth;
        [SerializeField] private int damage;
        [SerializeField] private int soulPoints;
        [SerializeField] private int scorePoints;

        public int MaxHealth => maxHealth;
        public int Damage => damage;
        public int SoulPoints => soulPoints;
        public int ScorePoints => scorePoints;

        public const string ConfigPath = "Config/BaseEnemyConfig";
        public const string DefaultConfigPath = ConfigPath + "/DefaultConfig";

        public static string GetConfigPath(string name) => $"{ConfigPath}/{name}";
    }
}