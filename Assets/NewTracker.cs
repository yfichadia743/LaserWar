using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;

public class NewTracker : MonoBehaviour
{
    SerialPort data_stream;
    void Start()
    {
        data_stream = new SerialPort("\\\\.\\COM8", 9600);
        data_stream.Open();
        data_stream.ReadTimeout = 20;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
