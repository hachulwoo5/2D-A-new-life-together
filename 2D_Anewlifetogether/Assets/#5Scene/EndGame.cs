using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
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
        if (Input.GetButtonDown("Jump") && isNextScene==true)
        {
            SceneManager.LoadScene("FisrtScene");
        }
    }

    IEnumerator Second()
    {
        yield return new WaitForSeconds(8f);
        isNextScene = true;
        yield return new WaitForSeconds(50f);
        SceneManager.LoadScene("FisrtScene");
    }
}
