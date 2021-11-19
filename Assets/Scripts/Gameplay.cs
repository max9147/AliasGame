using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Gameplay : MonoBehaviour
{
    public TextMeshProUGUI displayWord;
    public List<string> availableWords;
    public List<string> availableWordsBackup;
    public List<Themes> availableThemes;

    private string curWord;

    private void Start()
    {
        availableThemes = GameObject.Find("MenuSystem").GetComponent<StartGame>().selectedThemes;
        for (int i = 0; i < availableThemes.Count; i++)
        {
            for (int j = 0; j < availableThemes[i].words.Length; j++)
            {
                availableWords.Add(availableThemes[i].words[j]);
            }
        }
        availableWordsBackup = new List<string>(availableWords);
        ChangeWord();
    }

    public void ChangeWord()
    {
        curWord = availableWords[Random.Range(0, availableWords.Count)];
        displayWord.GetComponent<TextMeshProUGUI>().text = curWord;
        availableWords.Remove(curWord);
        if (availableWords.Count == 0)
        {
            availableWords = new List<string>(availableWordsBackup);
        }
    }
}