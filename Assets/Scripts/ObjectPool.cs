/*
 *File name: ObjectPool.cs
 *Author: Jahnaya Brooks
 *Student Number: 301359779
 *Data Last Modified: 2026/04/06
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

    public GameObject GetObject()
    {
        foreach(GameObject obj in pool)
        {
            if (!obj.activeInHierarchy)
            {
                obj.SetActive(true);
                return obj;
            }
        }
        GameObject newObj = Instantiate(prefab);
        newObj.SetActive(true);
        pool.Add(newObj);

        return newObj;
    }
}
