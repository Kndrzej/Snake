using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenWrapper : MonoBehaviour
{
    float leftConstraint = Screen.width;
    float rightConstraint = Screen.width;
    float bottom = Screen.height;
    float top = Screen.height;
    float buffer = 1.0f;
    Camera cam;
    float distanceZ;

    private void Start()
    {
        cam = Camera.main;
        distanceZ = Mathf.Abs(cam.transform.position.z + transform.position.z);
        leftConstraint = cam.ScreenToWorldPoint(new Vector3(0.0f, 0.0f, distanceZ)).x;
        rightConstraint = cam.ScreenToWorldPoint(new Vector3(0.0f, 0.0f, distanceZ)).x;
        bottom = cam.ScreenToWorldPoint(new Vector3(0.0f, 0.0f, distanceZ)).y;
        top = cam.ScreenToWorldPoint(new Vector3(0.0f, 0.0f, distanceZ)).y;
    }
    private void FixedUpdate()
    {
        if (transform.position.x < leftConstraint - buffer) transform.position = new Vector3(rightConstraint - 0.10f, transform.position.y, transform.position.z);
        if (transform.position.x > rightConstraint) transform.position = new Vector3(rightConstraint, transform.position.y, transform.position.z);
        if (transform.position.x < bottom - buffer) transform.position = new Vector3(transform.position.x,top+buffer,transform.position.z);
        if (transform.position.x > top + buffer) transform.position = new Vector3(transform.position.x, bottom - buffer, transform.position.z);
    }
}
