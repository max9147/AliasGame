using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundSystem : MonoBehaviour
{
    public AudioSource buttonClick;
    public AudioSource correctAnswer;
    public AudioSource wrongAnswer;
    public AudioSource roundEnd;
    public AudioSource timeOut;

    public void PlayButtonClick()
    {
        buttonClick.Play();
    }

    public void PlayCorrectAnswer()
    {
        correctAnswer.Play();
    }

    public void PlayWrongAnswer()
    {
        wrongAnswer.Play();
    }

    public void PlayRoundEnd()
    {
        roundEnd.Play();
    }

    public void PlayTimeOut()
    {
        timeOut.Play();
    }
}