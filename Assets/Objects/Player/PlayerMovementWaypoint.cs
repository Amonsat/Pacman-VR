using DG.Tweening;
using UnityEngine;

public class PlayerMovementWaypoint : MonoBehaviour
{
    public float speed;
    public float rotateSpeed;
    public LayerMask layerMask;  

    private Vector3 targetWaypoint;
    private Vector3 currentWaypoint;
    private Vector3 nextWaypoint;
    private Vector3 prevWaypoint;
    private RaycastHit[] forward, left, right;
    private bool isMoving = false;

    private float startMove;
    private float distance;
    private float percentage;
    private Vector3 startPosition;
    private Vector3 targetPosition;
    private Vector3 defaultPosition;
    private Quaternion defaultRotation;
        
    private void Start()
    {
        defaultPosition = transform.position;
        currentWaypoint = transform.position;
        defaultRotation = transform.rotation;
    }

    private void FixedUpdate()
    {
        if (GameManager.instance.isMenu) return;
        if (GameManager.instance.isControlBlocked) return;


        if (nextWaypoint == Vector3.zero && percentage > .9f)
        {
            Debug.DrawRay(targetWaypoint, transform.forward);

            RaycastHit nextWaypointHit;
            if (Physics.Raycast(targetWaypoint, transform.forward, out nextWaypointHit, Mathf.Infinity, layerMask))
            {
                if (nextWaypointHit.collider.CompareTag("Waypoint"))
                {
//                    print("Found a next waypoint - position: " + nextWaypointHit.collider.transform.position);
                    nextWaypoint = nextWaypointHit.collider.transform.position;
                }
            }
        }

        if (currentWaypoint != Vector3.zero && targetWaypoint == Vector3.zero && nextWaypoint == Vector3.zero)
        {
            RaycastHit waypointHit;
            if (Physics.Raycast(transform.position, transform.forward, out waypointHit, Mathf.Infinity, layerMask))
            {
                if (waypointHit.collider.CompareTag("Waypoint"))
                {
//                    print("Found a waypoint - position: " + waypointHit.collider.transform.position);
                    targetWaypoint = waypointHit.collider.transform.position;
                }
            }
        }

        if (targetWaypoint != Vector3.zero && currentWaypoint != Vector3.zero)
        {
            Move();
            prevWaypoint = currentWaypoint;
            currentWaypoint = Vector3.zero;
        }

        if (isMoving)
        {
            percentage = ((Time.time - startMove) * speed) / distance;
            transform.position = Vector3.Lerp(startPosition, targetPosition, percentage);
        }

        if (percentage >= 1f && nextWaypoint != Vector3.zero)
        {
            prevWaypoint = currentWaypoint;
            currentWaypoint = targetWaypoint;
            targetWaypoint = nextWaypoint;
            nextWaypoint = Vector3.zero;
//            print("Change a target - new position: " + targetWaypoint);
            transform.DOLookAt(targetWaypoint, 1 / rotateSpeed);
            Move();
        }

        if (Input.GetAxis("Horizontal") > .8f && percentage > .5f)
        {
            Debug.DrawRay(targetWaypoint, transform.right);

            RaycastHit nextWaypointHit;
            
            if (Physics.Raycast(targetWaypoint, transform.right, out nextWaypointHit, Mathf.Infinity, layerMask))
            {
                if (nextWaypointHit.collider.CompareTag("Waypoint"))
                {
//                    print("Found a next right waypoint - position: " + nextWaypointHit.collider.transform.position);
                    nextWaypoint = nextWaypointHit.collider.transform.position;
                }
            }
        }

        if (Input.GetAxis("Horizontal") < -.8f && percentage > .5f)
        {
            Debug.DrawRay(targetWaypoint, -transform.right);

            RaycastHit nextWaypointHit;
            if (Physics.Raycast(targetWaypoint, -transform.right, out nextWaypointHit, Mathf.Infinity, layerMask))
            {
                if (nextWaypointHit.collider.CompareTag("Waypoint"))
                {
//                    print("Found a next left waypoint - position: " + nextWaypointHit.collider.transform.position);
                    nextWaypoint = nextWaypointHit.collider.transform.position;
                }
            }
        }

        if (Input.GetAxis("Vertical") < -.8f && percentage > .1f && prevWaypoint != Vector3.zero)
        {
            Debug.DrawRay(targetWaypoint, -transform.forward);

            //            nextWaypoint = nextWaypointHit.collider.transform.position;

            nextWaypoint = Vector3.zero;
            targetWaypoint = prevWaypoint;
            prevWaypoint = Vector3.zero;
            transform.DOLookAt(targetWaypoint, 1 / rotateSpeed);
            
            Move();
        }
    }

    private void Move()
    {
        startMove = Time.time;
        startPosition = transform.position;
        targetPosition = targetWaypoint;
        distance = Vector3.Distance(startPosition, targetPosition);
        isMoving = true;
    }

    public void ResetPosition()
    {
        prevWaypoint = Vector3.zero;
        currentWaypoint = Vector3.zero;
        targetWaypoint = Vector3.zero;
        nextWaypoint = Vector3.zero;
        isMoving = false;
        transform.position = defaultPosition;
        transform.rotation = defaultRotation;
        currentWaypoint = transform.position;
    }

}