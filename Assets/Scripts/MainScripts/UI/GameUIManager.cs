using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class GameUIManager : MonoBehaviour
{
    public static GameUIManager GameUIManagerInstance { get; set; }

    public Action UpdateAllUI;
    public Action UpdateResourceUI;
    public Action<ResourceData.ResourceType> UpdateSpecificResourceUI;
    public event Action<IncidentData> ShowIncidentUI; //the event keyword makes it so outside scrtipts can subsribe but not invoke

    void Awake()
    {
        #region SingletonSetup
        DontDestroyOnLoad(gameObject);
        if (GameUIManagerInstance != null && GameUIManagerInstance != this)
        {
            Destroy(gameObject);
            return;
        }
        GameUIManagerInstance = this;
        #endregion
    }

    public void InvokeShowIncidentUI(IncidentData incidentData)
    {
        ShowIncidentUI.Invoke(incidentData);    
    }




}
