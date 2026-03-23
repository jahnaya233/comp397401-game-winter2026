using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public AudioSource menuMusic;

    public void PlayGame()
    {
        menuMusic.Stop();
        SceneManager.LoadScene("GameScene");
    }

    public void OpenOptions()
    {
        SceneManager.LoadScene("OptionsScene");
    }

    public void QuitGame()
    {
        Debug.Log("Quiting...");

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();

#endif
    }
}
