using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThemeSelection : MonoBehaviour
{
    public GameObject menuSystem;
    public Themes theme;

    private bool isSelected = false;

    public void SelectTheme()
    {
        if (!isSelected)
        {
            menuSystem.GetComponent<StartGame>().AddSelectedTheme(theme);
            transform.Find("Check").gameObject.SetActive(true);
            isSelected = true;
        }
        else
        {
            menuSystem.GetComponent<StartGame>().RemoveSelectedTheme(theme);
            transform.Find("Check").gameObject.SetActive(false);
            isSelected = false;
        }
    }
}