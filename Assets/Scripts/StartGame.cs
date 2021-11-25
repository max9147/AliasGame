using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartGame : MonoBehaviour
{
    public GameObject gameplay;
    public Button startDuelButton;
    public Button startTeamButton;

    private List<Themes> selectedThemes = new List<Themes>();
    private int teamCount;
    private int roundCount;
    private int roundLength;
    private int selectedCount = 0;

    public void LaunchGame()
    {
        GetComponent<MenuNavigation>().OpenMenu(4);
        GetComponent<Gameplay>().StartGame();
        GetComponent<TimerControl>().TimerCount();
        GetComponent<PhoneTilt>().isPlaying = true;
    }

    public void IncreaseSelectedCount()
    {
        selectedCount++;
        startDuelButton.interactable = true;
        startTeamButton.interactable = true;
    }

    public void DecreaseSelectedCount()
    {
        selectedCount--;
        if (selectedCount == 0)
        {
            startDuelButton.interactable = false;
            startTeamButton.interactable = false;
        }
    }

    public void ResetSelectedCount()
    {
        selectedCount = 0;
        startDuelButton.interactable = false;
        startTeamButton.interactable = false;
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