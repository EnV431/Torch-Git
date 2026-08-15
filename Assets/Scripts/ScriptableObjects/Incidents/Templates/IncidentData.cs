using UnityEngine;

[System.Serializable]
public struct IncidentDetails
{
    public bool isNegative;
    public string incidentName;
    [Tooltip("The probability of this incident when called by a POI occurring (0-100)")] public int chanceToHappen;
    public string incidentDescription;
    [Tooltip("Used to determine the type of incident: 1 = Resource, 2 = Character, 3 = Item")] public int incidentTypeId;
    public Sprite incidentImage;
}
[System.Serializable]
public struct AttackerDetails
{
    public bool isAttacker;
    public int attackPower;

    public enum AttackerEvilLevel
    {
        Neutral = 0,
        Rude = 1,
        Mean = 2,
        Bully = 3,
        Criminal = 4,
        Violent = 5,
        Physcopath = 6,
    }
    public AttackerEvilLevel attackerEvilLevel;
}

[CreateAssetMenu(fileName = "IncidentData", menuName = "Scriptable Objects/IncidentDatas/IncidentData")]
public class IncidentData : ScriptableObject
{
    public IncidentDetails IncidentDetails;
    public AttackerDetails AttackerDetails;
}
