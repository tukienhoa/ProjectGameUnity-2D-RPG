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
}
