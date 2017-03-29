using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ButtonSkippy : MonoBehaviour {

	public void SkipWait () {
		//Set Wave to be eligible to start
		GameObject.Find ("GameManagers").GetComponent<WaveMachine> ().CheckIfThereAreNoEnemiesLeft();
		// Sets the timer to 5 seconds
		GameObject.Find ("GameManagers").GetComponent<WaveMachine> ().startTimer = 5;

	}


}