using UnityEngine;
using System;
using System.Collections.Generic;


public class GameDatabase : MonoBehaviour 
{
    public static GameDatabase GameDatabaseInstance { get; set; }

    [SerializeField]private List<ResourceData> resourceDataList;




   public IReadOnlyList<ResourceData> ResourceDataList => resourceDataList; //makes it a public readonly
    //Public ItemDataList,
    //Public CharacterDataList,
    //Public EventDataList



    private void Awake()
    {
        #region SingletonSetup
        DontDestroyOnLoad(gameObject);
        if (GameDatabaseInstance != null && GameDatabaseInstance != this)
        {
            Destroy(gameObject);
            return;
        }
        GameDatabaseInstance = this;
        #endregion


    }


}