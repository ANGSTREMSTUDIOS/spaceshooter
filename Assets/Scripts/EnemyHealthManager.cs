using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthManager : MonoBehaviour {

	public int HP=1;

	public GameObject Coin;
	Quaternion CoinRotation;
	bool coinLimit=false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other)
	{
		if (HP <= 0) {
			Destroy (other.gameObject);
			Destroy (gameObject);
			if (!coinLimit)
				Instantiate (Coin, transform.position, CoinRotation);
			coinLimit = true;
		} 
		else
			HP--;
	}
}
