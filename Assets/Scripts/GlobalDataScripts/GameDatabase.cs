using UnityEngine;
using System;
using System.Collections.Generic;


public class GameDatabase : MonoBehaviour 
{
    public static GameDatabase GameDatabaseInstance { get; set; }
    #region TheBig4Arrays
    [SerializeField]private ResourceData[] resourceDataList;
    [SerializeField]private IncidentData[] incidentDataList;
    [SerializeField]private CharacterData[] characterDataList;
    #endregion

    [SerializeField]private PointOfInterestData[] pointOfInterestDataList;
    [SerializeField]private TraitData[] traitDataList;

    public IReadOnlyList<ResourceData> ResourceDataList => resourceDataList; //makes it a public readonly
    public IReadOnlyList<IncidentData> IncidentDataList => incidentDataList; //makes it a public readonly
    public IReadOnlyList<CharacterData> CharacterDataList => characterDataList; //makes it a public readonly

    public IReadOnlyList<PointOfInterestData> PointOfInterestDataList => pointOfInterestDataList;
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