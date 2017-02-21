using UnityEngine;
using System.Collections;

public class AISpawn : MonoBehaviour {


	Grid_Spawner Griddy;
	public GameObject Test;
	public int SpawnRate;
	public int WaveNumber = 1;

	void Start () {
		//Getting the grid hexes
		Griddy = GameObject.FindGameObjectWithTag ("Map").GetComponent<Grid_Spawner> ();
	
	}
	
	// Update is called once per frame
	void Update () {
		//Spawn on button press
		if (Input.GetKeyDown (KeyCode.O)) {
			//For each hex...
			for (int i = 0; i < Griddy.hexLayerTree.Count; i++) {				
				int RandomNumber = Random.Range (0, 100);
				//If the random number is less than 50...
				if (RandomNumber < (WaveNumber*2)) {

					//Check if something is in the spot...
					if(Physics.CheckSphere(Griddy.hexLayerTree[i].transform.position,0.25f)) {
						Debug.Log ("Full");
					} else {
					//If nothing is in the spot, spawn an AI
					Instantiate (Test, Griddy.hexLayerTree[i].transform.position , Quaternion.identity);
					}
				}
			}
		}

		if (Input.GetKeyDown (KeyCode.E)) {

			WaveNumber = WaveNumber + 1;
			Debug.Log (WaveNumber);
			

		}
	}



}
