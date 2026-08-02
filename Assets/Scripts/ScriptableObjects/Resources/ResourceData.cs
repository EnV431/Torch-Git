using UnityEngine;

[CreateAssetMenu(fileName = "ResourceData", menuName = "Scriptable Objects/ResourceData")]
public class ResourceData : ScriptableObject
{
    public enum ResourceType
    {
        Food,
        Water,
        Money,
        Happiness,
        Security,
        LightLevel,
        Alcohol
    }
    public bool isCapped;

    [Header("Identifiers")]
    public int resourceId;
    public string resourceName;
    public ResourceType resourceType;
}
