using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Purchasing;
using UnityEngine.UI;

public class InitializeThemes : MonoBehaviour
{
    private GameObject curButton;

    public Button watchAdButton;
    public GameObject VIPButtonPrefab;
    public GameObject themeButtonPrefab;
    public GameObject rectDuel;
    public GameObject mainContainerDuel;
    public GameObject freeContainerDuel;
    public GameObject adContainerDuel;
    public GameObject paidContainerDuel;
    public GameObject rectTeam;
    public GameObject mainContainerTeam;
    public GameObject freeContainerTeam;
    public GameObject adContainerTeam;
    public GameObject paidContainerTeam;
    public GameObject paidContent;
    public List<GameObject> VIPButtons;
    public Themes[] freeThemes;
    public Themes[] adThemes;
    public Themes[] paidThemes;
    public Themes curAdTheme;

    private void Start()
    {
        foreach (var item in freeThemes)
        {
            curButton = Instantiate(themeButtonPrefab, freeContainerDuel.transform);
            SetupTheme(item);
            curButton = Instantiate(themeButtonPrefab, freeContainerTeam.transform);
            SetupTheme(item);
        }
        freeContainerDuel.GetComponent<RectTransform>().sizeDelta = new Vector3(100, Mathf.Ceil(freeThemes.Length / 4f) * 245);
        freeContainerTeam.GetComponent<RectTransform>().sizeDelta = new Vector3(100, Mathf.Ceil(freeThemes.Length / 4f) * 245);

        foreach (var item in adThemes)
        {
            curButton = Instantiate(themeButtonPrefab, adContainerDuel.transform);
            SetupTheme(item);
            curButton = Instantiate(themeButtonPrefab, adContainerTeam.transform);
            SetupTheme(item);
        }
        adContainerDuel.GetComponent<RectTransform>().sizeDelta = new Vector3(100, Mathf.Ceil(adThemes.Length / 4f) * 245);
        adContainerTeam.GetComponent<RectTransform>().sizeDelta = new Vector3(100, Mathf.Ceil(adThemes.Length / 4f) * 245);

        foreach (var item in paidThemes)
        {
            curButton = Instantiate(themeButtonPrefab, paidContainerDuel.transform);
            SetupTheme(item);
            curButton = Instantiate(themeButtonPrefab, paidContainerTeam.transform);
            SetupTheme(item);
            if (!GetComponent<IAP>().GetVIPStatus())
            {
                curButton = Instantiate(VIPButtonPrefab, paidContainerDuel.transform);
                curButton.GetComponent<Button>().onClick.AddListener(delegate { GetComponent<MenuNavigation>().OpenMenu(9); });
                VIPButtons.Add(curButton);
                curButton = Instantiate(VIPButtonPrefab, paidContainerTeam.transform);
                curButton.GetComponent<Button>().onClick.AddListener(delegate { GetComponent<MenuNavigation>().OpenMenu(9); });
                VIPButtons.Add(curButton);
            }           
        }
        paidContainerDuel.GetComponent<RectTransform>().sizeDelta = new Vector3(100, Mathf.Ceil((paidThemes.Length + 1) / 4f) * 245);
        paidContainerTeam.GetComponent<RectTransform>().sizeDelta = new Vector3(100, Mathf.Ceil((paidThemes.Length + 1) / 4f) * 245);

        mainContainerDuel.GetComponent<RectTransform>().sizeDelta = new Vector3(1000, 220 + freeContainerDuel.GetComponent<RectTransform>().sizeDelta.y + adContainerDuel.GetComponent<RectTransform>().sizeDelta.y + paidContainerDuel.GetComponent<RectTransform>().sizeDelta.y);
        mainContainerDuel.GetComponent<RectTransform>().localPosition = new Vector3(0, -(mainContainerDuel.GetComponent<RectTransform>().sizeDelta.y - rectDuel.GetComponent<RectTransform>().sizeDelta.y) / 2);
        mainContainerTeam.GetComponent<RectTransform>().sizeDelta = new Vector3(1000, 220 + freeContainerTeam.GetComponent<RectTransform>().sizeDelta.y + adContainerTeam.GetComponent<RectTransform>().sizeDelta.y + paidContainerTeam.GetComponent<RectTransform>().sizeDelta.y);
        mainContainerTeam.GetComponent<RectTransform>().localPosition = new Vector3(0, -(mainContainerTeam.GetComponent<RectTransform>().sizeDelta.y - rectTeam.GetComponent<RectTransform>().sizeDelta.y) / 2);
    }

    private void SetupTheme(Themes item)
    {
        curButton.transform.Find("ThemeName").GetComponent<TextMeshProUGUI>().text = item.themeName;
        curButton.GetComponent<ThemeSelection>().theme = item;
        curButton.GetComponent<ThemeSelection>().menuSystem = gameObject;
        curButton.GetComponent<ThemeSelection>().watchAdButton = watchAdButton;
        curButton.GetComponent<ThemeSelection>().paidContent = paidContent;
        if (item.themeImage != null)
        {
            curButton.transform.Find("ThemeImage").GetComponent<Image>().sprite = item.themeImage;
        }
    }
}