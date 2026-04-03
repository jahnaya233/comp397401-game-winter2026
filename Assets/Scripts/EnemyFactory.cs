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

public class EnemyFactory : GameObjectFactory
{
    public GameObject enemyPrefab;

    public override GameObject CreateObject(Vector3 position)
    {
        return GameObject.Instantiate(enemyPrefab, position, Quaternion.identity);   
            }
}
