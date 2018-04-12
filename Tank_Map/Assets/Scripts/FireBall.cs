using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour {
	public float force = 700f;
	public float radius = 5f;
	public GameObject explosionEffect;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

	}

	void Explode ()
	{
		Instantiate(explosionEffect, transform.position, transform.rotation);
		Collider[] colliders = Physics.OverlapSphere (transform.position, radius);

		foreach (Collider nearbyObject in colliders) 
		{
			Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();
			if (rb != null) 
			{
				rb.AddExplosionForce(force, transform.position, radius);
			}
		}
		Destroy (gameObject);
	}
}
