using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public UIManager uiManager;

    public int startingMoney = 10;
    public int maxHP = 10;
    int currentHP = 10;
    int money = 0;

    public void Awake()
    {
        currentHP = maxHP;
        uiManager.UpdatePlayerHP(currentHP);
        money = startingMoney;
        uiManager.UpdatePlayerMoney(money);
    }

    public void PlayerHit(int damage)
    {
        currentHP -= damage;
        if (currentHP <= 0)
        {
            //TODO: Handle game over here
        }
        uiManager.UpdatePlayerHP(currentHP);
    }

    public void GainMoney(int amount)
    {
        money += amount;
        uiManager.UpdatePlayerMoney(money);
    }
    public bool SpendMoney(int amount)
    {
        if (money < amount)
        {
            return false;
        }

        money -= amount;
        uiManager.UpdatePlayerMoney(money);
        return true;
    }

}
