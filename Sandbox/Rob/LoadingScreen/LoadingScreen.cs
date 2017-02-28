using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingScreen : MonoBehaviour {

	public float countdown = 10f;
	public string LevelToLoad;

	public GameObject LoadingIcon;


	// Use this for initialization
	void Awake () {

		countdown = 10f;
	
	}
	
	// Update is called once per frame
	void Update () {

		countdown -= Time.deltaTime;

		if (countdown <= 0) {

			SceneManager.LoadScene (LevelToLoad, LoadSceneMode.Single);

		} else {

			LoadingIcon.transform.Rotate(new Vector3(0,0,1));

		}
	
	}
}
