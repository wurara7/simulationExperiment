using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class GameUI : MonoBehaviour 
{
    public GameObject homeUI;
    public GameObject gameUI;
    public GameObject HintUI;
    public GameObject procedureUI;
    public GameObject attentionUI;
    public GameObject practiceUI;

    public Button exitBtn;
    public Button attentiontBtn;


    void Start()
    {
        print("GamUI start");
        exitBtn.onClick.AddListener(exit);
        attentiontBtn.onClick.AddListener(attention);

        gameUI.SetActive(true);
        HintUI.SetActive(true);
        procedureUI.SetActive(true);
        attentionUI.SetActive(false);
    }
    void exit()
    {
        gameUI.SetActive(true);
        HintUI.SetActive(true);
        homeUI.SetActive(true);
        //◊¢“‚—≠–Ú
        HintUI.SendMessage("reset");
        gameUI.SendMessage("reset");
        homeUI.SendMessage("reStart");
        GameObject.Find("hintObjects").SendMessage("reset");
    
        gameUI.SetActive(false);
        HintUI.SetActive(false);
        GameObject.Find("Camera").GetComponent<PhysicsRaycaster>().enabled = true;
     
    }
    void setPractice()
    {
        //print("¡∑œ∞\n");
        practiceUI.SetActive(true);
    }
    void setExam()
    {
        //print("øº ‘\n");
        practiceUI.SetActive(false);
    }
    void attention()
    {
        if(!attentionUI.activeInHierarchy)
        attentionUI.SetActive(true);    
        else attentionUI.SetActive(false);
    }

    void Update()
    {
        
    }
}
