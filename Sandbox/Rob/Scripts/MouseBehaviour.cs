
using UnityEngine;
using System.Collections;

public class MouseBehaviour : MonoBehaviour {

	public Vector3 ClickedLocation;

	public float Distance = 450f;


//	void OnGUI () {
//		Event e = Event.current;
//		Debug.Log (e.mousePosition);
//
//	}

	// Update is called once per frame
	void FixedUpdate () {
		
		if (Input.GetMouseButtonDown (0)) {

			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			RaycastHit hit;
			if (Physics.Raycast (ray, out hit)) {
				Debug.DrawLine (ray.origin, hit.point);
				Debug.Log (ClickedLocation);
				ClickedLocation = hit.point;
			}

		}




	}


}