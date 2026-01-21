using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI playerHPText;
    public TextMeshProUGUI moneyText;

    public TowerButton tower1button;

    public void UpdatePlayerHP(int playerHP)
    {
        playerHPText.text = playerHP.ToString();
    }

    public void UpdatePlayerMoney(int money)
    {
        moneyText.text = money.ToString();

        if(money >= tower1button.towerBase.cost)
        {
            tower1button.SetInteractable(true);
        }
        else
        {
            tower1button.SetInteractable(false);
        }

    }

}
