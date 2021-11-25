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
            if (theme.type == themeType.free)
            {
                menuSystem.GetComponent<StartGame>().AddSelectedTheme(theme);
                transform.Find("Check").gameObject.SetActive(true);
                isSelected = true;
                menuSystem.GetComponent<StartGame>().IncreaseSelectedCount();
            }
            else
            {

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