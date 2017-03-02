using UnityEngine;
using System.Collections;

public class Armory : MonoBehaviour 
{

	public GameObject armoryPanel;

	UIManager uimanager;

	void Start()
	{

		uimanager = GameObject.FindGameObjectWithTag("Canvas").GetComponent<UIManager>();

	}

	void OnMouseDown()
	{

		GameObject _armoryPanel = (GameObject)Instantiate(armoryPanel, 
			transform.position, transform.rotation);

		_armoryPanel.transform.SetParent 
		(GameObject.FindGameObjectWithTag ("Canvas").transform, false);

		uimanager.buildingPanelActive = true;


	}

}
