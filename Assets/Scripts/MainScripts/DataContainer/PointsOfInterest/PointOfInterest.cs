using Unity.VisualScripting;
using UnityEngine;

public class PointOfInterest : MonoBehaviour
{
    private bool isCompleted = false;
    public PointOfInterestData pointOfInterestData;
    #region UnityFuncs
    private void Start()
    {
        if (pointOfInterestData == null)
        {
            Debug.LogError("PointOfInterestData is not assigned.");
            return;
        }
        gameObject.name = pointOfInterestData.name;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Party"))
        {
            RunPointOfInterestLogic();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        isCompleted = true;
    }
    #endregion
    private void RunPointOfInterestLogic()
    {
        if (isCompleted != false) return;

        UpdatePointOfInterestUI();


    }

    private void UpdatePointOfInterestUI()
    { 
        GlobalUIManager.GlobalUIManagerInstance.UpdatePointOfInterestUI?.Invoke(pointOfInterestData);
    }



}
