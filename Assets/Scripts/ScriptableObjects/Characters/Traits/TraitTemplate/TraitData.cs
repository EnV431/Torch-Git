using NUnit.Framework;
using UnityEngine;

[System.Serializable]
public struct TraitStruct
{
    public string traitName;
    public int traitId;
    public string traitDescription;
    public float traitModifier;
}

[CreateAssetMenu(fileName = "TraitData", menuName = "Scriptable Objects/TraitData")]
public class TraitData : ScriptableObject
{
    public TraitStruct traitInfo;   
}
