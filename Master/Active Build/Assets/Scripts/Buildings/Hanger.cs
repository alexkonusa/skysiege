using UnityEngine;
using System.Collections;

public class Hanger : MonoBehaviour 
{

	public int shipStorageCountToADD = 5; // Number of ship storage to add

	// Use this for initialization
	void Start () 
	{

        StatsManager.AvalibleStorage(5);
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
