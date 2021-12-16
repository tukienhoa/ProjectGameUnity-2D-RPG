using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMenuController : MonoBehaviour
{
    private static bool playerMenuExists;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
        if (!playerMenuExists)
        {
            playerMenuExists = true;
            DontDestroyOnLoad(transform.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
