using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy wave config")] 
public class WaveConfig : ScriptableObject
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private GameObject pathPrefab;
    [SerializeField] private float timeBetweenSpawns = 0.5f;
    [SerializeField] private float spawnRandomFactor = 0.3f;
    [SerializeField] private int numberOfEnemies = 5;
    [SerializeField] private float moveSpeed = 2f;

    public GameObject GetEnemyPrefab() { return enemyPrefab; }

    public List<Transform> GetWaypoints()
    {
        var waveWaypoints = pathPrefab.GetComponentsInChildren<Transform>().ToList();
        waveWaypoints.RemoveAt(0);
        
        return waveWaypoints; 
    }

    public float GetTimeBetweenSpawns()
    {
        return timeBetweenSpawns; 
    }

    public float GetSpawnRandomFactor()
    {
        return spawnRandomFactor; 
    }

    public int GetNumberOfEnemies()
    {
        return numberOfEnemies; 
    }

    public float GetMoveSpeed()
    {
        return moveSpeed;
    }
}
