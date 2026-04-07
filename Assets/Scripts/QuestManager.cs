
/*
 *File name: QuestManager.cs
 *Author: Jahnaya Brooks
 *Student Number: 301359779
 *Data Last Modified: 2026/04/06
 *Description:
 *Manages in game quest
 *Revision History:
 *1.0 Initial setup
 */
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    bool questCompleted = false;
   void OnEnable()
    {
        InventoryManager.OnCoinsChanged += UpdateQuest;

    }

     void OnDisable()
    {
        InventoryManager.OnCoinsChanged -= UpdateQuest;

    }

    void UpdateQuest(int coins)
    {
        if (!questCompleted && coins >= 20)
        {
            questCompleted = true;
            Debug.Log("Quest Complete: Collect 10 coins");
        }
    }
}
