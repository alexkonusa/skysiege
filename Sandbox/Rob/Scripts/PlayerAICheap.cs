 using UnityEngine;
using System.Collections;

public class PlayerAICheap : MonoBehaviour {

	NavMeshAgent nma;
	public GameObject Player;
	Vector3 PlayerLocation;
	MouseBehaviour ScriptStuff;

	public bool IsSelected = false;

	public Vector3 ClickedLocation;
	public GameObject Events;

	public float Countdown = 0.5f;
	float CountdownMax = 999;



	// Use this for initialization
	void Awake () {
		
//		PlayerLocation = new Vector3 (Player.transform.position.x, Player.transform.position.y, Player.transform.position.z);

		nma = GetComponent<NavMeshAgent> ();

		Player = GameObject.FindGameObjectWithTag ("Player");
		ScriptStuff = Player.GetComponentInChildren<Camera> ().GetComponent<MouseBehaviour> ();
//		Events = gameObject.GetComponent<MouseBehaviour> ();

	}
	
	// Update is called once per frame
	void Update () {

		Countdown -= Time.deltaTime;
		if (Countdown <= 0) {
			InitialMove ();
			Countdown = CountdownMax;	
		}
			

	}

	void InitialMove() {
		PlayerLocation = new Vector3 (Player.transform.position.x, Player.transform.position.y, Player.transform.position.z);
//		nma.SetDestination (PlayerLocation);
		nma.SetDestination (ScriptStuff.ClickedLocation);
		

	}
}
