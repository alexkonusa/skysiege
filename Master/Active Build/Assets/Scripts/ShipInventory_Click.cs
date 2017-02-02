using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ShipInventory_Click : MonoBehaviour 
{

	public int id = 1;
	public int avalible_Ships = 1;
	public Text avalibleShip_Display;

	GameObject objectsParent;
	// Use this for initialization
	void Start () 
	{

		this.gameObject.name = "Ship_" + id;

	}

	// Update is called once per frame
	void Update () 
	{

		avalibleShip_Display.text = "" + avalible_Ships;
	
	}

	public void OnMouseClick()
	{

		if (avalible_Ships > 0) {

				Debug.Log ("You have ships");
				avalible_Ships -- ;

			} 
			else 
			{

				Debug.Log ("You Don't have any ships");
			this.gameObject.SetActive (false);
			}
	}
}
