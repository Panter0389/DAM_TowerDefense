using System.Collections.Generic;
using UnityEngine;

public class CannonTower : TowerBase
{
    public override void Shoot()
    {
        List<BaseEnemy> enemiesInView = trigger.GetEnemiesInView();

        for (int i = enemiesInView.Count -1; i>=0; i-- )
        {
            enemiesInView[i].Hit(damage);
        }
    }
}
