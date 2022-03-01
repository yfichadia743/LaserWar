using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionAction2 : MonoBehaviour
{
    public GameObject obj;
    int num = 0;
    static float remainingTime;
    static bool countingDown;
    public Material newMaterial;
    public AudioSource source;
    public GameObject particles;
    ParticleSystem popping;
    // Start is called before the first frame update
    void Start()
    {
        obj.transform.localPosition = new Vector3(Random.Range(-1f, 1.5f), Random.Range(1.5f, 2f), 1f);
        particles.transform.localPosition = obj.transform.localPosition;
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

    void OnCollisionEnter()
    {
        Debug.Log("Boom");
        num += 1;
        popping = particles.GetComponent<ParticleSystem>();
        popping.Play(true);
        obj.transform.localPosition = new Vector3(0f, -100f, 0f);
        source.Play(0);
        Color color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f), 1f);
        //obj.GetComponent<MeshRenderer>().material.color = color;
        remainingTime = 1.5f;
        countingDown = true;
    }
    void Respawn() {
        Debug.Log("respawned");
        //obj.transform.localPosition = new Vector3(Random.Range(-1f, 1.5f), Random.Range(1f, 3f), Random.Range(-1f, 1f));
        obj.transform.localPosition = new Vector3(Random.Range(-1f, 1.5f), Random.Range(1.5f, 2f), 1f);
        particles.transform.localPosition = obj.transform.localPosition;
        countingDown = false;
    }
}
