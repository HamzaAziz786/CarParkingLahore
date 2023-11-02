using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public int[] ModeLevels_T;
    [Space(5)]
    public GameObject MainPanel;
    public GameObject LevelPanel;
    public GameObject SettingsPanel;
    public GameObject ShopPanel;
    public GameObject LoadingPanel;
    public GameObject QuitPanel;


    public Image loadingimg;
    AsyncOperation asyncLoad;
    public AudioSource BtnClickSource;
    public AudioClip BtnClip;

    [Space(5)]
    public static bool IsNext;
    public static int LevelNum;
    public Text[] CashTxt;
    public static MenuManager instance;
    public int modenumber;
    public GameObject MainMenu_T;
    public GameObject Mode_T;
    public GameObject Level_T;
    public GameObject Mode_Selection;
    public GameObject[] SelectorImag;
    public int current_mode;
    private void Start()
    {
        AudioListener.pause = false;

        Time.timeScale = 1;

        instance = this;
        for (int i = 0; i < SelectorImag.Length; i++)
        {
            SelectorImag[i].SetActive(false);
        }
        SelectorImag[current_mode].SetActive(true);
        if (PlayerPrefs.GetInt("Icoom")==1)
        {
            Mode_Selection.SetActive(true);
            MainPanel.SetActive(false);
            PlayerPrefs.SetInt("Icoom", PlayerPrefs.GetInt("Icoom", 0));
        }
        Firebase_Analytics.Instance.LogEvent("MainMenu");


        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        AdsController.instance.ShowAd(AdType.BANNER,0);
        // AdsManager.Instance.ShowBannerAd();
        // AdsManager.Instance.HideRectBannerAd();
        if (PlayerPrefs.GetInt("FirstTime") == 0)
        {
            MainMenu_T.SetActive(true);
        }
        else
        {
            MainMenu_T.SetActive(false);
        }
    }

    public void OnClickPLay()
    {
        if (PlayerPrefs.GetInt("FirstTime") == 0)
        {
            MainMenu_T.SetActive(false);
            Mode_T.SetActive(true);
            

        }
        else
        {
            MainMenu_T.SetActive(false);
            Mode_T.SetActive(false);
           
        }
    }
    public void HidePanels()
    {
        MainPanel.SetActive(false);
        LevelPanel.SetActive(false);
        SettingsPanel.SetActive(false);
        ShopPanel.SetActive(false);
        LoadingPanel.SetActive(false);
        QuitPanel.SetActive(false);
    }

    public void ModeNumber(int ModeNumber)
    {
        if (PlayerPrefs.GetInt("FirstTime") == 0)
        {
            MainMenu_T.SetActive(false);
            Mode_T.SetActive(false);
            Level_T.SetActive(true);

        }
        else
        {
            MainMenu_T.SetActive(false);
            Mode_T.SetActive(false);
            Level_T.SetActive(false);
        }
        modenumber = ModeNumber;
        switch (modenumber)
        {
            case 2:
                Firebase_Analytics.Instance.LogEvent("Simple_Mode");
                break;
            case 3:
                Firebase_Analytics.Instance.LogEvent("Hallowean_Mode");
                break;
            case 4:
                Firebase_Analytics.Instance.LogEvent("City_Mode");
                break;
            case 5:
                Firebase_Analytics.Instance.LogEvent("Snow_Mode");
                break;

            default:
                break;
        }
        if (ModeNumber == 0)
        {
            BtnClickSound();
           
        }
        else if(ModeNumber==1)
        {
            BtnClickSound();
            
        }
        switch (modenumber)
        {
            case 2:
                Firebase_Analytics.Instance.LogEvent("Simple_Mode");
                break;
            case 3:
                Firebase_Analytics.Instance.LogEvent("Hallowean_Mode");
                break;
            case 4:
                Firebase_Analytics.Instance.LogEvent("City_Mode");
                break;
            case 5:
                Firebase_Analytics.Instance.LogEvent("Snow_Mode");
                break;

            default:
                break;
        }
    }

    public void BtnClickSound()
    {
        //if (PlayerPrefs.GetInt("sound") == 0)
            BtnClickSource.PlayOneShot(BtnClip);
    }
    public void OnPlayBtnClick()
    {
        BtnClickSound();
        HidePanels();
        LevelPanel.SetActive(true);
        AdsController.instance.ShowAd(AdType.BANNER, 0);

    }
    public void ModePlayButtonClick()
    {
        BtnClickSound();
        HidePanels();
        LevelPanel.SetActive(true);
    }
    public void OnShopBtnClick()
    {
        BtnClickSound();
        ShopPanel.SetActive(true);
    }
    public void OnSettingBtnClick()
    {
        BtnClickSound();
        HidePanels();
        SettingsPanel.SetActive(true);

        //AdsManager.Instance.ShowRectBannerAd();
    }

    public void RateUs()
    {
        BtnClickSound();
        Application.OpenURL("https://play.google.com/store/apps/details?id=" + Application.identifier);
    }

    public void PolicyLinkOpen()
    {
        BtnClickSound();
        Application.OpenURL("https://sites.google.com/view/parkinggamesarena/home");
    }
    public void MoreGames()
    {
        BtnClickSound();
        Application.OpenURL("https://play.google.com/store/apps/developer?id=Parking+Games+Arena");
    }

    public void BackBtnFun()
    {
        BtnClickSound();
        if (!SettingsPanel.activeSelf)
        {
            if (MainPanel.activeSelf && !ShopPanel.activeSelf)
                BackFromMainPanel();
            else if (QuitPanel.activeSelf)
                BackFromQuitPanel();
            else if (LevelPanel.activeSelf && !ShopPanel.activeSelf)
                BackFromLevelPanel();
            else if (ShopPanel.activeSelf)
                BackFromShop();
            
        }
        else
            BackFromSettings();
    }
    public void ClickSound()
    {
        BtnClickSound();
    }
    void BackFromMainPanel()
    {
        HidePanels();
        QuitPanel.SetActive(true);
       // AdsManager.Instance.ShowRectBannerAd();
    }

    void BackFromLevelPanel()
    {
        HidePanels();
        MainPanel.SetActive(true);
       
    }
    
    void BackFromSettings()
    {
        HidePanels();
        MainPanel.SetActive(true);
       // AdsManager.Instance.HideRectBannerAd();
    }
    void BackFromShop()
    {
        ShopPanel.SetActive(false);
    }

    void BackFromStorePanel()
    {
        HidePanels();
        LevelPanel.SetActive(true);
    }

    void BackFromQuitPanel()
    {
        HidePanels();
        MainPanel.SetActive(true);
      //  AdsManager.Instance.HideRectBannerAd();
    }



    public void OnQuitBtnClick()
    {
        Application.Quit();
    }


    public void SelectLevel(int num)
    {
        if (PlayerPrefs.GetInt("FirstTime") == 0)
        {
            MainMenu_T.SetActive(false);
            Mode_T.SetActive(false);
            Level_T.SetActive(true);
            PlayerPrefs.SetInt("FirstTime", 1);

        }
        else
        {
            MainMenu_T.SetActive(false);
            Mode_T.SetActive(false);
            Level_T.SetActive(false);
        }
        switch (modenumber)
        {
            case 2:
                Firebase_Analytics.Instance.LogEvent("Simple_Mode "+"Level no "+ num);
                break;
            case 3:
                Firebase_Analytics.Instance.LogEvent("Hallowean_Mode " + "Level no " + num);
                break;
            case 4:
                Firebase_Analytics.Instance.LogEvent("City_Mode " + "Level no " + num);
                break;
            case 5:
                Firebase_Analytics.Instance.LogEvent("Snow_Mode " + "Level no " + num);
                break;

            default:
                break;
        }
        BtnClickSound();
        LevelNum = num;

        HidePanels();
        LoadingPanel.SetActive(true);
        StartCoroutine(LoadYourAsyncScene());

    }
    

    public void OnLevelNextBtnClick()
    {
        BtnClickSound();

    }

   public void IAP(string str)
    {
        BtnClickSound();
        ////Purchaser.instance.BuyProduct(str);
    }

    public void OnStorePlayBtnClick()
    {
        BtnClickSound();
        HidePanels();
        LoadingPanel.SetActive(true);
        StartCoroutine(LoadYourAsyncScene());
       // AdsManager.Instance.ShowInterstitialLoading();
    }
    
    IEnumerator LoadYourAsyncScene()
    {
       
            asyncLoad = SceneManager.LoadSceneAsync(modenumber);/*SceneManager.LoadSceneAsync("GamePlay");*/

        while (!asyncLoad.isDone)
        {
            float progress = Mathf.Clamp01(asyncLoad.progress / 0.9f);
            loadingimg.fillAmount = progress;
            yield return null;
        }
    }
    public void Selector_Mode(int CurrentNumber)
    {
        current_mode = CurrentNumber;
        for (int i = 0; i < SelectorImag.Length; i++)
        {
            SelectorImag[i].SetActive(false);
        }
        SelectorImag[CurrentNumber].SetActive(true);
    }
    private void Update()
    {

        if (LoadingPanel.activeSelf && asyncLoad != null)
            loadingimg.fillAmount = Mathf.Lerp(loadingimg.fillAmount, asyncLoad.progress, Time.deltaTime);

        foreach (Text txt in CashTxt)
        {
            txt.text = "" + PlayerPrefs.GetInt("cash");
        }

        
    }

    public void WatchVideo()
    {
      //  AdsManager.Instance.ShowRewardedVideoAd();
    }
   
}
