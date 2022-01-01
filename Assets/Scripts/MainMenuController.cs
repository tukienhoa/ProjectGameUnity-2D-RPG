using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class MainMenuController : MonoBehaviour
{
    // Inventory
    public GameObject inventoryObj;

    // Player Menu
    public GameObject playerMenu;

    private PlayerController thePlayer;

    private int mapProgress;

    // Start is called before the first frame update
    void Start()
    {
        Image[] locks = this.GetComponentsInChildren<Image>();
        foreach (Image item in locks)
        {
            if (item.name == "Lock_Volcano" || item.name == "Lock_Castle")
            {
                item.gameObject.SetActive(false);
            }
        }

        // if (PlayerPrefs.HasKey("Map Progress"))
        // {
        //     mapProgress = PlayerPrefs.GetInt("Map Progress");
        // }
        // else 
        // {
        //     mapProgress = 0;
        // }

        // thePlayer = GameObject.Find("Player").GetComponent<PlayerController>();

        // Button[] buttons = this.GetComponentsInChildren<Button>();
        // if (mapProgress < 1)
        // {
        //     for (int i = 0; i < buttons.Length; i++)
        //     {
        //         if (buttons[i].name == "Volcano" || buttons[i].name == "Castle")
        //         {
        //             buttons[i].interactable = false;
        //         }
        //     }

        //     foreach (Image item in locks)
        //     {
        //         if (item.name == "Lock_Volcano" || item.name == "Lock_Castle")
        //         {
        //             item.gameObject.SetActive(true);
        //         }
        //     }
        // }

        // if (mapProgress < 2)
        // {
        //     for (int i = 0; i < buttons.Length; i++)
        //     {
        //         if (buttons[i].name == "Castle")
        //         {
        //             buttons[i].interactable = false;
        //             break;
        //         }
        //     }

        //     foreach (Image item in locks)
        //     {
        //         if (item.name == "Lock_Castle")
        //         {
        //             item.gameObject.SetActive(true);
        //             break;
        //         }
        //     }
        // }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void LoadArea()
    {
        string name = EventSystem.current.currentSelectedGameObject.name;

        if (name.Equals("Ruined Village"))
        {
            SceneManager.LoadScene("RuinedVillageScene");
            if (thePlayer != null)
            {
                thePlayer.startPoint = "Ruined Village Start";
            }
        }

        if (name.Equals("Ice Mountain"))
        {
            SceneManager.LoadScene("IceMapScene");
            if (thePlayer != null)
            {
                thePlayer.startPoint = "Ice Map Start";
            }
        }

        if (name.Equals("Volcano"))
        {
            if (PlayerPrefs.GetInt("Map Progress") >= 1)
            {
                SceneManager.LoadScene("LavaScene");
                if (thePlayer != null)
                {
                    thePlayer.startPoint = "Volcano Start";
                }
            }
            else Debug.Log("Scene locked. Complete Ice Mountain Scene to unlock this scene.");

        }

        if (name.Equals("Castle"))
        {
            // if (PlayerPrefs.GetInt("Map Progress") >= 2)
            // {
            //     SceneManager.LoadScene("CastleScene");
            //     if (thePlayer != null)
            //     {
            //         thePlayer.startPoint = "Castle Scene Start";
            //     }
            // }
            // else Debug.Log("Scene locked. Complete Volcano Scene to unlock this scene.");
            SceneManager.LoadScene("CastleScene");
            if (thePlayer != null)
            {
                thePlayer.startPoint = "Castle Scene Start";
            }
        }

        if (name.Equals("Cancel") || name.Equals("Back to Village"))
        {
            string sceneName = SceneManager.GetActiveScene().name;
            if (sceneName.Equals("VillageScreen"))
            {
                if (inventoryObj.activeSelf)
                    inventoryObj.SetActive(false);

                playerMenu.SetActive(!playerMenu.activeSelf);
            }
            else
            {
                SceneManager.LoadScene("VillageScreen");
                if (thePlayer != null)
                {
                    thePlayer.startPoint = "Teleport Cancel";
                }
                if (inventoryObj.activeSelf)
                    inventoryObj.SetActive(false);

                playerMenu.SetActive(!playerMenu.activeSelf);
            }
        }
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
