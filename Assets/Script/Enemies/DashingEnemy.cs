using UnityEngine;

public class DashingEnemy : BaseEnemy
{
    [Header("Dashing Settings")]
    public float dashTime = 2;
    public float dashChargeTime = 2;
    public float dashSpeed = 10;

    float startingSpeed;
    float timer = 0;
    bool isDashing = false;

    public override void Awake()
    {
        base.Awake();
        startingSpeed = speed;
    }

    public override void Update()
    {
        base.Update();

        timer += Time.deltaTime;
        if(!isDashing)
        {
            if(timer >= dashChargeTime)
            {
                speed = dashSpeed;
                isDashing = true;
                timer = 0;
            }
        }
        if (isDashing)
        {
            if (timer >= dashTime)
            {
                speed = startingSpeed;
                isDashing = false;
                timer = 0;
            }
        }

    }


}
