using UnityEngine;

public class ResourceIncident : Incident
{
    protected override void ExecuteIncident()
    {
        foreach (var item in resourceIncidentData.resourceChangesList)
        {
            GlobalDictionary.GlobalDictionaryInstance.ChangeResource(item.resourceType, item.amountToChange);
        }
    }
}
