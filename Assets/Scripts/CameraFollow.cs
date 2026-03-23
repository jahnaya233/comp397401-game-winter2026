/*
 *File name: CameraFollow.cs
 *Author: Jahnaya Brooks
 *Student Number: 301359779
 *Data Last Modified: 2026/03/23
 *Description:
 *Makes the main camera follow the player as they move around
 *Revision History:
 *1.0 Initial setup 
 */
using UnityEngine;
//Control the main camera following player
public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;


     void Start()
    {
        if (target == null)
        {
            GameObject player = GameObject.FindWithTag("Player");
            if (player != null )
                target = player.transform;
        }
        
    }
    void LateUpdate()
    {
        //Follow target with offset
        transform.position = target.position + offset;
        transform.LookAt(target);
    }
}
