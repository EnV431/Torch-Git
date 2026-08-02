using UnityEngine;

[System.Serializable]
public struct ProficiencyInfo
{
    public string proficiencyName;
    public int proficiencyLevel;
    public float proficiencyBonus;
}

[CreateAssetMenu(fileName = "ProficiencyData", menuName = "Scriptable Objects/CharacterDatas/ProficiencyData")]
public class ProficiencyData : ScriptableObject
{
    public ProficiencyInfo proficiencyInfo;
}
