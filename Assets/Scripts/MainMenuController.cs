using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
public class MainMenuController : MonoBehaviour
{
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

        if (name.Equals("Cancel"))
        {
            SceneManager.LoadScene("VillageScreen");
            if (thePlayer != null)
            {
                thePlayer.startPoint = "Teleport Cancel";
            }
            
        }
    }

}
