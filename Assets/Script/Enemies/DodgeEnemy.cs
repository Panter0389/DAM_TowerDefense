using UnityEngine;

public class DodgeEnemy : BaseEnemy
{
    [Header("Dodge Settings")]
    public float dodgeChanceNormalized = 0.2f;

    [Header("Doge Components")]
    public GameObject missFeedbackPrefab;


    GameObject missFeedback;

    public override void Hit(int damage)
    {
        float rand = Random.Range(0.0f, 1.0f);
        if (rand <= dodgeChanceNormalized)
        {
            missFeedback = Instantiate(missFeedbackPrefab, transform.position + new Vector3(0f,0.3f,0f), Quaternion.identity, transform);
            Invoke("DestroyFeedback", 0.5f);
        }
        else
        {
            base.Hit(damage);
        }
    }

    void DestroyFeedback()
    {
        if(missFeedback !=null)
        {
            Destroy(missFeedback);
        }
    }

    
}
