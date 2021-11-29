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
            print("�ҵ������");
        else print("�Ҳ��������");
        if (operatingUI == null)
            print("�Ҳ���operatingUI");
        else print("�ҵ�operatingUI");

        if (HintUI == null)
            print("�Ҳ���hintUI");
        else print("�ҵ�hintUI");
        if (rabbit == null)
            print("�Ҳ���animator");
        else
        {
            print("�ҵ�animator");
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
        print("����");
        rabbit.SetBool("rabbitWeigh", true);
        GameObject.Find("weigher").GetComponent<Animator>().Play("weigh");
        HintUI.SetActive(true);
        camera.GetComponent<PhysicsRaycaster>().enabled = false;
        GameObject.Find("hintObjects").SendMessage("nextHint");
    }
    public void move()
    {
        print("����");
        if (rabbit != null)
        {
            print("��������"+rabbit.parameterCount);
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
            print("����ʱhintUI����");

            GameObject.Find("hintObjects").SendMessage("nextHint");
   
          //���������ٿ�ͼƬ
    }
    public void centrifuge()
    {
        print("���Ļ�");

        HintUI.SetActive(true);
        camera.GetComponent<PhysicsRaycaster>().enabled = false;

        tube.SetBool("centrifuge", true);

        GameObject.Find("hintObjects").SendMessage("nextHint");
    }
     public void uraneCollection()
    {
        print("��Һ�ռ�");
        HintUI.SetActive(true);
        camera.GetComponent<PhysicsRaycaster>().enabled = false;

        HintUI.GetComponent<hintUI>().SendMessage("Next");
    }
    public void gupse()
    {
        print("Һ̬ʯ��");
        GameObject.Find("gupse ").GetComponent<Animator>().Play("gupse");
        GameObject.Find("hintObjects").SendMessage("nextHint");
    }
    public void catheter()
    {
        print("�����");
        HintUI.SetActive(true);
        camera.GetComponent<PhysicsRaycaster>().enabled = false;
        GameObject.Find("catheter").GetComponent<Animator>().Play("catheter");
        GameObject.Find("hintObjects").SendMessage("nextHint");
    }
    public void machine()
    {
        print("Ѫѹ��");
        HintUI.SetActive(true);
        camera.GetComponent<PhysicsRaycaster>().enabled = false;
        GameObject.Find("machine").GetComponent<Animator>().Play("machine");
        GameObject.Find("hintObjects").SendMessage("nextHint");
    }
    public void injectHgcl2()
    {
        print("ע���Ȼ���");
        GameObject.Find("hintObjects").SendMessage("nextHint");
    }
    public void urethane()
    {
        print("ע�䰱����������");
        GameObject.Find("hintObjects").SendMessage("nextHint");
    }

}
