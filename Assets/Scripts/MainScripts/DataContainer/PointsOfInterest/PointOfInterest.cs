using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.Progress;

public class PointOfInterest
{
    public bool isCompleted = false;
    public PointOfInterestData pointOfInterestData;

    public void RunPointOfInterestLogic()
    {
        if (isCompleted != false) return;

        UpdatePointOfInterestUI();
        AttemptToTriggerIncidents();

    }
    private void UpdatePointOfInterestUI()
    {
        GlobalUIManager.GlobalUIManagerInstance.UpdatePointOfInterestUI?.Invoke(pointOfInterestData);
    }

    private void AttemptToTriggerIncidents()
    {
        foreach (IncidentData item in pointOfInterestData.possibleIncidents)
        {
            AttemptToGetIncident(item.incidentName, out Incident incident);
            int chanceToTrigger = CaculateChanceToHappen(item.chanceToHappen, incident.IncidentData);
            CheckIfIncidentTriggers(chanceToTrigger);
        }
    }

    private void AttemptToGetIncident(string incidentName, out Incident incident)
    {
        incident = GlobalDictionary.GlobalDictionaryInstance.GetIncident(incidentName);
    }

    private int CaculateChanceToHappen(int baseChance, IncidentData incidentData)
    {
        if (incidentData is ResourceIncidentData)
        {
            ResourceIncidentData rIncidentDat = incidentData as ResourceIncidentData;
            Debug.Log(rIncidentDat.resourceChangesArray.Length);
            foreach (var item in rIncidentDat.resourceChangesArray)
            {
                Debug.Log(item.resourceType + "IT works");
            }
        }
        if (incidentData.isNegative)
        {
            
        }
        switch (pointOfInterestData.poiDangerlevel)
        {
            case PointOfInterestData.POIDangerLevel.Safe:

                break;
            case PointOfInterestData.POIDangerLevel.Low:
                // Handle low danger POI logic
                break;
            case PointOfInterestData.POIDangerLevel.Medium:
                // Handle medium danger POI logic
                break;
            case PointOfInterestData.POIDangerLevel.High:
                // Handle high danger POI logic
                break;
            case PointOfInterestData.POIDangerLevel.Dangerous:
                // Handle dangerous POI logic
                break;

        }       return 0;
    }
    private void CheckIfIncidentTriggers(int chanceToHappen)
    {

        
    }
}
