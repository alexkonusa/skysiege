using UnityEngine;
using System.Collections;

public class Camera : MonoBehaviour {

    public Transform target;
    public float distance = 5;
    public float cameraAngle = 60;
    public float rotationSpeed = 1;
    float x;

    void LateUpdate()
    {
        //When right clicked rotate our camera
        if (Input.GetMouseButton(1))
        {

            //x will either return a possitive or negative number 
            //which will be applied to our camera rotation property
            x += Input.GetAxis("Mouse X") * rotationSpeed;
            transform.rotation = Quaternion.Euler(cameraAngle, x, 0);

        }

        //Rotation around our target while keeping the same distance
        Vector3 targetPosition = target.position - (transform.rotation * Vector3.forward * distance);
        transform.position = targetPosition;
    }
}
