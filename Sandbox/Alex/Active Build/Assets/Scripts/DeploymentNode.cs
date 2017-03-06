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
            if (buildManager.allyShip)
            {
                GameObject _shipDeployed = (GameObject)Instantiate(buildManager.allyShip, transform.position, transform.rotation);

                buildManager.allyShip = null;

                _shipDeployed.transform.SetParent(this.gameObject.transform, false);
                _shipDeployed.transform.localPosition = Vector3.zero;
            }

        }
	
	}
}
