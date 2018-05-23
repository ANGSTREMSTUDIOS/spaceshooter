﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

    float time=0;
    public int speed = 1;
    public float freq = 1;

    int difference;

    GameObject Target;

    // Use this for initialization
    void Start ()
    {
        difference = Random.Range(11, 16);
        Target = GameObject.Find("Player");
    }
	
	// Update is called once per frame
	void Update ()
    {
        MovementType2();
    }

    void MovementType1()
    {
        if (time < 1)
        {
            time += Time.deltaTime;
            double z = -Mathf.Abs(Mathf.Tan(time)) * freq + difference;
            float x = transform.position.x + 0.01f * speed;
            transform.position = new Vector3(x, 0, (float)z);
        }
        else if (time < 1.1)
        {
            transform.Translate(0, 0, -(transform.position.z - 5 - Time.deltaTime) / 20);

        }

        if (transform.position.y < 0)
            transform.position = new Vector3(transform.position.x, 0, transform.position.z);

    }

    void MovementType2()
    {

        transform.position = Vector3.Lerp(transform.position, Target.transform.position, 0.01f);

        transform.rotation = Quaternion.Lerp(transform.rotation, Target.transform.rotation, 1);

    }
}
