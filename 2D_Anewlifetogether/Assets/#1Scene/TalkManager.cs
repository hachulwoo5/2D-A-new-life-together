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
        talkData.Add(1, new string[] { "아빠의 입양조건인 퀴즈 게임을 잘 풀고 왔니?\n그렇다면 엄마의 입양조건도 알려줄게." 
            ,"어렵지 않아. 유기견을 입양하기 전에 필요한 정보와 용품들을 미리 알고 \n아이템들을 모아온 후에 유기견 보호소에서 입양을 해오는 것이란다."
            ,"첫 번째로 필요한 것은 동물 기본 양육 지침서야. \n반려동물을 키우는 데에 알아야 할 주의사항이나 \n기본적인 훈련방법에 대한 도움을 줄 거야. "
             ,"두 번째로 펫 라이프 스타일 지침서야. \n동물 기본 양육 지침서와는 다른데, 어떻게 해야 \n반려동물을 똑똑하고 경제적으로 키우는지에 대해 알려줄 거야.  "
              ,"세 번째는 사료야. \n인간도 밥을 꼭 먹어야 살아가듯 동물도 다르지 않아. \n건강하고 맛있는 밥으로 잘 키울 수 있도록 해야 돼."
              ,"네 번째는 돈이야. \n동물을 키우는 데에는 사료값 외에도 병원비나 용품 등 부가적인 \n비용이 생각보다 많이 들기 때문에 그 점을 인지해야해. "
              ,"마지막으로는 책임감이야. \n필요한 것들 중 가장 중요한데, 동물을 키우기로 마음 먹었다면 \n자신이 꼭 끝까지 책임질 수 있다는 마음이 필요해."
                , "동네를 돌아다니면 아이템들을 찾을 수 있을 거야.\n준비 됐으면 출발!"
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
