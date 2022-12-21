using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject talkPanel;
    public GameObject Image1;
    public GameObject Image2;
    public GameObject Image3;
    public GameObject Image4;
    public GameObject Image5;
    public GameObject Space;
    public GameObject Space2;

    public bool isChat;

    public Text talkText;
    public TalkManager talkManager;
    public int talkIndex;

    public float Timer;

    public float totalTime;








    private void Awake()
    {
        StartCoroutine(Gog());

    }
    private void Update()
    {
        
        Timer += Time.deltaTime;

      
        if (Input.GetButtonDown("Jump") && Timer >= 6.0f && isChat==false)
        {
            Space2.gameObject.SetActive(false);

            Talk(1, true);                            // ���� �ؽ�Ʈ�� ���� �ܿ��� ����� ĭ
            Image1.gameObject.SetActive(false); // ���� �⺻ ������
            Image2.gameObject.SetActive(false); // �� ��Ÿ�� ������
            Image3.gameObject.SetActive(false); // ���
            Image4.gameObject.SetActive(false); // ��
            Image5.gameObject.SetActive(false); // ��
            Space.gameObject.SetActive(false);


        }

        if (talkIndex==9 )
            {
            StartCoroutine(NextScene());                // ���� �� ����
            }

        if (Input.GetKeyDown(KeyCode.F2))
        {
            SceneManager.LoadScene("TestScene");

        }
    }
    public void Action()
    {
    }

    void Talk(int id, bool isNpc)       //�����̽��� �������ν� ����� �̺�Ʈ 
    {
        string talkData = talkManager.GetTalk(1, talkIndex);

        if(talkData ==null)
        {
            return;
        }
       // talkText.text = talkData;
        StartCoroutine(Typing(talkText, talkData)); // talkData �� �ؽ�Ʈ ����.
        StartCoroutine(StopSpace());
        talkIndex++;
    }

   IEnumerator Gog()
    {
        yield return new WaitForSeconds(4f);
        talkPanel.gameObject.SetActive(true);

    }
    
    IEnumerator Typing(Text typ,string message)
    {


        for (int i =0; i<message.Length; i++)
        {
            typ.text = message.Substring(0, i + 1);
            yield return new WaitForSeconds(0.05f);
        }


        if (talkIndex == 1)                // �ؽ�Ʈ ������� ������ ����
        {
            Space.gameObject.SetActive(true);


        }
        if (talkIndex==2)
        {
            
            Space.gameObject.SetActive(true);

        }
        if (talkIndex == 3)
        {
            Image1.gameObject.SetActive(true);
            Space.gameObject.SetActive(true);
        }
        if (talkIndex == 4)
        {
            Image2.gameObject.SetActive(true);
            Space.gameObject.SetActive(true);
        }
        if (talkIndex == 5)
        {
            Image3.gameObject.SetActive(true);
            Space.gameObject.SetActive(true);

        }
        if (talkIndex == 6)
        {
            Image4.gameObject.SetActive(true);
            Space.gameObject.SetActive(true);
        }
        if (talkIndex == 7)
        {
            Image5.gameObject.SetActive(true);
            Space.gameObject.SetActive(true);
        }
        if (talkIndex == 8)
        {
            Space.gameObject.SetActive(true);
        }
    }

    IEnumerator NextScene()
    {
        yield return new WaitForSeconds(2.5f);
        
       
        SceneManager.LoadScene("TestScene");

    }

    IEnumerator StopSpace()
    {
        isChat=true;
        yield return new WaitForSeconds(4f);
        isChat = false;


        

    }
}
