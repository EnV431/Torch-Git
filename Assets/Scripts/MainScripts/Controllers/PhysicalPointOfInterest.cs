using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PhysicalPointOfInterest : MonoBehaviour
{
    private PointOfInterest pointOfInterest;
    private Image mainImage;
    private TextMeshProUGUI dangerLevelText;

    private void Start()
    {
        GetPointOfInterest();
        if (pointOfInterest == null|| pointOfInterest.pointOfInterestData == null)
        {
            Debug.LogError("PointOfInterest or its data is not assigned.");
            return;
        }
        LoadUIElements();
        pointOfInterest.RunPointOfInterestLogic();
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
        dangerLevelText.text = pointOfInterest.pointOfInterestData.poiDangerlevel.ToString();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Party"))
        {
            pointOfInterest.RunPointOfInterestLogic();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        pointOfInterest.isCompleted = true;
    }
}
