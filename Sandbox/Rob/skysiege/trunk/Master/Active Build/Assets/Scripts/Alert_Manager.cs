using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Alert_Manager : MonoBehaviour 
{

	public GameObject alertPanel;
	public Transform canvas;

	public Text alertString;

	AlertList alertList;
	// Use this for initialization
	void Start () 
	{

		alertList = GameObject.Find("GameManagers").GetComponent<AlertList>();
		

	
	}
	
	// Update is called once per frame
	void Update () 
	{

		FetchAlertText(1);
	
	}

	void FetchAlertText(int  idToFetch)
	{
		InstantiateAlertPanel(true);

		string textToDisplay = alertList.alertDataBase[idToFetch];

		alertString.text = textToDisplay;

	}

	void InstantiateAlertPanel(bool activate)
	{

		if (activate == true) 
		{

			GameObject goodAlertBox = Instantiate (alertPanel, transform.position, transform.rotation) as GameObject;
			goodAlertBox.transform.SetParent (canvas, true);


		}

	}
}
