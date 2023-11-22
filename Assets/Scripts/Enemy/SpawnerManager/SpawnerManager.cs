using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnerManager : MonoBehaviour
{
    public GameObject[] SkySpawnPoints;
    public GameObject[] GroundSpawnPoints;
    [SerializeField]
    private Wave[] countWaves;
    private int _spawnedEnemyCount = 0;

    private float _currentTime;
    private int _currentWave = 0;
    private int _spawnedEnemiesInWave;

    private void Awake()
    {
        LightWorld.SetNewDuration(countWaves[_currentWave].WaveTime + countWaves[_currentWave + 1].WaveTime);
    }

    void Update()
    {
        if (_currentWave < countWaves.Length && _currentTime <= countWaves[_currentWave].WaveTime)
        {
            _currentTime += Time.deltaTime;

            if (_spawnedEnemiesInWave < countWaves[_currentWave].CountEnemy)
            {
                timeToSpawn -= Time.deltaTime;
                if (timeToSpawn <= 0f)
                {
                    ChooseEnemy();
                    timeToSpawn = countWaves[_currentWave].WaveTime / countWaves[_currentWave].CountEnemy;
                }
            }
        }
    }

    private float timeToSpawn;

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
        EnemyType groundEnemy;
        do
        {
            groundEnemy = countWaves[_currentWave].EnemyInWave[Random.Range(0, countWaves[_currentWave].EnemyInWave.Length)];
        } while (groundEnemy.GetComponent<EnemyType>().enemy != EnemyType.Type.Ground);

        return groundEnemy;
    }

    public void StartNewWave()
    {
        if (_currentWave + 1 == countWaves.Length)
            _currentWave--;
        else
            _currentWave++;
        
        _currentTime = 0;
        _spawnedEnemiesInWave = 0;
        Debug.Log($"{countWaves[_currentWave].name} start");
    }

    private EnemyType GetAirEnemy()
    {
        EnemyType airEnemy;
        do
        {
            airEnemy = countWaves[_currentWave].EnemyInWave[Random.Range(0, countWaves[_currentWave].EnemyInWave.Length)];
        } while (airEnemy.GetComponent<EnemyType>().enemy != EnemyType.Type.Sky);

        return airEnemy;
    }
    
    private void OnEnable()
    {
        LightWorld.OnNightStart += StartNewWave;
        LightWorld.OnDayStart += SetTimeDayNight;
    }

    private void SetTimeDayNight()
    {
        StartNewWave();
        LightWorld.SetNewDuration(countWaves[_currentWave].WaveTime + countWaves[_currentWave + 1].WaveTime);
    }

    private void OnDisable()
    {
        LightWorld.OnNightStart -= StartNewWave;
        LightWorld.OnDayStart -= SetTimeDayNight;
    }

    public void SpawnEnemy(GameObject spawnPoints, EnemyType enemyType)
    {
        if (_spawnedEnemyCount >= 200)
            _spawnedEnemyCount = 0;

        _spawnedEnemyCount++;
        spawnPoints.transform.position = new Vector3(spawnPoints.transform.position.x, spawnPoints.transform.position.y, 10f);

        var enemy = Instantiate(enemyType, spawnPoints.transform.position, Quaternion.identity, transform);
        enemy.GetComponent<SpriteRenderer>().sortingOrder = _spawnedEnemyCount;
        enemy.GetComponent<Health>().ScaleHealth(countWaves[_currentWave].HealthScale);
        enemy.GetComponent<IMovable>().ScaleSpeed(countWaves[_currentWave].SpeedScale);
    }

    
}
