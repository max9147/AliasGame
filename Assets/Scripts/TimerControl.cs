using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TimerControl : MonoBehaviour
{
    private bool isGoingGame = false;
    private float timerLength;
    
    public TextMeshProUGUI textTimer;
    public TextMeshProUGUI correctWordsCount;   
    public TextMeshProUGUI wrongWordsCount;
    public TextMeshProUGUI correctWords;
    public TextMeshProUGUI wrongWords;

    public void TimerCount()
    {
        timerLength = GetComponent<StartGame>().GetRoundLength();
    }

    public void StartTimer()
    {
        isGoingGame = true;
    }

    public void TotalScore()
    {
        correctWordsCount.text = GetComponent<GameControls>().correctWords.Count + " правильных ";
        wrongWordsCount.text = GetComponent<GameControls>().wrongWords.Count + " неправильных ";

        correctWords.text = "";
        wrongWords.text = "";

        foreach (var item in GetComponent<GameControls>().correctWords)
        {
            correctWords.text += item + "\n";
        }

        foreach (var item in GetComponent<GameControls>().wrongWords)
        {
            wrongWords.text += item + "\n";
        }

        GetComponent<GameControls>().ClearWords();
    }

    void Update()
    {
        if (isGoingGame)
        {
            timerLength -= Time.deltaTime;
            textTimer.text = timerLength.ToString("F2");

            if (timerLength <= 0)
            {
                TotalScore();
                isGoingGame = false;
                GetComponent<MenuNavigation>().OpenMenu(5);
                GetComponent<PhoneTilt>().isPlaying = false;
            }
        }
    }
}