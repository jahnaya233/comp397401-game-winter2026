/*
 *File name: SaveManager.cs
 *Author: Jahnaya Brooks
 *Student Number: 301359779
 *Data Last Modified: 2026/03/23
 *Description:
 *The script mangages the saving and loading the game state
 *Stores player position, health, and score
 *Revision History:
 *1.0 Initial version 
 *1.1 Added load functionality
 */
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;
//Manages saving and loading of the game data by saving the position of the player, the health and the score
public class SaveManager : MonoBehaviour
{

    private Transform player;
    private PlayerMovement playerMovement;
    private GameManager gameManager;
    string savePath;
    private Rigidbody rb;

    void Start()
    {
      
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.K))  //k to save
        {
            SaveGame();

        }

        if (Input.GetKeyUp(KeyCode.L))//Load
        {
            LoadGame();
        }
    }
    //Saves the current game state
    public void SaveGame()
    {
        GameObject playerObj = GameObject.FindWithTag("Player");

        if (playerObj == null)
        {
            Debug.Log("player not found");
            return;
        }
        player = playerObj.transform;
        playerMovement = player.GetComponent<PlayerMovement>();
        gameManager = FindAnyObjectByType<GameManager>();

        SaveData data = new SaveData();

        data.playerX = playerObj.transform.position.x;
        data.playerY = playerObj.transform.position.y;
        data.playerZ = playerObj.transform.position.z;

        data.health = playerMovement.health;
        data.score = gameManager.score;

        string json = JsonUtility.ToJson(data, true);
        File.WriteAllText(savePath, json);

        Debug.Log("Game saved");
    }
    //Loads the saved game state from the file, then restoring player data
    public void LoadGame()
    {
        Debug.Log("Loading game");
        if (!File.Exists(savePath))
        {
            Debug.Log("Save file not found");
            return;
        }

        Debug.Log("Loading game");

        GameObject playerObj = GameObject.FindWithTag("Player");

        if (playerObj == null)
        {
            Debug.LogError("player not found");
            return;
        }
        player = playerObj.transform;
        playerMovement = playerObj.GetComponent<PlayerMovement>();
        gameManager = FindAnyObjectByType<GameManager>();


        string json = File.ReadAllText(savePath);
        SaveData data = JsonUtility.FromJson<SaveData>(json);

        player.position = new Vector3(data.playerX, data.playerY, data.playerZ);

        playerMovement.health = data.health;
        playerMovement.livesText.text = "Lives: " + data.health;
        gameManager.score = data.score;

        Debug.Log("Game Loaded");
    }

    public void LoadGameFromMenu()
    {
        Debug.Log("Load button pressed");
        if (!File.Exists(savePath))
        {
            Debug.Log("No save file found");
            return;
        }

        SceneManager.LoadScene("GameScene");

        Invoke(nameof(LoadGame), 1f);
    } 
    void Awake()
    {
        savePath = Application.persistentDataPath + "/savegame.json";

        DontDestroyOnLoad(gameObject);
     }
}
