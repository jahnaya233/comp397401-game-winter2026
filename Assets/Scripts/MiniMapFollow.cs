using UnityEngine;

public class MiniMapFollow : MonoBehaviour
{
    public Transform player;
    public float height = 30f;

    void LateUpdate()
    {
        if (player == null) return;

        Vector3 newPos = player.position;
        newPos.y = height;

        transform.position = newPos;

        transform.rotation = Quaternion.Euler(90f, 0f, 0f);
    }
}