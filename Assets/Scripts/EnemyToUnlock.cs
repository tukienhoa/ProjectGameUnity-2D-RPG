using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyToUnlock : MonoBehaviour
{
    private PlayerController thePlayer;

    private GameObject dialog;

    // Start is called before the first frame update
    void Start()
    {
        thePlayer = GameObject.Find("Player").GetComponent<PlayerController>();
        dialog = GameObject.Find("Canvas").transform.Find("BossKilledDialog").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDestroy()
    {
        if (gameObject.GetComponent<EnemyHealthManager>().CurrentHealth <= 0)
        {
            Debug.Log("Boss killed.");

            switch (SceneManager.GetActiveScene().name)
            {
                case "RuinedVillageScene":
                PlayerPrefs.SetInt("Map Progress", 1);
                break;

                case "IceMapScene":
                PlayerPrefs.SetInt("Map Progress", 2);
                break;

                case "LavaScene":
                PlayerPrefs.SetInt("Map Progress", 3);
                break;

                case "CastleScene":
                PlayerPrefs.SetInt("Map Progress", 4);
                break;
            }

            dialog.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
