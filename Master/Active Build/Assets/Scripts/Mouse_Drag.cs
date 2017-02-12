using UnityEngine;
using System.Collections;

public class Mouse_Drag : MonoBehaviour {

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	void OnMouseEnter ()
	{

			this.transform.position = Input.mousePosition;

	}
}
