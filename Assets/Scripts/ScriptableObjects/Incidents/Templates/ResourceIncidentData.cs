using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public struct ResourceChangeStruct
{
    public ResourceData.ResourceType resourceType;
    public int amountToChange;
}

[CreateAssetMenu(fileName = "ResourceIncidentData", menuName = "Scriptable Objects/IncidentData/ResourceIncidentData")]
public class ResourceIncidentData : IncidentData
{
    public List<ResourceChangeStruct> resourceChangesList;
}
