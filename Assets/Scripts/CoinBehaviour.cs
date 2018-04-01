using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinBehaviour : MonoBehaviour {

	public GameObject Coin;
	public float CoinSpeed = 1;
	public float RotationSpeed = 1;
	public float JumpingSpeed = 1;
	float timeCounter;

	// Use this for initialization
	void Start () 
	{
		Coin.transform.rotation = Quaternion.Euler(10, 0, -90);	
	}

	// Update is called once per frame
	void Update () {
		Destroy (gameObject, 20f);
		timeCounter += Time.deltaTime * JumpingSpeed;
		Coin.transform.Rotate (Vector3.right * Time.deltaTime * RotationSpeed);
		double y = Mathf.Cos (timeCounter)/2;
		Coin.transform.position = new Vector3 (Coin.transform.position.x, (float)y, Coin.transform.position.z);	
		GetComponent<Rigidbody> ().velocity = -transform.forward * CoinSpeed;
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
