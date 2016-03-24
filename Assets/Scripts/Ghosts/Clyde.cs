using UnityEngine;

public class Clyde : Ghost 
{
    public override Vector3 GetTarget()
    {
        
        var distance = Vector3.Distance(target.position, transform.position);
        Vector3 targetPosition;
        
        if ( distance > 90 ) targetPosition = target.position;
        else targetPosition = HomePoint.position;
        
        return targetPosition;
    }
}
