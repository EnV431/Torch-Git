using System;
using Unity.VisualScripting;
using UnityEngine;

public class IGameStartSetupModule : MonoBehaviour, IGameModule 
{
    [SerializeField] DifficultyData chosenDifficulty; // being selected through inspecter for now

    public static event Action OnGameStart;
    public static event Action OnResetGame;

    public void InitializeModule()
    {
        Debug.Log("Init GameStartUp");
        SetResourceValuesToChosenDifficulty();
        OnGameStart?.Invoke();
    }

    public void ResetModule()
    {
        SetResourceValuesToChosenDifficulty();
        OnResetGame?.Invoke();
    }

    private void SetResourceValuesToChosenDifficulty()
    {
        if (GlobalDictionary.GlobalDictionaryInstance == null) Debug.Log("global dict is null"); 
        if (chosenDifficulty == null) Debug.Log("global dict is null");

        GlobalDictionary.GlobalDictionaryInstance.ChangeResource(ResourceData.ResourceType.Food, chosenDifficulty.food);
        GlobalDictionary.GlobalDictionaryInstance.ChangeResource(ResourceData.ResourceType.Water, chosenDifficulty.water);
        GlobalDictionary.GlobalDictionaryInstance.ChangeResource(ResourceData.ResourceType.Money, chosenDifficulty.money);
        GlobalDictionary.GlobalDictionaryInstance.ChangeResource(ResourceData.ResourceType.Happiness, chosenDifficulty.happiness);
        GlobalDictionary.GlobalDictionaryInstance.ChangeResource(ResourceData.ResourceType.Security, chosenDifficulty.security);
        GlobalDictionary.GlobalDictionaryInstance.ChangeResource(ResourceData.ResourceType.LightLevel, chosenDifficulty.lightLevel);
        GlobalDictionary.GlobalDictionaryInstance.ChangeResource(ResourceData.ResourceType.Alcohol, chosenDifficulty.alcohol);
    }





}

