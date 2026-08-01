using UnityEngine;

public class Incident
{
    public ResourceIncidentData resourceIncidentData;
    //public ItemIncidentData itemIncidentData;
    //public CharacterIncidentData characterIncidentData;
    protected virtual void ExecuteIncident()
    {
        Debug.Log("Base Incident class function triggered / Bad");
    }
    public void TriggerIncidentExecution() 
    {
        ExecuteIncident();       
    }
}
