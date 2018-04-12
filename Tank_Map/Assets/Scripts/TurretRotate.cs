using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretRotate : MonoBehaviour {

    public float sensitivityX = 1;
    public GameObject player;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (player.activeSelf == false)
        {


            float mouseX = Input.GetAxis("Mouse X");

            Rotating(mouseX);
        }
    }

    void Rotating(float mouseXInput)
    {

        Rigidbody ourBody = this.GetComponent<Rigidbody>();

        Vector3 targetDirection = new Vector3((mouseXInput * sensitivityX), 0f, 1f);

        transform.InverseTransformDirection(targetDirection);

        Quaternion deltaRotation = Quaternion.Euler(0f, (Input.GetAxis("Mouse X") * sensitivityX), 0f);

        ourBody.MoveRotation(ourBody.rotation * deltaRotation);

    }
}
