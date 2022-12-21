using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBlockSet : MonoBehaviour
{
    private bool isGrounded = false;
    private GameObject contactPlatform;
    private Vector3 platformPosition;
    private Vector3 distance;

    void Update()
    {
        //움직이는 발판에서 같이 움직이기
        if (contactPlatform != null)
        {
            //바닥을 밟고 있고, 좌우로 움직이고 있지 않은 경우
            if (isGrounded)
            {
                //캐릭터의 위치는 밟고 있는 플랫폼과 distance 만큼 떨어진 위치
                transform.position = contactPlatform.transform.position - distance;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //플랫폼이 45도 이내의 기울기일 때에만 바닥으로 판정
        if (collision.contacts[0].normal.y > 0.7f)
        {
            isGrounded = true;
            //접촉한 오브젝트의 태그가 platform 일 때,
            if (collision.gameObject.tag == "platform")
            {
                //접촉한 순간의 오브젝트 위치를 저장
                contactPlatform = collision.gameObject;
                platformPosition = contactPlatform.transform.position;
                //접촉한 순간의 오브젝트 위치와 캐릭터 위치의 차이를 distance에 저장
                distance = platformPosition - transform.position;
            }
        }
    }
}