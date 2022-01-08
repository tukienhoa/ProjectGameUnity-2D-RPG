using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMPManager : MonoBehaviour
{
    public int playerMaxMP;
    public int playerCurrentMP;

    // Start is called before the first frame update
    void Start()
    {
        playerCurrentMP = playerMaxMP;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ConsumeMP(int usedMP)
    {
        playerCurrentMP -= usedMP;
    }

    public int GetMaxMP()
    {
        return playerMaxMP;
    }

    public int GetCurrentMP()
    {
        return playerCurrentMP;
    }

    public void SetCurrentMP(int value)
    {
        playerCurrentMP = value;
    }

    public void ChangeMaxMP(int manaValue)
    {
        playerMaxMP += manaValue;
        // Handle when player unequips item -> decrease max MP -> decrease current MP if current MP > new max MP 
        if (playerMaxMP < playerCurrentMP)
            playerCurrentMP = playerMaxMP;
    }
}
