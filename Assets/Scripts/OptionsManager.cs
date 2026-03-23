using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class OptionsManager : MonoBehaviour
{
    public AudioSource music;
    public Slider volumeSlider;

     void Start()
    {
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

    public void Back()
    {
        SceneManager.LoadScene("GameScene");
    }
}
