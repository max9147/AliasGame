using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    private List<Themes> selectedThemes = new List<Themes>();

    public void LaunchGame()
    {
        foreach (var item in selectedThemes)
        {
            Debug.Log(item.themeName);
        }
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
}