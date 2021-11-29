using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class hintMethod : MonoBehaviour
{
    Animator rabbit;
    Animator tube;

    GameObject operatingUI;
    GameObject HintUI;
    GameObject camera;
    void Start() 
    {
       // print("hintMethodStart");
        HintUI = GameObject.Find("hintUI");
        operatingUI = GameObject.Find("operatingUI");

        rabbit = GameObject.FindGameObjectWithTag("rabbit").GetComponent<Animator>();
        rabbit.SetBool("rabbitWeigh", false);
        rabbit.SetBool("rabbitMove", false);

        tube = GameObject.Find("tube").GetComponent<Animator>();
        tube.SetBool("centrifuge", false);

        camera = GameObject.Find("Camera");
      /*  if (camera != null)
            print("找到摄像机");
        else print("找不到摄像机");
        if (operatingUI == null)
            print("找不到operatingUI");
        else print("找到operatingUI");

        if (HintUI == null)
            print("找不到hintUI");
        else print("找到hintUI");
        if (rabbit == null)
            print("找不到animator");
        else
        {
            print("找到animator");
        }*/
    }

    public void reset()
    {
        rabbit.SetBool("rabbitWeigh", false);
        rabbit.SetBool("rabbitMove", false);
        rabbit.Play("New State");

        tube.SetBool("centrifuge", false);
        tube.Play("New State");
    }
    public void weigh()
    {
        print("称重");
        rabbit.SetBool("rabbitWeigh", true);
        GameObject.Find("weigher").GetComponent<Animator>().Play("weigh");
        HintUI.SetActive(true);
        camera.GetComponent<PhysicsRaycaster>().enabled = false;
        GameObject.Find("hintObjects").SendMessage("nextHint");
    }
    public void move()
    {
        print("手术");
        if (rabbit != null)
        {
            print("动画参数"+rabbit.parameterCount);
            rabbit.SetBool("rabbitMove", true);
            print("rabbitMove");
        }
        GameObject.Find("operatingTable").GetComponent<Animator>().Play("table");
        GameObject.Find("hintObjects").SendMessage("nextHint");
    }
   
    public void operate()
    {
            HintUI.SetActive(true);
            camera.GetComponent<PhysicsRaycaster>().enabled = false;
            print("手术时hintUI激活");

            GameObject.Find("hintObjects").SendMessage("nextHint");
   
          //先填尿烷再看图片
    }
    public void centrifuge()
    {
        print("离心机");

        HintUI.SetActive(true);
        camera.GetComponent<PhysicsRaycaster>().enabled = false;

        tube.SetBool("centrifuge", true);

        GameObject.Find("hintObjects").SendMessage("nextHint");
    }
     public void uraneCollection()
    {
        print("尿液收集");
        HintUI.SetActive(true);
        camera.GetComponent<PhysicsRaycaster>().enabled = false;

        HintUI.GetComponent<hintUI>().SendMessage("Next");
    }
    public void gupse()
    {
        print("液态石膏");
        GameObject.Find("gupse ").GetComponent<Animator>().Play("gupse");
        GameObject.Find("hintObjects").SendMessage("nextHint");
    }
    public void catheter()
    {
        print("导尿管");
        HintUI.SetActive(true);
        camera.GetComponent<PhysicsRaycaster>().enabled = false;
        GameObject.Find("catheter").GetComponent<Animator>().Play("catheter");
        GameObject.Find("hintObjects").SendMessage("nextHint");
    }
    public void machine()
    {
        print("血压仪");
        HintUI.SetActive(true);
        camera.GetComponent<PhysicsRaycaster>().enabled = false;
        GameObject.Find("machine").GetComponent<Animator>().Play("machine");
        GameObject.Find("hintObjects").SendMessage("nextHint");
    }
    public void injectHgcl2()
    {
        print("注射氯化汞");
        GameObject.Find("hintObjects").SendMessage("nextHint");
    }
    public void urethane()
    {
        print("注射氨基甲酸乙酯");
        GameObject.Find("hintObjects").SendMessage("nextHint");
    }

}
