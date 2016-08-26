//Author: Zac Youngdale
using UnityEngine;
using System.Collections;

public class PlayerSnapPoint : CameraPointObject
{
    //where the player will be when execute is called and and moves self to ground to avoid 'dropping' the player on a point
    public Transform player;
    private CameraPointObject playerLook;
    void OnEnable()
    {
        player = FindObjectOfType<CharacterControlsModified>().transform;
        playerLook = transform.parent.GetComponentInChildren<PlayerLookPoint>();
        RaycastHit hit;
        if (Physics.Raycast(transform.position, -Vector3.up, out hit, 100.0f))
        {
            //make sure player is on ground at first frame of thing
            transform.position = new Vector3(transform.position.x, hit.point.y, transform.position.z);
        }
    }
    public override void Execute()
    {
        base.Execute();
        player.position = transform.position;
        player.forward = playerLook.transform.position - transform.position;
        //player.rotation = Quaternion.identity;
    }
}
