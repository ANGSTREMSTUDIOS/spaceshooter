using System.Collections;
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

    public GameObject[] Asteroids = new GameObject[1];
    Vector3 AsteriodStartPoint;
    public float AsteriodSpeed = 1;

    float timer = 0;

    Quaternion Rotation;
    public GameObject Enemy1;

    // Use this for initialization
    void Start ()
    {
        InvokeRepeating("BackGroundSpawner", 0f, 3f);
        InvokeRepeating("AsteroidSpawnAndShot", 10f, 5f);
        InvokeRepeating("Wave1", 3f, 10f);
        startPoint = SpawnPoint.transform.position;
    }
	
	// Update is called once per frame
	void Update ()
    {
		CameraMovement();

       
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
		if(Camera.transform.position.x < 1 && SpaceShipController.sideways > 0) transform.Translate(SpaceShipController.sideways/30, 0, 0);
		if(Camera.transform.position.x > -1 && SpaceShipController.sideways < 0) transform.Translate(SpaceShipController.sideways/30, 0, 0);
	}
		
    void AsteroidSpawnAndShot()
    {
        GameObject AsteroidPrefab = Asteroids[Random.Range(0, 1)];
        Quaternion SomeRotation = new Quaternion(0,0,0,0);
        Vector3 Direction = new Vector3(Random.Range(-10, 10), 0, Random.Range(1, 10));

        AsteriodStartPoint.x = Random.Range(-20, 20);
        AsteriodStartPoint.y = 0;
        AsteriodStartPoint.z = 10;

        var Asteriod = (GameObject)Instantiate(AsteroidPrefab, AsteriodStartPoint, SomeRotation);
        Asteriod.GetComponent<Rigidbody>().velocity = -Direction * AsteriodSpeed;
        Asteriod.transform.rotation = Quaternion.Euler(90, 0, 0);
        Destroy(Asteriod, 7.0f);
    }

    void Wave1()
    {
        for (int i = -15; i < 20; i+=5)
        {
            Instantiate(Enemy1, new Vector3(i, 0, 0), Rotation);
        }
    }
}
