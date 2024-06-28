using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour
{
    EnemySpawn enemySpawn;
    WaveConfigSO waveConfig;
    //[SerializeField] WaveConfigSO waveConfig;
    List<Transform> waypoints;
    int WaypointIndex = 0;

    private void Awake()
    {
        enemySpawn = FindObjectOfType<EnemySpawn>();

    }
    void Start()
    {
        waveConfig = enemySpawn.GetCurrentWave();
        waypoints = waveConfig.GetWaypoints();
        transform.position = waypoints[WaypointIndex].position;
    }

    void Update()
    {
        FollowPath();
    }

    void FollowPath()
    {
        if(WaypointIndex < waypoints.Count)
        {
            Vector3 targetPosition = waypoints[WaypointIndex].position;
            float delta = waveConfig.GetMoveSpeed() * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, delta);
            if(transform.position == targetPosition)
            {
                WaypointIndex++;
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
