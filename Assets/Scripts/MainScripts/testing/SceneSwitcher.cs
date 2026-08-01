using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    public static SceneSwitcher sceneSwitcher { get; set; }
    private void Start()
    {
        DontDestroyOnLoad(this);
        if (sceneSwitcher != null && sceneSwitcher != this)
        {
            Destroy(gameObject);
            return;
        }
        sceneSwitcher = this;
    }
    private void Update()
    {
        if (Keyboard.current.digit0Key.wasReleasedThisFrame)
        {
            SceneManager.LoadScene(0);
        }
        if (Keyboard.current.digit1Key.wasReleasedThisFrame)
        {
            SceneManager.LoadScene(1);
        }

        if (Keyboard.current.digit9Key.wasReleasedThisFrame)
        {
            GlobalDictionary.GlobalDictionaryInstance.TriggerIncident("Mold Outbreak");
        }

    }
}
