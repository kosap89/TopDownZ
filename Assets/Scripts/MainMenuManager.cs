using UnityEngine;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] private CanvasGroup _mainMenuButtonsCG;
    [SerializeField] private CanvasGroup _quitConfirmationCG;
    [SerializeField] private CanvasGroup _settingsMenuCG;

    CanvasGroup _mainMenuCG;

    private void Awake()
    {
        _mainMenuCG = GetComponent<CanvasGroup>();
        OpenMainMenu();
    }

    public void OpenMainMenu()
    {
        CanvasGroupSetState(_mainMenuCG, true);
    }

    public void CloseMainMenu()
    {
        CanvasGroupSetState(_mainMenuCG, false);
    }

    public void OpenQuitConfirmation()
    {
        CanvasGroupSetState(_mainMenuButtonsCG, false);
        CanvasGroupSetState(_quitConfirmationCG, true);
    }

    public void CloseQuitConfirmation()
    {
        CanvasGroupSetState(_quitConfirmationCG, false);
        CanvasGroupSetState(_mainMenuButtonsCG, true);
    }

    [SerializeField] private GameObject _backButtonGO;

    public void OpenSettingsMenu()
    {
        CanvasGroupSetState(_mainMenuButtonsCG, false);
        CanvasGroupSetState(_settingsMenuCG, true);
        _backButtonGO.SetActive(true); // N‰ytet‰‰n nappi
    }

    public void CloseSettingsMenu()
    {
        CanvasGroupSetState(_settingsMenuCG, false);
        CanvasGroupSetState(_mainMenuButtonsCG, true);
        _backButtonGO.SetActive(false); // Piilotetaan nappi
    }



    public void Play()
    {
        CloseMainMenu();
        GameManager.Instance.StartGame();
    }


    public void Quit()
    {
        Application.Quit();

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }

    private void CanvasGroupSetState(CanvasGroup canvasGroup, bool state)
    {
        canvasGroup.alpha = state ? 1f : 0f;
        canvasGroup.interactable = state;
        canvasGroup.blocksRaycasts = state;
    }
}
