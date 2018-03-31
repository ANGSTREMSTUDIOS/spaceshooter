﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

	public GameObject Camera;
	float sideways;

    public GameObject BackGround;
    public GameObject SpawnPoint;
	Vector3 startPoint;
    public int speed = 10;

	public int travelDistance = 1;
	public GameObject[] Shop = new GameObject[5];
	bool UpGoing=true;
	Vector3 startPos;
	Vector3 endPos;

	// Use this for initialization
	void Start ()
    {
        InvokeRepeating("BackGroundSpawner", 0f, 3f);
		startPoint = SpawnPoint.transform.position;
    }
	
	// Update is called once per frame
	void Update ()
    {
		CameraMovement ();
    }

    void BackGroundSpawner()
    {	
		for (int i = 0; i < 2; i++)
		{
			if (i == 0)
				startPoint.x = 20;
			else
				startPoint.x = -20;
			
			var plate = (GameObject)Instantiate(BackGround, startPoint, SpawnPoint.transform.rotation);
			plate.GetComponent<Rigidbody>().velocity = -plate.transform.forward*speed;
			plate.transform.rotation = Quaternion.Euler(90, 0, 0);
			Destroy(plate, 7.0f);
		}
    }

	void CameraMovement()
	{
		sideways = Input.GetAxis("Horizontal") * speed;
		if(Camera.transform.position.x < 1 && sideways > 0) transform.Translate(sideways/30, 0, 0);
		if(Camera.transform.position.x > -1 && sideways < 0) transform.Translate(sideways/30, 0, 0);
	}
		
}
