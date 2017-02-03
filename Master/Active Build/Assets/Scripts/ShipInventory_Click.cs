using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ShipInventory_Click : MonoBehaviour 
{

	public int ID = 1;
	public int avalible_Ships = 1;
	public Text avalibleShip_Display;
	public Button slotButton;
	public GameObject shipPrefab;

	GameObject objectsParent;

	BuildManager buildManager;
	// Use this for initialization
	void Start () 
	{

		this.gameObject.name = "Ship_" + ID;
		buildManager = GameObject.Find ("GameManagers").GetComponent<BuildManager> ();
	}

	// Update is called once per frame
	void Update () 
	{

		avalibleShip_Display.text = "" + avalible_Ships;

		if (avalible_Ships > 0) 
		{

			slotButton.interactable = true;

		}
	
	}

	public void OnMouseClick()
	{

		if (avalible_Ships > 0) 
		{
			
			Debug.Log ("You have ships");
			avalible_Ships -- ;
			buildManager.currentObject = shipPrefab;

			if (avalible_Ships == 0) {
				Debug.Log ("You Don't have any ships");
				slotButton.interactable = false;

			}


		}
	}
}
