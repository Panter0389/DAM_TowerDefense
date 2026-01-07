using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public UIManager uiManager;

    public int maxHP = 10;
    int currentHP = 10;

    public void Awake()
    {
        currentHP = maxHP;
        uiManager.UpdatePlayerHP(currentHP);
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

}
