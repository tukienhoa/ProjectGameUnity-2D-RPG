using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlsMenuController : MonoBehaviour
{
    private static bool ControlsMenuExists;

    // Start is called before the first frame update
    void Start()
    {
        if (!ControlsMenuExists)
        {
            ControlsMenuExists = true;
            DontDestroyOnLoad(transform.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
