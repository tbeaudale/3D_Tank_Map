using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour 
{
	public AudioClip shoutingClip;
	public float speedDampTime;
	public float sensitivityX = 1.0f;

	private Animator anim;
	private HashIDs hash;

	private float elapsedTime = 0;
	private bool noBackMov = true;

	void Awake()
	{
		anim = GetComponent <Animator> ();
		hash = GameObject.FindGameObjectWithTag ("GameController").GetComponent<HashIDs> ();

		anim.SetLayerWeight (1, 1f);

		Quaternion fixRotation = Quaternion.Euler (0f, -90f, 0f);
		Rigidbody ourBody = this.GetComponent<Rigidbody> ();
		ourBody.MoveRotation (fixRotation);
	}

	void FixedUpdate()
	{
		float v = Input.GetAxis ("Vertical");
		float s = Input.GetAxis ("Strafe");
		bool sneak = Input.GetButton ("Sneak");
		float mouseX = Input.GetAxis ("Mouse X");

		Rotating (mouseX);
		MovementManager (v, s, sneak);

		elapsedTime += Time.deltaTime;
		Debug.Log ("elapsed time is : ");
	}

	void Update()
	{
		bool shout = Input.GetButtonDown ("Attract");

		anim.SetBool (hash.shoutingBool, shout);

		AudioManagement (shout);
	}

	void MovementManager (float vertical, float strafe, bool sneaking)
	{
		anim.SetBool (hash.sneakingBool, sneaking);

		if (vertical > 0) 
		{
			noBackMov = true;
			anim.SetFloat (hash.speedFloat, 10f, speedDampTime, Time.deltaTime);
			anim.SetBool ("Backwards", false);

			Rigidbody ourBody = this.GetComponent<Rigidbody> ();
			float movement = Mathf.Lerp (0f, 0.025f, elapsedTime);
			Vector3 forward = new Vector3 (0.0f, 0.0f, movement);
			forward = ourBody.transform.TransformDirection (forward);
			ourBody.transform.position += forward;

			if (strafe < 0) {
				Vector3 moveSideways = new Vector3 (movement, 0.0f, 0.0f);
				moveSideways = ourBody.transform.TransformDirection (moveSideways);
				ourBody.transform.position += moveSideways;

			}
			if (strafe > 0) {
				Vector3 moveSideways = new Vector3 (-movement, 0.0f, 0.0f);
				moveSideways = ourBody.transform.TransformDirection (moveSideways);
				ourBody.transform.position += moveSideways;

			}
		} 

		if (vertical < 0) 
		{
			if (noBackMov == true) {
				elapsedTime = 0;
				noBackMov = false;
			}

			anim.SetFloat (hash.speedFloat, -1.5f, speedDampTime, Time.deltaTime);
			anim.SetBool ("Backwards", true);

			Rigidbody ourBody = this.GetComponent<Rigidbody> ();
			float movement = Mathf.Lerp (0f, -0.025f, elapsedTime);
			Vector3 moveBack = new Vector3 (0.0f, 0.0f, movement);
			moveBack = ourBody.transform.TransformDirection (moveBack);
			ourBody.transform.position += moveBack;


		} 

		if (vertical == 0) 	 
		{
			noBackMov = true;
			anim.SetFloat (hash.speedFloat, 0.01f);
			anim.SetBool (hash.backwardsBool, false);
		}
	}

	void Rotating (float mouseXInput)
	{
			
		Rigidbody ourBody = this.GetComponent<Rigidbody> ();

		Vector3 targetDirection = new Vector3 ((mouseXInput * sensitivityX), 0f, 1f);

		transform.InverseTransformDirection (targetDirection);

		Quaternion deltaRotation = Quaternion.Euler (0f, (Input.GetAxis ("Mouse X") * sensitivityX), 0f);

		ourBody.MoveRotation (ourBody.rotation * deltaRotation);

	}

	void AudioManagement (bool shout)
	{
		if (anim.GetCurrentAnimatorStateInfo (0).IsName ("Walk")) {
			if (!GetComponent<AudioSource> ().isPlaying) {
				GetComponent<AudioSource> ().pitch = 0.27f;
				GetComponent<AudioSource> ().Play ();
			}
		} 
		else 
		{
			GetComponent<AudioSource> ().Stop ();
		}

		if (shout) 
		{
			AudioSource.PlayClipAtPoint (shoutingClip, transform.position);
		}
	}

}
