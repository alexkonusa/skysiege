﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ShipInventory_Click : MonoBehaviour 
{
	//Public Variables
	public int ID = 1;
	public int avalible_Ships = 0;
	public Text avalibleShip_Display;
	public Button slotButton;
	public GameObject shipPrefab;

	//Private Variables
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
		//Updating the text prefab with the amount of ships we have avalible. 
		avalibleShip_Display.text = "" + avalible_Ships;

		//Running the UpdateShipAvalibleNumber function.
		UpdateShipAvalibleNumber (0);
	
	}

	//When we click the slot if we have ships we can deploy them.
	public void OnMouseClick()
	{

		if (avalible_Ships > 0) 
		{
			
			Debug.Log ("You have ships");
			avalible_Ships -- ;
			buildManager.currentObject = shipPrefab;

			if (avalible_Ships == 0) 
				
			{

				Debug.Log ("You Don't have any ships");
				slotButton.interactable = false;

			}


		}
	}

	//If we have ships. Button becomes avalible.
	public void UpdateShipAvalibleNumber (int shipCounterValue)
	{

		avalible_Ships += shipCounterValue;

		if (avalible_Ships > 0) 
		{

			slotButton.interactable = true;
		
		}

	}
}
