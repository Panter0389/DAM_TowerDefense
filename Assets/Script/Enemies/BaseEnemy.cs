using UnityEngine;

public class BaseEnemy : MonoBehaviour
{
    [Header("Settings")]
    public float speed = 20f;
    public int playerHitDamage = 1;
    public bool isSideSpriteFacingRight;
    public int maxHP = 2;
    public int moneyReward = 2;

    [Header("Components")]
    public Rigidbody2D rigidbody2D;
    public Animator animator;
    public SpriteRenderer spriteRenderer;
    public Collider2D enemyCollider;

    int currentHp = 2;
    bool active = true;
    bool isDead = false;

    LevelManager levelManager;
    int targetPathIndex = 0;
    public int TargetPathIndex => targetPathIndex;

    public virtual void Awake()
    {
        levelManager = FindFirstObjectByType<LevelManager>();
        currentHp = maxHP;
    }

    public virtual void Update()
    {
        if (!active)
        {
            return;
        }

        Vector3 targetPosition = levelManager.pathPoints[targetPathIndex].position;
        if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
        {
            if (targetPathIndex + 1 < levelManager.pathPoints.Count)
            {
                targetPathIndex++;
            }
            else
            {
                TargetReached();
            }
        }
    }

    public void FixedUpdate()
    {
        if (!active)
        {
            return;
        }

        Vector3 targetPosition = levelManager.pathPoints[targetPathIndex].position;
        Vector3 currentPosition = transform.position;

        Vector3 direction = (targetPosition - currentPosition).normalized;
        rigidbody2D.linearVelocity = direction * speed;

        animator.SetFloat("XNormalizedSpeed",direction.x);
        animator.SetFloat("YNormalizedSpeed", direction.y);

        if (isSideSpriteFacingRight)
        {
            spriteRenderer.flipX = (direction.x < 0);
        }
        else
        {
            spriteRenderer.flipX = (direction.x > 0);
        }
    }

    public void TargetReached()
    {
        active = false;

        PlayerManager playerManager = FindFirstObjectByType<PlayerManager>();
        if (playerManager != null)
        {
            playerManager.PlayerHit(playerHitDamage);
        }

        DestroyMe();
    }

    public virtual void Hit(int damage)
    {
        currentHp -= damage;
        spriteRenderer.color = Color.red;
        Invoke("ResetColor", 0.1f);

        if (currentHp <= 0 && !isDead)
        {
            isDead = true;
            enemyCollider.enabled = false;
            PlayerManager playerManager = FindFirstObjectByType<PlayerManager>();
            if(playerManager != null)
            {
                playerManager.GainMoney(moneyReward);
            }
            DestroyMe();
        }
    }

    void ResetColor()
    {
        if (spriteRenderer != null)
        {
            spriteRenderer.color = Color.white;
        }
    }

    public void DestroyMe()
    {
        EnemySpawner enemySpawner = FindFirstObjectByType<EnemySpawner>();
        if(enemySpawner != null)
        {
            enemySpawner.OnEnemyDie(this);
        }
        active = false;
        rigidbody2D.linearVelocity = Vector2.zero;

        animator.SetBool("Dead", isDead);
        Invoke("Despawn", 1f);
        
    }

    void Despawn()
    {
        Destroy(gameObject);
    }
}
