using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Wave", menuName = "Wave" )]
public class Wave : ScriptableObject
{
    public int CountEnemy;
    public float WaveTime;
    public EnemyType[] EnemyInWave;
    
    [SerializeField, Range(0f, 1f)]
    public float AirGroundSpawnRatio;
    
    public float SpeedScale = 1f;
    public float HealthScale = 1f;

}
