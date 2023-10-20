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
   
    private void Start()
    {
        AudioListener.pause = false;

        Time.timeScale = 1;
        instance = this;


       

        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        AdsController.instance.ShowAd(AdType.BANNER,0);
       // AdsManager.Instance.ShowBannerAd();
       // AdsManager.Instance.HideRectBannerAd();
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
        modenumber = ModeNumber;
        if (ModeNumber == 0)
        {
            BtnClickSound();
           
        }
        else if(ModeNumber==1)
        {
            BtnClickSound();
            
        }
    }

    public void BtnClickSound()
    {
        if (PlayerPrefs.GetInt("sound") == 0)
            BtnClickSource.PlayOneShot(BtnClip);
    }
    public void OnPlayBtnClick()
    {
        BtnClickSound();
        HidePanels();
        LevelPanel.SetActive(true);
        AdsController.instance.ShowAd(AdType.BANNER, 0);
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
