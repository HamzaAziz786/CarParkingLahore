using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sign_demo : MonoBehaviour
{
    public static sign_demo Instance;

    public Animator Message;
    public GameObject Tut_anim;

    private void Start()
    {
        Instance = this;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {


            //texttype.text = "You Successfully followed the rule.";
            //Gameplay.instance.ShowNotification();
            //this.GetComponent<BoxCollider>().enabled = false;
            RCC_SceneManager.Instance.activePlayerVehicle.rigid.isKinematic = true;
            this.GetComponent<BoxCollider>().enabled = false;


            Tut_anim.SetActive(true);
                
                //Time.timeScale = 0;
                //Gameplay.instance.SideImgsAnim.SetActive(true);
                //Gameplay.instance.GameplayPanel.SetActive(false);
                ShowNotification();
                      
            
        }
    }

    public void ShowNotification()
    {
        Message.enabled = true;
        
        StartCoroutine(HideNotification());
    }

    IEnumerator HideNotification()
    {
        yield return new WaitForSecondsRealtime(3f);
        Message.SetBool("state", true);
    }
}
