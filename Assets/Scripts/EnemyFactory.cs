/*
 *File name: GameObjectFactory.cs
 *Author: Jahnaya Brooks
 *Student Number: 301359779
 *Data Last Modified: 2026/04/01
 *Description:
 *Creates enemy objects
 *Revision History:
 *1.0 Initial setup 
 */
using UnityEngine;

public class EnemyFactory 
{
    public GameObject enemyPrefab;
    public ObjectPool pool;

    public virtual GameObject CreateObject(Vector3 position)
    {
        GameObject enemy = pool.GetObject();

        if(enemy != null)
        {
            enemy.transform.position = position;
            enemy.transform.rotation = Quaternion.identity;
        }
        return enemy;
    }
}
