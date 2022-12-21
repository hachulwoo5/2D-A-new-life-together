using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorgiMove : MonoBehaviour
{
    Rigidbody2D rigid;
    public Transform Target;
  

    public float Speed = 1f;
    public float Timer;
    Animator ani;
    public GameObject CorgiIdle;

   
    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();


    }

    // Update is called once per frame
    void Update()
    {

        Timer += Time.deltaTime;
        if (Timer >= 0.2 && Timer < 1.8f)
        {

            transform.position = Vector3.MoveTowards(transform.position, Target.position, Speed * Time.deltaTime);

        }
        if (Timer >= 1.81f)
        {
            Destroy(this.gameObject);
            CorgiIdle.gameObject.SetActive(true);

        }

       

    }




    
}