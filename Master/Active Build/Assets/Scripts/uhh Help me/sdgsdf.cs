using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//Test script [adding items to the inventory]

public class sdgsdf : MonoBehaviour 
{

	Inventory _inventory;

	public GameObject itemModel;
	public Sprite itemIcon;

	// Use this for initialization
	void Start () 
	{

		_inventory = GameObject.Find ("Inventory").GetComponent<Inventory> ();

		Inventory.ItemStructure item = new Inventory.ItemStructure
		{
			ID = 1, 
			Name = "Jipsy", 
			Type = "Cunt", 
			itemModel = Resources.Load<GameObject>("Prefabs/Cube1"), 
			itemIcon = Resources.Load<Sprite>("Assets/Inventory/Item_Icons/item_01"), 
			isStacable = true
		};

		Inventory.ItemStructure item1 = new Inventory.ItemStructure
		{
			ID = 2, 
			Name = "sdfgsdfg", 
			Type = "Cusdgfsdfnt", 
			itemModel = Resources.Load<GameObject>("Prefabs/Cube1"), 
			itemIcon = Resources.Load<Sprite>("Assets/Inventory/Item_Icons/item_02"), 
			isStacable = true
		};

		_inventory.inventory.Add (item);
		_inventory.inventory.Add (item1);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
		
}
