using UnityEngine;
using System.Collections;
using DG.Tweening;

public class Move2 : MonoBehaviour {

    public float speed;
    public float rotateTime;

    private Rigidbody rb;
    private bool rotated = false;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        //rb.velocity = transform.forward * speed;
        transform.DOMove(transform.position + transform.forward * 10, .5f);

        var x = transform.position.x;
        var z = transform.position.z;

        if (Input.GetKey(KeyCode.LeftArrow))
            if (!rotated /*!leftBlocked &&*/)
            {
                transform.DORotate(new Vector3(0, -90, 0), rotateTime, RotateMode.LocalAxisAdd);
                transform.eulerAngles = new Vector3(0, Mathf.RoundToInt(transform.eulerAngles.y / 90) * 90, 0);
                rotated = true;
            }
        if (Input.GetKeyUp(KeyCode.LeftArrow)) rotated = false;

        if (Input.GetKey(KeyCode.RightArrow))
            if (!rotated /*!rightBlocked &&*/)
            {
                transform.DORotate(new Vector3(0, 90, 0), rotateTime, RotateMode.LocalAxisAdd);
                transform.eulerAngles = new Vector3(0, Mathf.RoundToInt(transform.eulerAngles.y / 90) * 90, 0);
                rotated = true;
            }
        if (Input.GetKeyUp(KeyCode.RightArrow)) rotated = false;
    }
}
