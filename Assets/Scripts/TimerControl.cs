using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerControl : MonoBehaviour
{
    public float TimerLenght;
    public GameObject FinishScreen;
    public bool isTimer;

    // Start is called before the first frame update
    void Start()
    {
        TimerCount();
    }
    public void TimerCount()
    {
        TimerLenght = GetComponent<StartGame>().roundLength;
        isTimer = true;
    }
    // Update is called once per frame
    void Update()
    {
        if (isTimer)
        {
             TimerLenght -= Time.deltaTime;
        }
        if (TimerLenght <= 0)
        {
            FinishScreen.SetActive(true);
            isTimer = false;
        }
    }

}
