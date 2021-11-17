using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InitializeThemes : MonoBehaviour
{
    public GameObject themeButtonPrefab;
    public GameObject mainContainer;
    public GameObject freeContainer;
    public GameObject paidContainer;
    public Themes[] freeThemes;
    public Themes[] paidThemes;

    private GameObject curButton;

    private void Start()
    {
        foreach (var item in freeThemes)
        {
            curButton = Instantiate(themeButtonPrefab, freeContainer.transform);
            curButton.transform.Find("ThemeName").GetComponent<TextMeshProUGUI>().text = item.themeName;
            curButton.GetComponent<ThemeSelection>().theme = item;
            curButton.GetComponent<ThemeSelection>().menuSystem = gameObject;
        }
        freeContainer.GetComponent<RectTransform>().sizeDelta = new Vector3(100, Mathf.Ceil(freeThemes.Length / 4f) * 245);
        foreach (var item in paidThemes)
        {
            curButton = Instantiate(themeButtonPrefab, paidContainer.transform);
            curButton.transform.Find("ThemeName").GetComponent<TextMeshProUGUI>().text = item.themeName;
            curButton.GetComponent<ThemeSelection>().theme = item;
            curButton.GetComponent<ThemeSelection>().menuSystem = gameObject;
        }
        paidContainer.GetComponent<RectTransform>().sizeDelta = new Vector3(100, Mathf.Ceil(paidThemes.Length / 4f) * 245);

        mainContainer.GetComponent<RectTransform>().sizeDelta = new Vector3(1000, 150 + freeContainer.GetComponent<RectTransform>().sizeDelta.y + paidContainer.GetComponent<RectTransform>().sizeDelta.y);
    }
}