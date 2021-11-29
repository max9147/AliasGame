using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ThemeSelection : MonoBehaviour
{
    private bool isSelected = false;

    public GameObject menuSystem;
    public Themes theme;

    public void SelectTheme()
    {
        if (!isSelected)
        {
            if (theme.type == themeType.free)
            {
                menuSystem.GetComponent<StartGame>().AddSelectedTheme(theme);
                transform.Find("Check").gameObject.SetActive(true);
                isSelected = true;
                menuSystem.GetComponent<StartGame>().IncreaseSelectedCount();
            }
            else
            {
                
                menuSystem.GetComponent<MenuNavigation>().OpenMenu(7);
                menuSystem.GetComponent<StartGame>().GetDescriptionThemes(theme.description);
                menuSystem.GetComponent<StartGame>().GetNameThemes(theme.themeName);
            }
        }
        else
        {
            menuSystem.GetComponent<StartGame>().RemoveSelectedTheme(theme);
            transform.Find("Check").gameObject.SetActive(false);
            isSelected = false;
            menuSystem.GetComponent<StartGame>().DecreaseSelectedCount();
        }
    }

    public void DisselectThemes()
    {
        if (isSelected)
        {
            menuSystem.GetComponent<StartGame>().RemoveSelectedTheme(theme);
            transform.Find("Check").gameObject.SetActive(false);
            isSelected = false;
            menuSystem.GetComponent<StartGame>().ResetSelectedCount();
        }
    }
}