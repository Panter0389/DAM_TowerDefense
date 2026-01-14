using UnityEngine;

public class TowerPreview : MonoBehaviour
{
    public SpriteRenderer rangeRenderer;
    public SpriteRenderer towerRenderer;

    Color startingRangeColor;
    Color startingTowerColor;

    private void Awake()
    {
        startingRangeColor = rangeRenderer.color;
        startingTowerColor = towerRenderer.color;
    }
    public void PulseRed()
    {
        rangeRenderer.color = Color.red;
        towerRenderer.color = Color.red;

        Invoke("ResetColor", 0.2f);
    }
    void ResetColor()
    {
        rangeRenderer.color = startingRangeColor;
        towerRenderer.color = startingTowerColor;
    }

}
