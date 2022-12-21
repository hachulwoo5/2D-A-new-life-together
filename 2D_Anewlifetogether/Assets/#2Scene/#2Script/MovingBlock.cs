using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBlock : MonoBehaviour
{
    public int moveFlag = 1;
    public float moveSpeed = 20f;
    float movePower = 0.05f;

    void Start()
    {
        StartCoroutine("BlockMove");
    }

    private void LateUpdate()
    {
        Move();
    }

    void Move()
    {
        Vector3 moveVelocity = Vector3.zero;

        if(this.moveFlag ==1)
        {
            moveVelocity = new Vector3(0, movePower, 0);

        }
        else
        {
            moveVelocity = new Vector3(0, -movePower, 0);
        }
        transform.position += moveVelocity * moveSpeed * Time.deltaTime;
    }

    IEnumerator BlockMove()
    {
        if(moveFlag==1)
        {
            moveFlag = 2;
        }
        else
        {
            moveFlag = 1;
        }
        yield return new WaitForSeconds(2f);
        StartCoroutine("BlockMove");
    }
}
