/*
 *File name: AchievementManager.cs
 *Author: Jahnaya Brooks
 *Student Number: 301359779
 *Data Last Modified: 2026/04/06
 *Description:
 *Manages achievements
 *Revision History:
 *1.0 Timer achievement
 *1.1 1 coins achievement
 */
using UnityEngine;
using TMPro;
public class AchievementManager : MonoBehaviour
{
   private bool survivalUnlocked = false;
    public TextMeshProUGUI achievementText;
    public void CheckSurvival(float timeAlive)

    {
        if (!survivalUnlocked && timeAlive >= 30f)
        {
            survivalUnlocked = true;
            Unlock("Survivor (30 seconds)");
        }
    }

    System.Collections.IEnumerator ShowAchievement(string name)
    {
        achievementText.gameObject.SetActive(true);
        achievementText.text = "Achievement Unlocked:\n" + name;

        yield return new WaitForSeconds(3f);

        achievementText.gameObject.SetActive(false);
    }
    void Unlock(string achievementName)
    {
        Debug.Log("Achievement Unlocked: " + achievementName);

        StopAllCoroutines();
        StartCoroutine(ShowAchievement(achievementName));
    }

     void OnEnable()
    {
        InventoryManager.OnCoinsChanged += CheckCoins;
        
    }

     void OnDisable()
        
    {
        InventoryManager.OnCoinsChanged -= CheckCoins;  
    }

    void CheckCoins(int coins)
    {
        if (coins >=50)
        {
            Unlock("Coin Collector");
        }
    }
}
