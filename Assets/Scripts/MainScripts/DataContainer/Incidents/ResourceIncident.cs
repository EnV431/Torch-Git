using UnityEngine;

public class ResourceIncident : Incident
{
    protected override void ExecuteIncident()
    {
        Debug.Log("Executing Resource Incident: " + IncidentData.incidentName);
        if (IncidentData is ResourceIncidentData)
        {
            ResourceIncidentData resourceIncidentData = IncidentData as ResourceIncidentData;
            foreach (var item in resourceIncidentData.resourceChangesArray)
            {
                GlobalDictionary.GlobalDictionaryInstance.ChangeResource(item.resourceType, item.amountToChange);
                GlobalUIManager.GlobalUIManagerInstance.UpdateSpecificResourceUI(item.resourceType);
            }
        }
    }
}
