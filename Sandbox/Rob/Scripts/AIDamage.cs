using UnityEngine;
using System.Collections;

public class AIDamage : MonoBehaviour {

	public float countdown = 5f;
	public float AttackCountdown = 5f;

	public int range = 1;
	public int rangemax = 5;

	public bool Test2 = false;
	public bool FoundSomething = false;

	Transform Closest;

	void Update () {

		countdown -= Time.deltaTime;

		if (countdown <= 0) {
			NearestObject();
			countdown = AttackCountdown;
		}

		if (Test2 == true) {
			Invoke ("RangeIncrease", 1);
			Debug.Log ("RangeIncrease");
			Test2 = false;
		}
	}

	void Damage () {

	}

	void NearestObject () {

		GameObject[] PlayerShips = GameObject.FindGameObjectsWithTag ("Playable");

		float ShortestDistance = float.MaxValue;
		Closest = null;

		foreach (GameObject Playable in PlayerShips) {

			float dist = Vector3.Distance (transform.position, Playable.transform.position);
			if (dist < range) {
				//			ShortestDistance = dist;
				Closest = Playable.transform;
//				Debug.Log (Closest);
				FoundSomething = true;
			} else {
				Test2 = true;
			}
		}		

		}

	void RangeIncrease () {
		
		if (range < 5) {
			range = range + 1;
			Debug.Log ("Increasing Range");
		} else if (range == rangemax) {
			Debug.Log ("Max Range");
		}

	}
}



/*
  		countdown -= Time.deltaTime;
  		
		if (countdown <= 0) {

		var CollidersInRange = Physics.OverlapSphere (transform.position, range);
			if (range != rangemax) {
		for (int i = 0; i < CollidersInRange.Length; i++) {				
					if (gameObject.CompareTag ("HexTile") == false) {
						if (gameObject.CompareTag ("Playable") == true) {
							Debug.Log ("In Range");
						} else {
							Debug.Log ("Found Nothing");
							Test2 = true;
						}

					}
			}			
		}
			countdown = AttackCountdown;
	}
		*/