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

	void Start ()
	{

		icon.sprite = this_Building.GetComponent<Hanger>().icon;
		description.text = this_Building.GetComponent<Hanger>().description;

	}

}
