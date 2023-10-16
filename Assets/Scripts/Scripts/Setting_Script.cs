using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Setting_Script : MonoBehaviour
{


    public Toggle SoundToggle;
    public Toggle SteeringOn;
    public Toggle BtnsOn;
    public Toggle TiltOn;
    public Slider soundSlider;
    
    private void OnEnable()
    {
        soundSlider.value = PlayerPrefs.GetFloat("sound");

        if (PlayerPrefs.GetFloat("sound") == 0)
        {
            SoundToggle.isOn = false;
        }

            if (!SoundToggle.isOn)
            soundSlider.value = 0f;

        if (PlayerPrefs.GetInt("control") == 0)
        {           
            TiltOn.isOn = false;
            SteeringOn.isOn = false;
            BtnsOn.isOn = true;
            RCC_Settings.Instance.mobileController = RCC_Settings.MobileController.TouchScreen;
        }
        else if (PlayerPrefs.GetInt("control") == 1)
        {
            SteeringOn.isOn = false;
            BtnsOn.isOn = false;
            TiltOn.isOn = true;
            RCC_Settings.Instance.mobileController = RCC_Settings.MobileController.Gyro;
        }
        else if (PlayerPrefs.GetInt("control") == 2)
        {
            
            TiltOn.isOn = false;
            BtnsOn.isOn = false;
            SteeringOn.isOn = true;
            RCC_Settings.Instance.mobileController = RCC_Settings.MobileController.SteeringWheel;
        }

    }

    public void ChangeControl(int num)
    {
        if (SceneManager.GetActiveScene().name == "MainMenu")
            MenuManager.instance.BtnClickSound();
        else
            GamePlay_Manager.Instance.BtnClickSound();

        PlayerPrefs.SetInt("control", num);
        if (num == 0)
        {
            RCC_Settings.Instance.mobileController = RCC_Settings.MobileController.TouchScreen;
        }
        else if (num == 1)
        {
            RCC_Settings.Instance.mobileController = RCC_Settings.MobileController.Gyro;
        }
        else if (num == 2)
        {

            RCC_Settings.Instance.mobileController = RCC_Settings.MobileController.SteeringWheel;
        }
    }

    public void SoundCheckBox()
    {

        if (!SoundToggle.isOn)
            soundSlider.value = 0f;
        else
            soundSlider.value = 1f;
    }

    public void CheckSound()
    {
        if (soundSlider.value == 0)
            SoundToggle.isOn = false;
        else
            SoundToggle.isOn = true;

        AudioListener.volume = soundSlider.value;
        PlayerPrefs.SetFloat("sound", soundSlider.value);
    }

    //private void Update()
    //{

       
    //}
}
