/*
 *File name: GameManager.cs
 *Author: Jahnaya Brooks
 *Student Number: 301359779
 *Data Last Modified: 2026/03/23
 *Description:
 *Manages the score system and win condition
 *Revision History:
 *1.0 Initial version 
 *1.1 Added load functionality
 */

using UnityEngine;
using TMPro;

//Handles scoring and win
public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int totalCoins;
    private int collectedCoins;

    public GameObject winPanel;

    public AudioSource audioSource;
    public AudioClip winSound;

    public TextMeshProUGUI scoreText;
    //score starts at 0
    public int score = 0;
    void Awake()
    {
        instance = this;
        scoreText.text = "Score: 0";
    }
    //controls score, each coin is 10 points
    public void CollectCoin()

    {
        collectedCoins++;

        score += 10;
        scoreText.text = "Score: " + score;

        if (collectedCoins >= totalCoins)
        {
            WinGame();
        }
    }
    void WinGame()
    {
        winPanel.SetActive(true);
        Time.timeScale = 0f;
//music is called
        audioSource.PlayOneShot(winSound);
    }
}