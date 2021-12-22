using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogHolder : MonoBehaviour
{
    public string dialog;
    private DialogManager dManager;

    public string[] dialogLines;

    public GameObject weaponShop;

    public bool isActive = false;

    // Start is called before the first frame update
    void Start()
    {
        dManager = FindObjectOfType<DialogManager>();    
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (isActive == false)
            {
                isActive = true;
            }
            else
            {
                isActive = false;
            }
        }
    }

    private void OnTriggerStay2D(Collider2D other) {
        if (other.gameObject.name == "Player")
        {
            if (isActive == true)
            {
                weaponShop.SetActive(true);
            }
            else
            {
                weaponShop.SetActive(false);
            }
        }
    }
}
