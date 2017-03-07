using UnityEngine;
using System.Collections;

public class AI_Ally : MonoBehaviour
{

    public float health;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {

        if (health <= 0)
        {

            Destroy(gameObject);

        }
	
	}
}
