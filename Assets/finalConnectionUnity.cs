using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;
using System.Threading;

public class finalConnectionUnity : MonoBehaviour
{
    public SerialPort sp = new SerialPort("COM5", 9600);
    public string message2;
    void Start()
    {
        OpenConnection();
    }

    void Update()
    {
        try
        {
            message2 = sp.ReadLine();
        }
        catch(System.TimeoutException)
        {
            print("timed out");
        }
        //print(message2);
    }
    public void OpenConnection()
    {
        if(sp != null)
        {
            if(sp.IsOpen)
            {
                sp.Close();
                print("Closed Port because it was open");
            }
            else
            {
                sp.Open();
                sp.ReadTimeout = 20;
                print("Opened Port");
            }
        }
        else
        {
            if(sp.IsOpen)
            {
                print("Port is Open");
            }
            else
            {
                print("Port == null");
            }
        }
    }

    void OnCollisionEnter()
    {
        print("Sending Values!!!!!!!!!!!!!!!!!!!!!!");
        sp.Write('0'.ToString());
    }
}
