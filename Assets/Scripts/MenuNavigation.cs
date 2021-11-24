using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuNavigation : MonoBehaviour
{
    public GameObject[] menus;

    public void OpenMenu(int menuID)
    {
        foreach (var item in menus)
        {
            item.SetActive(false);
        }
        menus[menuID].SetActive(true);

        if (menuID == 1 || menuID == 2)
        {
            GameObject[] themes = GameObject.FindGameObjectsWithTag("Theme");
            foreach (var item in themes)
            {
                item.GetComponent<ThemeSelection>().DisselectThemes();
            }
        }
    }

    public void ReturnToMain()
    {
        foreach (var item in menus)
        {
            item.SetActive(false);
        }
        menus[0].SetActive(true);        
    }
}