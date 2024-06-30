using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    // List of wave configurations to be used for spawning enemies
    [SerializeField] List<WaveConfigSO> waveConfigs;
    [SerializeField] float timeBetweenWaves = 0f;
    [SerializeField] bool isLooping;
    WaveConfigSO currentWave;
    void Start()
    {
        StartCoroutine(SpawnEnemyWaves());
    }

    public WaveConfigSO GetCurrentWave()
    {
        return currentWave;
    }

    // Coroutine to loop through each wave and spawn enemies
    IEnumerator SpawnEnemyWaves()
    {
        do
        {
            // Loop through each wave configuration in the waveConfigs list
            foreach (WaveConfigSO wave in waveConfigs)
            {
                currentWave = wave;
                for (int i = 0; i < currentWave.getEnemyCount(); i++)
                {
                    // Instantiate an enemy prefab at the starting waypoint
                    Instantiate(currentWave.GetEnemyPrefabs(i),
                        currentWave.GetStartingWayPoint().position,
                    Quaternion.Euler(0,0,180), 
                    this.transform);
                    yield return new WaitForSeconds(currentWave.GetRandomSpawnTime());
                }
                yield return new WaitForSeconds(timeBetweenWaves);
            }

        }
        while (isLooping);
        
        
    }

}
