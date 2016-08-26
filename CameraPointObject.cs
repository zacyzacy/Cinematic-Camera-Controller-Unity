//Author: Zac Youngdale
using UnityEngine;
using System.Collections;

public class CameraPointObject : MonoBehaviour
{
    //a point for the camera to be at
    public bool execute;
    void Start()
    {
        GetComponent<MeshRenderer>().enabled = false;
    }
    public virtual void Execute()
    {
        execute = true;
    }
    public virtual void Stop()
    {
        execute = false;
    }
}
