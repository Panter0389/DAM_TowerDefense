using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TowerButton : MonoBehaviour
{
    public Button towerButton;
    public TowerBase towerBase;
    public TextMeshProUGUI costText;
    public Image buttonInternalIcon;

    public void Awake()
    {
        costText.text = towerBase.cost.ToString();
    }

    public void SetInteractable(bool interactable)
    {
        towerButton.interactable = interactable;
        if(interactable)
        {
            buttonInternalIcon.color = Color.white;
        }
        else
        {
            buttonInternalIcon.color = new Color(1, 1, 1, 0.4f);
        }
    }

}
