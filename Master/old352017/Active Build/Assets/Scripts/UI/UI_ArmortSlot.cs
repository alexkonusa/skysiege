using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UI_ArmortSlot : MonoBehaviour
{

    public GameObject thisShip;

    public Image icon;
    public Text description;

    int price;
    int materials;

	// Use this for initialization
	void Start ()
    {

        icon.sprite = thisShip.GetComponent<BuildingObjectInfo>().icon;
        description.text = thisShip.GetComponent<BuildingObjectInfo>().description;

        price = thisShip.GetComponent<BuildingObjectInfo>().price;
        materials = thisShip.GetComponent<BuildingObjectInfo>().materials;

    }

    public void ShipConstruction()
    {
        //check if we have enough gold and materials to construct the ship
        if (StatsManager.gold - price >= 0 && StatsManager.materials - materials >= 0)
        {
            //costs
            StatsManager.gold = (StatsManager.gold - price);
            StatsManager.materials = (StatsManager.materials - materials);

            //add 1 ship to the inv slot count
            int addships = 1;
            //Get the obejcts inventory slot and add 1 onto the slip.
            GameObject invSlot = thisShip.GetComponent<ShipParameters>().invSlot;
            invSlot.GetComponent<ShipInventory_Click>().avalible_Ships = (invSlot.GetComponent<ShipInventory_Click>().avalible_Ships + addships);
        }

    }
	
}
