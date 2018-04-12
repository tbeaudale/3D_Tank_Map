using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveOnTouch : MonoBehaviour {

    [SerializeField]
    private Vector3 velocity;

    private bool moving;

    private void OnCollisionEnter(Collision collision)
    {
        moving = true;
        collision.collider.transform.SetParent(transform);
    }

    private void OnCollisionExit(Collision collision)
    {
        moving = false; 
        collision.collider.transform.SetParent(null);
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (moving && transform.position.x <= -358.3)
        {
            moving = false;
        }
        if (moving)
        {
            transform.position += (velocity * Time.deltaTime);
        }
	}
}
