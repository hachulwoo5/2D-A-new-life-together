using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashBlock : MonoBehaviour
{
    public GameObject[] FlashBlocks1;
    public GameObject[] FlashBlocks2;
    public bool flashOn;
    public bool flashOff;
    
    void Start()
    {
        flashOn = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (flashOn == true)
        {
            StartCoroutine(FlashOn());
        }
        else if (flashOff == true)
        {
            StartCoroutine(FlashOff());
        }
    }

    IEnumerator FlashOff()
    {
        
        flashOff = false;
        yield return new WaitForSeconds(2f);
        for (int i = 0; i < FlashBlocks1.Length; i++)
        {
            FlashBlocks1[i].SetActive(false);
        }
        for (int i = 0; i < FlashBlocks2.Length; i++)
        {
            FlashBlocks2[i].SetActive(true);
        }
        flashOn = true;


    }
    IEnumerator FlashOn()
    {

        flashOn = false;
        yield return new WaitForSeconds(2f);

        for (int i = 0; i < FlashBlocks1.Length; i++)
        {
            FlashBlocks1[i].SetActive(true);
        }
        for (int i = 0; i < FlashBlocks2.Length; i++)
        {
            FlashBlocks2[i].SetActive(false);
        }
        flashOff = true;
    }
}
