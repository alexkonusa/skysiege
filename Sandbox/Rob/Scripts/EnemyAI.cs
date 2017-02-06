using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour {

	NavMeshAgent nma;

	public GameObject Base;
	Vector3 BaseLocation;

	enum EnemyState {
		Moving,
		Shooting,
	}

	EnemyState MyState;

	// Use this for initialization
	void Awake () {

		MyState = EnemyState.Moving;

		nma = GetComponent<NavMeshAgent>();
		Base = GameObject.FindGameObjectWithTag ("Base");
		BaseLocation = new Vector3 (Base.transform.position.x, 1, Base.transform.position.z);
			
	}

	void Update () {

		Debug.DrawRay (transform.position, transform.forward *10, Color.green);

		//Raycast
//		Ray ray = transform.position;
		RaycastHit hit;
		if (Physics.Raycast (transform.position, transform.forward, out hit, 50)) {
			if (hit.transform.tag == "Base") {
				Debug.Log ("Hit Shit");
				Shooting ();
			}
		} else {
			Moving ();
		}

		gameObject.transform.rotation = gameObject.GetComponent<Camera> ().transform.rotation;
			

	}

	void FixedUpdate () {

//		gameObject.transform.rotation = gameObject.GetComponent<Camera> ().transform.rotation;

	}
	
	// Movement
	void Moving () {

		nma.SetDestination (BaseLocation);
	
	}

	// Shooting
	void Shooting () {
		nma.speed = 0;

	}
}
