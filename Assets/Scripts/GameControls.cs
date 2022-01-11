using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameControls : MonoBehaviour
{
    private float colorTime = 0;

    public Color transparentColor;
    public Image gameplayBG;
    public GameObject correctBG;
    public GameObject wrongBG;
    public List<string> correctWords;
    public List<string> wrongWords;

    private void FixedUpdate()
    {
        if (colorTime > 0)
        {
            colorTime -= Time.deltaTime;
            gameplayBG.color = Color.Lerp(gameplayBG.color, Color.white, 0.055f);
        }
    }

    public void CorrectAnswer()
    {
        GetComponent<SoundSystem>().PlayCorrectAnswer();
        correctWords.Add(GetComponent<Gameplay>().GetWord());
        GetComponent<Gameplay>().ChangeWord();
        wrongBG.SetActive(false);
        correctBG.SetActive(true);
        gameplayBG.color = transparentColor;
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
        correctBG.SetActive(false);
        wrongBG.SetActive(true);
        gameplayBG.color = transparentColor;
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