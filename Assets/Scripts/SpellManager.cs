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
            if (!MyGameManager.Instance.areSpellsLoaded)
            {
                iceShardLevel = 1;
                windBreathLevel = 1;
                MyGameManager.Instance.areSpellsLoaded = true;
            }
        }
        else
        {
            if (PlayerPrefs.HasKey("IceShardLevel"))
            {
                if (!MyGameManager.Instance.areSpellsLoaded)
                {
                    iceShardLevel = PlayerPrefs.GetInt("IceShardLevel");
                    windBreathLevel = PlayerPrefs.GetInt("WindBreathLevel");
                    MyGameManager.Instance.areSpellsLoaded = true;
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
