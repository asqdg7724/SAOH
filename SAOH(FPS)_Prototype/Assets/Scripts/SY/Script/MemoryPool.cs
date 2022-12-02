using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemoryPool
{
    private class PoolItem
    {
        public bool isActive;
        public GameObject gameObject;
    }

    private int increaseCount = 5;
    private int maxCount;
    private int activeCount;

    private List<PoolItem> poolItemlist;
    private GameObject poolObject;

    public int MaxCount => maxCount;
    public int ActiveCount => activeCount;

    public MemoryPool(GameObject poolObject)
    { 
        maxCount = 0;
        activeCount = 0;
        this.poolObject = poolObject;

        poolItemlist = new List<PoolItem>();

        InstantiateObjects();
        
    }

    public void InstantiateObjects()
    {
        maxCount += increaseCount;

        for (int i = 0; i < increaseCount; i++)
        { 
            PoolItem poolItem = new PoolItem();

            poolItem.isActive = false;
            poolItem.gameObject = GameObject.Instantiate(poolObject);
            poolItem.gameObject.SetActive(false);

            poolItemlist.Add(poolItem);

        }
    }

    public GameObject ActivatePoolItem()
    {
        if (poolItemlist == null)
            return null;
        if (maxCount == activeCount)
        {
            InstantiateObjects();
        }

        int count = poolItemlist.Count;
        for (int i = 0; i < count; i++)
        {
            PoolItem poolItem = poolItemlist[i];

            if (poolItem.isActive == false)
            {
                activeCount++;

                poolItem.isActive = true;
                poolItem.gameObject.SetActive(true);

                return poolItem.gameObject;
            }
        }
        return null;
    }


    public void DeactivatePoolItem(GameObject removeObject)
    {
        if (poolItemlist == null || removeObject == null)
            return;

        int count = poolItemlist.Count;
        for (int i = 0; i < count; ++i)
        {
            PoolItem poolItem = poolItemlist[i];

            if (poolItem.gameObject == removeObject)
            {
                activeCount--;

                poolItem.isActive = false;
                poolItem.gameObject.SetActive(false);

                return;
            }
        }
    }
}
