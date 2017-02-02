using UnityEngine;
using System.Collections;

public class Grid : MonoBehaviour 
{

	public Color mouseOverColor;
	public GameObject currBuiltObject;

	Renderer _renderer;
	private Color gridStartColor;

	// Use this for initialization
	void Start () 
	{

		_renderer = GetComponent<Renderer> ();
		gridStartColor = _renderer.material.color;
	
	}

	void OnMouseDown ()
	{

		if (currBuiltObject == null) {

			Debug.Log ("It cant be built");
			return;

		} 
		else 
		{

			//Deploy the ship

		}
	
	}

	void OnMouseEnter ()
	{

		_renderer.material.color = mouseOverColor;
			
	}

	void OnMouseExit ()
	{

		_renderer.material.color = gridStartColor;

	}
}
