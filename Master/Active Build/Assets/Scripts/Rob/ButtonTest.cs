using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ButtonTest : MonoBehaviour {
	
	// Use this for initialization
	void Awake () {

		var btn = gameObject.GetComponent<Button>();
		var ASD = GameObject.Find ("GameManagers").GetComponent<ButtonSkippy> ();
		btn.onClick.AddListener (delegate {ASD.SkipWait();});

	}

}
