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

//Manages saving and loading of the game data by saving the position of the player, the health and the score
public class SaveManager : MonoBehaviour
{
    public Transform player; 
    public PlayerMovement playerMovement;
    public GameManager gameManager;

   
    string savePath;

    void Start()
    {
        savePath = Application.persistentDataPath + "/savegame.json";
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
        //create a new save data object

            SaveData data = new SaveData();

        //store the player's position
            data.playerX = player.position.x;
            data.playerY = player.position.y;
            data.playerZ = player.position.z;

            data.health = playerMovement.health;
            data.score = gameManager.score;
        //Convert to JSON
            string json = JsonUtility.ToJson(data, true);
        //Write JSON to file
            File.WriteAllText(savePath, json);

            Debug.Log("Game Saved to: " + savePath);
        }
    //Loads the saved game state from the file, then restoring player data
        public void LoadGame()
        {
            if (!File.Exists(savePath))
            {
                Debug.Log("Save file not found");
                return;
            }

            string json = File.ReadAllText(savePath);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            player.position = new Vector3(data.playerX, data.playerY, data.playerZ);

            playerMovement.health = data.health;
            gameManager.score = data.score;

            Debug.Log("Game Loaded");
        }
}
