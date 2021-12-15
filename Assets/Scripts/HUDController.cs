using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HUDController : MonoBehaviour
{
    private static bool HUDExists;

    public GameObject inventoryObj;

    // Start is called before the first frame update
    void Start()
    {
        if (!HUDExists)
        {
            HUDExists = true;
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

    public void ClickButton()
    {
        string name = EventSystem.current.currentSelectedGameObject.name;

        if (name.Equals("InventoryBtn"))
        {
            inventoryObj.SetActive(!inventoryObj.activeSelf);
        }
    }
}
