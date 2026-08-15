using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEditor.Progress;

public class PointOfInterest
{
    public PointOfInterestData pointOfInterestData;
    
    private int baseTriggerChance;

    #region DEMO
    private bool canChange = true;
    #endregion

    public void RunPointOfInterestLogic()
    {        
        AttemptToTriggerIncidents();
    }

    private void AttemptToTriggerIncidents()
    {
        if (pointOfInterestData == null || pointOfInterestData.possibleIncidents == null) { return; }
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
        if (CheckIfIncidentTriggers(chanceToTrigger, incident))
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

    private bool CheckIfIncidentTriggers(int chanceToTrigger, Incident incident)
    {
        if (chanceToTrigger > Random.Range(0, 100))
        {
            Debug.Log("Triggering " + incident.IncidentData.name);
            return true;
        }
        Debug.Log("Failed to Trigger " + incident.IncidentData.name);
        return false;
    }

    private void TriggerIncident(Incident incident)
    {
        if (canChange == false) return; //DEMO
        incident.TriggerIncidentExecution();
        GameUIManager.GameUIManagerInstance.InvokeShowIncidentUI(incident.IncidentData);
    }

    private void RunAttackedLogic(in AttackerDetails attackerDetails)
    {
        if (attackerDetails.attackPower < GlobalDictionary.GlobalDictionaryInstance.GetResource(ResourceData.ResourceType.Security).Amount)
        {
            // need to have a party thingy setup to give damage 
        }


        //int percentOfDamageToGuard = 0; // damage will be spread out across characters but mostly focused on the guard the more evil the enemy the more damage to civilians


    } //will run after the incident has been triggered

    private void StopTriggering() //DEMO
    {
        canChange = false;
    }

}
