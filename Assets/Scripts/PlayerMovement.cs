using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public float rotateSpeed;

    [Range(.2f, .8f)]
    public float rotationThreshold;

    private void FixedUpdate()
    {
        if (GameManager.instance.isMenu) return;
        if (GameManager.instance.isControlBlocked) return;

        var horizontal = Input.GetAxis("Horizontal") * rotateSpeed * Time.deltaTime;
        var vertical = Input.GetAxis("Vertical") * speed * Time.deltaTime;

        transform.Translate(0, 0, vertical);
        if (Mathf.Abs(Input.GetAxis("Horizontal")) > rotationThreshold) transform.Rotate(0, horizontal, 0);
        // print(horizontal);
    }
}