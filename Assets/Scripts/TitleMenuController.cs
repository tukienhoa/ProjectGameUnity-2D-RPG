using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class TitleMenuController : MonoBehaviour
{
    public GameObject continueButton;
    
    // Start is called before the first frame update
    void Start()
    {

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
            PlayerPrefs.DeleteAll();
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
