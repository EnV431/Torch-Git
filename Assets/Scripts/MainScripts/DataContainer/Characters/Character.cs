using Unity.VisualScripting;
using UnityEngine;

public class Character
{    
    public CharacterData characterData;
    
    public CharacterAttributes characterAttributes;
    public CharacterStats characterStats;
    public CharacterDietStats characterDietStats;

    public virtual void CopyDataFromCharacterData()
    { 
        characterAttributes = characterData.characterAttributes;
        characterStats = characterData.characterStats;
        characterDietStats = characterData.characterDietStats;

    }

}
