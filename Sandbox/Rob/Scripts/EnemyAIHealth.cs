using UnityEngine;
using System.Collections;

public class EnemyAIHealth : MonoBehaviour {
	
	public float Health = 100f;


	void Awake() {

		Health = 100f;

	}
	// Update is called once per frame
	void Update () {

		if (Health <= 0) {

			Destroy (gameObject);
		}
	
	}
}