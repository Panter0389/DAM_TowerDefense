
using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class WaveData
{
    public List<BaseEnemy> enemies = new List<BaseEnemy>();
    public int enemiesAmount;
    public float totalSpawnTime = 6;

    public BaseEnemy GetRandomEnemy()
    {
        int randomEnemyIndex = UnityEngine.Random.Range(0, enemies.Count - 1);
        return enemies[randomEnemyIndex];
    }

    public float GetSpawnRateTime()
    {
        return totalSpawnTime / enemiesAmount;
    }
}
