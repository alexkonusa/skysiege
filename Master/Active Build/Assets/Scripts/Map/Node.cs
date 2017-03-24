using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour, IPointerClickHandler
{

	public Material startMat;
	public Material highlightedMat;

	public GameObject buildPanel;
	public GameObject builtBuilding;

	string parentName;

	UIManager uimanager;
	Renderer rend;

	void Start ()
	{
		parentName = transform.parent.name;
		rend = GetComponent<MeshRenderer>();
		uimanager = GameObject.FindGameObjectWithTag("Canvas").GetComponent<UIManager>();

		GetComponentInParent<_HexInfo> ().hexObjectName = this.gameObject.name;
	}

    public void OnPointerClick(PointerEventData eventData)
    {


        BuildPanelDraw();


    }

	void OnMouseEnter ()
	{

		Material[] objMaterials = rend.GetComponent<MeshRenderer>().materials;
		objMaterials[0] = highlightedMat;
		rend.GetComponent<MeshRenderer>().materials = objMaterials;

	}

	void OnMouseExit ()
	{

		Material[] objMaterials = rend.GetComponent<MeshRenderer>().materials;
		objMaterials[0] = startMat;
		rend.GetComponent<MeshRenderer>().materials = objMaterials;

		if (builtBuilding != null) {
			Debug.Log (builtBuilding.name + parentName);
		}

	}

	void BuildPanelDraw()
	{

		if (uimanager.panelActive == false && builtBuilding == null) 
		{

				GameObject BuildPanel = (GameObject)Instantiate (buildPanel, transform.position, transform.rotation);

				BuildPanel.transform.SetParent (GameObject.FindGameObjectWithTag ("Canvas").transform, false);

				uimanager.panelActive = true;

				BuildPanel.GetComponent<UI_Building> ().hexSelected = parentName;

		}

		Debug.Log ("Its not working");

	}

}
