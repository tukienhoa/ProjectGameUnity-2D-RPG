using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    private static bool MenuExists;

    // Start is called before the first frame update
    void Start()
    {
        if (!MenuExists)
        {
            MenuExists = true;
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
