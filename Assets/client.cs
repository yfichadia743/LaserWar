using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net;
using System.Net.Sockets;
using System.Text;

public class client : MonoBehaviour
{
    Socket s;
    // Start is called before the first frame update
    void Start()
    {
        string host = Dns.GetHostName();
        s = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        s.Connect(host, 1234);
        Debug.Log("connected");
    }

    // Update is called once per frame
    void Update()
    {
        byte[] buffer = new byte[255];
        byte[] buffer2 = new byte[255];
        int rec = s.Receive(buffer, buffer.Length, 0);
        string rec2 = Encoding.ASCII.GetString(buffer);
        print(rec);
        print(rec2);
    }
}