using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogHolder : MonoBehaviour
{
    public string dialog;
    private DialogManager dManager;

    // Start is called before the first frame update
    void Start()
    {
        dManager = FindObjectOfType<DialogManager>();    
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D other) {
        if (other.gameObject.name == "Player")
        {
            if (Input.GetKey(KeyCode.F))
            {
                dManager.ShowDialog(dialog);
            }
        }
    }
}