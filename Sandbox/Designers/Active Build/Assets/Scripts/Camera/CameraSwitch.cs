using UnityEngine;
using System.Collections;

public class CameraSwitch : MonoBehaviour
{

    public Camera groundCamera;
    public Camera topCamera;
    
	void Start ()
    {
        groundCamera.enabled = true;
        topCamera.enabled = false;
	}
	
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            groundCamera.enabled = !groundCamera.enabled;
            topCamera.enabled = !topCamera.enabled;
        }
	}
}
