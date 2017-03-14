using UnityEngine;
using System.Collections;

public class DeploymentNode : MonoBehaviour
{

    public GameObject shipDeployed;
    public Material normalHexMat1;

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

                //Now change the color of our avalible hexs back to normal
                buildManager.ChangeOurHexMaterial(normalHexMat1);
                buildManager.avalibleHexs.Clear();


                shipDeployed = _shipDeployed;

                buildManager.allyShip = null;

                _shipDeployed.transform.SetParent(this.gameObject.transform, false);
                _shipDeployed.transform.localPosition = Vector3.zero;
            }

        }
	
	}
}
