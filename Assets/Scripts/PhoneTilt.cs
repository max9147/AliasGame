using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PhoneTilt : MonoBehaviour
{
    public float delayTime = 0;
    public float sensitivity = 3.5f;
    public bool isPlaying = false;
    public Slider sensSlider;

    private void Start()
    {
        Input.gyro.enabled = true;
        sensitivity = 5 - sensSlider.value * 10;
    }

    private void FixedUpdate()
    {
        if (isPlaying)
        {
            delayTime += Time.deltaTime;
            if (delayTime >= 0.8f)
            {
                if (Input.gyro.rotationRate.y > sensitivity)
                {
                    GetComponent<GameControls>().WrongAnswer();
                    delayTime = 0;
                }
                if (Input.gyro.rotationRate.y < -sensitivity)
                {
                    GetComponent<GameControls>().CorrectAnswer();
                    delayTime = 0;
                }
            }
        }
    }

    public void ChangeSensitivity()
    {
        sensitivity = 5 - sensSlider.value * 10;
        PlayerPrefs.SetFloat("Sensitivity", sensSlider.value);
    }
}