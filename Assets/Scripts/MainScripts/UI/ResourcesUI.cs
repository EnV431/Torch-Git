using TMPro;
using UnityEngine;

public class ResourcesUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI foodDisplay;
    [SerializeField] private TextMeshProUGUI waterDisplay;
    [SerializeField] private TextMeshProUGUI moneyDisplay;

    #region EventSubbing
    private void OnEnable()
    {
        IGameStartSetupModule.OnGameStart += UpdateAllResourceUI;
    }
    private void OnDisable()
    {
        IGameStartSetupModule.OnGameStart -= UpdateAllResourceUI;
    }
    #endregion

    public void UpdateAllResourceUI()
    {
        Debug.Log("Updating all resource UI");
        foodDisplay.text = GlobalDictionary.GlobalDictionaryInstance.GetResource(ResourceData.ResourceType.Food).Amount.ToString();
        waterDisplay.text = GlobalDictionary.GlobalDictionaryInstance.GetResource(ResourceData.ResourceType.Water).Amount.ToString();
        moneyDisplay.text = GlobalDictionary.GlobalDictionaryInstance.GetResource(ResourceData.ResourceType.Money).Amount.ToString();    
    
    }

    public void UpdateSpecificResourceUI(ResourceData.ResourceType resourceType)
    {
        switch (resourceType)
        {
            case ResourceData.ResourceType.Food:
                foodDisplay.text = GlobalDictionary.GlobalDictionaryInstance.GetResource(ResourceData.ResourceType.Food).Amount.ToString();
                break;
            case ResourceData.ResourceType.Water:
                waterDisplay.text = GlobalDictionary.GlobalDictionaryInstance.GetResource(ResourceData.ResourceType.Water).Amount.ToString();
                break;
            case ResourceData.ResourceType.Money:
                moneyDisplay.text = GlobalDictionary.GlobalDictionaryInstance.GetResource(ResourceData.ResourceType.Money).Amount.ToString();
                break;

        }
    }

}

