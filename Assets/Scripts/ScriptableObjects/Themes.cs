using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu]
public class Themes : ScriptableObject
{
    public string themeName;
    public Image themeImage;
    public string description;
    public string[] words;
}