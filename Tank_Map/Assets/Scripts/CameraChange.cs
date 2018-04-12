using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraChange : MonoBehaviour {

    public GameObject MainCam;
    public GameObject SceneCam;

    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Player")
        {


            MainCam.SetActive(false);
            SceneCam.SetActive(true);
        }
    }
    void OnTriggerExit(Collider collider)
    {
        if (collider.tag == "Player")
        {


            MainCam.SetActive(true);
            SceneCam.SetActive(false);
        }
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
