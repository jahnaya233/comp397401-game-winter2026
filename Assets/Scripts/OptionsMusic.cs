using UnityEngine;

public class OptionsMusic : MonoBehaviour
{
    private AudioSource audioSource;

     void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.Play();
    }
}
