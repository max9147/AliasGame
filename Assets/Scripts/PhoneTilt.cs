using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PhoneTilt : MonoBehaviour
{
    private float checkTime = 0;
    private float delayTime = 0;
    public float sensitivity = 2f;

    public bool isPlaying = false;
    public Slider sensSlider;

    private void Start()
    {
        Input.gyro.enabled = true;
        sensitivity = sensSlider.value * 10;
    }

    private void FixedUpdate()
    {
        if (isPlaying)
        {
            delayTime += Time.deltaTime;
            if (delayTime >= 0.5f)
            {
                checkTime += Time.deltaTime;
                if (checkTime >= 0.1f)
                {
                    checkTime = 0;
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
    }

    public void ChangeSensitivity()
    {
        sensitivity = sensSlider.value * 10;
    }
}