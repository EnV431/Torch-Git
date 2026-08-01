using System;
using UnityEngine;

public class GlobalUIManager : MonoBehaviour
{
    public static GlobalUIManager GlobalUIManagerInstance { get; set; }

    public Action UpdateAllUI;
    public Action UpdateResourceUI;
    public Action<ResourceData.ResourceType> UpdateSpecificResourceUI;

    void Awake()
    {
        #region SingletonSetup
        DontDestroyOnLoad(gameObject);
        if (GlobalUIManagerInstance != null && GlobalUIManagerInstance != this)
        {
            Destroy(gameObject);
            return;
        }
        GlobalUIManagerInstance = this;
        #endregion
    }


}
