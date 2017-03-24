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
    public int pointsToAdd = 512;

	int price;
	int materials;

	public string hexLocName;
	public GameObject hexLocation;

	GameObject buildPanel;
    Renderer rend;
	UIManager uimanager;

	void Start ()
	{

		buildPanel = GameObject.FindGameObjectWithTag ("_buildPanel");
		icon.sprite = this_Building.GetComponent<BuildingObjectInfo>().icon; 
		description.text = this_Building.GetComponent<BuildingObjectInfo>().description;

		price = this_Building.GetComponent<BuildingObjectInfo> ().price;
		materials = this_Building.GetComponent<BuildingObjectInfo> ().materials;
		priceDisplay.text = "Gold: " + price + " " + "Materials: " + materials;

        rend = GetComponent<Renderer>();

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
			//Costs and stuff
			StatsManager.gold = (StatsManager.gold - price);
			StatsManager.materials = (StatsManager.materials - materials);
            PointsManager.AddPoints(pointsToAdd);

            //Disable our hex renderer so that the armory is visible
            Transform hexChildToDis = hexLocation.transform.GetChild(1);
            rend = hexChildToDis.GetComponent<Renderer>();
            rend.enabled = false;

            //Instantiate our Building 
             GameObject building = (GameObject)Instantiate(this_Building, hexLocation.transform.position, hexLocation.transform.rotation);

            //Set the parent and local position
            building.transform.SetParent(GameObject.Find(hexLocName).transform, false);
            building.transform.localPosition = Vector3.zero;

            Node node;
            node = hexLocation.GetComponentInChildren<Node>();

            node.builtBuilding = this_Building.gameObject;

            //close our panel;
            Destroy(GameObject.FindGameObjectWithTag("_buildPanel"));
            uimanager.panelActive = false;

        }

	}

   

}
