using UnityEngine;
using System.Collections;

public class Camera_ : MonoBehaviour 
{

	//Camera target
	public Transform target;
	//Rotation Speed
	public float rotationSpeed = 10;


	// Use this for initialization
	void Start () 
	{

	}
		
	void LateUpdate () 
	{
		
		transform.LookAt (target);

		if (Input.GetKey ("left")) 
		{
			transform.Translate (Vector3.left * Time.deltaTime);
		}

		if (Input.GetKey ("right")) 
		{
			transform.Translate (Vector3.right * Time.deltaTime);
		}

	}
}
