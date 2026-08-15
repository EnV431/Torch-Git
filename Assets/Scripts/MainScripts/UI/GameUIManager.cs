using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GameUIManager : MonoBehaviour
{
    public static GameUIManager GameUIManagerInstance { get; set; }

    public GameObject IncidentUIGameObject; //DEMO
    public GameObject CharacterUIGameObject; //DEMO
    public Dictionary<string, Sprite> spriteDict = new();

    [SerializeField]private Sprite[] poiSprites;

    public Action UpdateAllUI;
    public Action UpdateResourceUI;
    public Action<ResourceData.ResourceType> UpdateSpecificResourceUI;
    public event Action<IncidentData> ShowIncidentUI; //the event keyword makes it so outside scrtipts can subsribe but not invoke
    public event Action ShowCharacterUI; //DEMO SETUP

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

        #region LoadSpritesToSpriteDict

        foreach (Sprite item in poiSprites)
        {
            spriteDict.Add(item.name, item); 
        }

        #endregion

    }

    public void InvokeShowIncidentUI(IncidentData incidentData)
    {
        if (ShowIncidentUI == null)
        {
            Debug.Log("ShowIncidentUI is null");
        }
        ShowIncidentUI?.Invoke(incidentData);

    }
    public void InvokeShowCharacterUI() //DEMO need to update function and event = DEMO SETUP
    {
        if (ShowCharacterUI == null)
        {
            Debug.Log("ShowCharacterUI is null");
        }
        ShowCharacterUI?.Invoke();

    }

    public Sprite GetSprite(string key)
    {
        if (spriteDict.ContainsKey(key + "_0"))
        {
            spriteDict.TryGetValue(key + "_0", out Sprite value);
            return value;
        }
        Debug.Log("spriteDict doesnt contain key " + key);
        return null;
    }


}
