using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

[RequireComponent(typeof(GenericObjectPool))]
public class POIPlacer : MonoBehaviour, IGameModule
{
    private POIPlacer POIPlacerInstance { get; set; }

    [SerializeField] private GameObject _poiLayout;
    [SerializeField] private GameObject[] _poiLayoutArray;

    private GenericObjectPool _layoutPool;

    private void Start()
    {
        #region SingletonSetup
        //DontDestroyOnLoad(gameObject);
        if (POIPlacerInstance != null && POIPlacerInstance != this)
        {
            Destroy(gameObject);
            return;
        }
        POIPlacerInstance = this;
        #endregion

        _layoutPool = GetComponent<GenericObjectPool>();
        if (_layoutPool == null)
        {
            Debug.Log("layout pool is null");
        }
    }

    public void InitializeModule()
    {       
        SetPoiLayout();

        
    }

    public void ResetModule()
    {
        
    }

    public void UpdateModule()
    { 
        
    
    }

    private void SetPoiLayout()
    { 
        _poiLayout = _poiLayoutArray[Random.Range(0, _poiLayoutArray.Length)];        
    }

    private Transform[] GetLayoutsChildren()
    {
        Transform[] poiArray = _poiLayout.GetComponentsInChildren<Transform>();
        return poiArray;
    }

    private void GiveLayoutsChildrenPois(Transform[] transformArray)
    {
        foreach (var item in transformArray)
        {
            
        }

    }
}
