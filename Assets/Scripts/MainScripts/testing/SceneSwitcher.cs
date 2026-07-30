using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    private void Start()
    {
        DontDestroyOnLoad(this);
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
    }
}
