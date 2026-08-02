using UnityEngine;
[System.Serializable]
public struct PerkStruct
{
    public string perkName;
    public int perkId;
    public string perkDescription;
    public float perkModifier;
}

[CreateAssetMenu(fileName = "PerkData", menuName = "Scriptable Objects/CharacterDatas/PerkData")]
public class PerkData : ScriptableObject
{
    public PerkStruct perk;
}
