using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingMenuController : MonoBehaviour
{
    // Mixer property
    public AudioMixer audioMixer;

    // Slider
    public Slider slider;

    // Resolutions
    public Dropdown resolutionDropdown;
    Resolution[] resolutions;

    // Start is called before the first frame update
    void Start()
    {
        // full screen and resolution
        if (PlayerPrefs.GetInt("fullscreen") == 0)
        {
            Screen.SetResolution(PlayerPrefs.GetInt("resolution width"), PlayerPrefs.GetInt("resolution height"), false);
        }
        else
        {
            Screen.SetResolution(PlayerPrefs.GetInt("resolution width"), PlayerPrefs.GetInt("resolution height"), true);
        }

        if (PlayerPrefs.HasKey("bgVolume"))
        {
            audioMixer.SetFloat("volume", PlayerPrefs.GetFloat("bgVolume"));
            slider.value = PlayerPrefs.GetFloat("bgVolume");
        }

        resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();
        int currentResolutionIndex = 0;

        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width && 
                resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
        PlayerPrefs.SetFloat("bgVolume", volume);
    }

    public void SetFullScreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
        if (isFullScreen == true)
        {
            PlayerPrefs.SetInt("fullscreen", 1);
        }
        else
        {
            PlayerPrefs.SetInt("fullscreen", 0);
        }
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
        PlayerPrefs.SetInt("resolution width", resolution.width);
        PlayerPrefs.SetInt("resolution height", resolution.height);
    }
}
