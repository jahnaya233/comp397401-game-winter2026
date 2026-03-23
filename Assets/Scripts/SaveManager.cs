using UnityEngine;
using System.IO;
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

        public void SaveGame()
        {
            SaveData data = new SaveData();

            data.playerX = player.position.x;
            data.playerY = player.position.y;
            data.playerZ = player.position.z;

            data.health = playerMovement.health;
            data.score = gameManager.score;

            string json = JsonUtility.ToJson(data, true);

            File.WriteAllText(savePath, json);

            Debug.Log("Game Saved to: " + savePath);
        }

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
