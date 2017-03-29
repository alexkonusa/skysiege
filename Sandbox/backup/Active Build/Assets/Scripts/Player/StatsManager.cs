using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StatsManager : MonoBehaviour 
{

	//Resources
	public static int materials = 10000;
	public static int gold = 10000;

	//Extras
	public static int shipStorage;
    static int maxShipStorage;
    static public int currentBuiltShips;
    public static int playerPoints;

	public Text goldDisplay;
	public Text materialDisplay;
	public Text shipStoraDisplay;
    public Text playerPointDisplay;

	
	// Update is called once per frame
	void FixedUpdate () 
	{

		DisplayStats ();

    }

	void DisplayStats()
	{
		goldDisplay.text = "" + gold;
		materialDisplay.text = "" + materials;
		shipStoraDisplay.text = "" + shipStorage + "/" + maxShipStorage;
        playerPointDisplay.text = "Score: " + playerPoints;

    }

    public static void AvalibleStorage(int avalibleStorage)
    {
        shipStorage = (shipStorage + avalibleStorage);
        maxShipStorage += avalibleStorage;
    }
}
