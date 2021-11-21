using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerControl : MonoBehaviour
{
    public float TimerLength;
    public GameObject FinishScreen;
    public bool isTimer;

    // Start is called before the first frame update
    void Start()
    {
        TimerCount();
    }
    public void TimerCount()
    {
        TimerLength = GetComponent<StartGame>().GetRoundLength();
        isTimer = true;
    }
    // Update is called once per frame
    void Update()
    {
        if (isTimer)
        {
             TimerLength -= Time.deltaTime;
        }
        if (TimerLength <= 0)
        {
            FinishScreen.SetActive(true);
            isTimer = false;
        }
    }

}