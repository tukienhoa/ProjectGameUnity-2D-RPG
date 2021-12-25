using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyToUnlock : MonoBehaviour
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

    private void OnDestroy()
    {
        Debug.Log("Boss killed.");
        // switch (SceneManager.GetActiveScene().name)
        // {
        //     case "IceMapScene":
        //     PlayerPrefs.SetInt("Map Progress", 1);
        //     break;

        //     case "LavaScene":
        //     PlayerPrefs.SetInt("Map Progress", 2);
        //     break;

        //     case "CastleScene":
        //     PlayerPrefs.SetInt("Map Progress", 3);
        // }

        SceneManager.LoadScene("VillageScreen");
        if (thePlayer != null)
        {
            thePlayer.startPoint = "Teleport Cancel";
        }
    }
}
