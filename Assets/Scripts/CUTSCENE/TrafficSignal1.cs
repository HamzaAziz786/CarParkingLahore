using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrafficSignal1 : MonoBehaviour
{
    
    public GameObject Red, Green;
   

    
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Red.SetActive(false);
            Green.SetActive(true);
            this.GetComponent<BoxCollider>().enabled = false;
        }

        
    }
}
