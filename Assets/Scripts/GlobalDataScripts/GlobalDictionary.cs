using System.Collections.Generic;
using UnityEngine;

public class GlobalDictionary : MonoBehaviour
{
    public static GlobalDictionary GlobalDictionaryInstance { get; set; }

    private Dictionary<ResourceData.ResourceType, Resource> resourceDictionary = new();


    private void Start() //on start so it happenes after the database
    {
        #region SingletonSetup
        DontDestroyOnLoad(gameObject);
        if (GlobalDictionaryInstance != null && GlobalDictionaryInstance != this)
        {
            Destroy(gameObject);
            return;
        }
        GlobalDictionaryInstance = this;
        #endregion

        #region LoadDictionarys
        LoadDictionarys();
        #endregion
    }

    private void LoadDictionarys()
    {
        foreach (ResourceData resourceData in GameDatabase.GameDatabaseInstance.ResourceDataList)
        {
            //Debug.Log(resourceData.resourceName);
            Resource resourceShell = new();
            resourceShell.resourceData = resourceData;
            resourceDictionary.Add(resourceShell.resourceData.resourceType, resourceShell);
            Debug.Log(" Added " + resourceShell.resourceData.resourceName + " to dictionary");
        }
    }

    public Resource GetResource(ResourceData.ResourceType resourceType) // public lookup method
    {
        if (resourceDictionary.TryGetValue(resourceType, out var resource))
        {
            return resource;
        }
        else Debug.LogError(" Resource not found in Dictionary"); return null;
    }

    public void ChangeResource(ResourceData.ResourceType resourceType, int amountToChange)
    {
        if (resourceDictionary.TryGetValue(resourceType, out var resource))
        {
            resource.ChangeAmount(amountToChange);
        }
        else Debug.LogError(" Resource not found in Dictionary"); return;
    }

}
