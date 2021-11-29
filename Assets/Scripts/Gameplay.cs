using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Gameplay : MonoBehaviour
{
    private string curWord;

    public List<string> availableWords;
    public List<string> availableWordsBackup;
    public List<Themes> availableThemes;    
    public TextMeshProUGUI displayWord;

    public string[] NameTeam;
    public int[] ScoreTeam;

   

    public void StartGame(bool isTeamGame)
    {
        if (isTeamGame)
        {

        }

        availableThemes = GetComponent<StartGame>().GetSelectedThemes();
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

    public string GetWord()
    {
        return curWord;
    }

    public void TeamSetUp()
    {
        NameTeam = new string[GetComponent<TeamSystem>().teamCount];
        ScoreTeam = new int[GetComponent<TeamSystem>().teamCount];
        int index = 0;

        foreach (var item in GetComponent<TeamSystem>().spawnedTeams)
        {
            
            
            index++;
        }
    }
}