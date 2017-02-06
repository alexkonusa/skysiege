using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	Rigidbody rb;

//	public float MovementSpeed = 10f;
	public float MaxSpeed = 15f;


	// Use this for initialization
	void Awake () {

		rb = GetComponent<Rigidbody> ();

	}
	
	// Update is called once per frame
	void FixedUpdate () {


		//Actual movement of the camera
		Vector3 targetVelocity = new Vector3 (Input.GetAxis ("Horizontal"), 0, Input.GetAxis ("Vertical"));
		targetVelocity = transform.TransformDirection (targetVelocity);
		targetVelocity *= MaxSpeed;

		Vector3 velocity = rb.velocity;
		Vector3 velocityChange = (targetVelocity - velocity);
		velocityChange.x = Mathf.Clamp (velocityChange.x,-10, 10);
		velocityChange.z = Mathf.Clamp (velocityChange.z, -10, 10);
		rb.AddForce (velocityChange, ForceMode.VelocityChange);


		//Scroll Wheel
		var Scroll = Input.GetAxis ("Mouse ScrollWheel");
		if (Scroll > 0f) {
			Debug.Log ("Scroll Up");
		} else if (Scroll < 0f) {
			Debug.Log ("Scroll Down");
		}
	}
}
