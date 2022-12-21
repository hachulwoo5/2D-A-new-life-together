using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FillBack4 : MonoBehaviour
{
    public float totalTime = 2;
    private float fillAmount = 1;
    private Image myImage;
    


    private void Awake()
    {
        myImage = GetComponent<Image>();
    }

    void Update()
    {
        if (fillAmount > 0 )
        {
            fillAmount = fillAmount - (Time.deltaTime / (totalTime - 1));
            myImage.fillAmount = fillAmount;
        }
      

    }


    IEnumerator Hold()
    {
        yield return new WaitForSeconds(1f);

    }
    
}
