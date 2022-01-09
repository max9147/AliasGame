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
    public GameObject linePrefab;
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
        correctContainer.GetComponent<RectTransform>().sizeDelta = new Vector3(500, GetComponent<GameControls>().correctWords.Count * 165 - 15);
        if (correctContainer.GetComponent<RectTransform>().sizeDelta.y > 1500)
        {
            correctContainer.transform.localPosition = new Vector3(0, (1500 - correctContainer.GetComponent<RectTransform>().sizeDelta.y) / 2);
        }
        wrongContainer.GetComponent<RectTransform>().sizeDelta = new Vector3(500, GetComponent<GameControls>().wrongWords.Count * 165 - 15);
        if (wrongContainer.GetComponent<RectTransform>().sizeDelta.y > 1500)
        {
            wrongContainer.transform.localPosition = new Vector3(0, (1500 - wrongContainer.GetComponent<RectTransform>().sizeDelta.y) / 2);
        }

        for (int i = 0; i < GetComponent<GameControls>().correctWords.Count; i++)
        {
            curWord = Instantiate(wordPrefab, correctContainer.transform);
            curWord.GetComponent<TextMeshProUGUI>().text = GetComponent<GameControls>().correctWords[i];
            if (i != GetComponent<GameControls>().correctWords.Count - 1)
            {
                Instantiate(linePrefab, correctContainer.transform);
            }
        }

        for (int i = 0; i < GetComponent<GameControls>().wrongWords.Count; i++)
        {
            curWord = Instantiate(wordPrefab, wrongContainer.transform);
            curWord.GetComponent<TextMeshProUGUI>().text = GetComponent<GameControls>().wrongWords[i];
            if (i != GetComponent<GameControls>().wrongWords.Count - 1)
            {
                Instantiate(linePrefab, wrongContainer.transform);
            }
        }

        if (correctContainer.GetComponent<RectTransform>().sizeDelta.y < 1500)
        {
            correctContainer.GetComponent<RectTransform>().sizeDelta = new Vector3(500, 1500);
        }
        if (wrongContainer.GetComponent<RectTransform>().sizeDelta.y < 1500)
        {
            wrongContainer.GetComponent<RectTransform>().sizeDelta = new Vector3(500, 1500);
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
                GetComponent<GameControls>().wrongWords.Add(GetComponent<Gameplay>().GetWord());
                TotalScore();
                isGoingGame = false;                
                GetComponent<MenuNavigation>().OpenMenu(5);
                GetComponent<PhoneTilt>().isPlaying = false;
                GetComponent<SoundSystem>().PlayRoundEnd();
            }
        }
    }
}