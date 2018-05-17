using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour {

    public GameObject BulletPrefab;
    public GameObject Gun;
    public float BulletSpeed=1;

	// Use this for initialization
	void Start ()
    {
        InvokeRepeating("Shooting", Random.Range(0f, 1f), 1f);
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    void Shooting()
    {
        var bullet = (GameObject)Instantiate(BulletPrefab, Gun.transform.position, Gun.transform.rotation);
        bullet.GetComponent<Rigidbody>().velocity = new Vector3(0,0,-BulletSpeed);
        bullet.transform.rotation = Quaternion.Euler(90, 0, 0);
        //Destroy(bullet, 2.0f);
    }
}
