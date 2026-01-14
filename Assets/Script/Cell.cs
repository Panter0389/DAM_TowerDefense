using UnityEngine;

public class Cell : MonoBehaviour
{
    public SpriteRenderer cellRenderer;
    public Color hoverColor;

    TowerBase tower;
    public bool HasTower => tower != null;

    public void HoverStart()
    {
        cellRenderer.color = hoverColor;
    }

    public void HoverEnd()
    {
        cellRenderer.color = new Color(0, 0, 0, 0);
    }

    public void InsertTowerInCell(TowerBase _tower)
    {
        tower = _tower;
    }
}
