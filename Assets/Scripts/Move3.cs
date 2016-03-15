using UnityEngine;
using System.Collections;

public class Move3 : MonoBehaviour
{
    public float gf_moveSpeed = 6f;
    public float gridSize = 2f;
    public float maxMoveTime = .5f;

    float moving = 0f;
    Vector3 targetPos;
    Rigidbody rb;
	
    void Start()
    {
        targetPos = transform.position;
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        var delta = Vector3.zero;
        if (moving <= 0)
        {
            var curTarget = targetPos;

            var dirZ = Input.GetAxis("Vertical");
            if (dirZ > 0) // up
            {
                if (!Physics.Raycast(curTarget, Vector3.forward, gridSize)) targetPos.z += gridSize;
            }
            else if (dirZ < 0) // down
            {
                if (!Physics.Raycast(curTarget, Vector3.back, gridSize)) targetPos.z -= gridSize;
            }

            var dirX = Input.GetAxis("Horizontal");
            if (dirX > 0) // right
            {
                if (!Physics.Raycast(curTarget, Vector3.right, gridSize)) targetPos.x += gridSize;
            }
            else if (dirX < 0) // left
            {
                if (!Physics.Raycast(curTarget, Vector3.left, gridSize)) targetPos.x -= gridSize;
            }

            if (targetPos != curTarget)
            {
                moving = maxMoveTime;
            }
        }
        else
        {
            delta = targetPos - transform.position;
            delta.y = 0;

            var maxDelta = gf_moveSpeed * Time.deltaTime;
            if (delta.magnitude < maxDelta)
            {
                moving = 0;
            }
            else
            {
                delta = Vector3.ClampMagnitude(delta, maxDelta);
                moving -= Time.deltaTime;
            }
        }
        if (delta != Vector3.zero)
        {
            //print(delta);
            transform.position += delta;
        }
            
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;        
        Gizmos.DrawLine(transform.position, Vector3.right);

        Gizmos.color = Color.blue;
        Gizmos.DrawLine(transform.position, Vector3.left);

        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(transform.position, Vector3.forward);

        Gizmos.color = Color.green;
        Gizmos.DrawLine(transform.position, Vector3.back);
    }
}
