using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public GameObject BackGround;
    public GameObject startPoint;
    public int speed = 10;

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
}
