using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickupScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject fingers;
    public GameObject root;
    public GameObject cube;
    public Rigidbody rb;
    float indexPos;
    float middlePos;
    float ringPos;
    float pinkiePos;
    float thumbPos;
    int numOfClosedFingers = 0;
    bool gripped = false;
    float distanceFromHand;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        numOfClosedFingers = 0;
        indexPos = fingers.GetComponent<ConnectToArduino>().recievedFloat2;
        if(indexPos >= 840)
        {
            numOfClosedFingers++;
        }
        middlePos = fingers.GetComponent<ConnectToArduino>().recievedFloat3;
        if(middlePos >= 810)
        {
            numOfClosedFingers++;
        }
        ringPos = fingers.GetComponent<ConnectToArduino>().recievedFloat4;
        if(ringPos >= 800)
        {
            numOfClosedFingers++;
        }
        pinkiePos = fingers.GetComponent<ConnectToArduino>().recievedFloat5;
        if(pinkiePos >= 815)
        {
            numOfClosedFingers++;
        }
        thumbPos = fingers.GetComponent<ConnectToArduino>().recievedFloat1;
        if(thumbPos >= 790)
        {
            numOfClosedFingers++;
        }

        if(numOfClosedFingers == 5)
        {
            gripped = true;
        }
        else
        {
            //rb.velocity = root.GetComponent<Rigidbody>().velocity;
            gripped = false;
            //rb.useGravity = true;
        }
        if(distanceFromHand < 0.02 && gripped)
        {
            //cube.transform.SetPositionAndRotation((root.GetComponent<Transform>().localPosition + new Vector3(-0.1f, 0f, 0f)), root.GetComponent<Transform>().localRotation);
            //rb.useGravity = false;
            fingers.GetComponent<ConnectToArduino>().OnGrabbedObject(true);
        }
    }
}
