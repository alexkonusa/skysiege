using UnityEngine;
using System.Collections;

public class AIDamage : MonoBehaviour {

	public float countdown = 5f;
	public float AttackCountdown = 5f;

	float countdownDamage;
	public float DamageCountdown = 5f;

	public int range = 1;
	public int rangemax = 5;

	public bool Test2 = false;
	public bool FoundSomething = false;

	public int AttackDamage;
	public int Health;


	Transform Closest;

	void Awake () {

		countdownDamage = DamageCountdown;

	}

	void Update () {

		if (FoundSomething == false) {
			countdown -= Time.deltaTime;
		}

		if (countdown <= 0 && FoundSomething == false) {
			NearestObject();
			countdown = AttackCountdown;
		}

		if (Test2 == true) {
			Invoke ("RangeIncrease", 1);
			Debug.Log ("RangeIncrease");
			Test2 = false;
		}

		if (FoundSomething == true) {

			countdownDamage -= Time.deltaTime;

			if (countdownDamage <= 0) {
				Damage ();

				countdownDamage = DamageCountdown;
			}

		}
	}

	void Damage () {

		Debug.Log ("Damaging Something");



		if (Closest != null) {
			Closest.GetComponent<PlayerShipDamage> ().Health -= 10;

		} else {
			FoundSomething = false;
		}

	}

	void NearestObject () {

		GameObject[] PlayerShips = GameObject.FindGameObjectsWithTag ("Playable");

		float ShortestDistance = float.MaxValue;
		Closest = null;

		foreach (GameObject Playable in PlayerShips) {

			float dist = Vector3.Distance (transform.position, Playable.transform.position);
			if (dist < range) {
				Closest = Playable.transform;
				FoundSomething = true;
			} else {
				Test2 = true;
			}
		}		

		}

	void RangeIncrease () {
		
		if (range < rangemax) {
			range = range + 1;
			Debug.Log ("Increasing Range");
		} else if (range == rangemax) {
			Debug.Log ("Max Range");
		}

	}
}