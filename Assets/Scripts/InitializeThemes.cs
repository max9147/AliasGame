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
    public GameObject mainContainerDuel;
    public GameObject freeContainerDuel;
    public GameObject adContainerDuel;
    public GameObject paidContainerDuel;
    public GameObject mainContainerTeam;
    public GameObject freeContainerTeam;
    public GameObject adContainerTeam;
    public GameObject paidContainerTeam;
    public GameObject paidContent;
    public Themes[] freeThemes;
    public Themes[] adThemes;
    public Themes[] paidThemes;
    public Themes curAdTheme;

    private void Start()
    {
        foreach (var item in freeThemes) // ������ �� ���� ���������� �����
        {
            curButton = Instantiate(themeButtonPrefab, freeContainerDuel.transform); // ������� ������ �� �������
            curButton.transform.Find("ThemeName").GetComponent<TextMeshProUGUI>().text = item.themeName; // ������� �� ������ ����� � ������ ��� �� �������� ������� ��������������� ����
            curButton.GetComponent<ThemeSelection>().theme = item; // ����������� ���������� theme �� ������� �� ����������� ������ ������ ����
            curButton.GetComponent<ThemeSelection>().menuSystem = gameObject; // � � ���������� menuSystem ����������� ������ �� ������� ��������� ���� ������ (InitializeThemes)
            curButton.GetComponent<ThemeSelection>().watchAdButton = watchAdButton;
            curButton.GetComponent<ThemeSelection>().paidContent = paidContent;
            if (item.themeImage != null)
            {
                curButton.GetComponent<Image>().sprite = item.themeImage;
                
            }
            curButton = Instantiate(themeButtonPrefab, freeContainerTeam.transform); // ��� �� �� �� ��� ���������� ����
            curButton.transform.Find("ThemeName").GetComponent<TextMeshProUGUI>().text = item.themeName;
            curButton.GetComponent<ThemeSelection>().theme = item;
            curButton.GetComponent<ThemeSelection>().menuSystem = gameObject;
            curButton.GetComponent<ThemeSelection>().watchAdButton = watchAdButton;
            curButton.GetComponent<ThemeSelection>().paidContent = paidContent;
            if (item.themeImage != null)
            {
                curButton.GetComponent<Image>().sprite = item.themeImage;
            }
        }
        freeContainerDuel.GetComponent<RectTransform>().sizeDelta = new Vector3(100, Mathf.Ceil(freeThemes.Length / 4f) * 245);
        freeContainerTeam.GetComponent<RectTransform>().sizeDelta = new Vector3(100, Mathf.Ceil(freeThemes.Length / 4f) * 245);

        foreach (var item in adThemes)
        {
            curButton = Instantiate(themeButtonPrefab, adContainerDuel.transform);
            curButton.transform.Find("ThemeName").GetComponent<TextMeshProUGUI>().text = item.themeName;
            curButton.GetComponent<ThemeSelection>().theme = item;
            curButton.GetComponent<ThemeSelection>().menuSystem = gameObject;
            curButton.GetComponent<ThemeSelection>().watchAdButton = watchAdButton;
            curButton.GetComponent<ThemeSelection>().paidContent = paidContent;
            if (item.themeImage != null)
            {
                curButton.GetComponent<Image>().sprite = item.themeImage;
            }
            curButton = Instantiate(themeButtonPrefab, adContainerTeam.transform);
            curButton.transform.Find("ThemeName").GetComponent<TextMeshProUGUI>().text = item.themeName;
            curButton.GetComponent<ThemeSelection>().theme = item;
            curButton.GetComponent<ThemeSelection>().menuSystem = gameObject;
            curButton.GetComponent<ThemeSelection>().watchAdButton = watchAdButton;
            curButton.GetComponent<ThemeSelection>().paidContent = paidContent;
            if (item.themeImage != null)
            {
                curButton.GetComponent<Image>().sprite = item.themeImage;
            }
        }
        adContainerDuel.GetComponent<RectTransform>().sizeDelta = new Vector3(100, Mathf.Ceil(adThemes.Length / 4f) * 245);
        adContainerTeam.GetComponent<RectTransform>().sizeDelta = new Vector3(100, Mathf.Ceil(adThemes.Length / 4f) * 245);

        foreach (var item in paidThemes)
        {
            curButton = Instantiate(themeButtonPrefab, paidContainerDuel.transform);
            curButton.transform.Find("ThemeName").GetComponent<TextMeshProUGUI>().text = item.themeName;
            curButton.GetComponent<ThemeSelection>().theme = item;
            curButton.GetComponent<ThemeSelection>().menuSystem = gameObject;
            curButton.GetComponent<ThemeSelection>().watchAdButton = watchAdButton;
            curButton.GetComponent<ThemeSelection>().paidContent = paidContent;
            if (item.themeImage != null)
            {
                curButton.GetComponent<Image>().sprite = item.themeImage;
            }
            curButton = Instantiate(themeButtonPrefab, paidContainerTeam.transform);
            curButton.transform.Find("ThemeName").GetComponent<TextMeshProUGUI>().text = item.themeName;
            curButton.GetComponent<ThemeSelection>().theme = item;
            curButton.GetComponent<ThemeSelection>().menuSystem = gameObject;
            curButton.GetComponent<ThemeSelection>().watchAdButton = watchAdButton;
            curButton.GetComponent<ThemeSelection>().paidContent = paidContent;
            if (item.themeImage != null)
            {
                curButton.GetComponent<Image>().sprite = item.themeImage;
            }
            if (!GetComponent<IAP>().GetVIPStatus())
            {
                curButton = Instantiate(VIPButtonPrefab, paidContainerDuel.transform);
                curButton.GetComponent<Button>().onClick.AddListener(delegate { GetComponent<MenuNavigation>().OpenMenu(9); });
                curButton = Instantiate(VIPButtonPrefab, paidContainerTeam.transform);
                curButton.GetComponent<Button>().onClick.AddListener(delegate { GetComponent<MenuNavigation>().OpenMenu(9); });
            }
           
        }
        paidContainerDuel.GetComponent<RectTransform>().sizeDelta = new Vector3(100, Mathf.Ceil(paidThemes.Length / 4f) * 245);
        paidContainerTeam.GetComponent<RectTransform>().sizeDelta = new Vector3(100, Mathf.Ceil(paidThemes.Length / 4f) * 245);

        mainContainerDuel.GetComponent<RectTransform>().sizeDelta = new Vector3(1000, 200 + freeContainerDuel.GetComponent<RectTransform>().sizeDelta.y + adContainerDuel.GetComponent<RectTransform>().sizeDelta.y + paidContainerDuel.GetComponent<RectTransform>().sizeDelta.y);
        mainContainerTeam.GetComponent<RectTransform>().sizeDelta = new Vector3(1000, 200 + freeContainerDuel.GetComponent<RectTransform>().sizeDelta.y + adContainerDuel.GetComponent<RectTransform>().sizeDelta.y + paidContainerDuel.GetComponent<RectTransform>().sizeDelta.y);
    }
}