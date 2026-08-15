using NUnit.Framework;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Runtime.CompilerServices;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.Progress;

public class POIPlacer : MonoBehaviour, IGameModule
{
    private POIPlacer POIPlacerInstance { get; set; }

    [SerializeField] private GameObject _layoutPoolObject;
    [SerializeField] private GameObject _poiLayout;
    [SerializeField] private GameObject[] _poiLayoutArray;

    private GenericObjectPool _layoutPool;

    private void Start()
    {
        if (_layoutPool == null)
        {
            _layoutPool = _layoutPoolObject.GetComponent<GenericObjectPool>();
        }
        #region SingletonSetup
        //DontDestroyOnLoad(gameObject);
        if (POIPlacerInstance != null && POIPlacerInstance != this)
        {
            Destroy(gameObject);
            return;
        }
        POIPlacerInstance = this;
        #endregion

        
    }

    public void InitializeModule()
    {
        SetPoiLayout();
        GetLayoutsChildren();
        //GiveLayoutsChildrenPois(transformArray);
        Debug.Log("Intializing PoiPlacer");
    }

    public void ResetModule()
    {

    }

    public void UpdateModule()
    {
        SetPoiLayout();
        GetLayoutsChildren();
        //GiveLayoutsChildrenPois(transformArray);
    }

    private void SetPoiLayout()
    {
        if (_poiLayout == null)
        {
            Destroy(_poiLayout);
        }
        _poiLayout = Instantiate(_poiLayoutArray[Random.Range(0, _poiLayoutArray.Length)], _poiLayout.transform);        
    }

    private void GetLayoutsChildren()
    {
        if (_layoutPool == null)
        {
            _layoutPool = _layoutPoolObject.GetComponent<GenericObjectPool>();
        }
        PhysicalPointOfInterest[] rawPoiArray = _poiLayout.GetComponentsInChildren<PhysicalPointOfInterest>();
        ConvertArrayToGameObject(rawPoiArray, out GameObject[] poiArray);

        if (poiArray == null)
        {
            Debug.Log("null poiArray");
        }
    }
    private void ConvertArrayToGameObject(PhysicalPointOfInterest[] arrayToConvert, out GameObject[] poiArray)
    {
        List<GameObject> poiFilterList = new List<GameObject>();
        foreach (var item in arrayToConvert)
        {
            if (item == null)
            {
                Debug.Log("item in arrayToConvert is null");
            }
            RunPoiLogic(item.stageInLevel, item.transform, out GameObject pooledGameObject);
            item.gameObject.SetActive(false);
            poiFilterList.Add(pooledGameObject);

        }
        poiArray = poiFilterList.ToArray();
    }

    private void RunPoiLogic(int stageInlevel, Transform transform, out GameObject pooledGameObject)
    {
        pooledGameObject = _layoutPool.GetPooledObject();
        if (pooledGameObject == null)
        {
            Debug.Log("pooled object is null");
        }
        pooledGameObject.GetComponent<IResettable>().TriggerReset();
        pooledGameObject.transform.position = transform.position;
        PhysicalPointOfInterest physicalPointOfInterest = pooledGameObject.GetComponent<PhysicalPointOfInterest>();
        physicalPointOfInterest.stageInLevel = stageInlevel;
        pooledGameObject.SetActive(true);
    }
}
