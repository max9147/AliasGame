using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.UI;

public class ThemeSelection : MonoBehaviour, IUnityAdsListener
{
    private bool isSelected = false;
    private bool adTestMode = true;
    private string gameID = "4497109";
    private string adType = "Rewarded_Android";

    public Button watchAdButton;
    public GameObject menuSystem;
    public Themes theme;

    private void Start()
    {
        Advertisement.AddListener(this);
        Advertisement.Initialize(gameID, adTestMode);
    }

    public void SelectTheme()
    {
        if (!isSelected)
        {
            if (theme.type == themeType.free)
            {
                menuSystem.GetComponent<StartGame>().AddSelectedTheme(theme);
                transform.Find("Check").gameObject.SetActive(true);
                isSelected = true;
                menuSystem.GetComponent<StartGame>().IncreaseSelectedCount();
            }
            else
            {                
                menuSystem.GetComponent<MenuNavigation>().OpenMenu(7);
                menuSystem.GetComponent<InitializeThemes>().curAdTheme = theme;
                watchAdButton.onClick.AddListener(delegate { WatchAd(); });
                menuSystem.GetComponent<StartGame>().GetDescriptionThemes(theme.description);
                menuSystem.GetComponent<StartGame>().GetNameThemes(theme.themeName);
            }
        }
        else
        {
            menuSystem.GetComponent<StartGame>().RemoveSelectedTheme(theme);
            transform.Find("Check").gameObject.SetActive(false);
            isSelected = false;
            menuSystem.GetComponent<StartGame>().DecreaseSelectedCount();
        }
    }

    public void DisselectThemes()
    {
        if (isSelected)
        {
            menuSystem.GetComponent<StartGame>().RemoveSelectedTheme(theme);
            transform.Find("Check").gameObject.SetActive(false);
            isSelected = false;
            menuSystem.GetComponent<StartGame>().ResetSelectedCount();
        }
    }

    public void WatchAd()
    {
        if (Advertisement.IsReady())
        {
            Advertisement.Show(adType);
        }
        else
        {
            Debug.Log("Ad not ready");
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
            if (showResult == ShowResult.Finished)
            {
                menuSystem.GetComponent<StartGame>().AddSelectedTheme(theme);
                transform.Find("Check").gameObject.SetActive(true);
                isSelected = true;
                menuSystem.GetComponent<StartGame>().IncreaseSelectedCount();
                menuSystem.GetComponent<MenuNavigation>().CloseDescription();
            }
            else
            {
                Debug.Log("Ad failed");
            }
        }
    }
}