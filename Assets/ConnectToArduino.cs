using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;
using System.Threading;

public class ConnectToArduino : MonoBehaviour
{
    public SerialPort sp = new SerialPort("COM17", 9600);
    public string[] recievedStrings;
    public GameObject test_data;
    public Transform index1;
    public Transform index2;
    public Transform index3;
    public Transform middle1;
    public Transform middle2;
    public Transform middle3;

    public Transform ring1;
    public Transform ring2;
    public Transform ring3;

    public Transform pinky1;
    public Transform pinky2;
    public Transform pinky3;
    public Transform thumb1;
    public Transform thumb2;
    public Transform thumb3;
    public Transform thumbXY;
    public float sensitivity1 = -0.52f;
    public float sensitivity2 = -0.82f;
    public float sensitivity3 = -0.62f;
    public float sensitivity4 = -0.5f;
    public float sensitivity5 = -0.8f;
    public float sensitivity6 = -0.75f;
    public float sensitivity7 = -0.6f;
    public float sensitivity8 = -0.85f;
    public float sensitivity9 = -0.77f;
    public float sensitivity10 = -0.4f;
    public float sensitivity11 = -0.82f;
    public float sensitivity12 = -0.7f;
    public float sensitivity13 = -0.64f;
    public float sensitivity14 = -0.85f;
    public float sensitivity15 = -0.74f;
    public float sensitivity16 = 0.35f;
    public float sensitivity17 = 0.05f;
    public float recievedFloat1;
    public float recievedFloat2;
    public float recievedFloat3;
    public float recievedFloat4;
    public float recievedFloat5;
    public float changingFloat1 = 27.895f;
    public float changingFloat2 = 21.294f;
    public float changingFloat3 = 8.77f;
    public string recievedString;
    public bool laserOn = false;
    public Color color = Color.cyan;
    public bool powerOn = true;
    GameObject laser;
    //public GameObject pointer;
    bool blinked = false;
    float [] currentValues;

