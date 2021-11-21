using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControls : MonoBehaviour
{
    public void CorrectAnswer()
    {
        GetComponent<Gameplay>().ChangeWord();
        GetComponent<ScoreControl>().AddScoreDuel();
    }

    public void WrongAnswer()
    {
        GetComponent<Gameplay>().ChangeWord();
    }
}