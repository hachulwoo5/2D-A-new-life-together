using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Move : MonoBehaviour
{
    public string Feedmsg;
    public float Tspeed = 0.2f;

    public float maxSpeed;
    public float jumpPower;
    public int jumpCount = 0;
    public int StarPer = 0;
    public int ItemCount = 0;

   

    public Image feed;
    public Image dogBook1;
    public Image dogBook2;
    public Image money;
    public Image star;
    public Image star1;
    public Image star2;
    public Image star3;
    public Image star4;
    public Image star5;
    public GameObject Wbutton;
    public GameObject AdManager;
    AdSet adset;

    // public int Sensor1;     // �з� ���� ��ġ // 1������ġ�� 100 �̻��� �Ǹ� isCorgigo = true, 2������ġ�� 100�̻��� �Ǹ� isCorgihome
    // public int Sensor2;     // �з� ���� ��ġ // 1������ġ�� 100 �̻��� �Ǹ� isCorgigo = true, 2������ġ�� 100�̻��� �Ǹ� isCorgihome
    public GameObject TextUI;

    //public GameObject TextMissoinUI;

    public Text text;
  
    public bool isPause;
    public bool isJump;
    public bool isCorgigo;   // �ڱ� �̵����
    public bool isCorgihome;  //�ڱ� �������, ����Ʈ ���
    public Animator animator;
    Rigidbody2D rigid;
    SpriteRenderer spriteRenderer;

  
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        rigid.freezeRotation = true;
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        isPause = true ;

        isJump = true;
        adset = GameObject.Find("AdManager").GetComponent<AdSet>();
    }

    // Update is called once per frame

    private void Update()
    {
        Vector3 flipMove = Vector3.zero;

        if(Input.GetAxisRaw("Horizontal")<0 && isPause==false)
        {
            flipMove = Vector3.left;
            transform.localScale = new Vector3(-0.3f, 0.3f, 1f);

        }
        else if (Input.GetAxisRaw("Horizontal")> 0 && isPause == false)
        {
            flipMove = Vector3.right;
            transform.localScale = new Vector3(0.3f, 0.3f, 1f);
        }

        /*
        // ���� ��ȯ
        if (Input.GetButtonDown("Horizontal") && isPause == false)
        {
            spriteRenderer.flipX = Input.GetAxisRaw("Horizontal") == -1;

        }
        */
        if (Input.GetButtonDown("Jump") && !animator.GetBool("isJump") && isPause == false && isJump ==true && jumpCount==0)
        {
            rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            jumpCount++;
            animator.SetBool("isJump", true);

        }
        // ��ž ���ǵ�

        if (Input.GetButtonUp("Horizontal") && isPause == false)
        {
            rigid.velocity = new Vector2(rigid.velocity.normalized.x * 0.5f, rigid.velocity.y);
        }

        
        // �ִϸ��̼� üũ
        if (Mathf.Abs(rigid.velocity.x) < 0.3)
        {
            animator.SetBool("isMove", false);
        }
        else
        {
            animator.SetBool("isMove", true);
        }

        if (isPause == true && Input.GetButtonDown("Jump"))
        {
            isPause = false;
            //Time.timeScale = 1;
            TextUI.gameObject.SetActive(false);
            return;

        }

        
        if(Input.GetButtonDown("Cancel"))
        {
            SceneManager.LoadScene("FistScene");
        }
        
        if (Input.GetKeyDown(KeyCode.F1))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            

        }

        if (Input.GetKeyDown(KeyCode.F2))
        {
            SceneManager.LoadScene("FisrtScene");


        }
        #region �Ծ����

        if (adset.pressure[0] >= 20 && ItemCount>=9)
        {
            isCorgigo = true;
        }
        else
        {
            isCorgigo = false;
        }


        // ������ �޾ƿ���
        // Sensor[0]= Sersor1;
        // Sensor[1]= Sersor2;
        #endregion

        if (ItemCount >= 9)
        {
           
           
            Wbutton.gameObject.SetActive(true);

            
        }

        if (isCorgigo==true)               // �̼ǿϷ��� ������
        {
            
            StartCoroutine(NextScene());
            

        }
        
        
    }
    void FixedUpdate()
    {
        //transform.Translate(Vector2.right * speed * Time.deltaTime);


       
        if (isPause == false)
        {
            float h = Input.GetAxisRaw("Horizontal");
            rigid.AddForce(Vector2.right * h, ForceMode2D.Impulse);
        }

        if (rigid.velocity.x > maxSpeed)
            rigid.velocity = new Vector2(maxSpeed, rigid.velocity.y);
        else if (rigid.velocity.x < maxSpeed * (-1))
            rigid.velocity = new Vector2(maxSpeed * (-1), rigid.velocity.y);


       



    }


    private void OnTriggerEnter2D(Collider2D other)
    {

        // ���� ���� �Ǻ�
        if (other.gameObject.layer == 6)
        {
            animator.SetBool("isJump", false);
            jumpCount = 0;
        }
        
        if (other.CompareTag("Feed") && this.CompareTag("Player"))
        {
            ItemCount++;
            GameObject.Find("SoundBox").GetComponent<AudioSource>().Play();
            Color color = feed.color;
            color.a = 255;
            feed.color = color;
            if (isPause == false)
            {
                isPause = true;
                //Time.timeScale = 0f;
                TextUI.gameObject.SetActive(true);
                text.text = "'���'\n�ݷ������� ���� ���ְ� �ǰ��� ����. ";

                Destroy(other.gameObject);

                return;

            }



        }


        if (other.CompareTag("DogBook1") && this.CompareTag("Player"))
        {
            ItemCount++;

            GameObject.Find("SoundBox").GetComponent<AudioSource>().Play();
            Color color = dogBook1.color;
            color.a = 255;
            dogBook1.color = color;
            if (isPause == false)
            {
                isPause = true;
                //Time.timeScale = 0;
                TextUI.gameObject.SetActive(true);
                text.text = "'���� �⺻ ���� ��ħ��'\n������ Ű��µ� �ʿ���\n�⺻���� ���İ� �Ʒù��� �˷��ִ� ��ħ����. ";
                Destroy(other.gameObject);

                return;

            }

        }


        if (other.CompareTag("DogBook2") && this.CompareTag("Player"))
        {
            ItemCount++;

            GameObject.Find("SoundBox").GetComponent<AudioSource>().Play();
            Color color = dogBook2.color;
            color.a = 255;
            dogBook2.color = color;
            if (isPause == false)
            {
                isPause = true;
                //Time.timeScale = 0;
                TextUI.gameObject.SetActive(true);
                text.text = "'�� ������ ��Ÿ�� ��ħ��'\n�ݷ������� �������̰� ����Ʈ�ϰ� Ű�� �� �ְ� �����ش�.\n�꺸��, �ǷἭ�� �� �� ����� ���� �������� �������ش�. ";
                Destroy(other.gameObject);

                return;

            }

        }
        if (other.CompareTag("Money") && this.CompareTag("Player"))
        {
            ItemCount++;

            GameObject.Find("SoundBox").GetComponent<AudioSource>().Play();
            Color color = money.color;
            color.a = 255;
            money.color = color;
            if (isPause == false)
            {
                isPause = true;
                //Time.timeScale = 0;
                TextUI.gameObject.SetActive(true);
                text.text = "'��'\n������ �Բ� ��Ȱ�Ϸ���\n���� ���� ����� ���� ���� �˾ƾ� �Ѵ�.";
                Destroy(other.gameObject);

                return;

            }

        }
        if (other.CompareTag("Star") && this.CompareTag("Player"))
        {
            StarPer++;
            ItemCount++;

            GameObject.Find("SoundBox").GetComponent<AudioSource>().Play();

            if (isPause == false)
            {
                isPause = true;
               // Time.timeScale = 0;

                if (StarPer == 1)
                {
                    TextUI.gameObject.SetActive(true);
                    star1.gameObject.SetActive(true);
                    text.text = "'å�Ӱ�'\n�ݷ������� Ű��°� �� ������ �����ϴ� ���̹Ƿ�\n���� �ƴ� �ڽ��� ���� �� �ִٴ� ū å�Ӱ��� �ʿ���.";
                }
                if (StarPer == 2)
                {
                    TextUI.gameObject.SetActive(true);
                    star2.gameObject.SetActive(true);

                    text.text = "'å�Ӱ�'\n�ܼ��� �ܷӴٶ�� ���������� ������ �Ծ��ؼ� �ȵ�.\n���� �ð��� ���� ��� ���� ���� ���ž�.";
                }
                if (StarPer == 3)
                {
                    TextUI.gameObject.SetActive(true);
                    star3.gameObject.SetActive(true);

                    text.text = "'å�Ӱ�'\n���� Ű�� �� �ִٴ� ������ �߿������� \n������ ��Ȱ�ϱ� ������ ȯ�������� �����غ�����.";
                }
                if (StarPer == 4)
                {
                    TextUI.gameObject.SetActive(true);
                    star4.gameObject.SetActive(true);

                    text.text = "'å�Ӱ�'\n������� ���� ���� ����� ���� �� �ֵ��� �������� \n������ �� ������ ������ ������ ����� �� �� �ֵ��� �ؾ���.";
                }
                if (StarPer >= 5)
                {
                    TextUI.gameObject.SetActive(true);
                    star5.gameObject.SetActive(true);
                    text.text = "'å�Ӱ�'\n������� ������ �������� �޾Ƶ��̰� \n������� Ű�� �غ� ������ �Ծ��� ����. (��ȣ�ҿ��� WŰ �Է�)";
                }


                Destroy(other.gameObject);

                return;

            }

        }

        if (other.CompareTag("Shelter") && this.CompareTag("Player"))
        {
           
            isJump = false;
            
        }
        




    } // ��Ʈ���� ������

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Shelter") && this.CompareTag("Player") && isJump == false && Input.GetKeyDown(KeyCode.W) )
        {

            if (isPause == false)
            {
               
                TextUI.gameObject.SetActive(true);
               // TextMissionUI.gameObject.SetActive(true);         // �̼ǿ� �ؽ�Ʈ
                text.text = "����� ��ȣ�ҿ� �����߽��ϴ�. \n����߰� ���� ���� ���� ��ȣ�ҿ��� ������ �����ּ��� ! \n( �̴Ͼ�ó�� ���� ������ ���� ���� �ν��� ���� 1�ʰ� �� �����ּ��� ) ";

                return;

            }

        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Shelter") && this.CompareTag("Player"))
        {
            isJump = true;
        }
    }

    IEnumerator NextScene()
    {
        yield return new WaitForSeconds(2f);
        
        SceneManager.LoadScene("MissionScene");

    }
}
