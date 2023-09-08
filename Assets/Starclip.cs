using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Starclip : MonoBehaviour
{
    public AudioSource starSource;
    public AudioClip starClip;
    // Start is called before the first frame update
    public void StarSound()
    {
        
            starSource.PlayOneShot(starClip);
    }
}
