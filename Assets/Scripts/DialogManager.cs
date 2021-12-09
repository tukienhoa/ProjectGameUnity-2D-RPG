using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    public GameObject dBox;
    public Text dText;

    public bool dialogActive;

    public string[] dialogLines;
    public int currentLine;

    private PlayerController thePlayer;

    // Start is called before the first frame update
    void Start()
    {
        thePlayer = FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (dialogActive && Input.GetKeyDown(KeyCode.Space)) {
            // dBox.SetActive(false);
            // dialogActive = false;
            currentLine++;
        }

        if (currentLine >= dialogLines.Length) {
            dBox.SetActive(false);
            dialogActive = false;

            currentLine = 0;
            thePlayer.canMove = true;
        }

        dText.text = dialogLines[currentLine];
    }

    public void ShowBox(string dialog) {
        dialogActive = true;
        dBox.SetActive(true);
        dText.text = dialog;
    }

    public void ShowDialog() {
        dialogActive = true;
        dBox.SetActive(true);
        thePlayer.canMove = false;
    }
}
