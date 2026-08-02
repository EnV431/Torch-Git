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
        if (characterData != null)
        {
            CharacterAttributes = new CharacterAttributes(characterData.characterAttributes);
            CharacterStats = new CharacterStats(characterData.characterStats);
            CharacterDietStats = new CharacterDietStats(characterData.characterDietStats);
            InitializeStats();
        }

    }

    private void InitializeStats()
    {
        CharacterAttributes.InitializeStats();
        CharacterStats.InitializeStats();
        CharacterDietStats.InitializeStats();
    }


}
