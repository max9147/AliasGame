using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    public Toggle effectsToggle;
    public Toggle vibrationsToggle;
    public Slider sensitivitySlider;
    public AudioMixer audioMixer;

    private bool effectsOn = true;
    private bool vibrationsOn = true;

    private void Start()
    {
        if (!PlayerPrefs.HasKey("Vibrations"))
        {
            PlayerPrefs.SetInt("Vibrations", 1);
        }
        else
        {
            if (PlayerPrefs.GetInt("Vibrations") == 0)
            {
                vibrationsOn = false;
                vibrationsToggle.isOn = false;
            }
        }
        vibrationsToggle.onValueChanged.AddListener(delegate { ToggleVibrations(); });

        if (!PlayerPrefs.HasKey("Sensitivity"))
        {
            PlayerPrefs.SetFloat("Sensitivity", sensitivitySlider.value);
        }
        else
        {
            sensitivitySlider.value = PlayerPrefs.GetFloat("Sensitivity");
            GetComponent<PhoneTilt>().ChangeSensitivity();
        }

        if (!PlayerPrefs.HasKey("Effects"))
        {
            PlayerPrefs.SetInt("Effects", 1);
        }
        else
        {
            if (PlayerPrefs.GetInt("Effects") == 0)
            {
                effectsOn = false;
                effectsToggle.isOn = false;
                audioMixer.SetFloat("EffectsVol", -80);
            }
        }
        effectsToggle.onValueChanged.AddListener(delegate { ToggleEffects(); });
    }

    public void ToggleVibrations()
    {
        GetComponent<SoundSystem>().PlayButtonClick();
        if (vibrationsOn)
        {
            vibrationsOn = false;
            PlayerPrefs.SetInt("Vibrations", 0);
        }
        else
        {
            vibrationsOn = true;
            PlayerPrefs.SetInt("Vibrations", 1);
        }
    }

    public bool GetVibrations()
    {
        return vibrationsOn;
    }

    public void ToggleEffects()
    {
        GetComponent<SoundSystem>().PlayButtonClick();
        if (effectsOn)
        {
            effectsOn = false;
            audioMixer.SetFloat("EffectsVol", -80);
            PlayerPrefs.SetInt("Effects", 0);
        }
        else
        {
            effectsOn = true;
            audioMixer.SetFloat("EffectsVol", 0);
            PlayerPrefs.SetInt("Effects", 1);
        }
    }
}