using NUnit.Framework;
using System.Collections.Generic;
using System.Reflection;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class CharacterUI : MonoBehaviour
{
    [SerializeField]GameObject characterUIObject;

    // UI Elements temporary
    [SerializeField] private TextMeshProUGUI NameT;
    [SerializeField] private TextMeshProUGUI AgeT;
    [SerializeField] private TextMeshProUGUI SpeciesT;
    [SerializeField] private TextMeshProUGUI DescriptionT;
    [SerializeField] private TextMeshProUGUI HistoryT;
    [SerializeField] private TextMeshProUGUI StrengthT;
    [SerializeField] private TextMeshProUGUI DexterityT;
    [SerializeField] private TextMeshProUGUI EnduranceT;
    [SerializeField] private TextMeshProUGUI WillpowerT;
    [SerializeField] private TextMeshProUGUI MindT;
    [SerializeField] private TextMeshProUGUI PhysicalHealthT;
    [SerializeField] private TextMeshProUGUI ImmunityT;
    [SerializeField] private TextMeshProUGUI HydrationT;
    [SerializeField] private TextMeshProUGUI HappinessT;
    [SerializeField] private TextMeshProUGUI EnergyT;
    [SerializeField] private TextMeshProUGUI InebriationT;
    [SerializeField] private TextMeshProUGUI ProteinT;
    [SerializeField] private TextMeshProUGUI SugarT;
    [SerializeField] private TextMeshProUGUI NutrientsT;
    [SerializeField] private TextMeshProUGUI GrainT;
    [SerializeField] private TextMeshProUGUI DairyT;

    
    private void OnEnable()
    {
        GameUIManager.GameUIManagerInstance.ShowCharacterUI += GetCharacterForUI; //DEMO SETUP
    }
    private void OnDisable()
    {
        GameUIManager.GameUIManagerInstance.ShowCharacterUI -= GetCharacterForUI; //DEMO SETUP
    }

    private void GetCharacterForUI()
    {
        DisplayCharacterUI(GlobalDictionary.GlobalDictionaryInstance.GetCharacter("John")); //DEMO
    }


    public void DisplayCharacterUI(Character character)
    {
        TurnOnCharacterUIObject();
        NameT.text = character.PersonalInfo.name;
        AgeT.SetText("{0}", character.PersonalInfo.age);
        SpeciesT.text = character.PersonalInfo.species;
        DescriptionT.text = character.PersonalInfo.description;
        HistoryT.text = character.PersonalInfo.history;
        StrengthT.SetText("Strength: {0}", character.CharacterAttributes.Strength.BaseValue);
        DexterityT.SetText("Dexterity: {0}", character.CharacterAttributes.Dexterity.BaseValue);
        EnduranceT.SetText("Endurance: {0}", character.CharacterAttributes.Endurance.BaseValue);
        WillpowerT.SetText("Willpower: {0}", character.CharacterAttributes.Willpower.BaseValue);
        MindT.SetText("Mind: {0}", character.CharacterAttributes.Mind.BaseValue);
        PhysicalHealthT.SetText("Physical Health: {0}", character.CharacterStats.PhysicalHealth.BaseValue);
        ImmunityT.SetText("Immunity: {0}", character.CharacterStats.Immunity.BaseValue);
        HydrationT.SetText("Hydration: {0}", character.CharacterStats.Hydration.BaseValue);
        HappinessT.SetText("Happiness: {0}", character.CharacterStats.Happiness.BaseValue);
        EnergyT.SetText("Energy: {0}", character.CharacterStats.Energy.BaseValue);
        InebriationT.SetText("Inebriation: {0}", character.CharacterStats.Inebriation.BaseValue);
        ProteinT.SetText("Protein: {0}", character.CharacterDietStats.Protein.BaseValue);
        SugarT.SetText("Sugar: {0}", character.CharacterDietStats.Sugar.BaseValue);
        NutrientsT.SetText("Nutrients: {0}", character.CharacterDietStats.Nutrients.BaseValue);
        GrainT.SetText("Grain: {0}", character.CharacterDietStats.Grain.BaseValue);
        DairyT.SetText("Dairy: {0} ", character.CharacterDietStats.Dairy.BaseValue); 
    }

    private void TurnOnCharacterUIObject()
    {
        characterUIObject.SetActive(true);
    }
    public void TurnOffCharacterUIObject()
    {
        characterUIObject.SetActive(false);
    }



}
