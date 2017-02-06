using UnityEngine;
using System.Collections;

public class TestScript : MonoBehaviour {


	Waves wave;

	void Awake () {

		wave = GameObject.FindGameObjectWithTag ("EventsSystem").GetComponent<Waves> ();
	}

	// Update is called once per frame
	void Update () {

		if (Input.GetKeyUp (KeyCode.E)) {
			var CurrentEnemy = GameObject.FindGameObjectWithTag ("Enemy");
			Destroy (CurrentEnemy);
			wave.EnemiesLeft--;
		}
	
	}
}
