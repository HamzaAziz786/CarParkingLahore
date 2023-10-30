using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class
    LevelsPanel : MonoBehaviour
{
    public GameObject[] levels;
    public GameObject[] lockedImg;
  
    public static LevelsPanel instance;
    public GameObject content;
    void Start()
    {
       
        instance = this;

    }

   
    private void OnEnable()
    {
        content.transform.position = new Vector3(0, 0, 0);
        Debug.Log(MenuManager.instance.ModeLevels_T[MenuManager.instance.modenumber]);
        foreach (var item in levels)
        {
            item.gameObject.SetActive(false);
        }
        for (int i = 0; i < levels.Length; i++)
        {
            if (i <= MenuManager.instance.ModeLevels_T[MenuManager.instance.modenumber])
                levels[i].gameObject.SetActive(true);
        }
        foreach (GameObject obj in levels)
        {
            obj.GetComponent<Button>().interactable = false;

        }
        
        levels[PlayerPrefs.GetInt("levels"+MenuManager.instance.modenumber)].transform.GetChild(0).gameObject.SetActive(false);
        for (int i = 0; i <= PlayerPrefs.GetInt("levels" + MenuManager.instance.modenumber); i++)
        {
            lockedImg[i].SetActive(true);
        }
     

    }


    void Update()
    {
        for (int i = 0; i <= PlayerPrefs.GetInt("levels" + MenuManager.instance.modenumber); i++)
        {
            levels[i].GetComponent<Button>().interactable = true;
        }
        for (int i = 0; i <= PlayerPrefs.GetInt("levels" + MenuManager.instance.modenumber); i++)
        {
            lockedImg[i].SetActive(false);
        }
    }
}
