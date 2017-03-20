using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Hub : MonoBehaviour
{

    public static float hubHealth = 100.0f;
    public float hubMaxHealth;
    public Transform healthBar;

	// Use this for initialization
	void Start ()
    {

        hubMaxHealth = hubHealth;


    }
	
	// Update is called once per frame
	void Update ()
    {

        HealthBarRotation(); //meh tis is cool 
        HubHealth(); //this is bad

    }

    void HubHealth()
    {

        Transform healthImageTrans = healthBar.GetChild(0);
        Image healthImage = healthImageTrans.GetComponent<Image>();

        healthImage.fillAmount = hubHealth / hubMaxHealth;

    }

    //Rotating our health bar to always face the camera 
    void HealthBarRotation()
    {

        healthBar.transform.rotation = Quaternion.LookRotation
            (GameObject.FindGameObjectWithTag("MainCamera").transform.position - transform.position);

    }
}
