//Author: Zac Youngdale
using UnityEngine;
using System.Collections;

public class MoveStartPoint : CameraPointObject
{
    //point that lerps for the camera to move along
    private CameraPointObject end;
    private float speed;
    private Camera cam;
    void OnEnable()
    {
        end = transform.parent.GetComponentInChildren<MoveEndPoint>();
        cam = FindObjectOfType<Camera>();
        //speed = transform.parent.GetComponent<ManualCameraObject>().movespeed;
    }
    public override void Execute()
    {
        base.Execute();
        cam.transform.position = transform.position;
    }
    void FixedUpdate()
    {
        if (execute == true)
        {
            transform.position = Vector3.Lerp(transform.position, end.transform.position, speed * Time.deltaTime);
            cam.transform.position = transform.position;        
        }
    }

}
