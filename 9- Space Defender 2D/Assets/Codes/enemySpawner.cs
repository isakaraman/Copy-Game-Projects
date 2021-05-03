using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawner : MonoBehaviour
{
    public List<waveConfig> configWawe;

    int startingWawe = 0;

    public bool looping=false;

    void Awake()
    {
        var currentWave = configWawe[startingWawe];
    }
    IEnumerator Start()
    {
        do
        {
           yield return StartCoroutine(SpawnAllWaves());
        } while (looping);

        
    }

    IEnumerator SpawnAllWaves()
    {
        for (int waweIndex = 0; waweIndex < configWawe.Count; waweIndex++)
        {
            var currentWave = configWawe[waweIndex];

            yield return StartCoroutine(spawnAllEnemiesInWave(currentWave));
        }
    }

    
    IEnumerator spawnAllEnemiesInWave(waveConfig currentWave)
    {
        for (int enemycounnt = 0; enemycounnt < currentWave.GetNumberOfEnemies(); enemycounnt++)
        {
            var newEnemy=Instantiate(currentWave.GetEnemyPrefab(), currentWave.GetPathPrefab()[0].position, Quaternion.identity) as GameObject;

            newEnemy.GetComponent<enemyScrpit>().SetWaveConfig(currentWave);
            yield return new WaitForSeconds(currentWave.GetTimeBetweenSpawn());
        
        }
    }

    void Update()
    {
        
    }
}
