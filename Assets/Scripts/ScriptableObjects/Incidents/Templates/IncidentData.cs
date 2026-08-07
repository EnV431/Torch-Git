using UnityEngine;

[CreateAssetMenu(fileName = "IncidentData", menuName = "Scriptable Objects/IncidentDatas/IncidentData")]
public class IncidentData : ScriptableObject
{
    public bool isNegative;
    public string incidentName;
    [Tooltip("The probability of this incident when called by a POI occurring (0-100)")]public int chanceToHappen;
    public string incidentDescription;
    [Tooltip("Used to determine the type of incident: 1 = Resource, 2 = Character, 3 = Item")]public int incidentTypeId;
}
