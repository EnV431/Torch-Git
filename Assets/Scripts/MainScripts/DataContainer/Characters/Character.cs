using Unity.VisualScripting;
using UnityEngine;

public class Character
{    
    public CharacterData characterData;
    
    public CharacterAttributes CharacterAttributes { get; private set; }
    public CharacterStats CharacterStats { get; private set; }
    public CharacterDietStats CharacterDietStats { get; private set; }
    public PersonalInfo PersonalInfo { get; private set; }

    public CharacterTraitContainer[] CharacterTraits { get; private set; }
    public CharacterProficiencyContainer[] CharacterProficiencies { get; private set; }

    public virtual void CopyDataFromCharacterData()
    {
        if (characterData == null)
        {
            Debug.Log("CharacterData is null in a base class instance");
            return;
        }
        else
        {
            InitializeStats();
            CharacterAttributes = new CharacterAttributes(characterData.characterAttributes);
            CharacterStats = new CharacterStats(characterData.characterStats);
            CharacterDietStats = new CharacterDietStats(characterData.characterDietStats);
            PersonalInfo = characterData.personalInfo;
            CharacterTraits = characterData.characterTraitsArray;
            CharacterProficiencies = characterData.characterProficienciesArray;
        }


    }

    private void InitializeStats()
    {
        CharacterAttributes.InitializeStats();
        CharacterStats.InitializeStats();
        CharacterDietStats.InitializeStats();
    }


}
