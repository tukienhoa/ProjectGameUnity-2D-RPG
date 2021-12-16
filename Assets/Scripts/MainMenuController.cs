using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
public class MainMenuController : MonoBehaviour
{
    // Inventory
    public GameObject inventoryObj;

    // Player Menu
    public GameObject playerMenu;

    private PlayerController thePlayer;

    // Start is called before the first frame update
    void Start()
    {
        thePlayer = FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadArea()
    {
        string name = EventSystem.current.currentSelectedGameObject.name;
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
            SceneManager.LoadScene("LavaScene");
            if (thePlayer != null)
            {
                thePlayer.startPoint = "Volcano Start";
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

}
