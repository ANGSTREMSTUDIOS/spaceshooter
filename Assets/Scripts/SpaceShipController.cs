using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpaceShipController : MonoBehaviour {

    public GameObject vehicle;

    float sideways;
	float forward;

	public float speed = 1;
    public int rotationSpeed=1;

	GameObject rotus;


    public Image HealthBar;
    public Image ShieldBar;
    public float Health=100;
    public float Shield=100;


	public ParticleSystem FumesParticles;
	ParticleSystem.EmissionModule emissionModule;


    public GameObject[] Guns = new GameObject[3];
    public GameObject BulletPrefab;
    public int BulletSpeed = 10;
    int m;

    public int GunUpdateStage=1;

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

        HealthBar.fillAmount = Health / 100;
        ShieldBar.fillAmount = Shield / 100;


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
		if(transform.position.x < 16.3 && sideways > 0) transform.Translate(sideways, 0, 0);
		if(transform.position.x > -16.3 && sideways < 0) transform.Translate(sideways, 0, 0);

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
            if (GunUpdateStage == 1)
            {
                m = i;
                if (m == 1) break;
            }

            else if (GunUpdateStage == 2)
            {
                m = i + 1;
                if (i == 2) break;
            }

            else m = i;

			var bullet = (GameObject)Instantiate(BulletPrefab, Guns[m].transform.position, Guns[m].transform.rotation);
            bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * BulletSpeed;
            bullet.transform.rotation = Quaternion.Euler(90, 0, 0);
            Destroy(bullet, 2.0f);

        }

    }
}
