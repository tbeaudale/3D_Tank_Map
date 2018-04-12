using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireProjectile : MonoBehaviour
{

    public float throwForce = 40f;
    public GameObject fireballPrefab;
    public GameObject Player;
    public ParticleSystem flameThrower;
    int triggerCheck = 1;

    void Start()
    {
        flameThrower.Stop();
    }


    // Update is called once per frame
    void Update()
    {


        if (Player.activeSelf == false)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                triggerCheck = 1;
                flameThrower.Stop();
            }
            else if (Input.GetButtonDown("Fire2"))
            {
                triggerCheck = 2;
            }

            if (Input.GetButtonDown("Fire") && triggerCheck == 1)
            {
                ThrowFireball();
                fireballPrefab.SetActive(true);
            }

            if (Input.GetButtonDown("Fire") && triggerCheck == 2)
            {
                flameThrower.Play();
            }
        }


    }



    void ThrowFireball()
    {
        GameObject fireball = Instantiate(fireballPrefab, transform.position, transform.rotation);
        Rigidbody rb = fireball.GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * throwForce, ForceMode.VelocityChange);
    }
}