using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProfile : MonoBehaviour
{
    private static bool PlayerInfoExists;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
        if (!PlayerInfoExists)
        {
            PlayerInfoExists = true;
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
