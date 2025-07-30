using UnityEngine;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{
    [SerializeField] private Slider _mainSlider;
    [SerializeField] private Slider _musicSlider;
    [SerializeField] private Slider _sfxSlider;

    private const float MAIN_DEFAULT_VOLUME = 0.5f;
    private const float MUSIC_DEFAULT_VOLUME = 1f;
    private const float SFX_DEFAULT_VOLUME = 1f;

    private void Start()
    {
        _mainSlider.value = PlayerPrefs.GetFloat("Settings.MasterVolume", MAIN_DEFAULT_VOLUME);
        _musicSlider.value = PlayerPrefs.GetFloat("Settings.MusicVolume", MUSIC_DEFAULT_VOLUME);
        _sfxSlider.value = PlayerPrefs.GetFloat("Settings.SFXVolume", SFX_DEFAULT_VOLUME);
    }

    public void ChangeMainVolume(float newVol)
    {
        AudioManager.Instance.ChangeMasterVolume(newVol);
    }

    public void ChangeMusicVolume(float newVol)
    {
        AudioManager.Instance.ChangeMusicVolume(newVol);
    }

    public void ChangeSFXVolume(float newVol)
    {
        AudioManager.Instance.ChangeSFXVolume(newVol);
    }
}
