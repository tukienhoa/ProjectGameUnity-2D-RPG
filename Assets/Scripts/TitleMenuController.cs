using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class TitleMenuController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadArea()
    {
        string name = EventSystem.current.currentSelectedGameObject.name;
        if (name.Equals("New Game"))
        {
            SceneManager.LoadScene("VillageScreen");   
        }

        if (name.Equals("Exit"))
        {
            Application.Quit();
        }
    }
}
