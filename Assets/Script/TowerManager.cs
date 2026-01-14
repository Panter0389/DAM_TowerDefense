using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class TowerManager : MonoBehaviour
{
    [Header("Settings")]
    public LayerMask raycastLayer;

    [Header("Components")]
    public TowerPreview towerPreview;
    public PlayerManager playerManager;

    [Header("Prefabs")]
    public TowerBase towerToBuild;

    Cell currentHoverCell;

    bool isBuildingTower;
    int buildTowerIndex = -1;

    private void Awake()
    {
        towerPreview.gameObject.SetActive(false);
    }

    public void Update()
    {
        Vector2 viewMousePos = Mouse.current.position.value;
        Vector2 worldMousePos = Camera.main.ScreenToWorldPoint(viewMousePos);

        RaycastHit2D hit = Physics2D.Raycast(worldMousePos, Vector2.zero, 500, raycastLayer);

        if(hit.collider != null)
        {
           Cell cell = hit.collider.transform.GetComponent<Cell>();
            if (cell != null && cell != currentHoverCell)
            {
                ResetHover();
                cell.HoverStart();
                currentHoverCell = cell;
            }
        }
        else
        {
            ResetHover();
            towerPreview.gameObject.SetActive(false);
        }

        if(isBuildingTower && currentHoverCell != null)
        {
            towerPreview.transform.position = currentHoverCell.transform.position;
            if (currentHoverCell.HasTower)
                towerPreview.gameObject.SetActive(false);
            else
                towerPreview.gameObject.SetActive(true);
        }

        if(Mouse.current.leftButton.wasPressedThisFrame && currentHoverCell != null)
        {
            if(isBuildingTower && !currentHoverCell.HasTower)
            {
                if(playerManager.SpendMoney(5))
                {
                    Vector3 pos = currentHoverCell.transform.position;
                    TowerBase newTower = Instantiate(towerToBuild, pos, Quaternion.identity, currentHoverCell.transform);
                    currentHoverCell.InsertTowerInCell(newTower);
                }
                else
                {
                    towerPreview.PulseRed();
                }
            }
        }
    }

    void ResetHover()
    {
        if (currentHoverCell != null)
        {
            currentHoverCell.HoverEnd();
            currentHoverCell = null;
        }
    }



    public void EventButton_BuildTower(int towerIndex)
    {
        if (isBuildingTower && buildTowerIndex == towerIndex)
        {
            isBuildingTower = false;
            towerPreview.gameObject.SetActive(false);
        }
        else
        {
            isBuildingTower = true;
            buildTowerIndex = towerIndex;
        }
    }
}
