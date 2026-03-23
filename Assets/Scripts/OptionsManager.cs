/*
 *File name: OptionsManager.cs
 *Author: Jahnaya Brooks
 *Student Number: 301359779
 *Data Last Modified: 2026/03/23
 *Description:
 *Handles the navigation in the options screen
 *Revision History:
 *1.0 Setup and sound 
 *1.1 Slider debugging
 */
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//Controls the options menu navigation
public class OptionsManager : MonoBehaviour
{
    public AudioSource music;
    public Slider volumeSlider;

     void Start()
    {//Manages volume slider
        float savedVolume = PlayerPrefs.GetFloat("Volume", 1f);
        music.volume = savedVolume;
        volumeSlider.value = savedVolume;

        volumeSlider.onValueChanged.AddListener(ChangeVolume); 
    }

    public void ChangeVolume(float value)
    {
       music.volume = value;
        PlayerPrefs.SetFloat("volume", value);
    }
    //returns to game
    public void Back()
    {
        SceneManager.LoadScene("GameScene");
    }
}
