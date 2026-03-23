using UnityEngine;
using TMPro;
public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int totalCoins;
    private int collectedCoins;

    public GameObject winPanel;

    public AudioSource audioSource;
    public AudioClip winSound;

    public TextMeshProUGUI scoreText;

    public int score = 0;
    void Awake()
    {
        instance = this;
        scoreText.text = "Score: 0";
    }

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

        audioSource.PlayOneShot(winSound);
    }
}