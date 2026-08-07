using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEditor.Progress;

public class PointOfInterest
{
    public bool isCompleted = false;
    public PointOfInterestData pointOfInterestData;

    private bool doesTrigger;
    private int baseTriggerChance;
    
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
            GetIncidentDetails(in item.IncidentDetails, in item.AttackerDetails); //optimize by passing a readonly ref of the struct so that the struct isnt copied
        }
    }

    private void GetIncidentDetails(in IncidentDetails incidentDetails, in AttackerDetails attackerDetails)
    {
        baseTriggerChance = incidentDetails.chanceToHappen;
        LookForIncident(incidentDetails.incidentName, out Incident incident);        
        int chanceToTrigger = FilterChanceStructLogics(in incidentDetails);
        if (CheckIfIncidentTriggers(chanceToTrigger))
        {
            TriggerIncident(incident);
        }
        
    }

    private void LookForIncident(string incidentName, out Incident incident)
    {
        incident = GlobalDictionary.GlobalDictionaryInstance.GetIncident(incidentName);
    }

    private int FilterChanceStructLogics(in IncidentDetails incidentDetails)
    {
        if (incidentDetails.isNegative) baseTriggerChance += CaculateDangerModifier(incidentDetails);

        baseTriggerChance = Mathf.Clamp(baseTriggerChance, 0, 100);
        return baseTriggerChance;
    }
    private int CaculateDangerModifier(in IncidentDetails incidentDetails)
    {
        int triggerChance = 0;
        if (incidentDetails.isNegative)
        {
            switch (pointOfInterestData.poiDangerlevel)
            {
                case PointOfInterestData.POIDangerLevel.Safe:
                    return 0;
                case PointOfInterestData.POIDangerLevel.Low:
                    triggerChance -= 10;
                    break;
                case PointOfInterestData.POIDangerLevel.Medium:
                    // Doesnt Change
                    break;
                case PointOfInterestData.POIDangerLevel.High:
                    triggerChance += 5;
                    break;
                case PointOfInterestData.POIDangerLevel.Dangerous:
                    triggerChance += 15;
                    break;
            }
        }
        return triggerChance;

    }

    private bool CheckIfIncidentTriggers(int chanceToTrigger)
    {
        if (chanceToTrigger > Random.Range(0, 100))
        {
            return true;
        }
        return false;
    }

    private void TriggerIncident(Incident incident)
    {
        incident.TriggerIncidentExecution();
    }

    private void RunAttackedLogic(in AttackerDetails attackerDetails)
    {
        if (attackerDetails.attackPower < GlobalDictionary.GlobalDictionaryInstance.GetResource(ResourceData.ResourceType.Security).Amount)
        {
            // need to have a party thingy setup to give damage 
        }


        //int percentOfDamageToGuard = 0; // damage will be spread out across characters but mostly focused on the guard the more evil the enemy the more damage to civilians


    } //will run after the incident has been triggered
}
