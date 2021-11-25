using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameControls : MonoBehaviour
{
    public Color correctColor;
    public Color wrongColor;

    public Image gameplayBG;

    public List<string> correctWords;
    public List<string> wrongWords;

    private float colorTime = 0;

    private void FixedUpdate()
    {
        if (colorTime > 0)
        {
            colorTime -= Time.deltaTime;
            gameplayBG.color = Color.Lerp(gameplayBG.color, Color.white, 0.1f);
        }
    }

    public void CorrectAnswer()
    {
        correctWords.Add(GetComponent<Gameplay>().GetWord());
        GetComponent<Gameplay>().ChangeWord();
        GetComponent<ScoreControl>().AddScoreDuel();
        gameplayBG.color = correctColor;
        colorTime = 1.5f;
    }

    public void WrongAnswer()
    {
        wrongWords.Add(GetComponent<Gameplay>().GetWord());
        GetComponent<Gameplay>().ChangeWord();
        gameplayBG.color = wrongColor;
        colorTime = 0.5f;
    }

    public void ClearWords()
    {
        correctWords.Clear();
        wrongWords.Clear();
    }
}