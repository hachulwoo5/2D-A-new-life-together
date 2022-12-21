using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkManagerS4 : MonoBehaviour
{
    Dictionary<int, string[]> talkData;

    private void Awake()
    {
        talkData = new Dictionary<int, string[]>();
        GenerateData();
    }

    void GenerateData()
    {
        talkData.Add(1, new string[] { "멍 !?? "
            ,  "안녕! 귀엽게 생겼구나. 내가 너의 새로운 주인이야!"
            ,"아직은 낯설겠지만 과거의 아픔은 잊고, \n우리 다시 함께 행복한 삶을 만들어 나가보자! "
            ,"멍.. 멍멍 !!! "
                   
                    ,"새 보금자리가 될 집에 도착했습니다 ! \n외출한 강아지를 집에 데리고 들어가주세요 ! \n( 미니어처를 집의 센서로 놓고 센서 인식을 위해 1초간 꾹 눌러주세요 )"


        });


    }



    public string GetTalk(int id, int talkIndex)
    {
        if (talkIndex == talkData[id].Length)
        {
            return null;
        }
        else
        {
            return talkData[id][talkIndex];

        }
    }

}