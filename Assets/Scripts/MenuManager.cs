/*
 *File name: MenuManager.cs
 *Author: Jahnaya Brooks
 *Student Number: 301359779
 *Data Last Modified: 2026/03/23
 *Description:
 *Controls main menu navigation and music
 *Revision History:
 *1.0 Initial version 
 *1.1 Debugging with quit
 */
using UnityEngine;
using UnityEngine.SceneManagement;
//Handles the menu and menu music
public class MenuManager : MonoBehaviour
{
    public AudioSource menuMusic;
    //starts the game
    public void PlayGame()
    {
        menuMusic.Stop();
        SceneManager.LoadScene("GameScene");
    }
    //Calls option scene
    public void OpenOptions()
    {
        SceneManager.LoadScene("OptionsScene");
    }

    //Loading
    public void LoadGameFromMenu()
    {
        FindObjectOfType<SaveManager>().LoadGame();
        SceneManager.LoadScene("GameScene");
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
}
