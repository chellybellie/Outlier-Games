using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
public class OptionsMenu : MonoBehaviour
{
    public GameObject op;

    public Toggle fullscreenToggle;
    public Dropdown resolutionDropdown;
    public Dropdown TextureQualityDropdown;
    public Dropdown AADropdown;
    public Dropdown vSyncDropdown;
    public Slider musicSlider;
    public Button applyButton;

    public  AudioSource musicSource;
    public Resolution[] resolutions;

    public GameSettings gameSettings;
    public void OpenOptions()
    {
        op.SetActive(true);
    }

    public void CloseOptions()
    {
        op.SetActive(false);
    }
    void OnEnable()
    {
        gameSettings = new GameSettings();

        fullscreenToggle.onValueChanged.AddListener(delegate { OnFullscreenToggle(); });
        resolutionDropdown.onValueChanged.AddListener(delegate { OnResolutionChange(); });
        TextureQualityDropdown.onValueChanged.AddListener(delegate { OnTextureChange(); });
        AADropdown.onValueChanged.AddListener(delegate { OnAAChange(); });
        vSyncDropdown.onValueChanged.AddListener(delegate { OnvSyncChange(); });
        musicSlider.onValueChanged.AddListener(delegate { OnMusicChange(); });
        applyButton.onClick.AddListener(delegate { OnApply(); });

        resolutions = Screen.resolutions;
        foreach(Resolution resolution in resolutions)
        {
            resolutionDropdown.options.Add(new Dropdown.OptionData(resolution.ToString()));
        }
        LoadSettings();
    }

    public void OnFullscreenToggle()
    {
        gameSettings.fullscreen = Screen.fullScreen = fullscreenToggle.isOn;
    }

    public void OnResolutionChange()
    {
        Screen.SetResolution(resolutions[resolutionDropdown.value].width, resolutions[resolutionDropdown.value].height, Screen.fullScreen);
        gameSettings.resolutionIndex = resolutionDropdown.value;
    }

    public void OnTextureChange()
    {
        QualitySettings.masterTextureLimit = gameSettings.textureQuality = TextureQualityDropdown.value;
        
    }

    public void OnAAChange()
    {
        QualitySettings.antiAliasing = gameSettings.antialiasing = (int)Mathf.Pow(2f, AADropdown.value);
    }

    public void OnvSyncChange()
    {
        QualitySettings.vSyncCount = gameSettings.vSync = vSyncDropdown.value;
    }

    public void OnMusicChange()
    {
        musicSource.volume = gameSettings.musicVolume = musicSlider.value;
    }

    public void OnApply()
    {
        SaveSettings();
    }

    public void SaveSettings()
    {
        string jsonData = JsonUtility.ToJson(gameSettings, true);
        File.WriteAllText(Application.persistentDataPath + "/gamesettings.json", jsonData);
    }
    public void LoadSettings()
    {
        gameSettings = JsonUtility.FromJson<GameSettings>(File.ReadAllText(Application.persistentDataPath + "/gamesettings.json"));
        musicSlider.value = gameSettings.musicVolume;
        AADropdown.value = gameSettings.antialiasing;
        vSyncDropdown.value = gameSettings.vSync;
        TextureQualityDropdown.value = gameSettings.textureQuality;
        resolutionDropdown.value = gameSettings.resolutionIndex;
        fullscreenToggle.isOn = gameSettings.fullscreen;
        Screen.fullScreen = gameSettings.fullscreen;

        resolutionDropdown.RefreshShownValue();
    }

}
