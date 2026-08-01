using System;
using Unity.VisualScripting;
using UnityEngine;

public class IGameStartSetupModule : MonoBehaviour, IGameModule 
{
    [SerializeField] DifficultyData chosenDifficulty; // being selected through inspecter for now

    public static event Action OnGameStart;
    public static Action OnResetGame;

    public void InitializeModule()
    {
        Debug.Log("Initializing GameStartUp");
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

        GlobalDictionary.GlobalDictionaryInstance.SetResource(ResourceData.ResourceType.Food, chosenDifficulty.food);
        GlobalDictionary.GlobalDictionaryInstance.SetResource(ResourceData.ResourceType.Water, chosenDifficulty.water);
        GlobalDictionary.GlobalDictionaryInstance.SetResource(ResourceData.ResourceType.Money, chosenDifficulty.money);
        GlobalDictionary.GlobalDictionaryInstance.SetResource(ResourceData.ResourceType.Happiness, chosenDifficulty.happiness);
        GlobalDictionary.GlobalDictionaryInstance.SetResource(ResourceData.ResourceType.Security, chosenDifficulty.security);
        GlobalDictionary.GlobalDictionaryInstance.SetResource(ResourceData.ResourceType.LightLevel, chosenDifficulty.lightLevel);
        GlobalDictionary.GlobalDictionaryInstance.SetResource(ResourceData.ResourceType.Alcohol, chosenDifficulty.alcohol);
    }





}

