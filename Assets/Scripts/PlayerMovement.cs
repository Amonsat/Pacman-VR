using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public float rotateSpeed;

	void Update()
	{
		var horizontal = Input.GetAxis ("Horizontal") * Time.deltaTime * rotateSpeed;
		var vertical = Input.GetAxis ("Vertical") * Time.deltaTime * speed;

		transform.Translate(0, 0, vertical);
		transform.Rotate(0, horizontal, 0);
	}
}
