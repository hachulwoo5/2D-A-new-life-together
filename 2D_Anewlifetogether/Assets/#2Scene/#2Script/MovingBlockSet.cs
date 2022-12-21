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
        //�����̴� ���ǿ��� ���� �����̱�
        if (contactPlatform != null)
        {
            //�ٴ��� ��� �ְ�, �¿�� �����̰� ���� ���� ���
            if (isGrounded)
            {
                //ĳ������ ��ġ�� ��� �ִ� �÷����� distance ��ŭ ������ ��ġ
                transform.position = contactPlatform.transform.position - distance;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //�÷����� 45�� �̳��� ������ ������ �ٴ����� ����
        if (collision.contacts[0].normal.y > 0.7f)
        {
            isGrounded = true;
            //������ ������Ʈ�� �±װ� platform �� ��,
            if (collision.gameObject.tag == "platform")
            {
                //������ ������ ������Ʈ ��ġ�� ����
                contactPlatform = collision.gameObject;
                platformPosition = contactPlatform.transform.position;
                //������ ������ ������Ʈ ��ġ�� ĳ���� ��ġ�� ���̸� distance�� ����
                distance = platformPosition - transform.position;
            }
        }
    }
}