using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuCon : MonoBehaviour
{
    public Image menu;
    private bool state;
    void Start()
    {
        state = true;

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("i"))
        {
            if (state == true)
            {
                menu.gameObject.SetActive(true);
                state = false;
            }

            else
            {
                menu.gameObject.SetActive(false);
                state = true;
            }
        }

        
    }
}
