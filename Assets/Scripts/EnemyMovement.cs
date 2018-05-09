using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

    float time=0;
    public int speed = 1;
    public float freq = 1;

	// Use this for initialization
	void Start ()
    {


	}
	
	// Update is called once per frame
	void Update ()
    {
        time += Time.deltaTime;
        double z = Mathf.Abs(Mathf.Tan(time)) * freq;
        float x = transform.position.x + 0.01f * speed;
        transform.position = new Vector3(x, 0, (float)z);
    }
}
