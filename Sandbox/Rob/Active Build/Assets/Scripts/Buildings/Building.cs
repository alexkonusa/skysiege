using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Building : MonoBehaviour 
{

	//store our buildings in this array
	public GameObject[] buildings;

	public Transform buildingPanel;
	public Transform buildingObjSlot;


	// Use this for initialization
	void Start () 
	{
		buildings = Resources.LoadAll<GameObject>("Prefabs/Map/Decor");

		for (int i = 0; i < buildings.Length; i++) 
		{

			Transform test = (Transform)Instantiate(buildingObjSlot, buildingPanel.position, 
				buildingPanel.rotation) as Transform;

			test.transform.SetParent(buildingPanel, false);

		}
	
	}
}
