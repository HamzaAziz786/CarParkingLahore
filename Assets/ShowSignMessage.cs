using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SWS;
public class StopSIgn : MonoBehaviour
{
    public static StopSIgn Instance;
    public GameObject messagePnael;
    public splineMove playerCar;
    //public Animator Camera;

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
    }
    private void OnTriggerEnter(Collider other)
    {

        
        if (other.CompareTag("Player"))
        {
            playerCar.Pause();
            messagePnael.SetActive(true);
            this.gameObject.GetComponent<BoxCollider>().enabled = false;


            StartCoroutine(Delay());
        }
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(2f);
        messagePnael.SetActive(false);
        

        

        yield return new WaitForSeconds(2f);
        print("333");

        messagePnael.SetActive(false);
        playerCar.Resume();


    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
