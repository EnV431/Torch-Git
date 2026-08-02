using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
using System;
[System.Serializable]
public struct PersonalInfo
{
    public string Name;
    public string Nationality;
    public string Description;    
}

[System.Serializable]
public struct CharacterTraitContainer
{
    public TraitData traitData;
}
public struct CharacterProficiencyContainer
{
    public ProficiencyData proficiencyData;
}

[CreateAssetMenu(fileName = "CharacterData", menuName = "Scriptable Objects/CharacterDatas/CharacterData")]
public class CharacterData : ScriptableObject
{

    public PersonalInfo personalInfo;
    public List<CharacterTraitContainer> characterTraitsList;
    public List<CharacterProficiencyContainer> characterProficienciesList;
}
