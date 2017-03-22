using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StatsManager : MonoBehaviour 
{

	//Resources
	public static int materials = 1000;
	public static int gold = 200;

	//Extras
	public static int shipStorage;
    static public int currentBuiltShips;

	public Text goldDisplay;
	public Text materialDisplay;
	public Text shipStoraDisplay;
	
	// Update is called once per frame
	void FixedUpdate () 
	{

		DisplayStats ();

    }

	void DisplayStats()
	{
		goldDisplay.text = "" + gold;
		materialDisplay.text = "" + materials;
		shipStoraDisplay.text = "" + shipStorage;

	}

    public static void AvalibleStorage(int avalibleStorage)
    {
        shipStorage = (shipStorage + avalibleStorage);
    }
}
