﻿using UnityEngine;
using System.Collections;

public class Mouse_Drag : MonoBehaviour {

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		this.transform.position = Input.mousePosition;
	}

	void OnMouseDown()
	{
		//this.transform.position = Input.mousePosition;

	}

}
