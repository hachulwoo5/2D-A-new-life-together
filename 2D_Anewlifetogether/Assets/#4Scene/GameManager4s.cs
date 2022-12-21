using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager4s : MonoBehaviour
{
    public GameObject talkPanel;
    public GameObject PanelMs;
    public GameObject Panelcorgi;
    
    public GameObject Space;
    public GameObject Space2;

    public GameObject Camera1;
    public GameObject Camera2;

    public bool isChat;

    public Text talkText;
    public TalkManagerS4 talkManagerS4;
    public int talkIndex;

    public float Timer;

    public float totalTime;

    public bool isCorgihome;


    AdSet adset;




    private void Awake()
    {
        StartCoroutine(Gog());
        adset = GameObject.Find("AdManager").GetComponent<AdSet>();

    }
    private void Update()
    {

        Timer += Time.deltaTime;


        if (Input.GetButtonDown("Jump") && Timer >= 6.0f && isChat == false  )
        {
            Space2.gameObject.SetActive(false);

            Talk(1, true);
           
            Space.gameObject.SetActive(false);


        }
        if (talkIndex == 1)
        {
            PanelMs.gameObject.SetActive(false);
            Panelcorgi.gameObject.SetActive(true);
        }

        if (talkIndex == 2)
        {
            Panelcorgi.gameObject.SetActive(false);
            PanelMs.gameObject.SetActive(true);
        }
        if (talkIndex == 3)
        {
            Panelcorgi.gameObject.SetActive(false);
            PanelMs.gameObject.SetActive(true);
        }
        if (talkIndex == 4)
        {
            Panelcorgi.gameObject.SetActive(true);
            PanelMs.gameObject.SetActive(false);
        }

        if (talkIndex == 5)
        {
            Camera1.gameObject.SetActive(false);
            Camera2.gameObject.SetActive(true);
            talkPanel.gameObject.SetActive(false);
            Panelcorgi.gameObject.SetActive(false);
            PanelMs.gameObject.SetActive(false);

        }

        if (talkIndex == 6)
        {
            PanelMs.gameObject.SetActive(true);
            talkPanel.gameObject.SetActive(true);

        }
        if (talkIndex == 7)
        {
          

        }

        if(adset.pressure[1]>=10)
        {
            isCorgihome = true;
        }
        else
        {
            isCorgihome = false;
        }

        if(isCorgihome==true)
        {
            StartCoroutine(NextScene());

        }
    }
    public void Action()
    {
    }

    void Talk(int id, bool isNpc)       //스페이스를 누름으로써 생기는 이벤트 
    {
        string talkData = talkManagerS4.GetTalk(1, talkIndex);

        if (talkData == null)
        {
            return;
        }
        // talkText.text = talkData;
        StartCoroutine(Typing(talkText, talkData)); // talkData 가 텍스트 내용.
        StartCoroutine(StopSpace());
        talkIndex++;
    }

    IEnumerator Gog()
    {
        yield return new WaitForSeconds(3f);
        talkPanel.gameObject.SetActive(true);

    }

    IEnumerator Typing(Text typ, string message)
    {


        for (int i = 0; i < message.Length; i++)
        {
            typ.text = message.Substring(0, i + 1);
            yield return new WaitForSeconds(0.05f);
        }


        if (talkIndex == 1)
        {
            
            Space2.gameObject.SetActive(true);
        }

        if (talkIndex == 2)
        {
          
            Space2.gameObject.SetActive(true);
        }
        if (talkIndex == 3)
        {
            
            Space2.gameObject.SetActive(true);
        }
        if (talkIndex == 4)
        {
           
            Space2.gameObject.SetActive(true);
        }

        if (talkIndex == 6)
        {
            

        }
        if (talkIndex == 7)
        {
           

        }


    }

    IEnumerator NextScene()
    {
        yield return new WaitForSeconds(2.9f);


        SceneManager.LoadScene("5Scene");

    }

    IEnumerator StopSpace()
    {
        isChat = true;
        yield return new WaitForSeconds(2f);
        isChat = false;




    }
}
