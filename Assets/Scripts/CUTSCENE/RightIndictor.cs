using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightIndictor : MonoBehaviour
{
    public GameObject rightIndicator;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            rightIndicator.SetActive(true);
            this.GetComponent<BoxCollider>().enabled = false;
        }
    }
}
