using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameControls : MonoBehaviour
{
    private float colorTime = 0;

    public Color correctColor;
    public Color wrongColor;
    public Image gameplayBG;
    public List<string> correctWords;
    public List<string> wrongWords;

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
        GetComponent<SoundSystem>().PlayCorrectAnswer();
        correctWords.Add(GetComponent<Gameplay>().GetWord());
        GetComponent<Gameplay>().ChangeWord();
        gameplayBG.color = correctColor;
        colorTime = 1.5f;
        if (GetComponent<Settings>().GetVibrations())
        {
            Handheld.Vibrate();
        }
        if (GetComponent<Gameplay>().teamGameSelected)
        {
            GetComponent<Gameplay>().AddTeamScore();
        }
    }

    public void WrongAnswer()
    {
        GetComponent<SoundSystem>().PlayWrongAnswer();
        wrongWords.Add(GetComponent<Gameplay>().GetWord());
        GetComponent<Gameplay>().ChangeWord();
        gameplayBG.color = wrongColor;
        colorTime = 1.5f;
        if (GetComponent<Settings>().GetVibrations())
        {
            Handheld.Vibrate();
        }
    }

    public void ClearWords()
    {
        correctWords.Clear();
        wrongWords.Clear();
    }
}