using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartGame : MonoBehaviour
{
    private int roundLength;
    private int selectedCount = 0;
    private List<Themes> selectedThemes = new List<Themes>();

    public Button startDuelButton;
    public Button startTeamButton;
    public GameObject gameplay;
    public TextMeshProUGUI nameTheme;
    public TextMeshProUGUI descriptionTheme;

    public void LaunchGame(bool isTeamGame)
    {
        GetComponent<MenuNavigation>().OpenMenu(4);
        GetComponent<Gameplay>().StartGame(isTeamGame);
        GetComponent<TimerControl>().TimerCount();        
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
    
    public void SetRoundLength(int length)
    {
        roundLength = length;
    }

    public int GetRoundLength()
    {
        return roundLength;
    }

    public void GetDescriptionThemes(string description)
    {
        descriptionTheme.text = description;
    }

    public void GetNameThemes(string name)
    {
        nameTheme.text = name;
    }
}