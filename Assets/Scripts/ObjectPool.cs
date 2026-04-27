/*
 *File name: ObjectPool.cs
 *Author: Jahnaya Brooks
 *Student Number: 301359779
 *Data Last Modified: 2026/04/26
 *Description:
 *Creates multiple game enemy objects
 *Revision History:
 *1.1 Setup
 */
using UnityEngine;
using System.Collections.Generic;
public class ObjectPool : MonoBehaviour
{
    public GameObject prefab;
    public int poolSize = 10;

    private List<GameObject> pool;

     void Awake()
    {
        pool = new List<GameObject>();
        
        for(int i = 0; i < poolSize; i++)
        {
            GameObject obj = Instantiate(prefab);
            obj.SetActive(false);
            pool.Add(obj);
        }
    }

    public GameObject GetObject(Vector3 position)
    {
        foreach(GameObject obj in pool)
        {
            if (!obj.activeInHierarchy)
            {
                obj.transform.position = position;
                obj.SetActive(true);
                return obj;
            }
        }
        GameObject newObj = Instantiate(prefab, position, Quaternion.identity);
        pool.Add(newObj);
        return newObj;
    }

    public void ReturnObject(GameObject obj)
    {
        obj.SetActive(false );
    }    
}
