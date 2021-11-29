using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class homeUI : MonoBehaviour
{
    public GameObject loginUI; 
    public GameObject modeChoiceUI;
    public GameObject gameUI;
    public GameObject hintUI;

    public Button loginBtn;
    public Button exitBtn;
    public Button examBtn;
    public Button practicBtn;

    void Start()
    {
       // print("homeUI start");
        loginBtn.onClick.AddListener(login);
        exitBtn.onClick.AddListener(exit);
        examBtn.onClick.AddListener(examMode);
        practicBtn.onClick.AddListener(practiceMode);

        reStart();

    }
    
    void reStart()
    {
       // print("home UI start");
        this.gameObject.SetActive(true);
        loginUI.SetActive(true);
        hintUI.SetActive(false);
        modeChoiceUI.SetActive(false);
        gameUI.SetActive(false);

        playerMovement.setIsMove(false);
    }
    void examMode()
    {
        playerMovement.setIsMove(true);
        modeChoiceUI.SetActive(false);
        hintUI.SetActive(true);
        gameUI.SetActive(true);
        GameObject.Find("GameUI").SendMessage("setExam");
        GameObject.Find("hintObjects").SendMessage("setExam");
        hintUI.SendMessage("setExam");
    }
    void practiceMode()
    {
        playerMovement.setIsMove(true);
        modeChoiceUI.SetActive(false);
        hintUI.SetActive(true);
        gameUI.SetActive(true);
        GameObject.Find("GameUI").SendMessage("setPractice");
        GameObject.Find("hintObjects").SendMessage("setPractice");
        hintUI.SendMessage("setPractice");
    }
        void login()
    {
       // print("µÇÂ¼");
        loginUI.SetActive(false);
        modeChoiceUI.SetActive(true);
    }
    void  exit()
    {
        loginUI.SetActive(false);
        Application.Quit();
    }

    void Update()
    {
        
    }
}
