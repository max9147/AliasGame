using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PhoneTilt : MonoBehaviour
{
    public bool isPlaying = false;
    public Slider sensSlider;

    private float curTilt = 0;
    private float checkTime = 0;
    private float delayTime = 0;
    private float sensitivity = 0.2f;

    private void Start()
    {
        Input.gyro.enabled = true;
        sensitivity = sensSlider.value;
    }

    public void ChangeSensitivity()
    {
        sensitivity = sensSlider.value;
    }

    private void FixedUpdate()
    {
        if (isPlaying)
        {
            delayTime += Time.deltaTime;
            if (delayTime >= 1.5f)
            {
                checkTime += Time.deltaTime;
                if (checkTime >= 0.1f)
                {
                    checkTime = 0;
                    if (Input.gyro.attitude.x - curTilt > sensitivity)
                    {
                        GetComponent<GameControls>().WrongAnswer();
                        delayTime = 0;
                    }
                    if (Input.gyro.attitude.x - curTilt < -sensitivity)
                    {
                        GetComponent<GameControls>().CorrectAnswer();
                        delayTime = 0;
                    }                    
                }                
            }
            else
            {
                curTilt = Input.gyro.attitude.x;
            }
        }
    }
}