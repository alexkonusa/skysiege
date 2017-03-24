using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ReCall_HealPanel : MonoBehaviour
{

    public static GameObject selectedShip;
    public Button reCall;
    public Button Repair;
    public int repairCost = 100;
    public Text repairCostText;

    UIManager uimanager;
	// Use this for initialization
	void Start ()
    {

        uimanager = GameObject.FindGameObjectWithTag("Canvas").GetComponent<UIManager>();

        repairCostText.text = "Repair Cost: " + repairCost + "Gold";

    }

    // Update is called once per frame
    void Update()
    {

        if (selectedShip.GetComponent<AI_Ally>().health == 100)
        {
            reCall.interactable = true;
        }
        else
        {

            reCall.interactable = false;

        }


        if (selectedShip.GetComponent<AI_Ally>().health < selectedShip.GetComponent<AI_Ally>().maxHealth)
        {
            Repair.interactable = true;
        }
        else
        {

            Repair.interactable = false;

        }
    }

    public void RepairShip()
    {

        selectedShip.GetComponent<AI_Ally>().health = selectedShip.GetComponent<AI_Ally>().maxHealth;
        StatsManager.gold -= repairCost;

    }

    public void ReCallShip()
    {

            reCall.interactable = true;
            CloseButton();
            GameObject tesst = selectedShip.GetComponent<ShipParameters>().invSlot;
            tesst.GetComponent<ShipInventory_Click>().avalible_Ships++;
            Destroy(selectedShip);

    }

    public void CloseButton()
    {
        Destroy(GameObject.FindGameObjectWithTag("_RepairPanel"));
        uimanager.panelActive = false;

    }
}
