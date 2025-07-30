using UnityEngine;

public class InGameUIManager : MonoBehaviour
{
    [SerializeField] private CanvasGroup _gameOverPanelCG;
    [SerializeField] private CanvasGroup _pauseMenuCG; // Lis‰‰ t‰m‰ Inspectorissa

    private CanvasGroup _cg;
    private bool _isPaused = false;

    private void Awake()
    {
        _cg = GetComponent<CanvasGroup>();
        SetCanvasGroupState(_cg, false);
        SetCanvasGroupState(_pauseMenuCG, false);
        SetCanvasGroupState(_gameOverPanelCG, false);
    }

    private void Update()
    {
        if (GameManager.Instance.GameIsRunning && Input.GetKeyDown(KeyCode.Escape))
        {
            if (_isPaused)
                ResumeGame();
            else
                PauseGame();
        }
    }

    public void ShowInGameUI()
    {
        SetCanvasGroupState(_cg, true);
    }

    public void ShowGameOverPanel()
    {
        SetCanvasGroupState(_gameOverPanelCG, true);
    }

    public void ReturnToMainMenu()
    {
        Time.timeScale = 1f;
        GameManager.Instance.ResetGame();
    }

    public void ResumeGame()
    {
        SetCanvasGroupState(_pauseMenuCG, false);
        Time.timeScale = 1f;
        _isPaused = false;
    }

    private void PauseGame()
    {
        SetCanvasGroupState(_pauseMenuCG, true);
        Time.timeScale = 0f;
        _isPaused = true;
    }

    private void SetCanvasGroupState(CanvasGroup canvasGroup, bool state)
    {
        canvasGroup.alpha = state ? 1f : 0f;
        canvasGroup.interactable = state;
        canvasGroup.blocksRaycasts = state;
    }
}
