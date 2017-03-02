using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Alert_Manager : MonoBehaviour 
{

	public GameObject alertPanel;
	public Transform canvas;
	public Transform parentPanel;
	public Text alertString;


	AlertList alertList;
	// Use this for initialization
	void Start () 
	{

		alertList = GameObject.Find("GameManagers").GetComponent<AlertList>();

	
	}

	public void FetchAlertText(int  idToFetch)
	{

		string textToDisplay = alertList.alertDataBase[idToFetch];

		alertString.text = textToDisplay;

		InstantiateAlertPanel(true);

	}

	void InstantiateAlertPanel(bool activate)
	{

		if (activate == true) 
		{

			GameObject goodAlertBox = Instantiate (alertPanel, transform.position, transform.rotation) as GameObject;
			goodAlertBox.transform.SetParent (parentPanel, false);


		}	

	}
}
