using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] GameObject mainMenu;
    [SerializeField] GameObject settings;

    public void ShowMainMenu()
    {
        mainMenu.SetActive(true);
        settings.SetActive(false);
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void OpenSettings()
    {
        mainMenu.SetActive(false);
        settings.SetActive(true);
    }
}
