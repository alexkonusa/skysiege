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

		LayerTwo = new string[54]
		{"Hex_10_15", "Hex_11_15", "Hex_12_15", "Hex_13_14", "Hex_13_13", "Hex_14_12", "Hex_14_11", 
		"Hex_15_10", "Hex_14_9", "Hex_14_8", "Hex_13_7", "Hex_13_6", "Hex_12_5", "Hex_10_5",
		"Hex_9_5", "Hex_8_5", "Hex_7_5", "Hex_7_6", "Hex_6_7", "Hex_6_8", "Hex_5_9", 
		"Hex_5_10", "Hex_6_12", "Hex_6_13", "Hex_7_14", "Hex_7_15", "Hex_11_5", "Hex_5_11", "Hex_8_15",
		"Hex_9_15", "Hex_10_14", "Hex_9_14", "Hex_8_14", "Hex_7_13", "Hex_7_12",
		"Hex_6_11", "Hex_6_10", "Hex_6_9", "Hex_7_8", "Hex_7_7", "Hex_8_6", "Hex_9_6", 
		"Hex_10_6", "Hex_11_6", "Hex_12_6", "Hex_12_7", "Hex_13_8", "Hex_13_9", "Hex_14_10",
			"Hex_13_11", "Hex_13_12", "Hex_12_13", "Hex_12_14", "Hex_11_14"
		};
			
		LayerThree = new string[78]
		{
			"Hex_4_13", "Hex_5_14", "Hex_5_15", "Hex_6_16", "Hex_6_17", "Hex_7_17", "Hex_8_17", "Hex_9_17", 
			"Hex_10_17", "Hex_11_17", "Hex_12_17", "Hex_13_17", "Hex_14_16", "Hex_14_15", "Hex_15_14", 
			"Hex_15_13", "Hex_16_12", "Hex_16_11", "Hex_17_10", "Hex_16_9", "Hex_16_8", "Hex_15_7",
			"Hex_15_6", "Hex_14_5", "Hex_14_4", "Hex_13_3", "Hex_12_3", "Hex_11_3", "Hex_10_3", "Hex_9_3",
			"Hex_8_3", "Hex_7_3", "Hex_6_3", "Hex_6_4", "Hex_5_5", "Hex_5_6", "Hex_4_7", "Hex_4_8", "Hex_3_9",
			"Hex_3_10", "Hex_3_11", "Hex_4_12", "Hex_4_10", "Hex_4_9", "Hex_5_8", "Hex_5_7", "Hex_6_6", 
			"Hex_6_5", "Hex_7_4", "Hex_8_4", "Hex_9_4", "Hex_10_4", "Hex_11_4", "Hex_12_4", "Hex_13_4", 
			"Hex_13_5", "Hex_14_6", "Hex_14_7", "Hex_15_8", "Hex_15_9", "Hex_16_10", "Hex_15_11",
			"Hex_15_12", "Hex_14_13", "Hex_14_14", "Hex_13_15", "Hex_13_16", "Hex_12_16", "Hex_11_16",
			"Hex_10_16", "Hex_9_16", "Hex_8_16", "Hex_7_16", "Hex_6_15", "Hex_6_14", "Hex_5_13",
			"Hex_5_12", "Hex_4_11"
		};

		hubHexPrefab = Resources.Load<GameObject>("Prefabs/Map/Hex_Hub");
		hexObjectsToInst = Resources.LoadAll<GameObject>("Prefabs/Map/Hex_ToInst");
		decorItems = Resources.LoadAll<GameObject>("Prefabs/Map/Decor");

	}

}
