using UnityEngine;
using System.Collections;

public class AlertList : MonoBehaviour 
{

	public string[] alertDataBase;


	// Use this for initialization
	void Start () 
	{
		alertDataBase = new string[2];

		alertDataBase[0] = "You Can't Build Here";
		alertDataBase[1] = "FUCK OFF";


	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
}
