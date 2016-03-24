using UnityEngine;

public class Pinky : Ghost 
{
    public float forwardOffset;
	
    public override Vector3 GetTarget()
    {
        return target.position + target.transform.forward * forwardOffset * 10;
    }
}
