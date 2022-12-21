using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FillBack : MonoBehaviour
{
    public float totalTime;
    private float fillAmount = 1;
    private Image myImage;
    public GameManager gamemanager;

    private void Awake()
    {
        myImage = GetComponent<Image>();
    }

    void Update()
    {
        if (fillAmount > 0 && gamemanager.talkIndex == 0)
        {
            fillAmount = fillAmount - (Time.deltaTime / (totalTime - 1));
            myImage.fillAmount = fillAmount;
        }

        if (gamemanager.talkIndex == 9)
        {
          
            fillAmount = fillAmount + (Time.deltaTime / (totalTime - 1));
            myImage.fillAmount = fillAmount;
        }
    }

 
    IEnumerator Hold()
    {
        yield return new WaitForSeconds(1f);

    }

}
