using UnityEngine;
using System.Collections;

public class Grid_Spawner : MonoBehaviour 
{

	public GameObject hexPrefab;
	public Transform hexParent;

	public int hexWidth = 10;
	public int hexHeight = 10;

	float xOffSet = 1.75f;
	float yOffSet = 1.75f;

	// Use this for initialization
	void Start () 
	{


		for (int x = 0; x < hexWidth; x++) 
		{

			for (int y = 0; y < hexHeight; y++) 
			{

				float xPossition = x * xOffSet;

				if (y % 2 == 1)
				{

					xPossition += xOffSet / 2f;

				}

				GameObject Hex = Instantiate (hexPrefab, new Vector3(xPossition, 0, y * yOffSet), transform.rotation = Quaternion.identity) as GameObject;

				hexPrefab.name = "Hex_" + x + "_" + y;

				Hex.transform.SetParent(hexParent, false);
				
			}
			
		}
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
