using System.Collections.Generic;
using UnityEngine;

public class GlobalDictionary : MonoBehaviour
{
    public static GlobalDictionary GlobalDictionaryInstance { get; set; }

    private Dictionary<ResourceData.ResourceType, Resource> resourceDictionary = new();
    private Dictionary<string, Incident> incidentDictionary = new();
    private Dictionary<string, Character> characterDictionary = new();

    private Dictionary<string, PointOfInterest> pointOfInterestDictionary = new();
    private Dictionary<string, TraitData> traitDictionary = new();

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
                ResourceIncidentData newResourceIncidentData = incidentData as ResourceIncidentData;
                ResourceIncident incidentShell = new();
                AddResourceIncident(incidentShell, newResourceIncidentData);
                //Debug.Log(" Added " + incidentShell.IncidentData.incidentName + " to dictionary");
            }            
        }
        foreach (CharacterData characterData in GameDatabase.GameDatabaseInstance.CharacterDataList)
        {
            Character characterShell = new();
            characterShell.CopyDataFromCharacterData(characterData);

            characterDictionary.Add(characterShell.PersonalInfo.name, characterShell);
            Debug.Log(" Added " + characterShell.PersonalInfo.name + " to dictionary");
        }
        foreach (TraitData traitData in GameDatabase.GameDatabaseInstance.TraitDataList)
        {            
            traitDictionary.Add(traitData.traitInfo.traitName, traitData);
        }
        foreach (PointOfInterestData poiData in GameDatabase.GameDatabaseInstance.PointOfInterestDataList)
        {
            PointOfInterest pointOfInterest = new();
            pointOfInterest.pointOfInterestData = poiData;
            pointOfInterestDictionary.Add(pointOfInterest.pointOfInterestData.name, pointOfInterest);
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

    public Incident GetIncidentByData(IncidentData incidentData)
    {
        if (incidentDictionary.TryGetValue(incidentData.name, out var incident))
        {
            ConvertIncidentToCorrectType(incident);
            return incident;
        }
        else Debug.LogError(" Incident not found in Dictionary"); return null;
    }

    private Incident ConvertIncidentToCorrectType(Incident incident)
    {
        switch (incident)
        {
            case ResourceIncident:
                return incident as ResourceIncident;
            
                default: return null;

            
        }
    }


    #region AddToDictionaryLogicForDifferentIncidentTypes

    private void AddResourceIncident(ResourceIncident incidentShell, ResourceIncidentData resourceIncidentData) //just do this but for other incident types as well
    {        
        incidentShell.IncidentData = resourceIncidentData;
        incidentDictionary.Add(incidentShell.IncidentData.IncidentDetails.incidentName, incidentShell);
        //Debug.Log(" Added " + incidentShell.IncidentData.incidentName + " to dictionary");
    }

    #endregion

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

    #region CharacterFuncs

    public Character GetCharacter(string characterName) // public lookup method
    {
        if (characterDictionary.TryGetValue(characterName, out var character))
        {
            return character;
        }
        else Debug.LogError(" Character not found in Dictionary"); return null;
    }

    #endregion
    #region POI Funcs
    public PointOfInterest GetPointOfInterest(string pointOfInterestName) // public lookup method
    {
        if (pointOfInterestDictionary.TryGetValue(pointOfInterestName, out var pointOfInterest))
        {
            return pointOfInterest;
        }
        else Debug.LogError(" Point of Interest not found in Dictionary"); return null;
    }
    #endregion

    #region TraitFuncs
    public TraitData GetTrait(string traitName) // public lookup method
    {
        if (traitDictionary.TryGetValue(traitName, out var trait))
        {
            return trait;
        }
        else Debug.LogError(" Trait not found in Dictionary"); return null;
    }
    #endregion
}

