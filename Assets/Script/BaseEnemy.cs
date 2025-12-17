using UnityEngine;

public class BaseEnemy : MonoBehaviour
{
    public Rigidbody2D rigidbody2D;
    public float speed = 20f;

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



    }
}
