using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public Transform player;
    public float speed = 3f;
    public float detectionRange = 8f;

    void Update()
    {
       float distance = Vector3.Distance(transform.position, player.position);
        
        if (distance < detectionRange )
        {
            transform.position = Vector3.MoveTowards(
                transform.position,
                player.position,
                speed * Time.deltaTime
                );
        }
    }
}
