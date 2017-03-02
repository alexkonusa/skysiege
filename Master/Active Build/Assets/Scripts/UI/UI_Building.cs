using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UI_Building : MonoBehaviour 
{

	public GameObject[] buildings;
	public string hexSelected;

	public Transform buildingPanel;
	public Transform buildingObjSlot;

	UIManager uimanager;

	// Use this for initialization
	void Start () 
	{
		buildings = Resources.LoadAll<GameObject>("Prefabs/Map/Buildings");
		uimanager = GameObject.FindGameObjectWithTag("Canvas").GetComponent<UIManager>();

		for (int i = 0; i < buildings.Length; i++) 
		{

			Transform build_Slot = (Transform)Instantiate(buildingObjSlot, buildingPanel.position, 
				buildingPanel.rotation) as Transform;

			build_Slot.GetComponent<UI_BuildingSlot>().this_Building = buildings[i].gameObject;

			build_Slot.transform.SetParent(buildingPanel, false);

		}
	
	}

	public void ClosePanel()
	{

		if (Node.builtBuilding == null)
		{

			Destroy(GameObject.FindGameObjectWithTag("_buildPanel"));
			uimanager.buildingPanelActive = false;
		}
	}
}
