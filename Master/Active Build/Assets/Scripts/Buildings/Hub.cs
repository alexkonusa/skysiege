using UnityEngine;
using System.Collections;

public class Hub : MonoBehaviour
{

    public static float hubHealth = 100.0f;
    public Transform healthBar;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        HealthBarRotation();


    }

    //Rotating our health bar to always face the camera 
    void HealthBarRotation()
    {

        healthBar.transform.rotation = Quaternion.LookRotation
            (GameObject.FindGameObjectWithTag("MainCamera").transform.position - transform.position);

    }
}
