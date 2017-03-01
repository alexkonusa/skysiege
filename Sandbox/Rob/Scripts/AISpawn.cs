using UnityEngine;
using System.Collections;

public class AISpawn : MonoBehaviour {


	Grid_Spawner Griddy;
	public GameObject Test;
	public int SpawnRate;
	public int WaveNumber = 1;
	public int SpawnedEnemies;
	public int SpawnedEnemiesMax;
	public int MaxEnemiesXWave = 2;

	public float WaveCountdown;
	public float WaveCountdownMax = 5f;

	public bool NextWave = true;	

	void Start () {
		//Getting the grid hexes
		Griddy = GameObject.FindGameObjectWithTag ("Map").GetComponent<Grid_Spawner> ();
	
	}
	
	// Update is called once per frame
	void Update () {

		SpawnedEnemiesMax = (WaveNumber * MaxEnemiesXWave);

		if (NextWave == true) {

			WaveCountdown -= Time.deltaTime;

			if (WaveCountdown <= 0) {
				//For each hex...
				for (int i = 0; i < Griddy.hexLayerTree.Count; i++) {				
					//If the random number is less than 50...
					if (SpawnedEnemies < (WaveNumber * 2)) {

						//Check if something is in the spot...
						if (Physics.CheckSphere (Griddy.hexLayerTree [i].transform.position, 0.25f)) {
							Debug.Log ("Full");
						} else {
							//If nothing is in the spot, spawn an AI
							Instantiate (Test, Griddy.hexLayerTree [i].transform.position, Quaternion.identity);
							SpawnedEnemies++;
						}
					}
				}

				WaveCountdown = WaveCountdownMax;

				if (SpawnedEnemies == (WaveNumber * 2)) {
					NextWave = false;
				}

			}


		}

		if (SpawnedEnemies == 0 && NextWave == false) {
			NextWave = true;
			WaveNumber++;
		}


	}



}
