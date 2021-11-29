using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hintObjects : MonoBehaviour
{
    public GameObject[] hintObject;
    int index = 0;
    bool isExam=false;

    void Start()
    {
        print("hintObj start");
        reset();
    }

    public void setExam()
    {
        isExam = true;
        reset();
    }
    public void setPractice()
    {
        isExam=false;
        reset();
    }
    public void reset()
    {
        print("reset");
        index = 0;
        for (int i = 0; i < hintObject.Length; i++)
        {
            hintObject[i].GetComponent<Glinting>().SendMessage("StopGlinting");
            hintObject[i].GetComponent<BoxCollider>().enabled = false;
        }
        if (!isExam)
        {
            hintObject[0].GetComponent<Glinting>().StartGlinting();
        }
        hintObject[0].GetComponent<BoxCollider>().enabled = true;
    }
    public void nextHint()
    {
        print(index+"¹Ø±Õ");
        hintObject[index].GetComponent<Glinting>().StopGlinting();
        hintObject[index].GetComponent<BoxCollider>().enabled = false;
        if (index+1<hintObject.Length)
        {
            index++;
            if(!isExam)
            { 
                hintObject[index].GetComponent<Glinting>().StartGlinting();
            }
            hintObject[index].GetComponent<BoxCollider>().enabled = true;
        }
    }
}
