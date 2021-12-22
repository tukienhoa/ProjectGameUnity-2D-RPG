using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class BGMController : MonoBehaviour
{
    // Mixer property
    public AudioMixer audioMixer;

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("bgVolume"))
        {
            audioMixer.SetFloat("volume", PlayerPrefs.GetFloat("bgVolume"));
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
