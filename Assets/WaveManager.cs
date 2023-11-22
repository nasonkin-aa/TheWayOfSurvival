using System.Collections;
using UnityEngine;
using System.Collections.Generic;

public class WaveManager : MonoBehaviour
{
    private Wave[] Waves;
    private int currentWaveIndex = 0;
    private int currentEnemyIndex = 0;

    public GameObject[] SkySpawnPoints;
    public GameObject[] GroundSpawnPoints;


    public void StartWave()
    {
        StartCoroutine(SpawnWave(Waves[currentWaveIndex]));
    }

    private IEnumerator SpawnWave(Wave wave)
    {
        float timeInterval = wave.WaveTime / wave.CountEnemy;

        for (int i = 0; i < wave.CountEnemy; i++)
        {
            //SpawnEnemy(wave.EnemyInWave[currentEnemyIndex], i);
            currentEnemyIndex = (currentEnemyIndex + 1) % wave.EnemyInWave.Length;
            yield return new WaitForSeconds(timeInterval);
        }

        // Check if all enemies are defeated before starting the next wave
        while (AreEnemiesAlive())
        {
            yield return null;
        }

        // Trigger the next wave (you need to implement a method to set the next wave in your game)
        StartNextWave();
    }

    // private void SpawnEnemy(EnemyType enemyType, int spawnIndex)
    // {
    //     
    //     if (enemyType.ContainsKey(enemyType.enemy))
    //     {
    //         GameObject enemyPrefab = enemyPrefabDictionary[enemyType.enemy];
    //         Vector3 spawnPoint = DetermineSpawnPoint(enemyType.enemy, spawnIndex);
    //         Instantiate(enemyPrefab, spawnPoint, Quaternion.identity, transform);
    //     }
    //     else
    //     {
    //         // Handle the case where the enemyType is not found
    //         Debug.LogError($"Prefab for enemy type {enemyType.enemy} not found!");
    //         // You may want to provide a default prefab or take other actions here
    //     }
    // }
    //
    // private Vector3 DetermineSpawnPoint(EnemyType.Type enemyType, int spawnIndex)
    // {
    //     // Determine the spawn point based on the enemy type
    //     return (enemyType == EnemyType.Type.Fly) ? SkySpawnPoints[spawnIndex % SkySpawnPoints.Length] : GroundSpawnPoints[spawnIndex % GroundSpawnPoints.Length];
    // }

    private bool AreEnemiesAlive()
    {
        // Assuming enemies set themselves as inactive or are destroyed when defeated
        // You need to adapt this logic based on how your enemies behave in your game

        // Find all enemy objects in the scene
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        // Check if any enemies are still active in the scene
        return enemies.Length > 0;
    }

    private void StartNextWave()
    {
        // Assuming you have a method to get the next wave index or next wave data
        // This method could be part of your game manager or another source

        currentWaveIndex++;

        // Check if there are more waves to start
        if (currentWaveIndex < Waves.Length)
        {
            // Start the next wave
            //StartWave(Waves[currentWaveIndex]);
        }
        else
        {
            // No more waves, you might want to handle the end of the level or game here
            Debug.Log("All waves completed!");
        }
    }
}
