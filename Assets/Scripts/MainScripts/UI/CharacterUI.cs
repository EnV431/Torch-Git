using NUnit.Framework;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class CharacterUI : MonoBehaviour
{
    Dictionary<string, TextMeshProUGUI> characterUITexts = new Dictionary<string, TextMeshProUGUI>();

    private void Awake()
    {
        TextMeshProUGUI[] textComponents = GetComponentsInChildren<TextMeshProUGUI>(true);
        foreach (TextMeshProUGUI textComponent in textComponents)
        {
            characterUITexts[textComponent.name] = textComponent;
        }
    }

    public void DisplayCharacterUI(Character character)
    {

    }

}
