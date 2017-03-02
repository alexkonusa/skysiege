using UnityEngine;
using System.Collections;

public class PlayerShipDamage : MonoBehaviour {

	public float Attack;
	public float AttackSpeed;

	public int Damage;

	public int Range = 1; // ? Dis needed or nah?

	public int AttackDamage;
	public int Health;

	public bool EnemyInRange = false;

	Transform Closest;

	// Use this for initialization
	void Awake () {
	
		Health = 100;

		Attack = AttackSpeed;

	}
	
	// Update is called once per frame
	void Update () {

		if (EnemyInRange == false) {
			NearestObject ();
		}

		if (EnemyInRange == true) {

			Attack -= Time.deltaTime;

			if (Attack <= 0) {
				DamageThem ();
				Attack = AttackSpeed;
			}

		}

		if (EnemyInRange == true && Attack <= 0) {

		}

		if (Health <= 0) {
			Destroy (gameObject);
		}
	
	}

	void DamageThem () {

		if (Closest != null) {
			Closest.GetComponent<AIDamage> ().Health -= Damage;
		} else {
			EnemyInRange = false;
		}

	}

	void NearestObject () {

		GameObject[] Enemies = GameObject.FindGameObjectsWithTag ("Enemy");

		float ShortestDistance = float.MaxValue;
		Closest = null;

		foreach (GameObject Enemy in Enemies) {

			float dist = Vector3.Distance (transform.position, Enemy.transform.position);
			if (dist < Range) {
				Closest = Enemy.transform;
				EnemyInRange = true;
			} else {
//				Test2 = true;
				if (Range <= 5) {
					Range++;
				} else {

				}

			}
		}

	}
}
