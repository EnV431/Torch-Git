using Unity.VisualScripting;
using UnityEngine;

public class Character
{    
    public CharacterData characterData;
    
    public CharacterAttributes CharacterAttributes { get; private set; }
    public CharacterStats CharacterStats { get; private set; }
    public CharacterDietStats CharacterDietStats { get; private set; }

    public virtual void CopyDataFromCharacterData()
    { 
        CharacterAttributes = characterData.characterAttributes;
        CharacterStats = characterData.characterStats;
        CharacterDietStats = characterData.characterDietStats;
        InitializeStats();
    }

    private void InitializeStats()
    {
        CharacterAttributes.InitializeStats();
        CharacterStats.InitializeStats();
        CharacterDietStats.InitializeStats();
    }


}
