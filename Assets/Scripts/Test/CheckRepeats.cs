using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckRepeats : MonoBehaviour
{
    public Themes[] allThemes;
    public string[] allWords;
    public List<string> checkedWords;

    private void Start()
    {
        for (int i = 0; i < allThemes.Length; i++)
        {
            allWords = allThemes[i].words;
            for (int j = 0; j < allWords.Length; j++)
            {
                if (checkedWords.Contains(allWords[j]))
                {
                    Debug.LogWarning(allWords[j] + " (" + j + ")" + " повторяется в теме " + allThemes[i].name);
                }
                checkedWords.Add(allWords[j]);
            }
            checkedWords.Clear();
        }
    }
}