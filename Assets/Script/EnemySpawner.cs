using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public LevelManager levelManager;
    public List<WaveData> waveDatas = new List<WaveData>();
    public float waveWaitTime = 10;
    float waveWaitTimer = 0;
    bool isSpawning = false;
    bool isWaitingNextWave = true;
    int enemiesWaveSpawned = 0;

    int currentWaveIndex = 0;
    List<BaseEnemy> spawnedEnemies = new List<BaseEnemy>();
    float spawnRateTime = 10f;
    float spawnRateTimer = 0;


    public void Update()
    {
        if (isWaitingNextWave)
        {
            waveWaitTimer += Time.deltaTime;
            if (waveWaitTimer > waveWaitTime)
            {
                isWaitingNextWave = false;
                isSpawning = true;
                StartWave();
            }
        }

        if(isSpawning)
        {
            spawnRateTimer += Time.deltaTime;
            if(spawnRateTimer > spawnRateTime)
            {
                spawnRateTimer = 0;
                BaseEnemy enemyToSpawn = waveDatas[currentWaveIndex].GetRandomEnemy();
                BaseEnemy newEnemy = Instantiate(enemyToSpawn, levelManager.pathPoints[0].position, Quaternion.identity);
                spawnedEnemies.Add(newEnemy);
                enemiesWaveSpawned++;
                if (enemiesWaveSpawned >= waveDatas[currentWaveIndex].enemiesAmount)
                {
                    isSpawning = false;
                }
            }
        }
    }

    void StartWave()
    {
        spawnRateTime = waveDatas[currentWaveIndex].GetSpawnRateTime();
        spawnRateTimer = 0;
        enemiesWaveSpawned = 0;
    }

    public void OnEnemyDie(BaseEnemy deathEnemy)
    {
        if (spawnedEnemies.Contains(deathEnemy))
        {
            spawnedEnemies.Remove(deathEnemy);
        }
        //Debug.Log("NEMICI RIMASTI:" + spawnedEnemies.Count);
        bool allWaveSpawed = enemiesWaveSpawned >= waveDatas[currentWaveIndex].enemiesAmount;
        if (allWaveSpawed && spawnedEnemies.Count <= 0)
        {
            waveWaitTimer = 0;
            currentWaveIndex++;
            if (currentWaveIndex < waveDatas.Count)
            {
                isWaitingNextWave = true;
            }
           
            
        }
    }

}
