using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseManager : MonoBehaviour
{

    public AudioSource gameOverMusic;

    public GameObject pausePanel;
    public GameObject gameOverPanel;
    public bool isGameOver;

    private bool isPaused = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
                Resume();
            else
                Pause();
        }
    }
    public void Pause()
    {
        pausePanel.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;


    }

    public void Resume()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;



    }

    public void LoadOptions()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("OptionsScene");
    }


    public void GameOver()
    {

        isGameOver = true;
        gameOverPanel.SetActive(true);
        Time.timeScale = 0f;
        gameOverMusic.Play();
      
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


public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }

    public void GoToMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MenuScene");
    }


}
