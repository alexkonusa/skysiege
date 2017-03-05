using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadingScene : MonoBehaviour {

	public string LevelName;
	AsyncOperation async;
	public float countdown = 3f;

	bool ButtonClicked = false;

	public GameObject ScreenCover;

	void StartLoading () {
		if (ButtonClicked == false) {
			StartCoroutine ("Load");
			ScreenCover.SetActive (true);
			ButtonClicked = true;
		}

	}

	void Update () {

		if (ButtonClicked == true) {		

			countdown -= Time.deltaTime;
			if (countdown <= 0) {

				async.allowSceneActivation = true;

			}
		}

	}

	IEnumerator Load () {

		Debug.LogWarning ("ASYNC STARTED - DON'T EXIT");
	
		async = SceneManager.LoadSceneAsync (LevelName);
		async.allowSceneActivation = false;
		ButtonClicked = true;
		yield return async;


	}

	public void ActivateScene () {

		async.allowSceneActivation = true;

	}

}
