using UnityEngine;
using System.Collections;

public class Inky : Ghost 
{
    public float forwardOffset;
    public Transform blinkyLink;
    
    public override Vector3 GetTarget()
    {
        return (target.position + target.transform.forward * forwardOffset) - blinkyLink.position + target.position;
    }
}
