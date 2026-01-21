using System.Collections.Generic;
using UnityEngine;

public class TowerBase : MonoBehaviour
{
    [Header("Settings")]
    public float range = 1.5f;
    public int damage = 1;
    public float shootRate = 1;
    public int cost = 5;

    float shootTimer = 1;

    [Header("Components")]
    public SpriteRenderer towerSpriteRenderer;
    public SpriteRenderer rangeSpriteRenderer;
    public TowerTrigger trigger;

    public void Awake()
    {
        rangeSpriteRenderer.transform.localScale = new Vector3(range * 2, range * 2, 1);
    }

    public void Update()
    {
        if(shootTimer < shootRate)
            shootTimer += Time.deltaTime;

        if (trigger.IsEnemyInView() && shootTimer >= shootRate)
        {
            Shoot();
            shootTimer = 0;
        }

    }

    public virtual void Shoot()
    {
       // IMPLEMENTATO DAI FIGLI
    }


}
