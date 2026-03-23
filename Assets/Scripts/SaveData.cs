/*
 *File name: SaveData.cs
 *Author: Jahnaya Brooks
 *Student Number: 301359779
 *Data Last Modified: 2026/03/23
 *Description:
 *Stores the game state data for the saving and loading
 *Revision History:
 *1.0 Initial version 
 *1.1 Added load functionality
 */
using UnityEngine;

//Serializable class for saving game
[System.Serializable]
public class SaveData : MonoBehaviour
{
    //data saved
    public float playerX;
    public float playerY;
    public float playerZ;

    public int health;
    public int score;
}
