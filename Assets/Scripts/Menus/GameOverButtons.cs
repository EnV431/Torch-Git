using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverButtons : MonoBehaviour
{
    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");    
    }
    public void Quit()
    {
        Application.Quit();  
    }
    public void CloseGameObject()
    { 
        gameObject.SetActive(false);
    }

}
