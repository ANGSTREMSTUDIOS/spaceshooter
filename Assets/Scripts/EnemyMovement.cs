using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

    float time=0;
    public int speed = 1;
    public float freq = 1;

    public int helper = 1;
    int difference;

    // Use this for initialization
    void Start ()
    {
        difference = Random.Range(11, 16);
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (time < 1)
        {
            time += Time.deltaTime;
            double z = -Mathf.Abs(Mathf.Tan(time)) * freq + difference;
            float x = transform.position.x + 0.01f * speed;
            transform.position = new Vector3(x, 0, (float)z);
        } 
        else if(time < 1.1)
        {
            transform.Translate(0, 0, -(transform.position.z - 5 - Time.deltaTime)/20);

        }



        //musi byc bo on nagle spada nie wiadomo czemu xD

        if (transform.position.y<0)
            transform.position = new Vector3(transform.position.x, 0, transform.position.z);


    }
}
