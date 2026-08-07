using UnityEngine;

public class PhysicalPointOfInterest : MonoBehaviour
{
    private PointOfInterest pointOfInterest;

    private void Start()
    {
        if (pointOfInterest.pointOfInterestData == null)
        {
            Debug.LogError("PointOfInterestData is not assigned.");
            return;
        }
        pointOfInterest.RunPointOfInterestLogic();
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
