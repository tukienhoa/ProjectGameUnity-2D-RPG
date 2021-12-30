using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeadController : MonoBehaviour
{
    private GameObject thePlayer;

    // Start is called before the first frame update
    void Start()
    {
        Transform[] objs = Resources.FindObjectsOfTypeAll<Transform>() as Transform[];
        for (int i = 0; i < objs.Length; i++)
        {
            if (objs[i].hideFlags == HideFlags.None)
            {
                if (objs[i].name == "Player")
                {
                    thePlayer = objs[i].gameObject;
                }
            }
        }     
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
            thePlayer.GetComponent<PlayerController>().startPoint = "Teleport Cancel";
            thePlayer.SetActive(true);
            thePlayer.GetComponent<SpriteRenderer>().color = Color.white;
            thePlayer.GetComponent<PlayerHealthManager>().playerCurrentHealth = thePlayer.GetComponent<PlayerHealthManager>().playerMaxHealth;
        }
    }
}
