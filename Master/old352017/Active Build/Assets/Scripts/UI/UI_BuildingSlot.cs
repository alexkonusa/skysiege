using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UI_BuildingSlot : MonoBehaviour 
{
	//Now we can use this GameObject to find the picture, description and any other 
	//information we need
	public GameObject this_Building;
	public Image icon;
	public Text description;
	public Text priceDisplay;

	int price;
	int materials;

	public string hexLocName;
	public GameObject hexLocation;

	GameObject buildPanel;

	UIManager uimanager;

	void Start ()
	{

		buildPanel = GameObject.FindGameObjectWithTag ("_buildPanel");
		icon.sprite = this_Building.GetComponent<BuildingObjectInfo>().icon; 
		description.text = this_Building.GetComponent<BuildingObjectInfo>().description;

		price = this_Building.GetComponent<BuildingObjectInfo> ().price;
		materials = this_Building.GetComponent<BuildingObjectInfo> ().materials;
		priceDisplay.text = "Gold: " + price + " " + "Materials: " + materials;

		uimanager = GameObject.FindGameObjectWithTag("Canvas").GetComponent<UIManager>();

		hexLocName = buildPanel.GetComponent<UI_Building> ().hexSelected;
		hexLocation = GameObject.Find (hexLocName);

	}

	public void BuildOnClick ()
	{

		Building ();

	}
 
	void Building ()
	{

		Debug.Log (StatsManager.gold);

		if (StatsManager.gold - price >= 0 && StatsManager.materials - materials >= 0) 
		{
			
			StatsManager.gold = (StatsManager.gold - price);
			StatsManager.materials = (StatsManager.materials - materials);

			GameObject building = (GameObject)Instantiate (this_Building, hexLocation.transform.position, hexLocation.transform.rotation);

			building.transform.SetParent (GameObject.Find (hexLocName).transform, false);
			building.transform.localPosition = Vector3.zero;

			Node node;
			node = hexLocation.GetComponentInChildren<Node> ();

			node.builtBuilding = this_Building.gameObject;

			Destroy (GameObject.FindGameObjectWithTag ("_buildPanel"));
			uimanager.panelActive = false;

			StatsManager.shipStorage = (StatsManager.shipStorage + building.GetComponent<Hanger> ().shipStorageCountToADD);

		}

	}

}
