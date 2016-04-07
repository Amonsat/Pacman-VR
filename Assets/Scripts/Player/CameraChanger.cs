using UnityEngine;
using System.Collections;

public class CameraChanger : MonoBehaviour
{
    public GameObject defaultCamera;
    public GameObject fpCamera;
    
	void Update ()
    {
        if (GameManager.instance.isMenu) return;

        if (Input.GetButtonDown("Jump"))
        {
            ChangeCamera();
        }
        
    }

    private void ChangeCamera()
    {
        defaultCamera.SetActive(!defaultCamera.activeSelf);
        fpCamera.SetActive(!fpCamera.activeSelf);
    }
}
