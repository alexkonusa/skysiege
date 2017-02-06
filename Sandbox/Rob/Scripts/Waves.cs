using UnityEngine;
using System.Collections;

public class Waves : MonoBehaviour {

	public bool NextWaveActive = false;

	public float WaveCountdown = 4f;
	public float WaveCountdownMax = 5f;

	public int WaveCount = 0;

	public int EnemiesLeft;
	public int MaxEnemies;

	public GameObject Enemy;

	public float MinX = 20;
	public float MaxX = 100;
	public float MinZ = 20;
	public float MaxZ = 100;
	public int Range = 100;
	public float radius = 20f;

	public Vector3 SpawnLocation;
	public Vector3 MinSpawn;
	public Vector3 MaxSpawn;

	public float TestCount = 2;
	public float TestCountMax = 5;

	public int numObjects = 10;
	public GameObject prefab;


	void Start() {

		NextWaveActive = false;
		//stopping constant spawn initially
		Invoke ("StopWaveSpawning", 0.05f);

	}

	void Update () {

		MaxEnemies = WaveCount * 3;

		//Spawning
		if (NextWaveActive == true) {
			do {
				Vector3 center = transform.position;
				Vector3 pos = RandomCircle (center, 5.0f);
				Instantiate (Enemy, pos, Quaternion.identity);
				EnemiesLeft++;
				Debug.Log ("Spawning Broke");
				if (EnemiesLeft >= MaxEnemies) {
					Invoke ("StopWaveSpawning", 0.5f);
					NextWaveActive = false;
					Debug.Log ("Stop Wave Spawn Broke");
				}

			} while (EnemiesLeft >= 20);
		}

		//Go for next wave
		if (EnemiesLeft <= 0 && NextWaveActive == false) {
			WaveCountdown -= Time.deltaTime;
			if (WaveCountdown <= 0) {
				NextWaveActive = true;
				WaveCountdown = WaveCountdownMax;
				Debug.Log ("Countdown");
				WaveCount++;
			}
		}
			
	}
	//Test
	void Test () {
		TestCount -= Time.deltaTime;
		if (TestCount <= 0) {
			EnemiesLeft--;
			TestCount = TestCountMax;
			Debug.Log ("Test Running");
		}
	}
	//Circle for spawn radius
	Vector3 RandomCircle ( Vector3 center ,   float radius  ){
		float ang = Random.value * 360;
		Vector3 pos;
		pos.x = center.x + radius * Mathf.Sin(ang * Mathf.Deg2Rad) + (Random.Range(-100,100) * 2);
		pos.z = center.z + radius * Mathf.Cos(ang * Mathf.Deg2Rad) + (Random.Range(-100,100) * 2);
		pos.y = center.y ;
		return pos;
	}

	void StopWaveSpawning () {

		NextWaveActive = false;

	}
}
