using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PhoneTilt : MonoBehaviour
{
    private float checkTime = 0;

    public float delayTime = 0;
    public float sensitivity = 3.5f;
    public bool isPlaying = false;
    public Slider sensSlider;

    public GameObject TESTTIME;
    public GameObject TESTTILT;

    private void Start()
    {
        Input.gyro.enabled = true;
        sensitivity = 5 - sensSlider.value * 10;
    }

    private void FixedUpdate()
    {
        if (isPlaying)
        {
            TESTTIME.GetComponent<RectTransform>().sizeDelta = new Vector2(1000 - (delayTime / 0.8f * 1000), 50);
            TESTTILT.transform.localPosition = new Vector3(Input.gyro.rotationRate.y/sensitivity*500, 1000);
            delayTime += Time.deltaTime;
            if (delayTime >= 0.8f)
            {
                checkTime += Time.deltaTime;
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