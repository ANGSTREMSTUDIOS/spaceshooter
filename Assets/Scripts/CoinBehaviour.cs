using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinBehaviour : MonoBehaviour {

	public float RotationSpeed = 1;
	public float JumpingSpeed = 1;
	float timeCounter;

	// Use this for initialization
	void Start () 
	{
		transform.rotation = Quaternion.Euler(10, 0, -90);	
	}

	// Update is called once per frame
	void Update () {
		
		timeCounter += Time.deltaTime * JumpingSpeed;
		transform.Rotate (Vector3.right * Time.deltaTime * RotationSpeed);
		double y = Mathf.Cos (timeCounter)/2;
		transform.position = new Vector3 (transform.position.x, (float)y, transform.position.z);	
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player") 
		{
			SpaceShipController.money++;
			Destroy (gameObject);
		}
	}
}
