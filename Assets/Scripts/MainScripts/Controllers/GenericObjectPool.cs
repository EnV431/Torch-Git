using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
using Unity.VisualScripting;

public class GenericObjectPool : MonoBehaviour
{
    [SerializeField]private List<GameObject> objectPool;
    [SerializeField] private Transform defualtParent;
    [SerializeField] private GameObject objectPrefab;
    [SerializeField] private int poolSize;

    public bool isInitialized = false;
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
        isInitialized = true;
        objectPool = new List<GameObject>();

        for (int i = 0; i < poolSize; i++)
        {
            CreateNewPooledObject(out GameObject newObject);
            AddObjectToPool(newObject);
        }
    }

    public GameObject GetPooledObject()
    {
        if (isInitialized == false)
        {
            InitializeObjectPool();
        }
        foreach (GameObject spawnedObject in objectPool)
        {
            if (!spawnedObject.activeInHierarchy)
            {
                return spawnedObject;
            }
        }

        CreateNewPooledObject(out GameObject newObject);
        AddObjectToPool(newObject);
        
        return newObject;
    }
    private void CreateNewPooledObject(out GameObject spawnedObject)
    {
        spawnedObject = Instantiate(objectPrefab, defualtParent);
        spawnedObject.SetActive(false);        
    }

    private void AddObjectToPool(GameObject spawnedObject)
    {
        objectPool.Add(spawnedObject);
    }

    public void SetPooledObjectPrefab(GameObject prefab)
    {
        objectPrefab = prefab;
    }
}
