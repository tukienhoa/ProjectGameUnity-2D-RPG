using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellManager : MonoBehaviour
{
    public int iceShardLevel;
    public int windBreathLevel;

    // Start is called before the first frame update
    void Start()
    {
        if (MyGameManager.Instance.isNewGame)
        {
            iceShardLevel = 1;
            windBreathLevel = 1;
        }
        else
        {
            if (PlayerPrefs.HasKey("IceShardLevel"))
            {
                iceShardLevel = PlayerPrefs.GetInt("IceShardLevel");
                windBreathLevel = PlayerPrefs.GetInt("WindBreathLevel");
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
