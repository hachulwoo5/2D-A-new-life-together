using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;
using System.IO;
using TMPro;


public class AdSet : MonoBehaviour
{


    public enum PortNumber
    {
        COM1, COM2, COM3, COM4, COM5, COM6, COM7, COM8, COM9, COM10, COM11, COM12, COM13, COM14, COM15, COM16
    }
    public int[] pressure = new int[2];   // �з� �� ���� 5
    //int pressure;
    SerialPort serial = new SerialPort("COM5", 9600);

    

    [SerializeField]
    public TextMeshProUGUI text1;  // ���� ���
    [SerializeField]
    public TextMeshProUGUI text2;  // ���� ���
   
    void Start()
    {
        serial.Open();
        serial.ReadTimeout = 1;




        /// 1�ʸ��� TXT ���� ��� �ڷ�ƾ
        StartCoroutine(textOut(1));
    }

    void Update()
    {

    }


    IEnumerator textOut(float delayTime)
    {


        if (serial.IsOpen)
        {
            try
            {
                
                
                for(int i=0;i<=1;i++)
                {
                    pressure[i] = serial.ReadByte();
                    Debug.Log(pressure[i]);                 // �� �а� �α� ���


                }
                // pressure= serial.ReadByte();
                //Debug.Log(pressure);            

                // Debug.Log(",");





                text1.text = " 1st : " + pressure[0];
                text2.text = " 2st : " + pressure[1];
                /*
                                text2.text = " 2nd : " + pressure[1];
                                text3.text = " 3rd : " + pressure[2];
                                text4.text = " 4th : " + pressure[3];
                                text5.text = " 5th : " + pressure[4];
                                sw.Flush();

                 */

            }

            catch (System.Exception)
            {

            }

        }



        /// 1�� ���� �۵�
        yield return new WaitForSeconds(delayTime);
        StartCoroutine(textOut(1));


    }

}
