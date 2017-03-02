using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Grid_Spawner : GridDB 
{

	public GameObject hexPrefabToInst; //Our 3D Hex Model
	public GameObject hexAiDeploymentSprite; 
	public GameObject hexShipDeploymentSprite; 

	public GameObject hexGridPrefab; //Hex Grid Sprite
	public Transform hexParent; //Parent "Map"

	public Sprite hexSprite; //Use this sprite to get our x and OffSet

	//Width and Height of our grid
	public int hexGridWidth = 20;
	public int hexGridHeight = 20;

	public float yOffSetCalc = 1.2f;

	//**** Hard Codded Layers of Interactable Hex's ****//
	public List<GameObject> hexLayerOne = new List<GameObject>(); //Player Base Hex's
	public List<GameObject> hexLayerTwo = new List<GameObject>(); //Player Ship Deployment Hex's
	public List<GameObject> hexLayerThree = new List<GameObject>(); //AI Hex's

	// Use this for initialization
	void Start () 
	{

		Debug.Log(hubHexPrefab.name);
		//Get the Width and Height of the sprite
		//Our grid offset 
		float xOffSet = hexSprite.bounds.size.x;
		float yOffSet = hexSprite.bounds.size.y / yOffSetCalc;


		for (int x = 0; x < hexGridWidth; x++) 
		{

			for (int y = 0; y < hexGridHeight; y++) 
			{

				float xPossition = x * xOffSet;

				if (y % 2 == 1)
				{

					xPossition += xOffSet / 2f;

				}

				//Instantiate our hex
				GameObject Hex = (GameObject)Instantiate (hexGridPrefab, new Vector3(xPossition, 0, y * yOffSet),
					transform.rotation = Quaternion.identity) as GameObject;

				//Rename our Hex to Axial position 
				Hex.name = "Hex_" + x + "_" + y;

				//Change the parent of our Hex ... 
				Hex.transform.SetParent(hexParent, false);

			}
		}

		//Create our layers
		HexLayerObjFetching ();
		HexLayerCreation ();
	}

	//Collecting our objects and storing in them in Lists
	void HexLayerObjFetching ()
	{

		//Pick a string "Hex  Name" from our layer array 
		//use the string to find our object and add it to the list

		//*************** Player Layer "Base" *************** 
		for (int i = 0; i < LayerOne.Length; i++) 
		{

			string name = LayerOne[i];
			//Debug.Log(name);
			hexLayerOne.Add(GameObject.Find(name));
			//Debug.Log(hexLayerOne);

		}

		//*************** Ship Layer "Deployment" *************** 
		for (int i = 0; i < LayerTwo.Length; i++) 
		{
			string names = LayerTwo[i];
			hexLayerTwo.Add(GameObject.Find(names));

		}

		//*************** AI Layer*************** 
		for (int i = 0; i < LayerThree.Length; i++) 
		{
			string names = LayerThree[i];
			hexLayerThree.Add(GameObject.Find(names));

		}

	}

	void HexLayerCreation ()
	{

		//Instantiate our Hexs using the list of objects in our list. 
		//This will instantiate a Model at every objects position in our list (0, 0, 0)
		//Unless we set a custom possition
		//And will change objects parent acording to the obejct it's bieng instantiated at

		//Player Base Layer
		for (int i = 0; i < hexLayerOne.Count; i++) 
		{
			
			//Pick a random hex from our array [hexObjectsToInst] and Instantiate that object
			int hexInt_ToInst = Random.Range(0, (hexObjectsToInst.Length));
			GameObject hexToInstantiate = hexObjectsToInst[hexInt_ToInst];

			//Instantiate Our Object
			GameObject HexIsland_ = (GameObject)Instantiate(hexToInstantiate, hexLayerOne[i].transform.position, 
				hexLayerOne[i].transform.rotation) as GameObject;

			//Parenting and Naming 
			Transform hexParent = hexLayerOne[i].transform;
			//hexParent.transform.GetChild(0).gameObject.SetActive(false);

			HexIsland_.transform.SetParent(hexParent, false);
			HexIsland_.transform.localPosition = Vector3.zero; 

			//Add Decor Items to our player base
			Vector3 decorOffSet = new Vector3(0f, 0.005f, 0f);

			int decorToInstID = Random.Range(0, (decorItems.Length));
			GameObject decorObjToInst = decorItems[decorToInstID];

			GameObject decorToInst = (GameObject)Instantiate(decorObjToInst, HexIsland_.transform.position, 
				HexIsland_.transform.rotation) as GameObject;

			//GameObject parentObj = HexIsland_.transform.GetChild(0);

			decorToInst.transform.SetParent(HexIsland_.transform.GetChild(0), false);
			decorToInst.transform.localPosition = decorOffSet;

		}

		//Hex Hub Instantiation

		hubHexPrefab_loc = GameObject.Find("Hex_10_10");
		GameObject hexHubPrefInst = (GameObject)Instantiate(hubHexPrefab, hubHexPrefab_loc.transform.position, 
			hubHexPrefab_loc.transform.rotation) as GameObject;

		hexHubPrefInst.transform.SetParent(hubHexPrefab_loc.transform, false);
		hexHubPrefInst.transform.localPosition = Vector3.zero;
		hubHexPrefab_loc.transform.GetChild(0).gameObject.SetActive(false);

		//Hub End

		//Ship Deploy Layer
		for (int i = 0; i < hexLayerTwo.Count; i++) 
		{
			
			//Instantiate Our Object
			GameObject hexShipSprite = (GameObject)Instantiate(hexShipDeploymentSprite, hexLayerTwo[i].transform.position, 
				hexLayerTwo[i].transform.rotation) as GameObject;

			//Parenting and Naming 
			Transform hexParent = hexLayerTwo[i].transform;
			hexShipSprite.transform.localPosition = Vector3.zero;

			hexShipSprite.transform.SetParent(hexParent, false);

			hexParent.transform.GetChild(0).gameObject.SetActive(false);


		}

		//Ship Deploy Layer
		for (int i = 0; i < hexLayerThree.Count; i++) 
		{

			//Instantiate Our Object
			GameObject hexAISprite = (GameObject)Instantiate(hexAiDeploymentSprite, hexLayerThree[i].transform.position, 
				hexLayerThree[i].transform.rotation) as GameObject;

			//Parenting and Naming 
			Transform hexParent = hexLayerThree[i].transform;
			hexAISprite.transform.localPosition = Vector3.zero;

			hexAISprite.transform.SetParent(hexParent, false);

			hexParent.transform.GetChild(0).gameObject.SetActive(false);


		}
	}
}
