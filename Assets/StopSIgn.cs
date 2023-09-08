using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SWS;
public class ShowSignMessage : MonoBehaviour
{
    public static ShowSignMessage Instance;
    public GameObject messagePnael;
    

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
    }
   
    public void SignBoard()
    {
        messagePnael.SetActive(true);
    }


}
