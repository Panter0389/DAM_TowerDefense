using UnityEngine;

public class BaseEnemy : MonoBehaviour
{
    public Rigidbody2D rigidbody2D;
    public Animator animator;
    public SpriteRenderer spriteRenderer;
    public float speed = 20f;
    public bool isSideSpriteFacingRight;

    LevelManager levelManager;
    int targetPathIndex = 0;

    private void Awake()
    {
        levelManager = FindFirstObjectByType<LevelManager>();
    }

    public void Update()
    {
        Vector3 targetPosition = levelManager.pathPoints[targetPathIndex].position;
        if (Vector3.Distance(transform.position, targetPosition) < 0.05f)
        {
            if (targetPathIndex + 1 < levelManager.pathPoints.Count)
            {
                targetPathIndex++;
            }
        }
    }

    public void FixedUpdate()
    {
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
}
