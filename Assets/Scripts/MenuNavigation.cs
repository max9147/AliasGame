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