using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public GameObject BackGround;
    public GameObject startPoint;
    public int speed = 10;

	public int travelDistance = 1;
	public GameObject[] Shop = new GameObject[5];
	bool UpGoing=true;
	Vector3 startPos;
	Vector3 endPos;

	// Use this for initialization
	void Start ()
    {
        InvokeRepeating("BackGroundSpawner", 0f, 1.2f);
    }
	
	// Update is called once per frame
	void Update ()
    {

    }

    void BackGroundSpawner()
    {
        var plate = (GameObject)Instantiate(BackGround, startPoint.transform.position, startPoint.transform.rotation);
        plate.GetComponent<Rigidbody>().velocity = -plate.transform.forward*speed;
        plate.transform.rotation = Quaternion.Euler(90, 0, 0);
        Destroy(plate, 6.0f);
    }

	public void ShopManager()
	{
		for (int i = 0; i < 5; i++) 
		{
			startPos = Shop [i].transform.position;
			if (UpGoing) endPos = Shop [i].transform.position + transform.up * travelDistance;
			else endPos = Shop [i].transform.position - transform.up * travelDistance;
			endPos.z=0;
			Shop [i].transform.position = Vector3.Lerp (startPos, endPos, Time.deltaTime / 10);
		}
		if (UpGoing)
			UpGoing = false;
		else
			UpGoing = true;
	}
}
