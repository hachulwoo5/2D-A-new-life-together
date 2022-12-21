using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public bool isNextScene;
    void Start()
    {
        isNextScene = false;
        StartCoroutine(Second());
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Jump") && isNextScene == true)
        {
            StartCoroutine(Next());
            GameObject.Find("SoundBox").GetComponent<AudioSource>().Play();
        }

        if (Input.GetButtonDown("Cancel"))
        {
            Application.Quit();
        }


        if (Input.GetKeyDown(KeyCode.F1))
        {
            SceneManager.LoadScene("TestScene");
        }
        if (Input.GetKeyDown(KeyCode.F2))
        {
            SceneManager.LoadScene("MissionScene");
        }
    }

    IEnumerator Second()
    {
        yield return new WaitForSeconds(5f);
        isNextScene = true;


    }

    IEnumerator Next()
    {
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene("2D Game");



    }
}
