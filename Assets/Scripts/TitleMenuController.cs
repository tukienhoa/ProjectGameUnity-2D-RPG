using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.Audio;
using UnityEngine.UI;

public class TitleMenuController : MonoBehaviour
{
    public GameObject continueButton;

    public AudioMixer audioMixer;
    
    // Start is called before the first frame update
    void Start()
    {
        if (!PlayerPrefs.HasKey("resolution width"))
        {
            PlayerPrefs.SetInt("resolution width", Screen.currentResolution.width);
            PlayerPrefs.SetInt("resolution height", Screen.currentResolution.height);
        }

        if (PlayerPrefs.HasKey("fullscreen"))
        {
            if (PlayerPrefs.GetInt("fullscreen") == 0)
            {
                Screen.SetResolution(PlayerPrefs.GetInt("resolution width"), PlayerPrefs.GetInt("resolution height"), false);
            }
            else
            {
                Screen.SetResolution(PlayerPrefs.GetInt("resolution width"), PlayerPrefs.GetInt("resolution height"), true);
            }
        }

        if (PlayerPrefs.HasKey("bgVolume"))
        {
            audioMixer.SetFloat("volume", PlayerPrefs.GetFloat("bgVolume"));
        }
        else
        {
            audioMixer.SetFloat("volume", 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.HasKey("Level")) 
        {
            continueButton.SetActive(true);
        }
        else
        {
            continueButton.SetActive(false);
        }
    }

    public void LoadArea()
    {
        string name = EventSystem.current.currentSelectedGameObject.name;
        if (name.Equals("New Game"))
        {
            MyGameManager.Instance.isNewGame = true;

            int width = PlayerPrefs.GetInt("resolution width");
            int height = PlayerPrefs.GetInt("resolution height");
            float volume = PlayerPrefs.GetFloat("bgVolume");
            int fullscreen = PlayerPrefs.GetInt("fullscreen");
            PlayerPrefs.DeleteAll();
            PlayerPrefs.SetInt("resolution width", width);
            PlayerPrefs.SetInt("resolution height", height);
            PlayerPrefs.SetFloat("bgVolume", volume);
            PlayerPrefs.SetInt("fullscreen", fullscreen);
            audioMixer.SetFloat("volume", volume);

            SceneManager.LoadScene("VillageScreen");
        }
        if (name.Equals("Continue"))
        {
            MyGameManager.Instance.isNewGame = false;
            SceneManager.LoadScene("VillageScreen");
        }
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
