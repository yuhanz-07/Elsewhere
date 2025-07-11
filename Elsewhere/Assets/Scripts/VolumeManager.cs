using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeManager : MonoBehaviour
{
    public Slider volumeSlider;

    // Start is called before the first frame update
    void Start()
    {
        if (!PlayerPrefs.HasKey("savedVolume"))
        {
            PlayerPrefs.SetFloat("savedVolume", 1);
            Load();
        }
        else
        {
            Load();
        }
    }

    public void ChangeVolume()
    {
        AudioListener.volume = volumeSlider.value;
    }

    public void Load()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("savedVolume");
    }

    public void Save()
    {
        PlayerPrefs.SetFloat("savedVolume", volumeSlider.value);
    }
}
