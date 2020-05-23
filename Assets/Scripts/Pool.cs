using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PoolItem
{
    public GameObject prefab;
    public int amount;
    public bool expandable;
}
public class Pool : MonoBehaviour
{
    public static Pool singleton;
    public List<PoolItem> items;
    public List<GameObject> pooledItem;

    private void Awake()
    {
        singleton = this;
    }
    private void Start()
    {
        pooledItem = new List<GameObject>();
        foreach (PoolItem item in items)
        {
            for (int i = 0; i < item.amount; i++)
            {
                GameObject obj = Instantiate(item.prefab);
                obj.SetActive(false);
                pooledItem.Add(obj);
            }
        }
    }

    public GameObject Get(string tag)
    {
        for (int i = 0; i < pooledItem.Count; i++)
        {
            if (!pooledItem[i].activeInHierarchy && pooledItem[i].tag == tag)
            {
                return pooledItem[i];
            }
        }

        foreach (PoolItem item in items)
        {
            if(item.prefab.tag == tag && item.expandable)
            {
                GameObject obj = Instantiate(item.prefab);
                obj.SetActive(false);
                pooledItem.Add(obj);
                return obj;
            }
        }

        return null;
    }

}
