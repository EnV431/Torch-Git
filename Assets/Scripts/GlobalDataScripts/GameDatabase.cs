using UnityEngine;
using System;
using System.Collections.Generic;


public class GameDatabase : MonoBehaviour 
{
    public static GameDatabase GameDatabaseInstance { get; set; }

    [SerializeField]private List<ResourceData> resourceDataList;
    [SerializeField]private List<IncidentData> incidentDataList;

   public IReadOnlyList<ResourceData> ResourceDataList => resourceDataList; //makes it a public readonly
   public IReadOnlyList<IncidentData> IncidentDataList => incidentDataList; //makes it a public readonly
    //Public ItemDataList,
    //Public CharacterDataList,

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