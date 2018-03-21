using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShipController : MonoBehaviour {

    public GameObject vehicle;

    float sideways;
	float forward;

	public float speed = 1;
    public int rotationSpeed=1;

	GameObject rotus;

	public ParticleSystem FumesParticles;
	ParticleSystem.EmissionModule emissionModule;

    public GameObject[] Guns = new GameObject[3];
    public GameObject BulletPrefab;
    public int BulletSpeed = 10;

	// -------- --------

	void Start()
	{

		emissionModule = FumesParticles.emission;

        InvokeRepeating("SpaceShipShooting", 0f, 0.4f);

    }

	// -------- --------

	void Update ()
    {
		SpaceShipMovement ();
    }

	// -------- --------

	void SpaceShipMovement()
	{

		forward = Input.GetAxis ("Vertical") * speed;
		if (transform.position.z < 8 && forward > 0) transform.Translate (0, 0, forward); 
		if (transform.position.z > -9.5 && forward < 0) transform.Translate (0, 0, forward);

		if (forward > 0) emissionModule.rate = 200f;
		if (forward < 0) emissionModule.rate = 2f;
		if (forward == 0) emissionModule.rate = 20f;

		sideways = Input.GetAxis("Horizontal") * speed;
		if(transform.position.x < 19 && sideways > 0) transform.Translate(sideways, 0, 0);
		if(transform.position.x > -19 && sideways < 0) transform.Translate(sideways, 0, 0);

		if (sideways < 0) 
		{
			rotus = GameObject.Find ("LeftIndicator");
		}

		if (sideways > 0)
		{
			rotus = GameObject.Find ("RightIndicator");
		}

		if (sideways == 0)
		{
			rotus = GameObject.Find ("LevelIndicator");
		}

		vehicle.transform.rotation = Quaternion.Slerp(vehicle.transform.rotation, rotus.transform.rotation , Time.deltaTime * rotationSpeed);
	}

    void SpaceShipShooting()
    {

        for(int i=0; i<3; i++)
        {
        var bullet = (GameObject)Instantiate(BulletPrefab, Guns[i].transform.position, Guns[i].transform.rotation);
        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * BulletSpeed;
        Destroy(bullet, 2.0f);
        }

    }
}
