﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UI_ArmortSlot : MonoBehaviour
{

    public GameObject thisShip;

    public Image icon;
    public Text description;
    public int pointsToGive = 256;

    int price;
    int materials;

    SoundManager soundManager;
    public AudioClip soundClip;
	// Use this for initialization
	void Start ()
    {

        icon.sprite = thisShip.GetComponent<BuildingObjectInfo>().icon;
        description.text = thisShip.GetComponent<BuildingObjectInfo>().description;
        soundManager = GetComponent<SoundManager>();
        price = thisShip.GetComponent<BuildingObjectInfo>().price;
        materials = thisShip.GetComponent<BuildingObjectInfo>().materials;

    }

    public void ShipConstruction()
    {

        soundManager.PlaySound(soundClip);
        //check if we have enough gold and materials to construct the ship
        if (StatsManager.gold - price >= 0 && StatsManager.materials - materials >= 0)
        {
            if (StatsManager.shipStorage - 1 >= 0)
            {

                StatsManager.shipStorage--;
                //costs
                StatsManager.gold = (StatsManager.gold - price);
                StatsManager.materials = (StatsManager.materials - materials);
                PointsManager.AddPoints(pointsToGive);

                //add 1 ship to the inv slot count
                int addships = 1;
                //Get the obejcts inventory slot and add 1 onto the slip.
                GameObject invSlot = thisShip.GetComponent<ShipParameters>().invSlot;
                invSlot.GetComponent<ShipInventory_Click>().avalible_Ships = (invSlot.GetComponent<ShipInventory_Click>().avalible_Ships + addships);
            }
        }

    }
	
}
