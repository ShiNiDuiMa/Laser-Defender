using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] List<WaveConfigSO> waveConfigs;
    [SerializeField] float timeBetweenWaves = 0f;
    WaveConfigSO currentWave;
    void Start()
    {
        StartCoroutine(SpawnEnemyWaves());
    }

    public WaveConfigSO GetCurrentWave()
    {
        return currentWave;
    }

    //go for loop through all of enemies
    IEnumerator SpawnEnemyWaves()
    {
        foreach(WaveConfigSO wave in waveConfigs)
        {
            currentWave = wave;
            for (int i = 0; i < currentWave.getEnemyCount(); i++)
            {
                Instantiate(currentWave.GetEnemyPrefabs(i), currentWave.GetStartingWayPoint().position,
                Quaternion.identity,
                transform);
                yield return new WaitForSeconds(currentWave.GetRandomSpawnTime());
            }
            yield return new WaitForSeconds(timeBetweenWaves);
        }
        
        
    }

}
