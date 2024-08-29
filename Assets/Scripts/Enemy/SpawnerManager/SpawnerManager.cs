using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnerManager : MonoBehaviour
{
    public GameObject[] SkySpawnPoints;
    public GameObject[] GroundSpawnPoints;
    [SerializeField]
    private WaveConfig[] countWaves;
    private int _spawnedEnemyCount = 0;

    private float _currentTime;
    private int _currentWave = 0;
    private int _spawnedEnemiesInWave;

    private float _timeToSpawn;
    
    private void Awake()
    {
        LightWorld.SetNewDuration(CalculateDuration());
    }
    
    private void OnEnable()
    {
        LightWorld.NightStartEvent += StartNewWave;
        LightWorld.DayStartEvent += SetTimeDayNight;
    }
    
    private void OnDisable()
    {
        LightWorld.NightStartEvent -= StartNewWave;
        LightWorld.DayStartEvent -= SetTimeDayNight;
    }

    void Update()
    {
        if (_currentWave < countWaves.Length && _currentTime <= countWaves[_currentWave].WaveTime)
        {
            _currentTime += Time.deltaTime;

            if (_spawnedEnemiesInWave < countWaves[_currentWave].CountEnemy)
            {
                _timeToSpawn -= Time.deltaTime;
                if (_timeToSpawn <= 0f)
                {
                    ChooseEnemy();
                    _timeToSpawn = countWaves[_currentWave].WaveTime / countWaves[_currentWave].CountEnemy;
                }
            }
        }
    }

    private float CalculateDuration() =>
        countWaves[_currentWave].WaveTime + countWaves[_currentWave + 1].WaveTime;
    
    public void ChooseEnemy()
    {
        float randomValue = Random.Range(0f, 1f);

        if (randomValue <= countWaves[_currentWave].AirGroundSpawnRatio)
        {
            // Spawn ground enemy
            var randomSpawnPoint = GroundSpawnPoints[Random.Range(0, GroundSpawnPoints.Length)];
            var randomEnemy = GetGroundEnemy();
            SpawnEnemy(randomSpawnPoint, randomEnemy);
        }
        else
        {
            // Spawn air enemy
            var randomSpawnPoint = SkySpawnPoints[Random.Range(0, SkySpawnPoints.Length)];
            var randomEnemy = GetAirEnemy();
            SpawnEnemy(randomSpawnPoint, randomEnemy);
        }

        _spawnedEnemiesInWave++;
    }

    private EnemyType GetGroundEnemy()
    {
        var a = (IList<EnemyType>)(countWaves[_currentWave].EnemyInWave
            .Where(x => x.GetComponent<EnemyType>().enemy == EnemyType.Type.Ground)
            .ToList());
       return a.GetRandomItem();
    }

    public void StartNewWave()
    {
        if (_currentWave + 1 == countWaves.Length)
            _currentWave--;
        else
            _currentWave++;
        Debug.Log(countWaves[_currentWave].name);

        _currentTime = 0;
        _spawnedEnemiesInWave = 0;
    }

    private EnemyType GetAirEnemy() {
        var a = (IList<EnemyType>)(countWaves[_currentWave].EnemyInWave
            .Where(x => x.GetComponent<EnemyType>().enemy == EnemyType.Type.Sky)
            .ToList());
        return a.GetRandomItem();
    }


    private void SetTimeDayNight()
    {
        StartNewWave();
        LightWorld.SetNewDuration(CalculateDuration());
    }


    public void SpawnEnemy(GameObject spawnPoints, EnemyType enemyType)
    {
        if (_spawnedEnemyCount >= 200)
            _spawnedEnemyCount = 0;

        _spawnedEnemyCount++;
        
        var position = spawnPoints.transform.position.With(z: 10f);
        spawnPoints.transform.position = position;

        var enemy = Instantiate(enemyType, position, Quaternion.identity, transform);
        enemy.GetComponent<SpriteRenderer>().sortingOrder = _spawnedEnemyCount;
        enemy.GetComponent<Health>().Scale(countWaves[_currentWave].HealthScale);
        enemy.GetComponent<IMovable>().ScaleSpeed(countWaves[_currentWave].SpeedScale);
        enemy.GetComponent<Attack>().Scale(countWaves[_currentWave].DamageScale);
    }
}
