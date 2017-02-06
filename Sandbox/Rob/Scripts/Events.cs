using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Events : MonoBehaviour {

	public float Countdown = 2;
	public float CountdownMax = 20;

	public float Text3Countdown = 5;
	public float Text3CountdownMax = 5;

	public float Money = 500;
	public float Resources = 100;

	public Text Text1;
	public Text Text2;
	public Text Text3;

	string MoneyString;
	string ResourcesString;

	public GameObject CheapoCubeo;

	void Awake () { 
		Text3.enabled = false;
	}

	// Update is called once per frame
	void Update () {

		

		MoneyString = Money.ToString ();
		ResourcesString = Resources.ToString ();

		Text1.text = "Money: " + MoneyString;
		Text2.text = "Resources: " + ResourcesString;
	

		//Timer Addition

		Countdown -= Time.deltaTime;

		if (Countdown <= 0) {
			Countdown = CountdownMax;
			Money += 5;
			Resources += 20;
		}

		//Debug Spending
		if (Input.GetKeyDown (KeyCode.Y)) {
			if (Resources > 100 && Money > 50) {
				Resources -= 100;
				Money -= 50;
				Text3.enabled = true;
				Text3.text = "Cheap";
				Text3Reset ();
				SpawnCheap ();
			}
		}

		if (Input.GetKeyDown (KeyCode.T)) {
			if (Resources > 500 && Money > 250) {
				Resources -= 500;
				Money -= 250;
				Text3.enabled = true;
				Text3.text = "Expensive";
				Text3Reset ();
			}
		}
	}

	void Text3Reset () {

		Text3Countdown -= Time.deltaTime;

		if (Text3Countdown <= 0) {
			Text3Countdown = Text3CountdownMax;
			Text3.enabled = false;
		}

	}

	void SpawnCheap () {
		Instantiate (CheapoCubeo, new Vector3 (0, 0, 0), Quaternion.identity);
	}


}
