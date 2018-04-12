using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhosTheDaddy : MonoBehaviour {

	private GameObject player;

	void Awake () {
		player = GameObject.FindGameObjectWithTag ("Player");
	}
	// Use this for initialization
	void Start () {
		
	}
	
	void OnCollisionEnter (Collision other) {
		if (other.gameObject == player) {
			player.transform.parent = this.transform;
		}
		
	}

	void OnCollisionExit (Collision other) {
		if (other.gameObject == player) {
			player.transform.parent = null;
		}

	}
}
