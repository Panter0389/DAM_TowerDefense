using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI playerHPText;
    public TextMeshProUGUI moneyText;

    public void UpdatePlayerHP(int playerHP)
    {
        playerHPText.text = playerHP.ToString();
    }

    public void UpdatePlayerMoney(int money)
    {
        moneyText.text = money.ToString();
    }

}
