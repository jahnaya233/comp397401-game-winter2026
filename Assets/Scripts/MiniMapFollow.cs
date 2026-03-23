/*
 *File name: MiniMapFollow.cs
 *Author: Jahnaya Brooks
 *Student Number: 301359779
 *Data Last Modified: 2026/03/23
 *Description:
 *Controls the minimap camera to follow the player from above
 *Revision History:
 *1.0 Initial setup 
 *1.1 Camera angle debugging
 */
using UnityEngine;
//Keeps the minimap camera above player
public class MiniMapFollow : MonoBehaviour
{
    public Transform player;
    public float height = 30f;

    void LateUpdate()
    {
        if (player == null) return;
        //Follows the player
        Vector3 newPos = player.position;
        newPos.y = height;

        transform.position = newPos;
        //Maintains over head view
        transform.rotation = Quaternion.Euler(90f, 0f, 0f);
    }
}