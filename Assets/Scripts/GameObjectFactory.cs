/*
 *File name: GameObjectFactory.cs
 *Author: Jahnaya Brooks
 *Student Number: 301359779
 *Data Last Modified: 2026/04/01
 *Description:
 *Creates game objects
 *Revision History:
 *1.0 Initial setup 
 */
using UnityEngine;

public abstract class GameObjectFactory
{
   public abstract GameObject CreateObject(Vector3 position);
}
