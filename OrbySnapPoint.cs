//Author: Zac Youngdale
using UnityEngine;
using System.Collections;

public class OrbySnapPoint : CameraPointObject
{
  public override void Execute()
    {
        base.Execute();
        FindObjectOfType<POIPulse>().startingValue = transform.position.y;
        FindObjectOfType<CompanionAI>()._idle.POI = transform.position;
        FindObjectOfType<CompanionAI>().transform.position = transform.position;
    }
}
