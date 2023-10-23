using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GamePlay_Manager : MonoBehaviour
{
    public GameObject GamePlayPanel, settingsPanel, PausePanel, FailPanel, CompletePanel, loadingPanel;
    [Space]
    public GameObject RaceToturial;
    public GameObject GearToturial;
    public GameObject GearUp, GearDown;

    [Space]
    public GameObject[] Levels;

    [Space]
    public GameObject[] Players;

    [Space]
    public GameObject ReverseCamImg;
    Camera ReverseCam;

    public static GamePlay_Manager Instance;
    public GameObject Confetti;
    public Canvas MainCanvas;
    public AudioSource BtnClickSource;
    public AudioClip BtnClip, victoryClip, AlarmClip;
    public Text LevelNoTxt;
    int num;

    float minutes, seconds;
    float time;
    string niceTime;

    public Text FailTimeTxt, CompTimeTxt;
    public AudioSource nice_job;
    public RCC_Camera cam;
  
    public GameObject player;
    public AudioSource SuddendlySounds;
    public AudioClip s1,s2,s3,s4,s5;
    public Rigidbody playerrb;
   
    private void Start()
    {
        Instance = this;
        Time.timeScale = 1;

        RCC_Settings.Instance.behaviorSelectedIndex = 3;

        MainCanvas.renderMode = RenderMode.ScreenSpaceOverlay;

        HidePanels();
        GamePlayPanel.SetActive(true);

        Levels[MenuManager.LevelNum].SetActive(true);
        //if (MenuManager.instance.modenumber == 3)
        //{
        //    player.transform.position = new Vector3(StartPoint[MenuManager.LevelNum].transform.position.x, player.transform.position.y, StartPoint[MenuManager.LevelNum].transform.position.z);
        //    player.transform.rotation = StartPoint[MenuManager.LevelNum].transform.rotation;
        //}
        Players[PlayerPrefs.GetInt("currentPlayer")].SetActive(true);
        if (MenuManager.instance.modenumber == 3)
            Invoke(nameof(StartSound),1.5f);
            
        //if(MenuManager.LevelNum == 0)
        //{
        //    //GearToturial.SetActive(false);
        //    //RaceToturial.SetActive(true);
        //}
        //else if (MenuManager.LevelNum == 2)
        //{
        //    GearToturial.SetActive(true);
        //    RaceToturial.SetActive(false);
        //}

        Screen.sleepTimeout = SleepTimeout.NeverSleep;

        ReverseCam = GameObject.FindGameObjectWithTag("reverse").GetComponent<Camera>();

        RCC_Settings.Instance.autoReverse = false;
        RCC_Settings.Instance.useAutomaticGear = false;


        if (PlayerPrefs.GetInt("control") == 0)
        {
            RCC_Settings.Instance.mobileController = RCC_Settings.MobileController.TouchScreen;
        }
        else if (PlayerPrefs.GetInt("control") == 1)
        {
            RCC_Settings.Instance.mobileController = RCC_Settings.MobileController.Gyro;
        }
        else if (PlayerPrefs.GetInt("control") == 2)
        {
            RCC_Settings.Instance.mobileController = RCC_Settings.MobileController.SteeringWheel;
        }


        num = MenuManager.LevelNum;
        Debug.Log(num);


        num++;
        LevelNoTxt.text = "LEVEL " + num;
        // FireBaseManager.Instance.LogEvent("level_" + num + "_start");
        AdsController.instance.ShowAd(AdType.BANNER,0);
        // AdsManager.Instance.ShowBannerAd();
        //AdsManager.Instance.HideRectBannerAd();
    }
    public void StartSound()
    {
        InvokeRepeating(nameof(SuddendlySound), .2f, 4);
    }
    public void SuddendlySound()
    {

        int a = Random.Range(0, 5);
        if(a==0)
            SuddendlySounds.PlayOneShot(s1);
        else if (a == 1)
            SuddendlySounds.PlayOneShot(s2);
        else if (a == 2)
            SuddendlySounds.PlayOneShot(s3);
        else if (a == 3)
            SuddendlySounds.PlayOneShot(s4);
        else if (a == 4)
            SuddendlySounds.PlayOneShot(s5);
    }
    public void BtnClickSound()
    {
        if (PlayerPrefs.GetInt("sound") == 0)
            BtnClickSource.PlayOneShot(BtnClip);
    }

    public void ChangeCamera()
    {
        if (cam.cameraMode == RCC_Camera.CameraMode.TPS)
            cam.cameraMode = RCC_Camera.CameraMode.TOP;
        else
            cam.cameraMode = RCC_Camera.CameraMode.TPS;
    }

    private void Update()
    {
        time += Time.deltaTime;

        minutes = Mathf.FloorToInt(time / 60F);
        seconds = Mathf.FloorToInt(time - minutes * 60);
        niceTime = string.Format("{0:0}:{1:00}", minutes, seconds);
    }

    public void ChangeTimeScale(float t)
    {
        Time.timeScale = t;
    }

    public void HidePanels()
    {
        settingsPanel.SetActive(false);
        GamePlayPanel.SetActive(false);
        PausePanel.SetActive(false);
        FailPanel.SetActive(false);
        CompletePanel.SetActive(false);
        loadingPanel.SetActive(false);
    }

    public void ReverseON()
    {
        BtnClickSound();
        ReverseCamImg.SetActive(true);
        ReverseCam.enabled = true;
    }
    public void ReverseOFF()
    {
        BtnClickSound();
        ReverseCamImg.SetActive(false);
        ReverseCam.enabled = false;
    }

    public void OnFail()
    {
        Time.timeScale = 0;
        HidePanels();
        FailPanel.SetActive(true);
        AudioListener.volume = 0;
        // FireBaseManager.Instance.LogEvent("level_" + num + "_failed");
        AdsController.instance.ShowAd(AdNetwork.ADMOB, AdType.INTERSTITIAL);
        //AdsManager.Instance.ShowInterstitialLoading();
        //AdsManager.Instance.ShowRectBannerAd();
    }
    public void OnComplete()
    {
        MainCanvas.renderMode = RenderMode.ScreenSpaceCamera;


        HidePanels();
        nice_job.Play();
        playerrb.isKinematic = true;
        Invoke("OpenCompltPanel", 2f);

        PlayerPrefs.SetInt("cash", PlayerPrefs.GetInt("cash") + 1000);


        if (PlayerPrefs.GetInt("levels"+MenuManager.instance.modenumber) < 29 && MenuManager.LevelNum == PlayerPrefs.GetInt("levels" + MenuManager.instance.modenumber))
        {
            PlayerPrefs.SetInt("levels"+MenuManager.instance.modenumber, PlayerPrefs.GetInt("levels" + MenuManager.instance.modenumber) + 1);
        }

        //FireBaseManager.Instance.LogEvent("level_" + num + "_complete");
    }
    public void OpenCompltPanel()
    {
        HidePanels();
        CompletePanel.SetActive(true);
        AdsController.instance.ShowAd(AdNetwork.ADMOB, AdType.INTERSTITIAL);
        //AdsManager.Instance.ShowInterstitialLoading();
        //AdsManager.Instance.ShowRectBannerAd();
    }
    public void Restart()
    {
        BtnClickSound();
        HidePanels();
        loadingPanel.SetActive(true);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        AudioListener.volume = 1f;
        // AdsManager.Instance.HideRectBannerAd();
    }
    public void OnHome()
    {
        BtnClickSound();
        HidePanels();
        loadingPanel.SetActive(true);
        SceneManager.LoadScene("MainMenu");
        AdsController.instance.ShowAd(AdNetwork.ADMOB, AdType.INTERSTITIAL);
        //AdsManager.Instance.HideRectBannerAd();
    }
    public void OnLevels()
    {
        BtnClickSound();
        HidePanels();
        loadingPanel.SetActive(true);
        MenuManager.IsNext = true;
        SceneManager.LoadScene("MainMenu");
        // AdsManager.Instance.HideRectBannerAd();
    }
    public void OnPause()
    {
        BtnClickSound();
        HidePanels();
        PausePanel.SetActive(true);
        Time.timeScale = 0;
        AudioListener.volume = 0;
        AdsController.instance.ShowAd(AdNetwork.ADMOB, AdType.INTERSTITIAL);
        // AdsManager.Instance.ShowInterstitialLoading();
        // AdsManager.Instance.ShowRectBannerAd();
    }
    public void OnSetting()
    {
        BtnClickSound();
        HidePanels();
        settingsPanel.SetActive(true);
        Time.timeScale = 0;
        //AudioListener.volume = 0;
        // AdsManager.Instance.ShowInterstitialLoading();
        // AdsManager.Instance.ShowRectBannerAd();
    }
    public void OnResume()
    {
        BtnClickSound();
        HidePanels();
        GamePlayPanel.SetActive(true);
        Time.timeScale = 1f;

        if (PlayerPrefs.GetFloat("sound") > 0)
        {
            AudioListener.volume = 1f;
        }
        else
        {
            AudioListener.volume = 0;
        }
        // AdsManager.Instance.HideRectBannerAd();
    }


    public void OnNext()
    {
        BtnClickSound();
        HidePanels();

        loadingPanel.SetActive(true);
        StartCoroutine(NextPlz());
        //  AdsManager.Instance.HideRectBannerAd();
    }
    IEnumerator NextPlz()
    {
        yield return new WaitForSecondsRealtime(2f);
        if (MenuManager.LevelNum < 29)
        {
            MenuManager.LevelNum++;

        }
        else
        {
            MenuManager.LevelNum = 0;
            //MenuManager.IsNext = true;

        }
        Restart();
    }

}
