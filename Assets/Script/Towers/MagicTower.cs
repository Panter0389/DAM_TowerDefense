using System.Collections.Generic;
using UnityEngine;

public class MagicTower :TowerBase
{
    public List<GameObject> slots = new List<GameObject>();
    public GameObject flamePrefab;

    int nextSlotIndex = 0;

    public void Awake()
    {
        SpawnFlameInSlot();
        SpawnFlameInSlot();
        SpawnFlameInSlot();
    }

    public void SpawnFlameInSlot()
    {
        if (nextSlotIndex >= slots.Count)
        {
            return;
        }

        GameObject newFlame = Instantiate(flamePrefab, slots[nextSlotIndex].transform);
        newFlame.transform.localPosition = Vector3.zero;
        nextSlotIndex++;
    }
}
