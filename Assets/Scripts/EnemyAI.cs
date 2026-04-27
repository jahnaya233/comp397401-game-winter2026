/*
 *File name: EnemyAI.cs
 *Author: Jahnaya Brooks
 *Student Number: 301359779
 *Data Last Modified: 2026/04/26
 *Description:
 *Controls enemy movement and is involved in player damage
 *Revision History:
 *1.0 AI movement 
 *1.1 Added taking damage code
 *1.2 Full functioning enemy ai
 */
using Unity.VisualScripting;
using UnityEngine;

//Handles the enemy chasing
public class EnemyAI : MonoBehaviour
{
    public Transform player;
    public float speed = 3f;
    public float detectionRange = 8f;
    public float stopDistance = 1.5f;

    public float patrolRadius = 5f;

    private Vector3 startPosition;
    private Vector3 patrolTarget;
    private bool chasing = false;

    void Start()
    {
        startPosition = transform.position;
        SetNewPatrolPoint();
    }

    void Update()
    {
        if (player == null) return;

        float distance = Vector3.Distance(transform.position, player.position);
        //Moves towards player
        if (distance < detectionRange)
        {
            chasing = true;
        }
        else if (distance > detectionRange + 2f)

        {
            chasing = false;
        }
        if (chasing)
        {
            MoveTowards(player.position);
        }
        else
        {
            Patrol();
        }
    }

    void MoveTowards(Vector3 target)
    {
        Vector3 direction = (target - transform.position).normalized;   

        transform.rotation = Quaternion.Slerp(
            transform.rotation,
            Quaternion.LookRotation(direction),
            5f * Time.deltaTime 
            );

        if (Vector3.Distance(transform.position, target) > stopDistance)
        {
            transform.position += transform.forward * speed * Time.deltaTime;
        }
    }

    void Patrol()
    {
        float dist = Vector3.Distance(transform.position, patrolTarget);

        if (dist < 1f)
        {
            SetNewPatrolPoint();
        }
        MoveTowards(patrolTarget);
    }

    void SetNewPatrolPoint()
    {
        patrolTarget = startPosition + new Vector3(
            Random.Range(-patrolRadius, patrolRadius),
            0,
            Random.Range(-patrolRadius, patrolRadius)
            );
    
        
    }

    void OnTriggerEnter(Collider other)
    {
        //Damage player on contact
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerMovement>().TakeDamage();
        }

    }

        void OnColliaionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                PlayerMovement playerMovement = collision.gameObject.GetComponent<PlayerMovement>();


                if (playerMovement != null)
                {
                    playerMovement.TakeDamage();
                }
            }
        }
    }
