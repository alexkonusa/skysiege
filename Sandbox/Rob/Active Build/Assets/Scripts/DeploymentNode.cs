using UnityEngine;
using System.Collections;

public class DeploymentNode : MonoBehaviour
{

    public GameObject shipDeployed;

    BuildManager buildManager;

	// Use this for initialization
	void Start ()
    {

        buildManager = GameObject.Find("GameManagers").GetComponent<BuildManager>();

    }
	
	void OnMouseDown ()
    {

        if (shipDeployed == null)
        {
            if (buildManager.currentObject)
            {
                GameObject _shipDeployed = (GameObject)Instantiate(buildManager.currentObject, transform.position, transform.rotation);

                buildManager.currentObject = null;

                _shipDeployed.transform.SetParent(this.gameObject.transform, false);
                _shipDeployed.transform.localPosition = Vector3.zero;
            }

        }
	
	}
}
