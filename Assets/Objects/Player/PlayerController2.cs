using DG.Tweening;
using System.Linq;
using UnityEngine;

public class PlayerController2 : MonoBehaviour
{
    public float speed;
    public float rotateSpeed;

    private Vector3 targetWaypoint;
    private Vector3 currentWaypoint;
    private RaycastHit[] forward, left, right;
    private bool isMoving = false;

    private void Start()
    {
        currentWaypoint = transform.position;
    }

    private void FixedUpdate()
    {
        if (targetWaypoint != Vector3.zero && currentWaypoint != Vector3.zero)
        {
            var distance = Vector3.Distance(currentWaypoint, targetWaypoint);
            transform.DOMove(targetWaypoint, distance / speed);
            currentWaypoint = Vector3.zero;
        }

        if (transform.position == targetWaypoint)
        {
            currentWaypoint = targetWaypoint;
            targetWaypoint = Vector3.zero;
        }

        if (currentWaypoint != Vector3.zero)
        {
            forward = Physics.RaycastAll(transform.position, transform.forward, Mathf.Infinity, 1 << LayerMask.NameToLayer("Waypoints")).OrderBy(h => h.distance).ToArray();
            right = Physics.RaycastAll(transform.position, transform.right, Mathf.Infinity, 1 << LayerMask.NameToLayer("Waypoints")).OrderBy(h => h.distance).ToArray();
            left = Physics.RaycastAll(transform.position, -transform.right, Mathf.Infinity, 1 << LayerMask.NameToLayer("Waypoints")).OrderBy(h => h.distance).ToArray();
        }

        if (Input.GetKey(KeyCode.D))
        {
            if (currentWaypoint != Vector3.zero && right.Length > 0)
            {
                transform.DOLookAt(right[0].transform.position, 1 / rotateSpeed);
                targetWaypoint = right[0].transform.position;
            }
        }
        if (Input.GetKey(KeyCode.A))
        {
            if (currentWaypoint != Vector3.zero && left.Length > 0)
            {
                transform.DOLookAt(left[0].transform.position, 1 / rotateSpeed);
                targetWaypoint = left[0].transform.position;
            }
        }

        if (targetWaypoint == Vector3.zero && forward.Length > 0) //currentWaypoint != Vector3.zero &&
        {
            targetWaypoint = forward[0].transform.position;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position, transform.position + transform.forward * 10);
        Gizmos.DrawLine(transform.position, transform.position + transform.right * 10);
        Gizmos.DrawLine(transform.position, transform.position + -transform.right * 10);
    }
}