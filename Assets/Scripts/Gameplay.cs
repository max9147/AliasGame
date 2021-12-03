using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;

public class Gameplay : MonoBehaviour
{
    private string curWord;

    public GameObject teamScorePrefab;
    public GameObject scoringContainer;
    public GameObject rotateScreen;
    public List<string> availableWords;
    public List<string> availableWordsBackup;
    public List<Themes> availableThemes;    
    public TextMeshProUGUI displayWord;
    public TextMeshProUGUI nameTeamText;
    public TextMeshProUGUI rotateScreenTeamName;

    public string[] teamNames;
    public int[] teamScores;

    public int currentTeam = 0;

    public bool teamGameSelected;
    public bool rotateShowing = false;

    public void StartGame(bool isTeamGame)
    {
        currentTeam = 0;
        if (isTeamGame)
        {
            TeamSetUp();
            SetCurrentTeam();
            teamGameSelected = true;
        }
        else
        {
            teamGameSelected = false;
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

    public void SkipRotation()
    {
        GetComponent<TimerControl>().StartTimer();
        rotateShowing = false;
        rotateScreen.SetActive(false);
        GetComponent<PhoneTilt>().isPlaying = true;
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
        teamNames = new string[GetComponent<TeamSystem>().teamCount];
        teamScores = new int[GetComponent<TeamSystem>().teamCount];
        int index = 0;

        foreach (var item in GetComponent<TeamSystem>().spawnedTeams)
        {
            teamNames[index] = item.transform.Find("TeamName").GetComponent<TMP_InputField>().text;
            index++;
        }
       
    }

    public void SetCurrentTeam()
    {
        if (currentTeam != GetComponent<TeamSystem>().teamCount)
        {
            nameTeamText.text = teamNames[currentTeam];
            currentTeam++;
            rotateScreen.SetActive(true);
            rotateScreenTeamName.text = "Сейчас играет комманда: " + teamNames[currentTeam - 1];
        }
        else
        {
            FinishTeamGame();
        }

    }

    public void GetCurrentTeamName()
    {
        nameTeamText.text = teamNames[currentTeam];
    }

    public void AddTeamScore()
    {
        teamScores[currentTeam - 1]++;
    }
    
    public void FinishTeamGame()
    {
        foreach (Transform child in scoringContainer.transform)
        {
            Destroy(child.gameObject);
        }
        Dictionary<string, int> scores = new Dictionary<string, int>();
        GetComponent<MenuNavigation>().OpenMenu(8);
        for (int i = 0; i < GetComponent<TeamSystem>().teamCount; i++)
        {
            scores.Add(teamNames[i], teamScores[i]);            
        }
        var scoresSorted = from score in scores orderby score.Value descending select score;
        foreach (var item in scoresSorted)
        {
            GameObject curScore = Instantiate(teamScorePrefab, scoringContainer.transform);
            curScore.transform.Find("TeamName").GetComponent<TextMeshProUGUI>().text = item.Key;
            curScore.transform.Find("TeamPoints").GetComponent<TextMeshProUGUI>().text = item.Value.ToString();
        }
    }    
}