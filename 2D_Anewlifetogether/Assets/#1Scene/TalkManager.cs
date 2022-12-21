using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkManager : MonoBehaviour
{
    Dictionary<int, string[]> talkData;

    private void Awake()
    {
        talkData = new Dictionary<int, string[]>();
        GenerateData();
    }

    void GenerateData()
    {
        talkData.Add(1, new string[] { "�ƺ��� �Ծ������� ���� ������ �� Ǯ�� �Դ�?\n�׷��ٸ� ������ �Ծ����ǵ� �˷��ٰ�." 
            ,"����� �ʾ�. ������� �Ծ��ϱ� ���� �ʿ��� ������ ��ǰ���� �̸� �˰� \n�����۵��� ��ƿ� �Ŀ� ����� ��ȣ�ҿ��� �Ծ��� �ؿ��� ���̶���."
            ,"ù ��°�� �ʿ��� ���� ���� �⺻ ���� ��ħ����. \n�ݷ������� Ű��� ���� �˾ƾ� �� ���ǻ����̳� \n�⺻���� �Ʒù���� ���� ������ �� �ž�. "
             ,"�� ��°�� �� ������ ��Ÿ�� ��ħ����. \n���� �⺻ ���� ��ħ���ʹ� �ٸ���, ��� �ؾ� \n�ݷ������� �ȶ��ϰ� ���������� Ű������� ���� �˷��� �ž�.  "
              ,"�� ��°�� ����. \n�ΰ��� ���� �� �Ծ�� ��ư��� ������ �ٸ��� �ʾ�. \n�ǰ��ϰ� ���ִ� ������ �� Ű�� �� �ֵ��� �ؾ� ��."
              ,"�� ��°�� ���̾�. \n������ Ű��� ������ ��ᰪ �ܿ��� ������ ��ǰ �� �ΰ����� \n����� �������� ���� ��� ������ �� ���� �����ؾ���. "
              ,"���������δ� å�Ӱ��̾�. \n�ʿ��� �͵� �� ���� �߿��ѵ�, ������ Ű���� ���� �Ծ��ٸ� \n�ڽ��� �� ������ å���� �� �ִٴ� ������ �ʿ���."
                , "���׸� ���ƴٴϸ� �����۵��� ã�� �� ���� �ž�.\n�غ� ������ ���!"
                ,""
        });
        

    }

   

    public string GetTalk(int id, int talkIndex)
    {
        if(talkIndex==talkData[id].Length)
        {
            return null;
        }
        else
        {
            return talkData[id][talkIndex];

        }
    }

}
