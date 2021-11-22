using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControls : MonoBehaviour
{
    public List<string> correctWords;
    public List<string> wrongWords;

    public void CorrectAnswer()
    {
        correctWords.Add(GetComponent<Gameplay>().GetWord());
        GetComponent<Gameplay>().ChangeWord();
        GetComponent<ScoreControl>().AddScoreDuel();
    }

    public void WrongAnswer()
    {
        wrongWords.Add(GetComponent<Gameplay>().GetWord());
        GetComponent<Gameplay>().ChangeWord();
    }
}