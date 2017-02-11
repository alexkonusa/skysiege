using UnityEngine;
using System.Collections;

public class GridDB : MonoBehaviour 
{
	public string[] LayerOne; //Player Base Name Hex's
	public string[] LayerTwo; //Player Ship Diployment Name Hex's
	public string[] LayerThree; 

	public GameObject hubHexPrefab; 
	public GameObject hubHexPrefab_loc;
	public GameObject[] hexObjectsToInst; //List of Hex's we Inst at the start

	public GameObject[] decorItems;
	void Awake ()

	{

		LayerOne = new string[36]
		{"Hex_9_10", "Hex_9_11", "Hex_10_11", "Hex_11_10", "Hex_10_9", "Hex_9_9", "Hex_10_8", 
		"Hex_11_8", "Hex_11_9", "Hex_12_10", "Hex_11_11", "Hex_11_12", "Hex_10_12", "Hex_9_12",
		"Hex_8_11", "Hex_8_10", "Hex_8_9", "Hex_9_8", "Hex_13_10", "Hex_12_11", "Hex_12_12", 
		"Hex_11_13", "Hex_10_13", "Hex_9_13", "Hex_8_13", "Hex_8_12", "Hex_7_11", "Hex_7_10",
		"Hex_7_9", "Hex_8_8", "Hex_8_7", "Hex_9_7", "Hex_10_7", "Hex_11_7", "Hex_12_8", 
		"Hex_12_9"
		};

		LayerTwo = new string[30]
		{"Hex_10_15", "Hex_11_15", "Hex_12_15", "Hex_13_14", "Hex_13_13", "Hex_14_12", "Hex_14_11", 
		"Hex_15_10", "Hex_14_9", "Hex_14_8", "Hex_13_7", "Hex_13_6", "Hex_12_5", "Hex_10_5",
		"Hex_9_5", "Hex_8_5", "Hex_7_5", "Hex_7_6", "Hex_6_7", "Hex_6_8", "Hex_5_9", 
		"Hex_5_10", "Hex_6_12", "Hex_6_13", "Hex_7_14", "Hex_7_15", "Hex_11_5", "Hex_5_11", "Hex_8_15",
			"Hex_9_15"
		};
			
		LayerThree = new string[]
		{

		};

		hubHexPrefab = Resources.Load<GameObject>("Prefabs/Map/Hex_Hub");
		hexObjectsToInst = Resources.LoadAll<GameObject>("Prefabs/Map/Hex_ToInst");
		decorItems = Resources.LoadAll<GameObject>("Prefabs/Map/Decor");

	}

}
