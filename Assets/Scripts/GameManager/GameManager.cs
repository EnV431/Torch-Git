using UnityEngine;
using System.Collections.Generic;
using Unity.VisualScripting;
using System;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static GameManager GameManagerInstance { get; set; }

    private Dictionary<Type, IGameModule> gameModulesDictionary = new Dictionary<Type, IGameModule>();
    [SerializeField] private List<IGameModule> gameModuleList = new();
    private void Start() //needs to run on start so that events can be subscribved to before init the module
    {
        #region SingletonSetup
        DontDestroyOnLoad(gameObject); 
        if (GameManagerInstance != null && GameManagerInstance != this)
        {
            Destroy(gameObject);
            return;
        }
        GameManagerInstance = this;
        #endregion

        #region LoadModulesToDictionary
        gameModulesDictionary.Clear();
        gameModuleList.AddRange(GetComponents<IGameModule>());
        #endregion


        foreach (var module in gameModuleList)
        {
            gameModulesDictionary.Add(module.GetType(), module); //add module to dict
            //Debug.Log(module + " added to dict");
            module.InitializeModule(); //inits module
        }
    }
    public T GetModule<T>() where T : class, IGameModule //public lookup method
    {
        if (gameModulesDictionary.TryGetValue(typeof(T), out var module))
        {
            return module as T;
        }
        else Debug.Log(" Game Module not found in Dictionary"); return null;
    }

    public void ResetScene()
    {
        TriggerModuleUpdate();
        SceneManager.LoadScene("Game");
    }
    private void TriggerModuleUpdate()
    {
        foreach (IGameModule item in gameModuleList)
        {
            item.UpdateModule();
        }
    }



}
