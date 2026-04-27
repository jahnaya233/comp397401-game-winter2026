/*
 *File name: Coin.cs
 *Author: Jahnaya Brooks
 *Student Number: 301359779
 *Data Last Modified: 2026/03/23
 *Description:
 *Handles the collection of coins and scoring
 *Revision History:
 *1.0 Initial version 
 *1.1 Added sound
 */
using UnityEngine;
//Coin pickup beahavior 
public class Coin : MonoBehaviour
{

    private bool collected = false;
    public AudioClip collectSound;

     void OnEnable()
    {
        collected = false;  
    }

     void OnTriggerEnter(Collider other)
    {
        if (collected) return;

        if (other.CompareTag("Player"))

        {
            collected = true;
            //Sound plays when collected
            AudioSource.PlayClipAtPoint(collectSound, transform.position);
            GameManager.instance.CollectCoin();
            //Coin disappears when collection
            FindAnyObjectByType<InventoryManager>().AddCoins(10);
            FindAnyObjectByType<ObjectPool>().ReturnObject(gameObject);
            Destroy(gameObject);
        }
    }
}