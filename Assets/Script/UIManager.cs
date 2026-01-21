
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI playerHPText;
    public TextMeshProUGUI moneyText;

    public List<TowerButton> towerButtons = new List<TowerButton>();

    public void UpdatePlayerHP(int playerHP)
    {
        playerHPText.text = playerHP.ToString();
    }

    public void UpdatePlayerMoney(int money)
    {
        moneyText.text = money.ToString();

        foreach (TowerButton tb in towerButtons)
        {
            if (money >= tb.towerBase.cost)
            {
                tb.SetInteractable(true);
            }
            else
            {
                tb.SetInteractable(false);
            }
        }

        

    }

}
