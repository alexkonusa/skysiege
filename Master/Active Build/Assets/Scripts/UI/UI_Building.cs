using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UI_Building : MonoBehaviour 
{

	public GameObject[] buildings;

	public Transform buildingPanel;
	public Transform buildingObjSlot;

	// Use this for initialization
	void Start () 
	{
		buildings = Resources.LoadAll<GameObject>("Prefabs/Map/Decor");

		for (int i = 0; i < buildings.Length; i++) 
		{

			Transform build_Slot = (Transform)Instantiate(buildingObjSlot, buildingPanel.position, 
				buildingPanel.rotation) as Transform;

			build_Slot.GetComponent<UI_BuildingSlot>().this_Building = buildings[i].gameObject;

			build_Slot.transform.SetParent(buildingPanel, false);


		}
	
	}
}
