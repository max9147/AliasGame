using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TimerControl : MonoBehaviour
{
    public float TimerLength = 10f;
    public GameObject FinishScreen;
    public bool isGoingGame = false;
    
    public TextMeshProUGUI textTimer;
    public TextMeshProUGUI CorrectWordsCount;
   
    public TextMeshProUGUI WrongWordsCount;
    public TextMeshProUGUI CorrectWords;
    public TextMeshProUGUI WrongWords;

    public void TimerCount()
    {
        TimerLength = GetComponent<StartGame>().GetRoundLength();
        isGoingGame = true;
    }

    public void TotalScore(int score)
    {
        CorrectWordsCount.text = score.ToString() + " ochkoff ";
        WrongWordsCount.text = GetComponent<GameControls>().wrongWords.Count + " ochkoff ";

        foreach (var item in GetComponent<GameControls>().correctWords)
        {
            CorrectWords.text += item + "\n";
        }

        foreach (var item in GetComponent<GameControls>().wrongWords)
        {
            WrongWords.text += item + "\n";
        }
    }

    void Update()
    {
        if (isGoingGame)
        {
            TimerLength -= Time.deltaTime;
            textTimer.text = TimerLength.ToString("F2");

            if (TimerLength <= 0)
            {
                TotalScore(GetComponent<ScoreControl>().GetScore());
                isGoingGame = false;

                FinishScreen.SetActive(true);
            }
        }
    }
}