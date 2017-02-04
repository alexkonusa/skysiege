using UnityEngine;
using System.Collections;

public class Camera_ : MonoBehaviour 
{

	//Camera target
	public Transform target;
	//Rotation Speed
	public float rotationSpeed = 10f;


	// Use this for initialization
	void Start () 
	{

	}
		
	void Update () 
	{
		
		transform.LookAt (target);

		if (Input.GetKey ("left")) 
		{
			transform.Translate (Vector3.left * rotationSpeed * Time.deltaTime);
		}

		if (Input.GetKey ("right")) 
		{
			transform.Translate (Vector3.right * rotationSpeed * Time.deltaTime);
		}

	}
}
