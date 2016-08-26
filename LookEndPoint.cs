//Author: Zac Youngdale
using UnityEngine;
using System.Collections;

public class LookEndPoint : CameraPointObject
{
    //a point fo the camera to look at
    private Camera cam;
    void OnEnable()
    {
        cam = FindObjectOfType<Camera>();
    }
    void FixedUpdate()
    {
        if (execute == true)
        {
            cam.transform.LookAt(transform.position);
        }
    }
}
