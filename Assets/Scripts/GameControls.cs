using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameControls : MonoBehaviour
{
    public Color transparentColor;
    public Image gameplayBG;
    public GameObject correctBG;
    public GameObject wrongBG;
    public List<string> correctWords;
    public List<string> wrongWords;

    private void FixedUpdate()
    {
        if (gameplayBG.color!=Color.white)
        {
            gameplayBG.color = Color.Lerp(gameplayBG.color, Color.white, 0.06f);
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