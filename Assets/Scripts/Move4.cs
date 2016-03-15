using UnityEngine;
using System.Collections;

public class Move4 : MonoBehaviour
{
    public float gf_moveSpeed = 6f;
    public float gf_rotationSpeed = 6f;
    public float gridSize = 2f;
    public float maxMoveTime = .5f;
    public float maxRotationTime = .5f;

    float moving = 0f;
    float rotation = 0f;
    Vector3 targetPos;
    Vector3 targetRotation;
    Rigidbody rb;
    Transform tr;
	
    void Start()
    {
        targetPos = transform.position;
        targetRotation = transform.eulerAngles;
        rb = GetComponent<Rigidbody>();
        tr = GetComponent<Transform>();
    }

    void Update()
    {
        var delta = Vector3.zero;
        var deltaRotation = 0f;

        if (moving <= 0 && rotation <= 0)
        {
            var curTarget = targetPos;
            var currentRotation = targetRotation;

            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {                
                if (!Physics.Raycast(curTarget, -transform.right, gridSize)) targetRotation -= new Vector3(0, 90, 0);
                print(targetRotation);
            }
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {                
                if (!Physics.Raycast(curTarget, transform.right, gridSize)) targetRotation += new Vector3(0, 90, 0);
                print(targetRotation);
            }

            if (!Physics.Raycast(curTarget, transform.forward, gridSize)) targetPos += transform.forward * gridSize;

            //var dirZ = Input.GetAxis("Vertical");
            //if (dirZ > 0) // up
            //{
            //    if (!Physics.Raycast(curTarget, Vector3.forward, gridSize)) targetPos.z += gridSize;
            //}
            //else if (dirZ < 0) // down
            //{
            //    if (!Physics.Raycast(curTarget, Vector3.back, gridSize)) targetPos.z -= gridSize;
            //}

            //var dirX = Input.GetAxis("Horizontal");
            //if (dirX > 0) // right
            //{
            //    if (!Physics.Raycast(curTarget, Vector3.right, gridSize)) targetPos.x += gridSize;
            //}
            //else if (dirX < 0) // left
            //{
            //    if (!Physics.Raycast(curTarget, Vector3.left, gridSize)) targetPos.x -= gridSize;
            //}

            if (targetPos != curTarget)
            {
                moving = maxMoveTime;
            }
            if (targetRotation != currentRotation)
            {
                rotation = maxRotationTime;
            }
        }
        else if (moving > 0)
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
        else if (rotation > 0)
        {
            deltaRotation = Quaternion.Angle(transform.rotation, Quaternion.Euler(targetRotation)); //targetPos - transform.position;            
            print(deltaRotation);
            var maxDeltaRotation = gf_rotationSpeed * Time.deltaTime;
            if (deltaRotation < maxDeltaRotation)
            {
                rotation = 0;
            }
            else
            {
                deltaRotation = Mathf.Clamp(deltaRotation, 0f, maxDeltaRotation);
                rotation -= Time.deltaTime;
            }
        }

        if (deltaRotation != 0f)
        {
            //print(deltaRotation);
            //var rot = transform.eulerAngles;
            //rot.y += deltaRotation;
            transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + deltaRotation, 0); ;
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
        Gizmos.DrawLine(transform.position, transform.position + -transform.right * gridSize);
        Gizmos.DrawLine(transform.position, transform.position + transform.right * gridSize);

        //Gizmos.color = Color.blue;
        //Gizmos.DrawLine(transform.position, Vector3.left);

        //Gizmos.color = Color.yellow;
        //Gizmos.DrawLine(transform.position, Vector3.forward);

        //Gizmos.color = Color.green;
        //Gizmos.DrawLine(transform.position, Vector3.back);
    }
}
