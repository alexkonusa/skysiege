using UnityEngine;
using System.Collections;

public class CameraRotationUI : MonoBehaviour
{

	// Update is called once per frame
	void Update ()
    {
        transform.Rotate(0, Time.deltaTime, 0, Space.World);
	}
}
