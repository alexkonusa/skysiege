using UnityEngine;
using System.Collections;

public class PlayerAIHealth : MonoBehaviour {

	public float Health = 100f;

	void Awake() {

		Health = 100f;

	}

	void Update () {
	
		if (Health <= 0) {

			Destroy (gameObject);

		}

	}
}
