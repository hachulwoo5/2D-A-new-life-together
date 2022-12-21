using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MsMove : MonoBehaviour
{
    Rigidbody2D rigid;
   
    public Transform Target2;

    public float Speed = 1f;
    Animator ani;
    public GameObject MsCorgiIdle;

    public GameManager4s gameManager4S;
    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();


    }

    // Update is called once per frame
    void Update()
    {

        

        if (gameManager4S.talkIndex == 5)
        {
            transform.position = Vector3.MoveTowards(transform.position, Target2.position, Speed * Time.deltaTime);
            StartCoroutine(Delay());
           
        }
        if (gameManager4S.talkIndex == 6)
        {
            Destroy(this.gameObject);
            MsCorgiIdle.gameObject.SetActive(true);

        }
        

    }




    IEnumerator Delay()
    {
        yield return new WaitForSeconds(2.6f);
        gameManager4S.talkIndex = 6;
    }
}