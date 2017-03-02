using UnityEngine;
using System.Collections;

public class _Grid_Spawner : MonoBehaviour 
{

	//Will go over this shit later 

	int numObjects = 20;
	int numObjects2 = 25;
	public GameObject prefab;
	public float firstGridLineRadius = 20;
	public float secondGridLineRadius = 26;

	// Use this for initialization
	void Start () 
	{


		for (int i = 0; i < numObjects; i++) 
			
			{
			
			GameObject test = Instantiate (prefab, this.transform.position + Vector3.forward * firstGridLineRadius ,new Quaternion(0, 0, 0 ,0 )) as GameObject;
			test.transform.RotateAround (this.transform.position, Vector3.down, 360 / (float)numObjects * i);

			}


		for (int i = 0; i < numObjects2; i++) 

		{

			GameObject test = Instantiate (prefab, this.transform.position + Vector3.forward * secondGridLineRadius ,new Quaternion(0, 0, 0 ,0 )) as GameObject;
			test.transform.RotateAround (this.transform.position, Vector3.down, 360 / (float)numObjects * i);

		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
