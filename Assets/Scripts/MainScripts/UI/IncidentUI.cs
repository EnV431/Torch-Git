using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.Rendering.VolumeComponent;

public class IncidentUI : MonoBehaviour
{
    [SerializeField]private GameObject incidentContainer;
    [SerializeField] private Image incidentImage;
    [SerializeField] private TextMeshProUGUI nameOfIncidientT;
    [SerializeField] private TextMeshProUGUI descriptionOfIncidenetT;
    [SerializeField] private TextMeshProUGUI resultOfIncidientT;

    [SerializeField] private Button closePopupB;

    private void OnEnable()
    {
        GameUIManager.GameUIManagerInstance.ShowIncidentUI += EnableIncidentUI;
    }
    private void OnDisable()
    {
        GameUIManager.GameUIManagerInstance.ShowIncidentUI -= EnableIncidentUI;
    }

    private void EnableIncidentUI(IncidentData incidentData)
    { 
        incidentContainer.SetActive(true);
        incidentImage.sprite = incidentData.IncidentDetails.incidentImage;
        nameOfIncidientT.text = incidentData.IncidentDetails.incidentName;
        descriptionOfIncidenetT.text = incidentData.IncidentDetails.incidentDescription;
        resultOfIncidientT.text = GetResultInfoFromDataType(incidentData);
    }
    public void DisableIncidentUI()
    {
        incidentContainer.SetActive(false);
    }

    private string GetResultInfoFromDataType(IncidentData ogIncidentData)
    {
        if (ogIncidentData == null)
        {
            Debug.Log("Incidenet Data is null when trying to get incident data type in incident UI");
            return null;
        }

        switch (ogIncidentData)
        {
            case ResourceIncidentData:                
                return GetResultInfoFromResourceIncident(ogIncidentData as ResourceIncidentData);

            default:
                return " only generic inicdent data found";
        }
    }

    private string GetResultInfoFromResourceIncident(ResourceIncidentData resourceIncidentData)
    {
        string incidentResults = string.Empty;
        int amount = -1;
        foreach (var item in resourceIncidentData.resourceChangesArray)
        {
            amount++;
            incidentResults += resourceIncidentData.resourceChangesArray[amount].resourceType.ToString() + " " + resourceIncidentData.resourceChangesArray[amount].amountToChange + " : ";
        }
        return incidentResults;    
    }



}
