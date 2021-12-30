using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapClearController : MonoBehaviour
{
    private PlayerController thePlayer;

    // Start is called before the first frame update
    void Start()
    {
        thePlayer = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BackToVillage()
    {
        SceneManager.LoadScene("VillageScreen");
        if (thePlayer != null)
        {
            thePlayer.startPoint = "Teleport Cancel";
            Time.timeScale = 1;
        }
    }
}
