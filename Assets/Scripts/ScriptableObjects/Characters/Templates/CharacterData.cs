using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
using System;
using Range = UnityEngine.RangeAttribute;
using JetBrains.Annotations;
[System.Serializable]
public struct PersonalInfo
{
    public string Name;
    public string Species;
    public string Description;
    public string History;
}

[System.Serializable]
public struct CharacterTraitContainer
{
    public TraitData traitData;
}
[System.Serializable]
public struct CharacterProficiencyContainer
{
    public ProficiencyData proficiencyData;
}
[System.Serializable]
public struct CharacterAttributes
{
    [Range(0, 100)] [SerializeField]private int _strength;
    [Range(0, 100)] [SerializeField]private int _dexterity;
    [Range(0, 100)] [SerializeField]private int _endurance;
    [Range(0, 100)] [SerializeField]private int _willpower;
    [Range(0, 100)] [SerializeField]private int _mind;

    public int Strength { get => _strength; set => _strength = Mathf.Clamp(value, 0, 100); }
    public int Dexterity { get => _dexterity; set => _dexterity = Mathf.Clamp(value, 0, 100); }
    public int Endurance { get => _endurance; set => _endurance = Mathf.Clamp(value, 0, 100); }
    public int Willpower { get => _willpower; set => _willpower = Mathf.Clamp(value, 0, 100); }
    public int Mind { get => _mind; set => _mind = Mathf.Clamp(value, 0, 100); }
}
[System.Serializable]
public struct CharacterStats
{
    [Range(0, 100)] [SerializeField]private int _physicalHealth;
    [Range(0, 100)] [SerializeField]private int _immunity;
    [Range(0, 100)] [SerializeField]private int _hydration;
    [Range(0, 100)] [SerializeField]private int _happiness;
    [Range(0, 100)] [SerializeField]private int _energy;
    [Range(0, 100)] [SerializeField]private int _inebriation;

    public int PhysicalHealth { get => _physicalHealth; set => _physicalHealth = Mathf.Clamp(value, 0, 100); }
    public int Immunity { get => _immunity; set => _immunity = Mathf.Clamp(value, 0, 100); }
    public int Hydration { get => _hydration; set => _hydration = Mathf.Clamp(value, 0, 100); }
    public int Happiness { get => _happiness; set => _happiness = Mathf.Clamp(value, 0, 100); }
    public int Energy { get => _energy; set => _energy = Mathf.Clamp(value, 0, 100); }
    public int Inebriation { get => _inebriation; set => _inebriation = Mathf.Clamp(value, 0, 100); }
}
[System.Serializable]
public struct CharacterDietStats
{
    [Range(0, 100)][SerializeField] private int _protein;
    [Range(0, 100)][SerializeField] private int _sugar;
    [Range(0, 100)][SerializeField] private int _nutrients;
    [Range(0, 100)][SerializeField] private int _grain;
    [Range(0, 100)][SerializeField] private int _dairy;

    public int Protein { get => _protein; set => _protein = Mathf.Clamp(value, 0, 100); }
    public int Sugar { get => _sugar; set => _sugar = Mathf.Clamp(value, 0, 100); }
    public int Nutrients { get => _nutrients; set => _nutrients = Mathf.Clamp(value, 0, 100); }
    public int Grain { get => _grain; set => _grain = Mathf.Clamp(value, 0, 100); }
    public int Dairy { get => _dairy; set => _dairy = Mathf.Clamp(value, 0, 100); }
}

[CreateAssetMenu(fileName = "CharacterData", menuName = "Scriptable Objects/CharacterDatas/CharacterData")]
public class CharacterData : ScriptableObject
{

    public PersonalInfo personalInfo;
    public CharacterTraitContainer[] characterTraitsArray;
    public CharacterProficiencyContainer[] characterProficienciesArray;
    public CharacterAttributes characterAttributes;
    public CharacterStats characterStats;
    public CharacterDietStats characterDietStats;
}
