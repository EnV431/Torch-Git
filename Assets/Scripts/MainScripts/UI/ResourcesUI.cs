using TMPro;
using UnityEngine;

public class ResourcesUI : MonoBehaviour //placeholder UI
{
    [SerializeField] private TextMeshProUGUI foodDisplay;
    [SerializeField] private TextMeshProUGUI waterDisplay;
    [SerializeField] private TextMeshProUGUI moneyDisplay;
    [SerializeField] private TextMeshProUGUI happinessDisplay;
    [SerializeField] private TextMeshProUGUI securityDisplay;
    [SerializeField] private TextMeshProUGUI lightLevelDisplay;

    #region EventSubbing
    private void OnEnable()
    {
        IGameStartSetupModule.OnGameStart += UpdateAllResourceUI;
        GameUIManager.GameUIManagerInstance.UpdateResourceUI += UpdateAllResourceUI;
        GameUIManager.GameUIManagerInstance.UpdateSpecificResourceUI += UpdateSpecificResourceUI;
    }
    private void OnDisable()
    {
        IGameStartSetupModule.OnGameStart -= UpdateAllResourceUI;
        GameUIManager.GameUIManagerInstance.UpdateResourceUI -= UpdateAllResourceUI;
        GameUIManager.GameUIManagerInstance.UpdateSpecificResourceUI -= UpdateSpecificResourceUI;
    }
    #endregion

    public void UpdateAllResourceUI()
    {
        Debug.Log("Updating all resource UI");
        foodDisplay.text = GlobalDictionary.GlobalDictionaryInstance.GetResource(ResourceData.ResourceType.Food).Amount.ToString();
        waterDisplay.text = GlobalDictionary.GlobalDictionaryInstance.GetResource(ResourceData.ResourceType.Water).Amount.ToString();
        moneyDisplay.text = GlobalDictionary.GlobalDictionaryInstance.GetResource(ResourceData.ResourceType.Money).Amount.ToString();
        happinessDisplay.text = GlobalDictionary.GlobalDictionaryInstance.GetResource(ResourceData.ResourceType.Happiness).Amount.ToString();
        securityDisplay.text = GlobalDictionary.GlobalDictionaryInstance.GetResource(ResourceData.ResourceType.Security).Amount.ToString();
        lightLevelDisplay.text = GlobalDictionary.GlobalDictionaryInstance.GetResource(ResourceData.ResourceType.LightLevel).Amount.ToString();    
    
    }

    public void UpdateSpecificResourceUI(ResourceData.ResourceType resourceType)
    {
        switch (resourceType)
        {
            case ResourceData.ResourceType.Food:
                foodDisplay.text = ("Food: " + GlobalDictionary.GlobalDictionaryInstance.GetResource(ResourceData.ResourceType.Food).Amount.ToString());
                break;
            case ResourceData.ResourceType.Water:
                waterDisplay.text = ("Water: " + GlobalDictionary.GlobalDictionaryInstance.GetResource(ResourceData.ResourceType.Water).Amount.ToString());
                break;
            case ResourceData.ResourceType.Money:
                moneyDisplay.text = ("Money: " + GlobalDictionary.GlobalDictionaryInstance.GetResource(ResourceData.ResourceType.Money).Amount.ToString());
                break;
            case ResourceData.ResourceType.Happiness:
                moneyDisplay.text = ("Money: " + GlobalDictionary.GlobalDictionaryInstance.GetResource(ResourceData.ResourceType.Happiness).Amount.ToString());
                break;
            case ResourceData.ResourceType.Security:
                moneyDisplay.text = ("Money: " + GlobalDictionary.GlobalDictionaryInstance.GetResource(ResourceData.ResourceType.Security).Amount.ToString());
                break;
            case ResourceData.ResourceType.LightLevel:
                moneyDisplay.text = ("Money: " + GlobalDictionary.GlobalDictionaryInstance.GetResource(ResourceData.ResourceType.LightLevel).Amount.ToString());
                break;
        }
    }

}

