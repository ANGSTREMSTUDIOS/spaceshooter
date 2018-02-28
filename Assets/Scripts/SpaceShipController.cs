using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShipController : MonoBehaviour {

    public GameObject vehicle;
    float turn;
    public int rotationSpeed=1;
    Transform rotus

	void Start ()
    {
		
	}

	void Update ()
    {

        turn = Input.GetAxis("Horizontal") * rotationSpeed;
        transform.Translate(turn, 0, 0);
        if(turn<0) vehicle.transform.Rotate(0, 0, 10);
        else if (turn>0) vehicle.transform.Rotate(0, 0, 10);
        else vehicle.transform.Rotate(0, 0, 0);
        transform.rotation = Quaternion.Lerp(vehicle.transform.rotation, rotus.rotation , Time.time);

    }
}
