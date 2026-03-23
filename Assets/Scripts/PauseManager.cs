/*
 *File name: PauseManager.cs
 *Author: Jahnaya Brooks
 *Student Number: 301359779
 *Data Last Modified: 2026/03/23
 *Description:
 *Controls the pause functions
 *Revision History:
 *1.0 Pause menu
 *1.1 Debugging music code
 */

using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

//Manages the pause menu and gave over functions
public class PauseManager : MonoBehaviour
{

    public AudioSource gameOverMusic;

    public GameObject pausePanel;
    public GameObject gameOverPanel;
    public bool isGameOver;

    private bool isPaused = false;

    //escape calls paused screen
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
    //pauses game
    public void Pause()
    {
        pausePanel.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;


    }
//resumes the game
    public void Resume()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;



    }
    //calls options scene
    public void LoadOptions()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("OptionsScene");
    }

    //Triggers game over and the music
    public void GameOver()
    {


       isGameOver = true;
        gameOverPanel.SetActive(true);
        Time.timeScale = 0f;
        gameOverMusic.Play();
      
    }
    //closes game
    public void QuitGame()
    {
        Debug.Log("Quiting...");

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();

#endif
    }

//restarts game
public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }
    //returns to menu
    public void GoToMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MenuScene");
    }


}
