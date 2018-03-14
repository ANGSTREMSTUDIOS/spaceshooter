using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public GameObject BackGround;
    public int speed = 10;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        BackGround.transform.Rotate(Vector3.up * Time.deltaTime * speed);
	}
}
