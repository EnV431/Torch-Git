using NUnit.Framework;
using UnityEngine;
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
    public Stat Strength;
    public Stat Dexterity;
    public Stat Endurance;
    public Stat Willpower;
    public Stat Mind;

    public void InitializeStats()
    {
        Strength.SetCurrentValueToBaseValue();
        Dexterity.SetCurrentValueToBaseValue();
        Endurance.SetCurrentValueToBaseValue();
        Willpower.SetCurrentValueToBaseValue();
        Mind.SetCurrentValueToBaseValue();
    }
}
[System.Serializable]
public struct CharacterStats
{
    public Stat PhysicalHealth;
    public Stat Immunity;
    public Stat Hydration;
    public Stat Happiness;
    public Stat Energy;
    public Stat Inebriation;

    public void InitializeStats()
    {
        PhysicalHealth.SetCurrentValueToBaseValue();
        Immunity.SetCurrentValueToBaseValue();
        Hydration.SetCurrentValueToBaseValue();
        Happiness.SetCurrentValueToBaseValue();
        Energy.SetCurrentValueToBaseValue();
        Inebriation.SetCurrentValueToBaseValue();
    }
}
[System.Serializable]
public struct CharacterDietStats
{
    public Stat Protein;
    public Stat Sugar;
    public Stat Nutrients;
    public Stat Grain;
    public Stat Diary;

    public void InitializeStats()
    {
        Protein.SetCurrentValueToBaseValue();
        Sugar.SetCurrentValueToBaseValue();
        Nutrients.SetCurrentValueToBaseValue();
        Grain.SetCurrentValueToBaseValue();
        Diary.SetCurrentValueToBaseValue();
    }
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
