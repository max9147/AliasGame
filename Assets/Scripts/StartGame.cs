using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public List<Themes> selectedThemes = new List<Themes>();

    private int playerCount;
    private int roundCount;
    private int roundLength;

    private void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    public void LaunchGame()
    {
        SceneManager.LoadScene(1);
    }

    public void AddSelectedTheme(Themes theme)
    {
        selectedThemes.Add(theme);
    }

    public void RemoveSelectedTheme(Themes theme)
    {
        selectedThemes.Remove(theme);
    }

    public void SetPlayerCount(int count)
    {
        playerCount = count;
    }

    public void SetRoundCount(int count)
    {
        roundCount = count;
    }
    
    public void SetRoundLength(int length)
    {
        roundLength = length;
    }
}