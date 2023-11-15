using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnerManager : MonoBehaviour
{
    public GameObject[] SkySpawnPoin;
    public GameObject[] GroundSpawnPoin;
    [SerializeField] 
    private Wave[] countWaves;
    
    private float _currentTime;
    private int _currentWave;
    private float timeToSpawn;
    void Update()
    {
        if (_currentWave < countWaves.Length && _currentTime <= countWaves[_currentWave].WaveTime )
        {
            _currentTime += Time.deltaTime;
            
            timeToSpawn -= Time.deltaTime;
            if (timeToSpawn <= 0f)
            {
                ChooseEnemy();
                timeToSpawn = countWaves[_currentWave].WaveTime / countWaves[_currentWave].CountEnemy;
            }
        }   
        else
        {
            _currentTime = 0;
            _currentWave++;
        }
    }

    public void ChooseEnemy()
    {
        var RandomNumberInArray = Random.Range(0, countWaves[_currentWave].EnemyInWave.Length );
        var RandomEnemy = countWaves[_currentWave].EnemyInWave[RandomNumberInArray];
        if (RandomEnemy.GetComponent<EnemyType>().enemy == EnemyType.Type.Ground)
        {
            SpawnEnemy(GroundSpawnPoin, RandomEnemy);
        }
        else
        {
            SpawnEnemy(SkySpawnPoin, RandomEnemy);
        }
    }

    public void SpawnEnemy(GameObject[] spawnPoints,EnemyType enemyType )
    {
        var RandomSpawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
        RandomSpawnPoint.transform.position = new Vector3(RandomSpawnPoint.transform.position.x, RandomSpawnPoint.transform.position.y, 10f);
        
        Instantiate(enemyType, RandomSpawnPoint.transform.position,Quaternion.identity, transform);
    }
    
}