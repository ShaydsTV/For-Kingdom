using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverUI;
    public GameObject pauseMenuUI;

    public static GameManager instance;

    public static bool isMenuDisplayed = false;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("There is more than one instance of GameOverManager in the scene.");
            return;
        }
        instance = this;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            OnPauseMenu();
        }

        // if menu is displayed, time = 0 to pause the game.
        // else, resume the time = 1 to unpause the game.
        if (isMenuDisplayed)
        {
            Time.timeScale = 0;
        } else
        {
            Time.timeScale = 1;
        }
    }

    private void OnPauseMenu()
    {
        PlayerController.instance.enabled = isMenuDisplayed;
        pauseMenuUI.SetActive(!isMenuDisplayed);
        isMenuDisplayed = !isMenuDisplayed;
    }

    public void OnPlayerDeath()
    {
        if (CurrentSceneManager.instance.isPlayerEnabled)
        {
            DontDestroyOnLoadScene.instance.RemoveFromDontDestroyOnLoad();
        }
        gameOverUI.SetActive(true);
    }

    public void OnClickRetryButton()
    {
        Inventory.instance.RemoveCoin(CurrentSceneManager.instance.coinsPickedUp);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        PlayerStatsController.instance.Respawn();
        gameOverUI.SetActive(false);
    }

    public void OnClickMenuButton()
    {
        DontDestroyOnLoadScene.instance.RemoveFromDontDestroyOnLoad();
        OnPauseMenu();
        SceneManager.LoadScene("Main Menu");
    }

    public void OnClickQuitButton()
    {
        Application.Quit();
    }

    public void OnClickResumeButton()
    {
        OnPauseMenu();
    }
}
