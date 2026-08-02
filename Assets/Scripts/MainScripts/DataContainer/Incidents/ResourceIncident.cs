using UnityEngine;

public class ResourceIncident : Incident
{
    protected override void ExecuteIncident()
    {
        Debug.Log("Executing Resource Incident: " + resourceIncidentData.incidentName);
        foreach (var item in resourceIncidentData.resourceChangesArray)
        {
            GlobalDictionary.GlobalDictionaryInstance.ChangeResource(item.resourceType, item.amountToChange);
            GlobalUIManager.GlobalUIManagerInstance.UpdateSpecificResourceUI(item.resourceType);
        }
    }
}
