using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthManager : MonoBehaviour {

	public int HP=1;

	public ParticleSystem explosion;

	public GameObject Coin;
	Quaternion CoinRotation;
	bool coinLimit=false;

	// Use this for initialization
	void Start () {
		explosion.enableEmission=false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other)
	{
		if (HP <= 0) {
			explosion.enableEmission=true;
			Destroy (other.gameObject);
			if (!coinLimit)
				Instantiate (Coin, transform.position, CoinRotation);
			coinLimit = true;
			Destroy (gameObject);
		} 
		else
			HP--;
	}
}
