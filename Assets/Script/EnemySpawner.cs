using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] List<WaveConfig> waveConfigList = new List<WaveConfig>();
    WaveConfig waveConfig;
    [SerializeField] float timeBetweenWaves = 1f;
    bool isLooping = true;
    void Start()
    {
        StartCoroutine(SpawEnemies());
    }
    public WaveConfig GetWaveConfig() 
    {
        return waveConfig;
    }
    IEnumerator SpawEnemies()
    {
        do
        {
            foreach (WaveConfig waveConfigEle in waveConfigList)
            {
                waveConfig = waveConfigEle;
                for (int i = 0; i < waveConfig.GetEnemyCount(); i++)
                {
                    Instantiate(waveConfig.GetEnemyPrefab(i), waveConfig.GetPathWay().position, Quaternion.Euler(new Vector3(0,0,180)), transform);
                    yield return new WaitForSeconds(waveConfig.GetRamdomSpawnTime());
                }
                yield return new WaitForSeconds(timeBetweenWaves);
            }
        }
        while (isLooping);
    }
  
}
