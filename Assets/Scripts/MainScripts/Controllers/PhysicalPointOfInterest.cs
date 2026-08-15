using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using SAE.PAX.Torch.Party;

public class PhysicalPointOfInterest : MonoBehaviour, IResettable
{
    private PointOfInterest pointOfInterest;
    private Image mainImage;
    private TextMeshProUGUI dangerLevelText;
    public int stageInLevel; //temporary system (stage in level manual setup)
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
        
        if (dangerLevelText == null)
        {
            dangerLevelText = GetComponentInChildren<TextMeshProUGUI>();
            if (dangerLevelText == null)
            {
                Debug.Log("danger level text is null right after assigning via getcomponetn in childrne");
            }
        }
        if (mainImage == null)
        {
            mainImage = GetComponentInChildren<Image>();
            mainImage.sprite = GameUIManager.GameUIManagerInstance.GetSprite("DefualtPOI");
        }
        dangerLevelText.text = pointOfInterest.pointOfInterestData.poiDangerlevel.ToString() + " Danger";
        DisablePopupUI();

    }

    private void EnablePopupUI()
    {
        dangerLevelText.gameObject.SetActive(true);
    }
    private void DisablePopupUI()
    {
        dangerLevelText.gameObject.SetActive(false);
    }

    public void ResetPOI()
    {
        if (pointOfInterest != null)
        {
            pointOfInterest = null;
        }
        
        GetPointOfInterest();
        LoadUIElements();
        if (pointOfInterest == null)
        {
            Debug.Log("poi is null");
        }
    }

    public void TriggerReset()
    { 
        ResetPOI();    
    }

}
