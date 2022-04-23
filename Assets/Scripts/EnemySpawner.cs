using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class EnemySpawner : MonoBehaviour
{

    [SerializeField] private List<WaveConfig> waveConfigs;

    private int startingWave = 0;
    void Start()
    {
        var currentWave = waveConfigs[startingWave];
        StartCoroutine(SpawnAllEnemiesInWave(currentWave));
        
    }

    private IEnumerator SpawnAllEnemiesInWave(WaveConfig currentWave)
    {
        for (int enemyCount = 0; enemyCount < waveConfigs[startingWave].NumberOfEnemies; enemyCount++)
        {
            Instantiate(
                currentWave.EnemyPrefab(),
                currentWave.Waypoints()[0].transform.position,
                Quaternion.identity);
            yield return new WaitForSeconds(currentWave.TimeBetweenSpawns());
        }
    }
}
