using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class OptionsManager : MonoBehaviour
{
    public Slider volumeSlider;

     void Start()
    {
        volumeSlider.value = AudioListener.volume; 
    }

    public void ChangeVolume(float value)
    {
        AudioListener.volume = value;
    }

    public void Back()
    {
        SceneManager.LoadScene("GameScene");
    }
}
