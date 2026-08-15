using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PhysicalPointOfInterest : MonoBehaviour
{
    private PointOfInterest pointOfInterest;
    private Image mainImage;
    private TextMeshProUGUI dangerLevelText;
    [SerializeField] private int stageInLevel; //temporary system (stage in level manual setup)
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Party"))
        {
            Debug.Log("Running point of interest logic");
            pointOfInterest.RunPointOfInterestLogic(); 
        }
    }
    
    private void OnMouseDown()
    {
        if (PartyController.currentStageInlevel > stageInLevel || PartyController.currentStageInlevel < stageInLevel)
        {
            return;
        }
        if (PartyController.canPartyMove == true)
        {
            //Debug.Log("Trying To move party from POI");
            PartyController.movePartyTo(gameObject);
        }       
        
    }

    private void OnMouseEnter()
    {
        EnablePopupUI();
    }
    private void OnMouseExit()
    {
        DisablePopupUI();
    }

    private void Start()
    {
        GetPointOfInterest();
        if (pointOfInterest == null|| pointOfInterest.pointOfInterestData == null)
        {
            Debug.LogError("PointOfInterest or its data is not assigned.");
            return;
        }
        LoadUIElements();
        //Debug.Log(pointOfInterest.pointOfInterestData.name);
    }

    private void GetPointOfInterest()
    {
        PointOfInterestData poiData = GameDatabase.GameDatabaseInstance.PointOfInterestDataList[Random.Range(0, GameDatabase.GameDatabaseInstance.PointOfInterestDataList.Count)];
        pointOfInterest = GlobalDictionary.GlobalDictionaryInstance.GetPointOfInterest(poiData.name);
    }
    private void LoadUIElements()
    {
        mainImage = GetComponentInChildren<Image>();

        dangerLevelText = GetComponentInChildren<TextMeshProUGUI>();
        dangerLevelText.text = pointOfInterest.pointOfInterestData.poiDangerlevel.ToString() + " Danger";
        dangerLevelText.gameObject.SetActive(false);
    }

    private void EnablePopupUI()
    {
        dangerLevelText.gameObject.SetActive(true);
    }
    private void DisablePopupUI()
    {
        dangerLevelText.gameObject.SetActive(false);
    }

}
