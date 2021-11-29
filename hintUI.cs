using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class hintUI : MonoBehaviour
{
    public GameObject hintsUI;
    public Button next;
    public GameObject[] hint;
    public Text mark;
    public Text scoreText;
    int index = 0;
    int score = 0;

    bool isExam;

    //用作接收输入
    string str;
    void Start()
    {
        print("hint UIstart");
        next.onClick.AddListener(Next);
        reset();
    }

    void setExam()
    {
        isExam = true;
    }
    void setPractice()
    {
        isExam=false;
    }
    public void reset()
    {
        this.index = 0;
        for (int i = 0; i < hint.Length - 1; i++)
        {
            hint[i].SetActive(false);
        }
        hint[0].SetActive(true);
        GameObject.Find("Camera").GetComponent<PhysicsRaycaster>().enabled = false;
        score = 0;
        scoreText.text = score.ToString();
        mark.GetComponent<Text>().text = " ";
        mark.enabled = false;

    }
    void Next()
    {
        if (index + 1 < hint.Length)
        {
            print(index + "执行");
            //枚举非常舒服
            if (index == 6)
            {
                str = hint[index].GetComponentInChildren<InputField>().text;
                try
                {
                    if (float.Parse(str) <= 2.5 && float.Parse(str) >= 2)
                    {
                        print("氯化汞输入正确");
                        score += 4;
                        scoreText.text = score.ToString();
                    }
                }
                catch (System.FormatException EX)
                {
                    print(EX.Message);
                }
                hint[index].GetComponentInChildren<InputField>().text = "";//清零
            }
            else if (index == 7)
            {
                str = hint[index].GetComponentInChildren<InputField>().text;
                if (str == "12.5")
                {
                    print("尿烷输入正确");
                    score += 4;
                    scoreText.text = score.ToString();
                }
                hint[index].GetComponentInChildren<InputField>().text = "";
            }
            else if (index == 21)
            {
                str = hint[index].GetComponentInChildren<InputField>().text;
                if (str == "3000")
                {
                    print("离心速度输入正确");
                    score += 4;
                    scoreText.text = score.ToString();
                }
                hint[index].GetComponentInChildren<InputField>().text = "";
            }
            else if (index == 25)
            {
                str = hint[index].GetComponentInChildren<InputField>().text;
                if (str == "20")
                {
                    print("生理盐水输入正确");
                    score += 4;
                    scoreText.text = score.ToString();
                }
                hint[index].GetComponentInChildren<InputField>().text = "";
            }
            else if (index == 26)
            {
                str = hint[index].GetComponentInChildren<InputField>().text;
                if (str == "10")
                {
                    print("葡萄糖输入正确");
                    score += 4;
                    scoreText.text = score.ToString();
                }
                hint[index].GetComponentInChildren<InputField>().text = "";//清零
            }
            else if (index == 28)
            {
                str = hint[index].GetComponentInChildren<InputField>().text;
                try
                {
                    if (float.Parse(str) <= 0.5 && float.Parse(str) >= 0.3)
                    {
                        print("去甲肾上腺素输入正确");
                        score += 4;
                        scoreText.text = score.ToString();
                    }
                }
                catch (System.FormatException EX)
                {
                    print(EX.Message);
                }
                hint[index].GetComponentInChildren<InputField>().text = "";//清零
            }
            else if (index == 30 || index == 25 || index == 32)//2.5答案大集合
            {
                str = hint[index].GetComponentInChildren<InputField>().text;
                if (str == "2.5")
                {
                    print("呋塞米输入正确");
                    score += 4;
                    scoreText.text = score.ToString();
                }
                hint[index].GetComponentInChildren<InputField>().text = "";//清零
            }
            else if (index == 31)
            {
                str = hint[index].GetComponentInChildren<InputField>().text;
                if (str == "1")
                {
                    print("神经垂体素输入正确");
                    score += 4;
                    scoreText.text = score.ToString();
                }
                hint[index].GetComponentInChildren<InputField>().text = "";//清零
            }
            else if (index == 34)//四张表
            {
                 InputField[] str= hint[index].GetComponentsInChildren<InputField>();
 
                if (str[0].text == "2")
                {
                    print("小空输入正确");
                    score += 2;
                }
                if (str[1].text == "4")
                {
                    print("小空输入正确");
                    score += 2;
                }
                scoreText.text = score.ToString();

                str[0].text = "";
                str[1].text = "";
            }
            else if (index == 35)//四张表
            {
                InputField[] str = hint[index].GetComponentsInChildren<InputField>();

                if (str[0].text == "7.9")
                {
                    print("小空输入正确");
                    score += 2;
                }
                if (str[1].text == "2.0")
                {
                    print("小空输入正确");
                    score += 2;
                }
                scoreText.text = score.ToString();

                str[0].text = "";
                str[1].text = "";
            }
            else if (index == 36)//四张表
            {
                InputField[] str = hint[index].GetComponentsInChildren<InputField>();

                if (str[0].text == "2.0")
                {
                    print("小空输入正确");
                    score += 2;
                }
                if (str[1].text == "0.2")
                {
                    print("小空输入正确");
                    score += 2;
                }
                scoreText.text = score.ToString();
                str[0].text = "";
                str[1].text = "";
            }
            else if (index == 37)//四张表
            {
                InputField[] str = hint[index].GetComponentsInChildren<InputField>();

                if (str[0].text == "0.2")
                {
                    print("小空输入正确");
                    score += 2;
                }
                if (str[1].text == "5.0")
                {
                    print("小空输入正确");
                    score += 2;
                }
                scoreText.text = score.ToString();
                str[0].text = "";
                str[1].text = "";
            }


            //跳页功能
            hint[index++].SetActive(false);
            hint[index].SetActive(true);
         

            if (index == 4 || index == 5 || index == 21 || index == 25)//结束后关闭的步骤
            {
                hintsUI.SetActive(false);
                GameObject.Find("Camera").GetComponent<PhysicsRaycaster>().enabled = true;
            }
        }
        else//数组越界,提示结束，全部关闭
        {
            //这就是最后的判断啦！jojo！
            str = hint[index].GetComponentInChildren<InputField>().text;
            if (str == "1")
            {
                print("班氏试剂输入正确");
                score += 4;
                scoreText.text = score.ToString();
            }
            hint[index].GetComponentInChildren<InputField>().text = "";//清零

            hint[index].SetActive(false);
            hintsUI.SetActive(false);
            index = 0;

            if (isExam)
            {//本次实验得分为：
                mark.enabled = true;
                mark.text = string.Concat("本次实验得分为：", score.ToString());
            }
        }

        
    
    }
}
