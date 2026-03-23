/*
 *File name: OptionsMusic.cs
 *Author: Jahnaya Brooks
 *Student Number: 301359779
 *Data Last Modified: 2026/03/23
 *Description:
 *Controls options music
 *Revision History:
 *1.0 Initial version 
 *1.1 Fixing music
 */
using UnityEngine;

//Handles the the options screen music
public class OptionsMusic : MonoBehaviour
{
    private AudioSource audioSource;

     void Start()
    {//starts music when on the option scene
        audioSource = GetComponent<AudioSource>();
        audioSource.Play();
    }
}
