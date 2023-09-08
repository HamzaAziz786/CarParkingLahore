using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SWS;

public class yield : MonoBehaviour
{
    public static yield Instance;
    public splineMove bus;

    private void OnTriggerEnter(Collider other)
    {
        if( other.CompareTag("Player"))
        {
            bus.StartMove();
            this.GetComponent<BoxCollider>().enabled = false;
        }
    }
}
