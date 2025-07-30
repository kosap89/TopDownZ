using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public bool GameIsRunning { get; private set; }


    [SerializeField] private MainMenuManager _mainMenuManager;
    [SerializeField] private InGameUIManager _inGameUIManager;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(this);
            return;
        }

        Instance = this;

        Time.timeScale = 0f;
    }

    public void GameOver()
    {
        Time.timeScale = 0f;
        GameIsRunning = false;
        _inGameUIManager.ShowGameOverPanel();
    }


    public void StartGame()
    {
        Time.timeScale = 1f;
        GameIsRunning = true;
        _inGameUIManager.ShowInGameUI();
    }


    public void ResetGame()
    {
        SceneManager.LoadScene(0);
    }
}
