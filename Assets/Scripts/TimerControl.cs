using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TimerControl : MonoBehaviour
{
    private bool isGoingGame = false;
    private bool isTicking = false;
    private float timerLength;
    private GameObject curWord;

    public GameObject wordPrefab;
    public GameObject correctContainer;
    public GameObject wrongContainer;
    public TextMeshProUGUI textTimer;
    public TextMeshProUGUI correctWordsCount;   
    public TextMeshProUGUI wrongWordsCount;

    public void TimerCount()
    {
        timerLength = GetComponent<StartGame>().GetRoundLength();
        isTicking = false;
    }

    public void StartTimer()
    {
        isGoingGame = true;
    }

    public void TotalScore()
    {
        correctWordsCount.text = GetComponent<GameControls>().correctWords.Count + " правильных ";
        wrongWordsCount.text = GetComponent<GameControls>().wrongWords.Count + " неправильных ";

        foreach (Transform child in correctContainer.transform)
        {
            Destroy(child.gameObject);
        }
        foreach (Transform child in wrongContainer.transform)
        {
            Destroy(child.gameObject);
        }
        correctContainer.GetComponent<RectTransform>().sizeDelta = new Vector3(500, GetComponent<GameControls>().correctWords.Count * 160 - 10);
        correctContainer.transform.localPosition = new Vector3(0, (1500 - correctContainer.GetComponent<RectTransform>().sizeDelta.y) / 2);
        wrongContainer.GetComponent<RectTransform>().sizeDelta = new Vector3(500, GetComponent<GameControls>().wrongWords.Count * 160 - 10);
        wrongContainer.transform.localPosition = new Vector3(0, (1500 - wrongContainer.GetComponent<RectTransform>().sizeDelta.y) / 2);

        foreach (var item in GetComponent<GameControls>().correctWords)
        {
            curWord = Instantiate(wordPrefab, correctContainer.transform);
            curWord.GetComponent<TextMeshProUGUI>().text = item;
        }

        foreach (var item in GetComponent<GameControls>().wrongWords)
        {
            curWord = Instantiate(wordPrefab, wrongContainer.transform);
            curWord.GetComponent<TextMeshProUGUI>().text = item;
        }

        GetComponent<GameControls>().ClearWords();
    }

    void Update()
    {
        if (isGoingGame)
        {
            timerLength -= Time.deltaTime;
            textTimer.text = timerLength.ToString("F2");

            if (timerLength <= 10 && !isTicking)
            {
                GetComponent<SoundSystem>().PlayTimeOut();
                isTicking = true;
            }

            if (timerLength <= 0)
            {
                TotalScore();
                isGoingGame = false;                
                GetComponent<MenuNavigation>().OpenMenu(5);
                GetComponent<PhoneTilt>().isPlaying = false;
                GetComponent<SoundSystem>().PlayRoundEnd();
            }
        }
    }
}