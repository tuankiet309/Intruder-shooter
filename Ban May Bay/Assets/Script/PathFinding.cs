using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinding : MonoBehaviour
{
    EnemySpawner enemySpawner;
    WaveConfig waveConfig;
    List<Transform> waypoints;
    int waypointIndex = 0;
    private void Awake()
    {
        enemySpawner = FindObjectOfType<EnemySpawner>();
        

    }
    void Start()
    {
        waveConfig = enemySpawner.GetWaveConfig();
        waypoints = waveConfig.GetWayPoints();
        transform.position = waypoints[waypointIndex].position;
    }
    
    void Update()
    {
        FollowPath();
    }
    void FollowPath()
    {
        if (waypointIndex < waypoints.Count)
        {
            Vector3 targetPosition = waypoints[waypointIndex].position;
            float delta = waveConfig.GetMoveSpeed() * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, delta);
            if (transform.position.x == targetPosition.x && transform.position.y == targetPosition.y)
            {
                waypointIndex++;
            }
        }
        else
            Destroy(gameObject);
    }
}
