using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vehicle_Lights : MonoBehaviour
{
    public GameObject BrakeLights;
    public Animator Indicator,brakeLights;


    public static Vehicle_Lights Instance;
    private void Start()
    {
        Instance = this;
        InvokeRepeating("CheckBrakes", 1f, 0.1f);
    }

    void CheckBrakes()
    {
        if (RCC_SceneManager.Instance.activePlayerVehicle.brakeInput > 0.1)
            BrakeLights.SetActive(true);
        else
            BrakeLights.SetActive(false);
    }
}
