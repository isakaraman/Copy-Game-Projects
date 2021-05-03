using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName ="Wave/Enemy Wave Config")]
public class waveConfig : ScriptableObject
{
    public GameObject enemyPrefab;
    public GameObject pathPrefab;
    public float timeBetweenSpawn = 0.5f;
    public float spawnRandomFactor = 0.3f;
    public int numberOfEnemies = 5;
    public float moveSpeed = 2f;

    public GameObject GetEnemyPrefab() { return enemyPrefab; }
    public List<Transform> GetPathPrefab() {

        var wayPoints = new List<Transform>();

        foreach (Transform child in pathPrefab.transform)
        {
            wayPoints.Add(child);
        }
        
        return wayPoints; 
    }
    public float GetTimeBetweenSpawn() { return timeBetweenSpawn; }
    public float GetSpawnRandomFactor() { return spawnRandomFactor; }
    public int GetNumberOfEnemies() { return numberOfEnemies; }
    public float GetMoveSpeed() { return moveSpeed; }
   
}
