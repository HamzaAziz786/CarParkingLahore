using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftIndictor : MonoBehaviour
{
    public GameObject leftIndicator;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            leftIndicator.SetActive(true);
            this.GetComponent<BoxCollider>().enabled = false;
        }
    }
}
