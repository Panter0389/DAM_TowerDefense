using System.Collections.Generic;
using UnityEngine;

public class ArchersTower : TowerBase
{
    public override void Shoot()
    {
        List<BaseEnemy> enemiesInView = trigger.GetEnemiesInView();

        int biggerPathIndex = -1;
        BaseEnemy target = null;
        foreach (BaseEnemy enemy in enemiesInView)
        {
            if (enemy.TargetPathIndex > biggerPathIndex)
            {
                biggerPathIndex = enemy.TargetPathIndex;
                target = enemy;
            }
        }
        if (target != null)
        {
            target.Hit(damage);
        }
    }
}
