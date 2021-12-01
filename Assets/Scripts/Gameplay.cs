using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;

public class Gameplay : MonoBehaviour
{
    private string curWord;

    public GameObject rotateScreen;
    public List<string> availableWords;
    public List<string> availableWordsBackup;
    public List<Themes> availableThemes;    
    public TextMeshProUGUI displayWord;
    public TextMeshProUGUI nameTeamText;
    public TextMeshProUGUI FinishTeamNameText;
    public TextMeshProUGUI FinishScoreText;
    public TextMeshProUGUI rotateScreenTeamName;

    public string[] NameTeam;
    public int[] ScoreTeam;

    public int currentTeam = 0;

    public bool TeamGameSelected;
    public bool rotateShowing = false;

    public void StartGame(bool isTeamGame)
    {
        if (isTeamGame)
        {
            TeamSetUp();
            SetCurrentTeam();
            TeamGameSelected = true;
        }
        else
        {
            TeamGameSelected = false;
            rotateScreen.SetActive(true);
            rotateScreenTeamName.text = "";
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
        rotateShowing = true;
    }

    private void Update()
    {
        if (Input.gyro.attitude.x > 0.4f && rotateShowing)
        {
            GetComponent<TimerControl>().StartTimer();
            rotateShowing = false;
            rotateScreen.SetActive(false);
            GetComponent<PhoneTilt>().isPlaying = true;
        }
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
            NameTeam[index] = item.transform.Find("TeamName").GetComponent<TMP_InputField>().text;
            index++;
        }
       
    }

    public void SetCurrentTeam()
    {
        if (currentTeam != GetComponent<TeamSystem>().teamCount)
        {
            nameTeamText.text = NameTeam[currentTeam];
            currentTeam++;
            rotateScreen.SetActive(true);
            rotateScreenTeamName.text = "������ ������ ��������: " + NameTeam[currentTeam];
        }
        else
        {
            FinishTeamGame();
        }

    }

    public void GetCurrentTeamName()
    {
        nameTeamText.text = NameTeam[currentTeam];
    }

    public void AddTeamScore()
    {
        ScoreTeam[currentTeam - 1]++;
    }
    
    public void FinishTeamGame()
    {
        GetComponent<MenuNavigation>().OpenMenu(8);
        for (int i = 0; i < NameTeam.Length; i++)
        {
            FinishTeamNameText.text = NameTeam[i] + " \n ";
            FinishScoreText.text = ScoreTeam[i] + " \n ";
        }        
    }    
}