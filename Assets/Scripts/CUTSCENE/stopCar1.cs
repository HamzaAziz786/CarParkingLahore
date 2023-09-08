using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SWS;

public class stopCar1 : MonoBehaviour
{
    public static stopCar1 Instance;
    public RCC_CarControllerV3 Car;
    //public RCC_AICarController Car;
    //splineMove car;
    //public splineMove cam;
    public GameObject cutScene, gameManger, RccCam;

    private void Start()
    {
        Instance = this;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            print("player");
            Car.rigid.drag = 3;
            Car.brakeInput = 1;
            
            //messagePanel.SetActive(true);
            //Car.engineRunning = false;
            // Car.enabled = false;
            //car = other.transform.GetComponent<splineMove>();
            //car.Pause();
            StartCoroutine(Delay());
        }
    }

    IEnumerator Delay()
    {


        yield return new WaitForSeconds(2f);
        //messagePanel.SetActive(false);
        gameManger.SetActive(true);
        cutScene.SetActive(false);
        RccCam.SetActive(true);
        //CUTSCENE.Instance.skipBtn.SetActive(false);
        //car.Resume();



    }
}
