using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject gameMenu;

    public void PlayGame()
    {
        mainMenu.SetActive(false);
        gameMenu.SetActive(true);
    }

    public void ReturnToMainMenu()
    {
        mainMenu.SetActive(true);
        gameMenu.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
    

    
    
}
