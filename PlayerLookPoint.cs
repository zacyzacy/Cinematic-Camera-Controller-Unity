//Author: Zac Youngdale
using UnityEngine;
using System.Collections;

public class PlayerLookPoint : CameraPointObject
{
    //where the player will look when execute is called
    private CameraPointObject playersnap;
    void OnEnable()
    {
        playersnap = transform.parent.GetComponentInChildren<PlayerSnapPoint>();
    }
    void Update()
    {
        if (transform.position.y != playersnap.transform.position.y)
        {
            transform.position = new Vector3(transform.position.x, playersnap.transform.position.y, transform.position.z);
        }
    }
}
