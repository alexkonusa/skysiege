using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BuildManager : MonoBehaviour
{

	//This variable contained the current object that we can place down / deploy.
	public GameObject allyShip;
    public Material normalMat;

    //This is where we will store our avalible hexs
    public List<GameObject> avalibleHexs = new List<GameObject>(); 

    Grid_Spawner grid_Spawner;

    void Start()
    {

        grid_Spawner = GameObject.Find("Map").GetComponent<Grid_Spawner>();

        StartCoroutine(timer(5f));

    }

    //Call this to get the hexs that can be built on
    public void GetOurAvalibleHexs()
    {
        for (int i = 0; i < grid_Spawner.hexLayerTwo.Count; i++)
        {

            GameObject currHex = grid_Spawner.hexLayerTwo[i];

            if (currHex.transform.GetChild(1).GetComponent<DeploymentNode>().shipDeployed == null)
            {

                avalibleHexs.Add(currHex.gameObject);

            }
        }
    }


    //Call this function to change the materials of the object
    public void ChangeOurHexMaterial(Material objMat)
    {

        foreach (GameObject AvalibleHexs in avalibleHexs)
        {

            GameObject test = AvalibleHexs.transform.GetChild(1).gameObject;


            Renderer rend;
            rend = test.transform.GetChild(0).GetComponent<MeshRenderer>();

            Material[] objMaterials = rend.materials;
            objMaterials[0] = objMat;
            rend.materials = objMaterials;

        }
    }

    IEnumerator timer(float time)
    {

        yield return new WaitForSeconds(time);
        GetOurAvalibleHexs();

    }
}
