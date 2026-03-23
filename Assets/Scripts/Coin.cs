using UnityEngine;

public class Coin : MonoBehaviour
{
    public AudioClip collectSound;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            AudioSource.PlayClipAtPoint(collectSound, transform.position);
            GameManager.instance.CollectCoin();
            
            Destroy(gameObject);
        }
    }
}