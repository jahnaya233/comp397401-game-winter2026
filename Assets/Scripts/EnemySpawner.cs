/*
 *File name: GameObjectFactory.cs
 *Author: Jahnaya Brooks
 *Student Number: 301359779
 *Data Last Modified: 2026/04/01
 *Description:
 *Spawns the enemies using factory pattern
 *Revision History:
 *1.0 Initial setup 
 */
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public int numOfEnemies = 7;

    public EnemyFactory enemyFactory;
    public ObjectPool pool;
    void Start()
    {
        enemyFactory = new EnemyFactory();

        enemyFactory.enemyPrefab = enemyPrefab;
        enemyFactory.pool = pool;

        SpawnEnemies();

    }
    void SpawnEnemies()
    {
        for (int i = 0; i < numOfEnemies; i++)
        {
            Vector3 spawnPos = new Vector3(
                Random.Range(-368f - 700f, -368f + 700f),
                1f,
                Random.Range(-350f, 350f)
                );


            enemyFactory.CreateObject(spawnPos);
        }

    }
}