/*
 *File name: InventoryManager.cs
 *Author: Jahnaya Brooks
 *Student Number: 301359779
 *Data Last Modified: 2026/04/06
 *Description:
 *Inventory system stores player resources like coins
 *Revision History:
 *1.0 Initial setup
 */
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public int coins = 0;

    public static System.Action<int> OnCoinsChanged;

    public void AddCoins(int amount)
    {
        coins += 1;

        //Update UI
        GameManager gm = FindAnyObjectByType<GameManager>();

        if (gm != null)
        {
            gm.score += amount;
            gm.scoreText.text = "Score: " + gm.score;
        }
        //Notify
        OnCoinsChanged?.Invoke(coins);
    }
}