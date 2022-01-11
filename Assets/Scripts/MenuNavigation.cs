using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuNavigation : MonoBehaviour
{
    public GameObject[] menus;

    public void OpenMenu(int menuID)
    {
        GetComponent<SoundSystem>().PlayButtonClick();
        if (menuID != 7 && menuID != 9)
        {
            foreach (var item in menus)
            {
                item.SetActive(false);
            }
        }
        menus[menuID].SetActive(true);

        if (menuID == 1 || menuID == 2)
        {
            GameObject[] themes = GameObject.FindGameObjectsWithTag("Theme");
            foreach (var item in themes)
            {
                item.GetComponent<ThemeSelection>().DisselectThemes();
            }
            GetComponent<StartGame>().ResetSelectedCount();
        }

        if (menuID == 2)
        {
            GetComponent<TeamSystem>().ResetTeams();
        }
    }

    public void CloseDescription()
    {
        GetComponent<SoundSystem>().PlayButtonClick();
        menus[7].SetActive(false);
    }

    public void CloseVIP()
    {
        GetComponent<SoundSystem>().PlayButtonClick();
        menus[9].SetActive(false);
    }

    public void RestartRound()
    {
        GetComponent<SoundSystem>().PlayButtonClick();
        GetComponent<Gameplay>().ChangeWord();
        foreach (var item in menus)
        {
            item.SetActive(false);
        }
        menus[4].SetActive(true);
        if (GetComponent<Gameplay>().teamGameSelected)
        {
            GetComponent<Gameplay>().SetCurrentTeam();
        }
        GetComponent<TimerControl>().TimerCount();
        GetComponent<Gameplay>().rotateScreen.SetActive(true);
        GetComponent<Gameplay>().rotateShowing = true;
    }

    public void ReturnToMain()
    {
        GetComponent<SoundSystem>().PlayButtonClick();
        foreach (var item in menus)
        {
            item.SetActive(false);
        }
        menus[0].SetActive(true);        
    }
}