using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string sceneToLoad;

    public GameObject settings;

    public void PlayButton()
    {
        SceneManager.LoadScene(sceneToLoad);
    }

    public void SettingsButton()
    {
        settings.SetActive(true);
    }
    
    public void CloseSettingsButton()
    {
        settings.SetActive(false);
    }

    public void QuitButton()
    {
        Application.Quit();
    }
}
