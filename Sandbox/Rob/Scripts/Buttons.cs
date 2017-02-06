using UnityEngine;
using System.Collections;

public class Buttons : MonoBehaviour {

	public void NextWave () {
		var NextWave = gameObject.GetComponent<Waves> ().NextWaveActive = true;
		var WaveAddition = gameObject.GetComponent<Waves> ().WaveCount++;
	}
	public void Recall () {
		Debug.Log ("recalled");
	}
}