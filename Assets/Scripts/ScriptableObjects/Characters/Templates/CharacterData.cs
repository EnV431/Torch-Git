using NUnit.Framework;
using UnityEngine;
[System.Serializable]
public struct PersonalInfo
{
    public string name;
    public int age;
    public string species;
    public string description;
    public string history;
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

    public CharacterAttributes(CharacterAttributes template)
    {
        Strength = new Stat(template.Strength);
        Dexterity = new Stat(template.Dexterity);
        Endurance = new Stat(template.Endurance);
        Willpower = new Stat(template.Willpower);
        Mind = new Stat(template.Mind);
    }

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

    public CharacterStats(CharacterStats template)
    {
        PhysicalHealth = new Stat(template.PhysicalHealth);
        Immunity = new Stat(template.Immunity);
        Hydration = new Stat(template.Hydration);
        Happiness = new Stat(template.Happiness);
        Energy = new Stat(template.Energy);
        Inebriation = new Stat(template.Inebriation);
    }

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

    public CharacterDietStats(CharacterDietStats template)
    {
        Protein = new Stat(template.Protein);
        Sugar = new Stat(template.Sugar);
        Nutrients = new Stat(template.Nutrients);
        Grain = new Stat(template.Grain);
        Diary = new Stat(template.Diary);
    }
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
