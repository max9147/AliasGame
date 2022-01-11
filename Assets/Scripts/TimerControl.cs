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
    private float correctHeight;
    private float wrongHeight;
    private GameObject curWord;

    public GameObject wordPrefab;
    public GameObject linePrefab;
    public GameObject correctContainer;
    public GameObject wrongContainer;
    public List<GameObject> correctLines;
    public List<GameObject> wrongLines;
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
        correctLines.Clear();
        wrongLines.Clear();
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
        for (int i = 0; i < GetComponent<GameControls>().correctWords.Count; i++)
        {
            curWord = Instantiate(wordPrefab, correctContainer.transform);
            curWord.GetComponent<TextMeshProUGUI>().text = GetComponent<GameControls>().correctWords[i];
            correctLines.Add(curWord);
            if (i != GetComponent<GameControls>().correctWords.Count - 1)
            {
                Instantiate(linePrefab, correctContainer.transform);
            }
        }
        for (int i = 0; i < GetComponent<GameControls>().wrongWords.Count; i++)
        {
            curWord = Instantiate(wordPrefab, wrongContainer.transform);
            curWord.GetComponent<TextMeshProUGUI>().text = GetComponent<GameControls>().wrongWords[i];
            wrongLines.Add(curWord);
            if (i != GetComponent<GameControls>().wrongWords.Count - 1)
            {
                Instantiate(linePrefab, wrongContainer.transform);
            }
        }
        GetComponent<GameControls>().ClearWords();
    }

    private void CorrectSizes()
    {
        correctHeight = 0;
        wrongHeight = 0;
        foreach (var item in correctLines)
        {
            item.GetComponent<TextMeshProUGUI>().ForceMeshUpdate();
            item.GetComponent<RectTransform>().sizeDelta = new Vector2(500, item.GetComponent<TextMeshProUGUI>().textInfo.lineCount * 75);
            correctHeight += item.GetComponent<TextMeshProUGUI>().textInfo.lineCount * 75 + 35;
        }
        foreach (var item in wrongLines)
        {
            item.GetComponent<TextMeshProUGUI>().ForceMeshUpdate();
            item.GetComponent<RectTransform>().sizeDelta = new Vector2(500, item.GetComponent<TextMeshProUGUI>().textInfo.lineCount * 75);
            wrongHeight += item.GetComponent<TextMeshProUGUI>().textInfo.lineCount * 75 + 35;
        }

        correctContainer.GetComponent<RectTransform>().sizeDelta = new Vector3(500, correctHeight - 20);
        if (correctContainer.GetComponent<RectTransform>().sizeDelta.y > 1500)
        {
            correctContainer.transform.localPosition = new Vector3(0, (1500 - correctContainer.GetComponent<RectTransform>().sizeDelta.y) / 2);
        }
        wrongContainer.GetComponent<RectTransform>().sizeDelta = new Vector3(500, wrongHeight - 20);
        if (wrongContainer.GetComponent<RectTransform>().sizeDelta.y > 1500)
        {
            wrongContainer.transform.localPosition = new Vector3(0, (1500 - wrongContainer.GetComponent<RectTransform>().sizeDelta.y) / 2);
        }

        if (correctContainer.GetComponent<RectTransform>().sizeDelta.y < 1500)
        {
            correctContainer.GetComponent<RectTransform>().sizeDelta = new Vector3(500, 1500);
        }
        if (wrongContainer.GetComponent<RectTransform>().sizeDelta.y < 1500)
        {
            wrongContainer.GetComponent<RectTransform>().sizeDelta = new Vector3(500, 1500);
        }
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
                CorrectSizes();
            }
        }
    }
}