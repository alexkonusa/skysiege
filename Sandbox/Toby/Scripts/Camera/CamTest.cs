using UnityEngine;
using System.Collections;

public class CamTest : MonoBehaviour
{

    public float speed = 5.0f;
    public float distance = 30f;
    public float maxDist = 30f;
    public float minDist = 5f;
    public float zoomRate = 40;
    public float zoomSoft = 5f;
    public float currentDist;
    public float desiredDist;

    public int yMinLimit = 5;
    public int yMaxLimit = 90;

    public Transform target;

    private Vector3 position;

    void Start()
    {
        distance = Vector3.Distance(transform.position, target.position);
        currentDist = distance;
        desiredDist = distance;

        position = transform.position;

    }


    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            transform.LookAt(target);
            transform.RotateAround(target.position, Vector3.up, Input.GetAxis("Mouse X") * speed);
        }
        
        desiredDist -= Input.GetAxis("Mouse ScrollWheel") * Time.deltaTime * zoomRate * Mathf.Abs(desiredDist);





        desiredDist = Mathf.Clamp(desiredDist, minDist, maxDist);


    }
}