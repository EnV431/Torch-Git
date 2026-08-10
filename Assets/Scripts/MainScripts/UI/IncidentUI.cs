using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class IncidentUI : MonoBehaviour
{
    [SerializeField]private GameObject incidentUIEmpty;
    [SerializeField] private Image incidentImage;
    [SerializeField] private TextMeshProUGUI nameOfIncidientT;
    [SerializeField] private TextMeshProUGUI descriptionOfIncidenetT;
    [SerializeField] private TextMeshProUGUI resultOfIncidientT;

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
        incidentUIEmpty.SetActive(true);
        incidentImage.sprite = incidentData.IncidentDetails.incidentImage;
        nameOfIncidientT.text = incidentData.IncidentDetails.incidentName;
        descriptionOfIncidenetT.text = incidentData.IncidentDetails.incidentDescription;
        
    }

    //need to add a func that gets the type of incidentData so can show result sof thingy


}
