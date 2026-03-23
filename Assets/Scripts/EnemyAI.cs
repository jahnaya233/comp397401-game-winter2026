/*
 *File name: EnemyAI.cs
 *Author: Jahnaya Brooks
 *Student Number: 301359779
 *Data Last Modified: 2026/03/23
 *Description:
 *Controls enemy movement and is involved in player damage
 *Revision History:
 *1.0 AI movement 
 *1.1 Added taking damage code
 */
using UnityEngine;

//Handles the enemy chasing
public class EnemyAI : MonoBehaviour
{
    public Transform player;
    public float speed = 3f;
    public float detectionRange = 8f;

    void Update()
    {
       float distance = Vector3.Distance(transform.position, player.position);
        //Moves towards player
        if (distance < detectionRange )
        {
            transform.position = Vector3.MoveTowards(
                transform.position,
                player.position,
                speed * Time.deltaTime
                );
        }
    }

     void OnTriggerEnter(Collider other)
    {
        //Damage player on contact
      if(other.CompareTag("Player"))
        {
           other.GetComponent<PlayerMovement>().TakeDamage();
        }
    }
}
