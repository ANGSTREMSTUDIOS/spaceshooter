using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthManager : MonoBehaviour {

	public int HP = 1;
	public float Speed = 0.2f;

	public Transform explosion;

	public GameObject Coin;
	Quaternion CoinRotation;
	bool coinLimit = false;

	// -------- --------

	void Update(){

		float x, z;
		transform.position -= new Vector3 (0f, 1f, 0f) * Time.deltaTime;

	}

	// -------- --------

	void OnTriggerEnter(Collider other)
	{
		if (HP <= 0) {
			Transform e = Instantiate (explosion, transform.position, transform.rotation);

			Destroy (e.gameObject, 1f);
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
