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
        talkData.Add(1, new string[] { "�� !?? "
            ,  "�ȳ�! �Ϳ��� ���屸��. ���� ���� ���ο� �����̾�!"
            ,"������ ���������� ������ ������ �ذ�, \n�츮 �ٽ� �Բ� �ູ�� ���� ����� ��������! "
            ,"��.. �۸� !!! "
                   
                    ,"�� �����ڸ��� �� ���� �����߽��ϴ� ! \n������ �������� ���� ������ ���ּ��� ! \n( �̴Ͼ�ó�� ���� ������ ���� ���� �ν��� ���� 1�ʰ� �� �����ּ��� )"


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