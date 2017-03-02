using UnityEngine;
using System.Collections;

public class Node : MonoBehaviour 
{

	public Material startMat;
	public Material highlightedMat;

	public GameObject buildPanel;
	public static GameObject builtBuilding;

	string parentName;

	UIManager uimanager;
	Renderer rend;

	void Start ()
	{
		parentName = transform.parent.name;
		rend = GetComponent<MeshRenderer>();
		uimanager = GameObject.FindGameObjectWithTag("Canvas").GetComponent<UIManager>();
	}

	void OnMouseDown ()
	{

		BuildPanelDraw();

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

	void BuildPanelDraw()
	{

		if (builtBuilding == null && uimanager.buildingPanelActive == false)
		{
			GameObject BuildPanel = (GameObject)Instantiate(buildPanel, transform.position, transform.rotation) as GameObject;

			BuildPanel.transform.SetParent( GameObject.FindGameObjectWithTag("Canvas").transform, false);

			uimanager.buildingPanelActive = true;

			BuildPanel.GetComponent<UI_Building>().hexSelected = parentName;

		}

	}

	void BuildFunction ()
	{



	}

}
