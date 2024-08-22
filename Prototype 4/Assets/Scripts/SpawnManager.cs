using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject powerup;
    private float spawnRange = 9f;
    public int enemyCount;
    public int waveNumber = 1;
  
    void Start()
    {
        SpawnPowerup();
        SpawnEnemyWave(waveNumber);
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsOfType<Enemy>().Length;
        if (enemyCount == 0)
        {
            waveNumber++;
            SpawnPowerup();
            SpawnEnemyWave(waveNumber);
        }

    }
    void SpawnPowerup()
    {
        Instantiate(powerup, GenerateSpawnPos(), powerup.transform.rotation);
    }


    void SpawnEnemyWave(int waveNumber)
    {
        for (int i = 0; i < waveNumber; i++)
        {
            Instantiate(enemyPrefab, GenerateSpawnPos(), enemyPrefab.transform.rotation);
        }
    }

    private Vector3 GenerateSpawnPos()
    {

        float spawnX = Random.Range(-spawnRange, spawnRange);
        float spawnZ = Random.Range(-spawnRange, spawnRange);

        Vector3 randomPos = new Vector3(spawnX, 0, spawnZ);

        return randomPos;
    }
}
