using Unity.VisualScripting;
using UnityEngine;

public class Character
{
    public enum InfoEnum
    {
        Name = 0,
        Age = 1,
        Species = 2,
        Description = 3,
        History = 4,
        Strength = 5,
        Dexterity = 6,
        Endurance = 7,
        Willpower = 8,
        Mind = 9,
        PhysicalHealth = 10,
        Immunity = 11,
        Hydration = 12,
        Happiness = 13,
        Energy = 14,
        Inebriation = 15,
        Protein = 16,
        Sugar = 17,
        Nutrients = 18,
        Grain = 19,
        Dairy = 20,
    }

    public InfoEnum infoEnum;

    public CharacterAttributes CharacterAttributes { get; private set; }
    public CharacterStats CharacterStats { get; private set; }
    public CharacterDietStats CharacterDietStats { get; private set; }
    public PersonalInfo PersonalInfo { get; private set; }

    public CharacterVanity CharacterVanity { get; private set; }

    public CharacterTraitContainer[] CharacterTraits { get; private set; }
    public CharacterProficiencyContainer[] CharacterProficiencies { get; private set; }

    public virtual void CopyDataFromCharacterData(CharacterData characterData)
    {
        if (characterData == null)
        {
            Debug.Log("CharacterData is null in a base class instance");
            return;
        }
        else
        {
            CharacterAttributes = new CharacterAttributes(characterData.characterAttributes);
            CharacterStats = new CharacterStats(characterData.characterStats);
            CharacterDietStats = new CharacterDietStats(characterData.characterDietStats);
            PersonalInfo = characterData.personalInfo;
            CharacterVanity = characterData.characterVanity;
            CharacterTraits = characterData.characterTraitsArray;
            CharacterProficiencies = characterData.characterProficienciesArray;
        }
    }

}
