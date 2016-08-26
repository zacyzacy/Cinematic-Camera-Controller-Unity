//Author: Zac Youngdale
using UnityEngine;
using System.Collections;

public class LookStartPoint : CameraPointObject
{
    //a point for the camera to look at
    private CameraPointObject end;
    private float speed;
    void OnEnable()
    {
        end = transform.parent.GetComponentInChildren<LookEndPoint>();
        //speed = transform.parent.GetComponent<ManualCameraObject>().lookSpeed;
    }
    void FixedUpdate()
    {
        if (execute == true)
        {
            transform.position = Vector3.Lerp(transform.position, end.transform.position, speed * Time.deltaTime);
        }
    }
}
