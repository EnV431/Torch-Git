using UnityEngine;

[CreateAssetMenu(fileName = "ResourceIncidentData", menuName = "Scriptable Objects/IncidentData/ResourceIncidentData")]
public class ResourceIncidentData : ScriptableObject
{
    public ResourceData.ResourceType resource1;
    public int amountToChangeResource1;

    public ResourceData.ResourceType resource2;
    public int amountToChangeResource2;

    public ResourceData.ResourceType resource3;
    public int amountToChangeResource3;

    public ResourceData.ResourceType resource4;
    public int amountToChangeResource4;

}