    // Start is called before the first frame update
    void Start()
    {
        OpenConnection();
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
                sp.DtrEnable = true;
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

    void OnTriggerEnter()
    {
        sp.WriteTimeout = 20;
        sp.Write('1'.ToString());
        //fingerRelease();
    }

    void OnTriggerExit()
    {
        sp.WriteTimeout = 20;
        sp.Write('0'.ToString());
    }

    public void OnGrabbedObject(bool grabbed)
    {
        if(grabbed)
        {
            sp.Write('2'.ToString());
        }
    }

    // Update is called once per frame
    void Update()
    {
        try {
                //sp.ReadTimeout = 20;
                recievedString = sp.ReadLine();
                string[] recievedStrings = recievedString.Split(',');
                recievedFloat1 = float.Parse(recievedStrings[0]);
                recievedFloat2 = float.Parse(recievedStrings[1]);
                recievedFloat3 = float.Parse(recievedStrings[2]);
                recievedFloat4 = float.Parse(recievedStrings[3]);
                recievedFloat5 = float.Parse(recievedStrings[4]);
                sp.BaseStream.Flush();
            }
        catch (System.TimeoutException)
        {

        }

        if(recievedFloat2 < -1)
        {

        }
        else
        {
            index1.transform.localEulerAngles = new Vector3(1.643f, 5.84f, (recievedFloat2 * sensitivity1) - 131.7f);
            index2.transform.localEulerAngles = new Vector3(-0.116f, -0.566f, (recievedFloat2 * sensitivity2) + 136.2f);
            index3.transform.localEulerAngles = new Vector3(0.014f, 0.133f, (recievedFloat2 * sensitivity3) + 191.5f);
        }
        
        if(recievedFloat3 < -1)
        {

        }
        else
        {
            middle1.transform.localEulerAngles = new Vector3(0.005f, 0.021f, (recievedFloat3 * sensitivity4) - 131.7f);
            middle2.transform.localEulerAngles = new Vector3(0.077f, 0.416f, (recievedFloat3 * sensitivity5) + 136.2f);
            middle3.transform.localEulerAngles = new Vector3(-0.079f, -0.466f, (recievedFloat3 * sensitivity6) + 191.5f);
        }
        if(recievedFloat4 < -1)
        {

        }
        else
        {
            ring1.transform.localEulerAngles = new Vector3(0.934f, 4.602f, (recievedFloat4 * sensitivity7) - 121.8f);
            ring2.transform.localEulerAngles = new Vector3(-0.047f, -0.286f, (recievedFloat4 * sensitivity8) + 152.7f);
            ring3.transform.localEulerAngles = new Vector3(0.089f, 0.481f, (recievedFloat4 * sensitivity9) + 186.3f);
        }

        if(recievedFloat5 < -1)
        {

        }
        else
        {
            pinky1.transform.localEulerAngles = new Vector3(0.093f, -3.258f, (recievedFloat5 * sensitivity10) - 131.7f);
            pinky2.transform.localEulerAngles = new Vector3(0.217f, 1.295f, (recievedFloat5 * sensitivity11) + 136.2f);
            pinky3.transform.localEulerAngles = new Vector3(-0.219f, -1.44f, (recievedFloat5 * sensitivity12) + 191.5f);
        }

        //thumb1.transform.localEulerAngles = new Vector3(0, 0, (recievedFloat3 * sensitivity13));
        thumb2.transform.localEulerAngles = new Vector3(0.046f, 0.151f, (recievedFloat1 * sensitivity14) - 131.7f);
        thumb3.transform.localEulerAngles = new Vector3(-0.014f, -0.161f, (recievedFloat1 * sensitivity15) + 136.2f);

        //thumb1.transform.localEulerAngles = new Vector3((recievedFloat1 * sensitivity16) + 80.016f, (recievedFloat1 * sensitivity17) - 151.1f, 38.641f);

        //pointer.transform.parent = this.transform;
        //pointer.transform.localPosition = new Vector3(0f, -10f, -0.01f);
        //pointer.transform.localRotation = Quaternion.identity;

        if(powerOn == false)
        {
            if(laserOn == true)
            {
                Destroy(laser);
                laserOn = false;
            }
            if(recievedFloat2 >= 860 && recievedFloat3 >= 880 && recievedFloat4 >= 910 && recievedFloat5 >= 870)
            {
                powerOn = true;
            }
        }
        else
        {
            if(recievedFloat2 <= 860 && recievedFloat3 <= 880 && recievedFloat4 <= 920 && recievedFloat5 <= 870 && !(laserOn)) {
                laser = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
                laserOn = true;
                //CapsuleCollider laserCollider = laser.AddComponent<CapsuleCollider>();
                laser.transform.localScale = new Vector3(0.05f, 10f, 0.05f);
                laser.transform.parent = this.transform;
                laser.transform.localPosition = new Vector3(0f, -10f, -0.01f);
                laser.transform.localRotation = Quaternion.identity;
                Material newMaterial = new Material(Shader.Find("Unlit/Color"));
                newMaterial.SetColor("_Color", color);
                laser.GetComponent<MeshRenderer>().material = newMaterial;
            }
            else if(recievedFloat2 <= 860 && recievedFloat3 <= 880 && recievedFloat4 <= 920 && recievedFloat5 <= 870 && laserOn)
            {
                laser.transform.parent = this.transform;
            }
            else if(laserOn == true) {
                Destroy(laser);
                laserOn = false;
            }
            else {

            }
        }
    }

    void fingerRelease()
    {
        //float currentFloat1 = recievedFloat1;
        currentValues[0] = recievedFloat2;
        currentValues[1] = recievedFloat3;
        currentValues[2] = recievedFloat4;
        currentValues[3] = recievedFloat5;
        for(float i = 800; i < 875; i++)
        {
            if(i < 815)
            {
                //index1.transform.localEulerAngles = new Vector3(1.643f, 5.84f, (i * sensitivity1) + 47.7f);
                //index2.transform.localEulerAngles = new Vector3(-0.116f, -0.566f, (i * sensitivity2) - 90.92f);
                //index3.transform.localEulerAngles = new Vector3(0.014f, 0.133f, (i * sensitivity3) + 108.3f);
            }
            if(i < 835)
            {
                //middle1.transform.localEulerAngles = new Vector3(0.005f, 0.021f, (i * sensitivity4) + 47.7f);
                //middle2.transform.localEulerAngles = new Vector3(0.077f, 0.416f, (i * sensitivity5) - 90.92f);
                //middle3.transform.localEulerAngles = new Vector3(-0.079f, -0.466f, (i * sensitivity6) + 216.12f);
            }
            if(i < 875)
            {
                //ring1.transform.localEulerAngles = new Vector3(0.934f, 4.602f, (i * sensitivity7) + 138.1f);
                //ring2.transform.localEulerAngles = new Vector3(-0.047f, -0.286f, (i * sensitivity8) - 43.4f);
                //ring3.transform.localEulerAngles = new Vector3(0.089f, 0.481f, (i * sensitivity9) - 123.3f);
            }
            if(i < 825)
            {
                //pinky1.transform.localEulerAngles = new Vector3(0.093f, -3.258f, (i * sensitivity10) - 28.6f);
                //pinky2.transform.localEulerAngles = new Vector3(0.217f, 1.295f, (i * sensitivity11) - 62.8f);
                //pinky3.transform.localEulerAngles = new Vector3(-0.219f, -1.44f, (i * sensitivity12) - 172.8f);
            }
        }
    }
}