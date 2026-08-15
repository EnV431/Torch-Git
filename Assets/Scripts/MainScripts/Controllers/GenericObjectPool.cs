using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

public class GenericObjectPool : MonoBehaviour
{
    private List<GameObject> objectPool;
    [SerializeField] private Transform defualtParent;
    [SerializeField] private GameObject objectPrefab;
    [SerializeField] private int poolSize;

    private void Awake()
    {
        if (defualtParent == null)
        {
            defualtParent = gameObject.transform;
        }

        InitializeObjectPool();
    }
    private void InitializeObjectPool()
    { 
        objectPool = new List<GameObject>();

        for (int i = 0; i < poolSize; i++)
        {
            CreateNewPooledObject();
        }
    }

    public GameObject GetPooledObject()
    {
        foreach (GameObject spawnedObject in objectPool)
        {
            if (!spawnedObject.activeInHierarchy)
            {
                return spawnedObject;
            }
        }
        
        GameObject newObject = CreateNewPooledObject();       
        return newObject;
    }

    public void SetPooledObjectPrefab(GameObject prefab)
    {
        objectPrefab = prefab;    
    }


    private GameObject CreateNewPooledObject()
    {
        GameObject spawnedObject = Instantiate(objectPrefab, defualtParent);
        spawnedObject.SetActive(false);
        objectPool.Add(spawnedObject);
        return spawnedObject;
    }


}
