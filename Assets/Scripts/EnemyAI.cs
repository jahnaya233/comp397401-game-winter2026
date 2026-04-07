/*
 *File name: EnemyAI.cs
 *Author: Jahnaya Brooks
 *Student Number: 301359779
 *Data Last Modified: 2026/04/06
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

    void Update()
    {
        if (player == null) return;

        float distance = Vector3.Distance(transform.position, player.position);
        //Moves towards player
        if (distance < detectionRange)
        {
            Vector3 direction = (player.position - transform.position).normalized;

            Quaternion lookRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(
                transform.rotation,
                lookRotation,
                5f * Time.deltaTime
                );

            if (distance > stopDistance)
            {
                transform.position += transform.forward * speed * Time.deltaTime;
            }
        }
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
