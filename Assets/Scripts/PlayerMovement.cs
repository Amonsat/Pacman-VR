using UnityEngine;
using System.Collections;
using DG.Tweening;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public float rotateSpeed;
    public float rotateTime;
    public bool classicMovement;
    public Vector3 checkBoxSize;

    private Vector3 forward;
    private Vector3 right;
    private Vector3 left;
    private Vector3 rightForward;
    private Vector3 leftForward;
    private Vector3 leftBack;
    private Vector3 rightBack;
    private Rigidbody rb;
    private bool rotated = false;
    

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
	{
        //forward = transform.TransformPoint(Vector3.forward * .7f);
        
        //leftForward = transform.TransformPoint(Vector3.left * 2 + Vector3.forward / 2);
        //rightForward = transform.TransformPoint(Vector3.right * 2 + Vector3.forward / 2);

        //leftBack = transform.TransformPoint(Vector3.left * 2 + Vector3.back / 2);
        //rightBack = transform.TransformPoint(Vector3.right * 2 + Vector3.back / 2);

        left = transform.TransformPoint(Vector3.left);
        right = transform.TransformPoint(Vector3.right);

        //var forwardWall = Physics.Linecast(transform.position, forward, 1 << LayerMask.NameToLayer("Walls"));
        
        //var leftForwardWall = Physics.Linecast(transform.position, leftForward, 1 << LayerMask.NameToLayer("Walls"));
        //var rightForwardWall = Physics.Linecast(transform.position, rightForward, 1 << LayerMask.NameToLayer("Walls"));

        //var leftWall = Physics.Linecast(transform.position, left, 1 << LayerMask.NameToLayer("Walls"));
        //var rightWall = Physics.Linecast(transform.position, right, 1 << LayerMask.NameToLayer("Walls"));

        //var leftBackWall = Physics.Linecast(transform.position, leftBack, 1 << LayerMask.NameToLayer("Walls"));
        //var rightBackWall = Physics.Linecast(transform.position, rightBack, 1 << LayerMask.NameToLayer("Walls"));

        var leftBlocked = Physics.CheckBox(left, checkBoxSize);
        var rightBlocked = Physics.CheckBox(right, checkBoxSize);
        //print(leftBlocked);

        if (!classicMovement) 
		{
			var horizontal = Input.GetAxis ("Horizontal") * Time.deltaTime * rotateSpeed;
			var vertical = Input.GetAxis ("Vertical") * Time.deltaTime * speed;

			transform.Translate(0, 0, vertical);
			transform.Rotate(0, horizontal, 0);
		}
		else
		{
            rb.velocity = transform.forward * speed;

            Vector3 correctPosition = transform.position;

            if ((int)transform.eulerAngles.y == 0 || (int)transform.eulerAngles.y == 180)
                correctPosition = new Vector3(                            
                            Mathf.RoundToInt(transform.position.x / 5) * 5,
                            transform.position.y,
                            transform.position.z);
            else if ((int)transform.eulerAngles.y == 90 || (int)transform.eulerAngles.y == -90 || (int)transform.eulerAngles.y == 270)
                correctPosition = new Vector3(
                    transform.position.x,
                    transform.position.y,
                    Mathf.RoundToInt(transform.position.z / 5) * 5);

            transform.position = Vector3.Slerp(transform.position, correctPosition, Time.deltaTime);

            if (Input.GetKey(KeyCode.LeftArrow))
                if (!rotated && !leftBlocked)
                {
                    transform.DORotate(new Vector3(0, -90, 0), rotateTime, RotateMode.LocalAxisAdd);
                    transform.eulerAngles = new Vector3( 0, Mathf.RoundToInt(transform.eulerAngles.y / 90) * 90, 0);                    
                    rotated = true;
                }
            if (Input.GetKeyUp(KeyCode.LeftArrow)) rotated = false;

            if (Input.GetKey(KeyCode.RightArrow))
                if (!rotated && !rightBlocked)
                {
                    transform.DORotate(new Vector3(0, 90, 0), rotateTime, RotateMode.LocalAxisAdd);
                    transform.eulerAngles = new Vector3(0, Mathf.RoundToInt(transform.eulerAngles.y / 90) * 90, 0);
                    rotated = true;
                }
            if (Input.GetKeyUp(KeyCode.RightArrow)) rotated = false;
        }
	}

    int RoundAndFold(float number, int fold)
    {
        int x = (int)number;
        if (x % fold != 0) x = (x / fold) * fold + fold;
        return x;
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        //Gizmos.DrawLine(transform.position, forward);
        //Gizmos.DrawLine(transform.position, leftForward);
        //Gizmos.DrawLine(transform.position, rightForward);
        //Gizmos.DrawLine(transform.position, leftBack);
        //Gizmos.DrawLine(transform.position, rightBack);
        Gizmos.DrawCube(left, checkBoxSize);
        Gizmos.DrawCube(right, checkBoxSize);
    }
}
