using UnityEngine;

[CreateAssetMenu(fileName = "IncidentData", menuName = "Scriptable Objects/IncidentDatas/IncidentData")]
public class IncidentData : ScriptableObject
{
    public string incidentName;
    public int incidentTypeId;
}
