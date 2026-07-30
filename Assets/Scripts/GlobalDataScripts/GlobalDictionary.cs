using System.Collections.Generic;
using UnityEngine;

public class GlobalDictionary : MonoBehaviour
{
    public static GlobalDictionary GlobalDictionaryInstance { get; set; }

    private Dictionary<string, Resource> resourceDictionary = new();


    private void Start() //on start so it happenes after the database
    {
        #region SingletonSetup
        //DontDestroyOnLoad(gameObject);
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
            resourceDictionary.Add(resourceShell.resourceData.resourceName, resourceShell);
            Debug.Log(" Added " + resourceShell.resourceData.resourceName + " to dicionary");
        }
    }

    public Resource GetResource(string resourceName) // public lookup method
    {

        if (resourceDictionary.TryGetValue(resourceName, out var resource))
        {
            return resource;
        }
        else Debug.LogError(" Resource not found in Dictionary"); return null;
    }


    // Load the data from the GameDatabase into each dictionary
    //foreach (ResourceData resourceData in GameDatabaseInstance.GameDatabase.resourceList ) //do null checks of course


    //Resource newResource = new; // want to make a new clone of the data so the og data isn't affected // this line is probably not right
    //newResource.resourceDataBox = resourceData;
    //newResource.name = resourceData.resourceName;
    // this will make a new instance of a resource and then insert the data from the scriptable object stored in the database so now the resource data can be changed but the og data is safe.
    //Make Lookup Functions for each dictionary

}
