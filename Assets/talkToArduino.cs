using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;

public class talkToArduino : MonoBehaviour
{
    SerialPort sp;
    public int transfer = 0;
    int previousTransfer;
    // Start is called before the first frame update
    void Start()
    {
        previousTransfer = transfer;
        sp = new SerialPort("\\\\.\\COM7", 9600);
        sp.Open();
    }

    // Update is called once per frame
    void Update()
    {
        if(previousTransfer != transfer)
        {
            Debug.Log(transfer);
            sp.Write(transfer.ToString());
            previousTransfer = transfer;
        }
    }
}
