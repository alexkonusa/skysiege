using UnityEngine;
using System.Collections;

public class Alert_Settings : MonoBehaviour {

	// Use this for initialization
	void Start () 
	{

		StartCoroutine(DestroyAlert());
	
	}

	IEnumerator DestroyAlert()
	{

		yield return new WaitForSeconds(1.5f);
		Destroy(gameObject);

	}
}
