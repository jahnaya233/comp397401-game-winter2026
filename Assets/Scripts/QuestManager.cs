
/*
 *File name: QuestManager.cs
 *Author: Jahnaya Brooks
 *Student Number: 301359779
 *Data Last Modified: 2026/04/26
 *Description:
 *Manages in game quest
 *Revision History:
 *1.0 Initial setup
 */
using UnityEngine;
using TMPro;

public class QuestManager : MonoBehaviour
{
    public Quest currentQuest;
    public TextMeshProUGUI questText;

  

   void OnEnable()
    {
        InventoryManager.OnCoinsChanged += UpdateQuest;

    }

     void OnDisable()
    {
        InventoryManager.OnCoinsChanged -= UpdateQuest;

    }

     void Start()
    {
        questText.text = "Quest: Collect all 10 coins";
    }
    void UpdateQuest(int coins)
    {
        if (!currentQuest.completed && coins >= currentQuest.targetCoins)
        {
            currentQuest.completed = true;
            questText.text = "Quest Complete!";

            Debug.Log("Quest Complete: Collect 10 coins");
        }
    }
}
