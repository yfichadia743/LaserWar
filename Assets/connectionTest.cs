using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;

public class connectionTest : MonoBehaviour {
    SerialPort sp;  
    float next_time; int ii = 0;  
    // Use this for initialization  
    void Start () {  
        string the_com="";  
        next_time = Time.time;   
        sp = new SerialPort("\\\\.\\COM8", 9600);  
        if (!sp.IsOpen)  
        {  
            print("Opening " + the_com + ", baud 9600");  
            sp.Open();  
            sp.ReadTimeout = 100;   
            if (sp.IsOpen) { print("Open"); }  
        }  
    }  
    // Update is called once per frame  
    void Update() {  
        if (Time.time > next_time) {   
            if (!sp.IsOpen)  
            {  
                sp.Open();  
                print("opened sp");  
            }  
 
                print("Writing " + ii);  
                sp.Write((ii.ToString()));  
              
            next_time = Time.time + 5;  
            if (++ii > 9) ii = 0;  
        }
        if(sp.IsOpen)
        {
            sp.Close();
        }  
    }
}  