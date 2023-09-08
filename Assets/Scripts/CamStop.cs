using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SWS;

public class CamStop : MonoBehaviour
{
    
    splineMove cam;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ActionCam"))
        {
            cam = other.transform.GetComponent<splineMove>();
            cam.Pause();
            StartCoroutine(Delay());
        }
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(6f);
            
        cam.Resume();



    }
}
