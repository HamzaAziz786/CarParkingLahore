using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Splash : MonoBehaviour
{
    public GameObject LoadingPanel;
    public GameObject PrivacyPanel;
    public Image loadingimg;
    AsyncOperation asyncLoad;

    private void Start()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;

        if (PlayerPrefs.GetInt("Once") == 0)
        {
            PlayerPrefs.SetInt("control", 2);
            PlayerPrefs.SetFloat("sound", 1f);
            PrivacyPanel.SetActive(true);
        }
        else
            StartCoroutine(ActiveLoading());
        
    }

    public void AcceptBtn()
    {
        PlayerPrefs.SetInt("Once", 1);
        StartCoroutine(ActiveLoading());
        PrivacyPanel.SetActive(false);
    }

    public void PolicyLinkOpen()
    {
        Application.OpenURL("https://sites.google.com/view/parkinggamesarena/home");
    }

    IEnumerator ActiveLoading()
    {
        yield return new WaitForSeconds(0f);

        PrivacyPanel.SetActive(false);
        LoadingPanel.SetActive(true);
        StartCoroutine(LoadYourAsyncScene());
    }
    IEnumerator LoadYourAsyncScene()
    {
        yield return new WaitForSecondsRealtime(1f);
        asyncLoad = SceneManager.LoadSceneAsync("MainMenu");

        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            float progress = Mathf.Clamp01(asyncLoad.progress / 0.9f);
            yield return null;
        }
    }

    private void Update()
    {
        if (LoadingPanel.activeSelf && asyncLoad != null)
        {
            loadingimg.fillAmount = asyncLoad.progress;
        }
    }
}
