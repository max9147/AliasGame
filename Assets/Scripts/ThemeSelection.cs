using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.UI;

public class ThemeSelection : MonoBehaviour, IUnityAdsListener
{
    private bool isSelected = false;
    private bool adTestMode = false;
    private bool adSkip = false;
    private string gameID = "4497109";
    private string adType = "Rewarded_Android";

    public Button watchAdButton;
    public Button[] paidThemeButtons;
    public Color colorSelected;
    public Color colorUnselected;
    public GameObject menuSystem;
    public GameObject paidContent;
    public GameObject duelMenu;
    public GameObject teamMenu;
    public Themes theme;
    public string gamemode;

    private void Start()
    {
        Advertisement.AddListener(this);
        Advertisement.Initialize(gameID, adTestMode);
    }

    public void SelectTheme()
    {
        menuSystem.GetComponent<SoundSystem>().PlayButtonClick();
        menuSystem.GetComponent<MenuNavigation>().CloseVIP();
        if (!isSelected)
        {
            if (theme.type == themeType.free)
            {
                menuSystem.GetComponent<StartGame>().AddSelectedTheme(theme);
                transform.Find("ThemeBackground").GetComponent<Image>().color = colorSelected;
                isSelected = true;
                menuSystem.GetComponent<StartGame>().IncreaseSelectedCount();
            }
            else if (theme.type == themeType.ad)
            {
                if (menuSystem.GetComponent<IAP>().GetVIPStatus() || adSkip)
                {
                    menuSystem.GetComponent<StartGame>().AddSelectedTheme(theme);
                    transform.Find("ThemeBackground").GetComponent<Image>().color = colorSelected;
                    isSelected = true;
                    menuSystem.GetComponent<StartGame>().IncreaseSelectedCount();
                }
                else
                {
                    watchAdButton.gameObject.SetActive(true);
                    paidContent.SetActive(false);
                    menuSystem.GetComponent<MenuNavigation>().OpenMenu(7);
                    menuSystem.GetComponent<InitializeThemes>().curAdTheme = theme;
                    watchAdButton.onClick.AddListener(delegate { WatchAd(); });
                    menuSystem.GetComponent<StartGame>().GetDescriptionThemes(theme.description);
                    menuSystem.GetComponent<StartGame>().GetNameThemes(theme.themeName);
                }
            }
            else if (theme.type == themeType.paid)
            {
                bool hasThis = false;
                if (theme.name == "Alcohol" && menuSystem.GetComponent<IAP>().GetAlcStatus())
                {
                    hasThis = true;
                }
                else if (theme.name == "18" && menuSystem.GetComponent<IAP>().Get18Status())
                {
                    hasThis = true;
                }
                if (menuSystem.GetComponent<IAP>().GetVIPStatus() || hasThis)
                {
                    menuSystem.GetComponent<StartGame>().AddSelectedTheme(theme);
                    transform.Find("ThemeBackground").GetComponent<Image>().color = colorSelected;
                    isSelected = true;
                    menuSystem.GetComponent<StartGame>().IncreaseSelectedCount();
                }
                else
                {
                    watchAdButton.gameObject.SetActive(false);
                    paidContent.SetActive(true);
                    foreach (var item in paidThemeButtons)
                    {
                        item.gameObject.SetActive(false);
                    }
                    if (theme.name=="Alcohol")
                    {
                        paidThemeButtons[0].gameObject.SetActive(true);
                    }
                    else if (theme.name == "18")
                    {
                        paidThemeButtons[1].gameObject.SetActive(true);
                    }
                    menuSystem.GetComponent<MenuNavigation>().OpenMenu(7);
                    menuSystem.GetComponent<InitializeThemes>().curAdTheme = theme;
                    menuSystem.GetComponent<StartGame>().GetDescriptionThemes(theme.description);
                    menuSystem.GetComponent<StartGame>().GetNameThemes(theme.themeName);
                }
            }
        }
        else
        {
            menuSystem.GetComponent<StartGame>().RemoveSelectedTheme(theme);
            transform.Find("ThemeBackground").GetComponent<Image>().color = colorUnselected;
            isSelected = false;
            menuSystem.GetComponent<StartGame>().DecreaseSelectedCount();
        }
    }

    public void DisselectThemes()
    {
        if (isSelected)
        {
            transform.Find("ThemeBackground").GetComponent<Image>().color = colorUnselected;
            isSelected = false;
        }
    }

    public void WatchAd()
    {
        if (Advertisement.IsReady())
        {
            Advertisement.Show(adType);
        }
    }

    public void OnUnityAdsReady(string placementId)
    {
        
    }

    public void OnUnityAdsDidError(string message)
    {
        
    }

    public void OnUnityAdsDidStart(string placementId)
    {
        
    }

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        if (theme == menuSystem.GetComponent<InitializeThemes>().curAdTheme)
        {
            if ((teamMenu.activeInHierarchy && gamemode!="Team") || (duelMenu.activeInHierarchy && gamemode != "Duel"))
            {
                return;
            }
            if (showResult == ShowResult.Finished)
            {
                menuSystem.GetComponent<StartGame>().AddSelectedTheme(theme);
                transform.Find("ThemeBackground").GetComponent<Image>().color = colorSelected;
                isSelected = true;
                adSkip = true;
                menuSystem.GetComponent<StartGame>().IncreaseSelectedCount();
                menuSystem.GetComponent<MenuNavigation>().CloseDescription();
            }
        }
    }

    public void DisableAdSkip()
    {
        adSkip = false;
    }
}