using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNewArea : MonoBehaviour
{
    public string levelToLoad;

    public string exitPoint;

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

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            SceneManager.LoadScene(levelToLoad);
            thePlayer.startPoint = exitPoint;
        }
    }
}
