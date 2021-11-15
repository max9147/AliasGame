using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuNavigation : MonoBehaviour
{
    public GameObject[] menus;

    private int curMenu = 0;

    public void OpenMenu(int menuID)
    {
        menus[0].SetActive(false);
        menus[menuID].SetActive(true);
        curMenu = menuID;
    }

    public void ReturnToMain()
    {
        menus[curMenu].SetActive(false);
        menus[0].SetActive(true);
    }
}