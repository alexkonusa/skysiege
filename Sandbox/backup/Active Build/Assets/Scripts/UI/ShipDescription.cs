using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ShipDescription : MonoBehaviour
{

    public Text shipName;
    public Text shipLevel;
    public Text shipHealth;
    public Text shipDmg;
    public Text shipFireRate;

    public static GameObject ourShipInfo;

    // Use this for initialization
    void Start ()
    {

        shipName.text = ourShipInfo.GetComponent<AI_Ally>().shipName;
        shipLevel.text = "Level: " + ourShipInfo.GetComponent<AI_Ally>().aiShipLevel;
        shipHealth.text = "Health: " + ourShipInfo.GetComponent<AI_Ally>().health;
        shipDmg.text = "Damage: " + ourShipInfo.GetComponent<AI_Ally>().enemyDamage;
        shipFireRate.text = "Fire Rate: " + ourShipInfo.GetComponent<AI_Ally>().fireRate;

    }


	
	// Update is called once per frame
	void Update () {
	
	}
}
