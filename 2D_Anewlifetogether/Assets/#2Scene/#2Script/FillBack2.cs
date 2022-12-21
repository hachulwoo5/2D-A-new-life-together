using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FillBack2 : MonoBehaviour
{ 
    public float totalTime =2.5f;
    private float fillAmount = 1;
    private Image myImage;
    public Move move;


    private void Awake()
{
    myImage = GetComponent<Image>();
}

void Update()
{
        if (fillAmount > 0 && move.isCorgigo == false)
         {
            fillAmount = fillAmount - (Time.deltaTime / (totalTime - 1));
            myImage.fillAmount = fillAmount;
         }

        
        if (move.isCorgigo==true)
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
