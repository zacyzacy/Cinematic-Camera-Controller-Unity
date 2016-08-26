//Author: Zac Youngdale
using UnityEngine;
using System.Collections;

public class ManualCameraObject : MonoBehaviour
{
    //loops through children and calls the childs execute in order to do some cool camera stuff
    private Vector3[] StartingPoints;
    private Animator camAnim;
    private AnimatorOverrideController overrideController;
    private RuntimeAnimatorController original;
    private AnimationClipPair[] acp;
    public bool execute = false;



    public AnimationClip CameraAnimation;
    void OnEnable()
    {
        camAnim = FindObjectOfType<Camera>().GetComponent<Animator>();
        overrideController = FindObjectOfType<CameraAnimOverider>().camOverride;
        original = camAnim.runtimeAnimatorController;
        acp = overrideController.clips;
        camAnim.enabled = false;
    }
    public void Execute()
    {
        StartingPoints = new Vector3[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).GetComponent<CameraPointObject>().Execute();
            StartingPoints[i] = transform.GetChild(i).position;
        }
        FindObjectOfType<FollowCameraUnrestricted>().enabled = false;
        //set anim override

        camAnim.enabled = true;
        acp[0].overrideClip = CameraAnimation;
        overrideController.clips = acp;
        camAnim.runtimeAnimatorController = overrideController;
        camAnim.SetTrigger("PlayCameraAnimation");
        execute = true;
        /*
        Debug.Log(overrideController.clips[0].overrideClip);
        Debug.Log(overrideController.clips[0].originalClip);
        //*/
    }
    public void Stop()
    {
        //reset overide controller?
        camAnim.runtimeAnimatorController = original;
        camAnim.enabled = false;
        FindObjectOfType<FollowCameraUnrestricted>().enabled = true;
        for (int i = 0; i < transform.childCount; i++)
        {            
            transform.GetChild(i).position = StartingPoints[i];
            transform.GetChild(i).GetComponent<CameraPointObject>().Stop();
        }
        execute = false;
    }
}
