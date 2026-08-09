using UnityEngine;

[CreateAssetMenu(fileName = "PointOfInterestData", menuName = "Scriptable Objects/PointOfInterestData")]
public class PointOfInterestData : ScriptableObject
{
    // can move data into structs
    public enum POIDangerLevel
    {
        Safe,
        Low,
        Medium,
        High,
        Dangerous
    }

    public POIDangerLevel poiDangerlevel;
    public string pointOfInterestDescription;
    public IncidentData[] possibleIncidents;
}
