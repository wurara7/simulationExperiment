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

    //������������
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
            print(index + "ִ��");
            //ö�ٷǳ����
            if (index == 6)
            {
                str = hint[index].GetComponentInChildren<InputField>().text;
                try
                {
                    if (float.Parse(str) <= 2.5 && float.Parse(str) >= 2)
                    {
                        print("�Ȼ���������ȷ");
                        score += 4;
                        scoreText.text = score.ToString();
                    }
                }
                catch (System.FormatException EX)
                {
                    print(EX.Message);
                }
                hint[index].GetComponentInChildren<InputField>().text = "";//����
            }
            else if (index == 7)
            {
                str = hint[index].GetComponentInChildren<InputField>().text;
                if (str == "12.5")
                {
                    print("����������ȷ");
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
                    print("�����ٶ�������ȷ");
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
                    print("������ˮ������ȷ");
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
                    print("������������ȷ");
                    score += 4;
                    scoreText.text = score.ToString();
                }
                hint[index].GetComponentInChildren<InputField>().text = "";//����
            }
            else if (index == 28)
            {
                str = hint[index].GetComponentInChildren<InputField>().text;
                try
                {
                    if (float.Parse(str) <= 0.5 && float.Parse(str) >= 0.3)
                    {
                        print("ȥ����������������ȷ");
                        score += 4;
                        scoreText.text = score.ToString();
                    }
                }
                catch (System.FormatException EX)
                {
                    print(EX.Message);
                }
                hint[index].GetComponentInChildren<InputField>().text = "";//����
            }
            else if (index == 30 || index == 25 || index == 32)//2.5�𰸴󼯺�
            {
                str = hint[index].GetComponentInChildren<InputField>().text;
                if (str == "2.5")
                {
                    print("߻����������ȷ");
                    score += 4;
                    scoreText.text = score.ToString();
                }
                hint[index].GetComponentInChildren<InputField>().text = "";//����
            }
            else if (index == 31)
            {
                str = hint[index].GetComponentInChildren<InputField>().text;
                if (str == "1")
                {
                    print("�񾭴�����������ȷ");
                    score += 4;
                    scoreText.text = score.ToString();
                }
                hint[index].GetComponentInChildren<InputField>().text = "";//����
            }
            else if (index == 34)//���ű�
            {
                 InputField[] str= hint[index].GetComponentsInChildren<InputField>();
 
                if (str[0].text == "2")
                {
                    print("С��������ȷ");
                    score += 2;
                }
                if (str[1].text == "4")
                {
                    print("С��������ȷ");
                    score += 2;
                }
                scoreText.text = score.ToString();

                str[0].text = "";
                str[1].text = "";
            }
            else if (index == 35)//���ű�
            {
                InputField[] str = hint[index].GetComponentsInChildren<InputField>();

                if (str[0].text == "7.9")
                {
                    print("С��������ȷ");
                    score += 2;
                }
                if (str[1].text == "2.0")
                {
                    print("С��������ȷ");
                    score += 2;
                }
                scoreText.text = score.ToString();

                str[0].text = "";
                str[1].text = "";
            }
            else if (index == 36)//���ű�
            {
                InputField[] str = hint[index].GetComponentsInChildren<InputField>();

                if (str[0].text == "2.0")
                {
                    print("С��������ȷ");
                    score += 2;
                }
                if (str[1].text == "0.2")
                {
                    print("С��������ȷ");
                    score += 2;
                }
                scoreText.text = score.ToString();
                str[0].text = "";
                str[1].text = "";
            }
            else if (index == 37)//���ű�
            {
                InputField[] str = hint[index].GetComponentsInChildren<InputField>();

                if (str[0].text == "0.2")
                {
                    print("С��������ȷ");
                    score += 2;
                }
                if (str[1].text == "5.0")
                {
                    print("С��������ȷ");
                    score += 2;
                }
                scoreText.text = score.ToString();
                str[0].text = "";
                str[1].text = "";
            }


            //��ҳ����
            hint[index++].SetActive(false);
            hint[index].SetActive(true);
         

            if (index == 4 || index == 5 || index == 21 || index == 25)//������رյĲ���
            {
                hintsUI.SetActive(false);
                GameObject.Find("Camera").GetComponent<PhysicsRaycaster>().enabled = true;
            }
        }
        else//����Խ��,��ʾ������ȫ���ر�
        {
            //����������ж�����jojo��
            str = hint[index].GetComponentInChildren<InputField>().text;
            if (str == "1")
            {
                print("�����Լ�������ȷ");
                score += 4;
                scoreText.text = score.ToString();
            }
            hint[index].GetComponentInChildren<InputField>().text = "";//����

            hint[index].SetActive(false);
            hintsUI.SetActive(false);
            index = 0;

            if (isExam)
            {//����ʵ��÷�Ϊ��
                mark.enabled = true;
                mark.text = string.Concat("����ʵ��÷�Ϊ��", score.ToString());
            }
        }

        
    
    }
}
