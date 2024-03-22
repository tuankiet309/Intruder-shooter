using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Wave Config", fileName = "New Wave Config")]
public class WaveConfig : ScriptableObject
{
    [SerializeField] List<GameObject> enemyPrefab;
    [SerializeField] Transform pathPrefab;
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float timeBetweenSpawns = 1f;
    [SerializeField] float spawnTimeVarience = 0f;
    [SerializeField] float minimumSpawnTime = 0.2f;
    public Transform GetPathWay()
    {
       
        return pathPrefab.GetChild(0); 
    }
    public List<Transform> GetWayPoints()
    {
        List<Transform> list = new List<Transform>();
        foreach (Transform child in pathPrefab)
        {
            list.Add(child);
        }
        return list;
    }
    public float GetMoveSpeed()
    {
        return moveSpeed;
    }
    public int GetEnemyCount()
    {
        return enemyPrefab.Count;
    }
    public GameObject GetEnemyPrefab(int enemyIndex)
    {
        return enemyPrefab[enemyIndex];
    }
    public float GetRamdomSpawnTime()
    {
        float spawnTime = Random.Range(timeBetweenSpawns - spawnTimeVarience, timeBetweenSpawns + spawnTimeVarience);
        return Mathf.Clamp(spawnTime, minimumSpawnTime, float.MaxValue);
    }
}
