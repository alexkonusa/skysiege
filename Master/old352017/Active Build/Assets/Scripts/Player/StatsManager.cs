using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StatsManager : MonoBehaviour 
{

	//Resources
	public static int materials = 9999;
	public static int gold = 9999;

	//Extras
	public static int shipStorage;


	public Text goldDisplay;
	public Text materialDisplay;
	public Text shipStoraDisplay;


	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{

		DisplayStats ();
	
	}

	void DisplayStats()
	{
		goldDisplay.text = "Gold: " + gold;
		materialDisplay.text = "Materials: " + materials;
		shipStoraDisplay.text = "Ship Storage: " + shipStorage;

	}
}
