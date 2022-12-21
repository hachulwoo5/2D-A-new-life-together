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

    // public int Sensor1;     // 압력 센서 수치 // 1센서수치가 100 이상이 되면 isCorgigo = true, 2센서수치가 100이상이 되면 isCorgihome
    // public int Sensor2;     // 압력 센서 수치 // 1센서수치가 100 이상이 되면 isCorgigo = true, 2센서수치가 100이상이 되면 isCorgihome
    public GameObject TextUI;

    //public GameObject TextMissoinUI;

    public Text text;
  
    public bool isPause;
    public bool isJump;
    public bool isCorgigo;   // 코기 이동모드
    public bool isCorgihome;  //코기 도착모드, 디폴트 모드
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
        // 방향 전환
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
        // 스탑 스피드

        if (Input.GetButtonUp("Horizontal") && isPause == false)
        {
            rigid.velocity = new Vector2(rigid.velocity.normalized.x * 0.5f, rigid.velocity.y);
        }

        
        // 애니메이션 체크
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
        #region 입양상태

        if (adset.pressure[0] >= 20 && ItemCount>=9)
        {
            isCorgigo = true;
        }
        else
        {
            isCorgigo = false;
        }


        // 센서값 받아오기
        // Sensor[0]= Sersor1;
        // Sensor[1]= Sersor2;
        #endregion

        if (ItemCount >= 9)
        {
           
           
            Wbutton.gameObject.SetActive(true);

            
        }

        if (isCorgigo==true)               // 미션완료후 다음씬
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

        // 점프 착지 판별
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
                text.text = "'사료'\n반려동물을 위한 맛있고 건강한 사료다. ";

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
                text.text = "'동물 기본 양육 지침서'\n동물을 키우는데 필요한\n기본적인 지식과 훈련법을 알려주는 지침서다. ";
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
                text.text = "'펫 라이프 스타일 지침서'\n반려동물을 경제적이고 스마트하게 키울 수 있게 도와준다.\n펫보험, 의료서비스 등 펫 산업에 대한 정보들을 제공해준다. ";
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
                text.text = "'돈'\n동물과 함께 생활하려면\n적지 않은 비용이 들어가는 것을 알아야 한다.";
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
                    text.text = "'책임감'\n반려동물을 키우는건 새 가족을 맞이하는 것이므로\n남이 아닌 자신이 돌볼 수 있다는 큰 책임감이 필요해.";
                }
                if (StarPer == 2)
                {
                    TextUI.gameObject.SetActive(true);
                    star2.gameObject.SetActive(true);

                    text.text = "'책임감'\n단순히 외롭다라는 이유만으로 동물을 입양해선 안돼.\n비용과 시간이 많이 들고 손이 많이 갈거야.";
                }
                if (StarPer == 3)
                {
                    TextUI.gameObject.SetActive(true);
                    star3.gameObject.SetActive(true);

                    text.text = "'책임감'\n내가 키울 수 있다는 의지도 중요하지만 \n동물이 생활하기 적합한 환경인지도 생각해봐야해.";
                }
                if (StarPer == 4)
                {
                    TextUI.gameObject.SetActive(true);
                    star4.gameObject.SetActive(true);

                    text.text = "'책임감'\n유기견이 가진 아픈 기억을 잊을 수 있도록 정서적인 \n교감을 잘 나누어 나에게 마음을 충분히 열 수 있도록 해야해.";
                }
                if (StarPer >= 5)
                {
                    TextUI.gameObject.SetActive(true);
                    star5.gameObject.SetActive(true);
                    text.text = "'책임감'\n유기견을 온전히 가족으로 받아들이고 \n사랑으로 키울 준비가 됐으면 입양을 하자. (보호소에서 W키 입력)";
                }


                Destroy(other.gameObject);

                return;

            }

        }

        if (other.CompareTag("Shelter") && this.CompareTag("Player"))
        {
           
            isJump = false;
            
        }
        




    } // 온트리거 종료점

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Shelter") && this.CompareTag("Player") && isJump == false && Input.GetKeyDown(KeyCode.W) )
        {

            if (isPause == false)
            {
               
                TextUI.gameObject.SetActive(true);
               // TextMissionUI.gameObject.SetActive(true);         // 미션용 텍스트
                text.text = "유기견 보호소에 도착했습니다. \n유기견과 집에 가기 위해 보호소에서 데리고 나와주세요 ! \n( 미니어처를 왼쪽 센서로 놓고 센서 인식을 위해 1초간 꾹 눌러주세요 ) ";

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
