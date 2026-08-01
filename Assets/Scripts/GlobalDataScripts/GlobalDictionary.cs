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
            if (incidentData is ResourceIncidentData resourceIncidentData) //just do this but for other incident types as well
            {
                ResourceIncident incidentShell = new();
                AddResourceIncident(incidentShell, resourceIncidentData);
            }            
        }
    }
    #region AddToDictionaryLogicForDifferentIncidentTypes

    private void AddResourceIncident(ResourceIncident incidentShell, ResourceIncidentData resourceIncidentData) //just do this but for other incident types as well
    {
        incidentShell.resourceIncidentData = resourceIncidentData;
        incidentDictionary.Add(incidentShell.resourceIncidentData.incidentName, incidentShell);
        Debug.Log(" Added " + incidentShell.resourceIncidentData.incidentName + " to dictionary");
    }

    #endregion


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
        if (incident is ResourceIncident resourceIncident)
        {
            resourceIncident.TriggerIncidentExecution();
            Debug.Log("triggering " + incidentName);
        }
        else
        {
            Debug.Log("triggering base incident from dict / not hunky dory");
        }

    }

    #endregion




}
