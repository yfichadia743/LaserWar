using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collisionAction : MonoBehaviour
{
    public GameObject obj1;
    int num = 0;
    static float remainingTime;
    static bool countingDown;
    public Material newMaterial;
    public AudioSource source;
    public GameObject particles;
    public GameObject scoreboard;
    public GameObject hand;
    static int points = 0;
    ParticleSystem popping;
    // Start is called before the first frame update
    void Start()
    {
        obj1.transform.localPosition = new Vector3(Random.Range(-1f, 1.5f), Random.Range(1.5f, 2f), 5f);
        particles.transform.localPosition = obj1.transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        if(countingDown == true)
        {
            if(remainingTime >= 0)
            {
                remainingTime -= Time.deltaTime;
                Debug.Log(remainingTime);
            }
            else
            {
                Respawn();
            }
        }
    }

    void OnCollisionEnter(Collision col)
    {
        Debug.Log(col.collider.name);
        if(col.collider.name != "Pointer")
        {
            Debug.Log("Boom");
            num += 1;
            popping = particles.GetComponent<ParticleSystem>();
            popping.Play(true);
            obj1.transform.localPosition = new Vector3(0f, -100f, 0f);
            hand.GetComponent<ConnectToArduino>().powerOn = false;
            source.Play(0);
            Color color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f), 1f);
            points = points + 1;
            scoreboard.GetComponent<Score>().setText(points + "");
            //obj.GetComponent<MeshRenderer>().material.color = color;
            remainingTime = 1.5f;
            countingDown = true;
        }

    }
    void Respawn() {
        
        Debug.Log("respawned");
        //obj.transform.localPosition = new Vector3(Random.Range(-1f, 1.5f), Random.Range(1f, 3f), Random.Range(-1f, 1f));
        obj1.transform.localPosition = new Vector3(Random.Range(-1f, 1.5f), Random.Range(1.5f, 2f), 5f);
        particles.transform.localPosition = obj1.transform.localPosition;
        countingDown = false;
    }
}
