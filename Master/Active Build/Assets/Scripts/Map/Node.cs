using UnityEngine;
using System.Collections;

public class Node : MonoBehaviour 
{

	public Material startMat;
	public Material highlightedMat;

	Renderer rend;

	void Start ()
	{

		rend = GetComponent<MeshRenderer>();

	}

	void OnMouseEnter ()
	{

		Material[] objMaterials = rend.GetComponent<MeshRenderer>().materials;
		objMaterials[1] = highlightedMat;
		rend.GetComponent<MeshRenderer>().materials = objMaterials;

	}

	void OnMouseExit ()
	{

		Material[] objMaterials = rend.GetComponent<MeshRenderer>().materials;
		objMaterials[1] = startMat;
		rend.GetComponent<MeshRenderer>().materials = objMaterials;

	}


}
