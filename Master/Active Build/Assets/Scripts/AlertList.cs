using UnityEngine;
using System.Collections;

public class AlertList : MonoBehaviour 
{

	public string[] alertDataBase;


	// Use this for initialization
	void Start () 
	{
		alertDataBase = new string[3];

		alertDataBase[0] = "You Can't Build Here";
		alertDataBase[1] = "Ship Has Been Built!";
		alertDataBase[2] = "Please Select A ship to Deploy";


	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
}
