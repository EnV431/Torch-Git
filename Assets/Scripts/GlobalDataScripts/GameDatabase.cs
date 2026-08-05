using UnityEngine;
using System;
using System.Collections.Generic;


public class GameDatabase : MonoBehaviour 
{
    public static GameDatabase GameDatabaseInstance { get; set; }
    #region TheBig4Lists
    [SerializeField]private List<ResourceData> resourceDataList;
    [SerializeField]private List<IncidentData> incidentDataList;
    [SerializeField]private List<CharacterData> characterDataList;
    #endregion

    [SerializeField]private List<TraitData> traitDataList;

    public IReadOnlyList<ResourceData> ResourceDataList => resourceDataList; //makes it a public readonly
    public IReadOnlyList<IncidentData> IncidentDataList => incidentDataList; //makes it a public readonly
    public IReadOnlyList<CharacterData> CharacterDataList => characterDataList; //makes it a public readonly


    public IReadOnlyList<TraitData> TraitDataList => traitDataList; //makes it a public readonly   
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