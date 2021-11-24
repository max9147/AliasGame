using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum themeType { free, ad, paid };

[CreateAssetMenu]
public class Themes : ScriptableObject
{
    public string themeName;
    public Image themeImage;
    public string description;
    public themeType type;
    public string[] words;
}