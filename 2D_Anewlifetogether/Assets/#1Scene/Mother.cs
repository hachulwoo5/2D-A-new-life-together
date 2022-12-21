using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mother : MonoBehaviour
{
    Rigidbody2D rigid;
    public Transform Target;
    public float Speed = 1f;
    public float Timer;
    Animator ani;
    public GameObject MotherIdle;
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
        if (Timer >= 1.1 && Timer < 2.8f)
        {

            transform.position = Vector3.MoveTowards(transform.position, Target.position, Speed * Time.deltaTime);

        }
        if (Timer>=2.81f )
        {
            Destroy(this.gameObject);
            MotherIdle.gameObject.SetActive(true);

        }
    }





}
