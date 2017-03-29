using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ButtonSkippy : MonoBehaviour {

	public Transform Button;
	public Transform TextPanel;

	public void SkipWait () {
		//Set Wave to be eligible to start
		GameObject.Find ("GameManagers").GetComponent<WaveMachine> ().CheckIfThereAreNoEnemiesLeft ();
		// Sets the timer to 5 seconds
		GameObject.Find ("GameManagers").GetComponent<WaveMachine> ().startTimer = 5;
		//Destroys itself once pressed
		GameObject.Destroy (GameObject.FindGameObjectWithTag("SkipWave"), 1);
	}

	void Update(){

		if (GameObject.Find ("GameManagers").GetComponent<WaveManager> ().CurrentActiveEnemies.Count <= 0 && GameObject.FindGameObjectWithTag("SkipWave") == false) {

			Transform ButtonSpawn = (Transform)Instantiate (Button, Button.transform.position, Quaternion.identity);
			ButtonSpawn.transform.SetParent (TextPanel, false);
			ButtonSpawn.transform.SetSiblingIndex (2);


		}
		
	}

}