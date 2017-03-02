using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Inventory : MonoBehaviour 
{
	//Item structure
	public struct ItemStructure
	{

		public int ID;
		public string Name;
		public string Type;
		public GameObject itemModel;
		public Sprite itemIcon;
		public bool isStacable;

	}

	//Creating our list to store our items
	public List<ItemStructure> inventory = new List<ItemStructure>();

	//Get Item by it's Id, looks though the list and if found will returnt the information.
	public ItemStructure getItemByID (int id)
	{
		for (int i = 0; i < inventory.Count; i++)
		{
			if (inventory [i].ID == id) 
			{

				return inventory [i];

			}
		}
		return inventory [0];
	}
		
	
	// Update is called once per frame
	void Update () 
	{

		Debug.Log (inventory[0].ID + inventory[0].Name + inventory [0].Type + inventory [0].itemModel + inventory [0].itemIcon + inventory [0].isStacable);
		Debug.Log (inventory[1].ID + inventory[1].Name + inventory [1].Type + inventory [1].itemModel + inventory [1].itemIcon + inventory [1].isStacable);
		Debug.Log (getItemByID (2).Name);
	
	}
}
