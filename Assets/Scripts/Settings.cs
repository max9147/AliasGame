using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settings : MonoBehaviour
{
    private bool vibrationsOn = true;

    public void ToggleVibrations()
    {
        if (vibrationsOn)
        {
            vibrationsOn = false;
        }
        else
        {
            vibrationsOn = true;
        }
    }

    public bool GetVibrations()
    {
        return vibrationsOn;
    }
}