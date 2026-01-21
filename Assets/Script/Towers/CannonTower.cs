using System.Collections.Generic;
using UnityEngine;

public class CannonTower : TowerBase
{
    public override void Shoot()
    {
        List<BaseEnemy> enemiesInView = trigger.GetEnemiesInView();

        foreach (BaseEnemy enemy in enemiesInView)
        {
            enemy.Hit(damage);
        }
    }
}
