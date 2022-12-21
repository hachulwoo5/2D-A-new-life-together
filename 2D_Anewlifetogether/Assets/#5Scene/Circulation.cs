using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Circulation : MonoBehaviour
{
    public float speed = 1.0f;
    public float startPosition = 0;
    public float endPosition = 1;

    void Update()
    {
        // x�������� ���ݾ� �̵�
        transform.Translate(-1 * speed * Time.deltaTime, 0, 0);

        // ��ǥ ������ �����ߴٸ�
        if (transform.position.x <= endPosition)
        {
            ScrollEnd();
        }
    }

    void ScrollEnd()
    {
        // ���� ��ġ�� �ʱ�ȭ ��Ų��.
        transform.Translate(-1 * (endPosition - startPosition), 0, 0);
    }
}