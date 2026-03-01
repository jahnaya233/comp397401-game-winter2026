using UnityEngine;

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
        transform.position = target.position + offset;
        transform.LookAt(target);
    }
}
