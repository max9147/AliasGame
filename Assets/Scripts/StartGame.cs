using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public GameObject gameplay;

    private List<Themes> selectedThemes = new List<Themes>();
    private int teamCount;
    private int roundCount;
    private int roundLength;

    public void LaunchGame()
    {
        gameplay.SetActive(true);
        GetComponent<Gameplay>().StartGame();
    }

    public void AddSelectedTheme(Themes theme)
    {
        selectedThemes.Add(theme);
    }

    public void RemoveSelectedTheme(Themes theme)
    {
        selectedThemes.Remove(theme);
    }

    public List<Themes> GetSelectedThemes()
    {
        return selectedThemes;
    }

    public void SetTeamCount(int count)
    {
        teamCount = count;
    }

    public int GetTeamCount()
    {
        return teamCount;
    }

    public void SetRoundCount(int count)
    {
        roundCount = count;
    }

    public int GetRoundCount()
    {
        return roundCount;
    }
    
    public void SetRoundLength(int length)
    {
        roundLength = length;
    }

    public int GetRoundLength()
    {
        return roundLength;
    }
}