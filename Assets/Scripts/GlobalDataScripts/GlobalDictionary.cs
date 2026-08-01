using System.Collections.Generic;
using UnityEngine;

public class GlobalDictionary : MonoBehaviour
{
    public static GlobalDictionary GlobalDictionaryInstance { get; set; }

    private Dictionary<ResourceData.ResourceType, Resource> resourceDictionary = new();
    private Dictionary<string, Incident> incidentDictionary = new();


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
            //Debug.Log(" Added " + resourceShell.resourceData.resourceName + " to dictionary");
        }

        foreach (IncidentData incidentData in GameDatabase.GameDatabaseInstance.IncidentDataList)
        {
            //Debug.Log(incidentData.incidentName);
            Incident incidentShell = new();
            if (incidentData is ResourceIncidentData resourceIncidentData)
            {
                incidentShell.incidentData = resourceIncidentData;
            }
            else
            {
                incidentShell.incidentData = incidentData;
                Debug.Log("Incident is using default incident data / Thats not good");
            }
            
            incidentDictionary.Add(incidentShell.incidentData.incidentName, incidentShell);
            Debug.Log(" Added " + incidentShell.incidentData.incidentName + " to dictionary");
        }
    }
    #region ResourceFuncs
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
    public void SetResource(ResourceData.ResourceType resourceType, int amountToChange)
    {
        if (resourceDictionary.TryGetValue(resourceType, out var resource))
        {
            resource.SetAmount(amountToChange);
        }
        else Debug.LogError(" Resource not found in Dictionary"); return;
    }
    #endregion

    #region IncidentFuncs

    public Incident GetIncident(string incidentName) // public lookup method
    {
        if (incidentDictionary.TryGetValue(incidentName, out var incident))
        {
            return incident;
        }
        else Debug.LogError(" Incident not found in Dictionary"); return null;
    }

    public void TriggerIncident(string incidentName)
    {
        Incident incident = GetIncident(incidentName);
        if (incident != null)
        {
            incident.TriggerIncidentExecution();
        }
    }

    #endregion




}
