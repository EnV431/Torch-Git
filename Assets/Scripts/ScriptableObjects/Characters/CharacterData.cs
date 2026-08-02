using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
[System.Serializable]
public struct PersonalInfo
{
    public string Name;
    public string Nationality;
    public string Description;
}

[System.Serializable]
public struct CharacterPerkContainer
{
    public PerkData perkData;
}

[CreateAssetMenu(fileName = "CharacterData", menuName = "Scriptable Objects/CharacterDatas/CharacterData")]
public class CharacterData : ScriptableObject
{
    public PersonalInfo personalInfo;
    public List<CharacterPerkContainer> characterPerksList;
}
