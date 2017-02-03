using UnityEngine;
using System.Collections;

public class Grid : MonoBehaviour 
{

	public Color mouseOverColor;
	public GameObject currBuiltObject;
	GameObject buildObject;

	Renderer _renderer;
	BuildManager buildManager;
	private Color gridStartColor;

	// Use this for initialization
	void Start () 
	{

		_renderer = GetComponent<Renderer> ();
		buildManager = GameObject.Find ("GameManagers").GetComponent<BuildManager> ();
		gridStartColor = _renderer.material.color;
	
	}

	void OnMouseDown ()
	{

		if (currBuiltObject == null) {

			Debug.Log ("It cant be built");
			buildObject = buildManager.currentObject;
			Instantiate(buildObject, transform.position, transform.rotation);
			currBuiltObject = buildObject;
			return;

		} 
		else 
		{

			Debug.Log ("UPS YOU CAN'T FUCKING BUILD HERE");

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
