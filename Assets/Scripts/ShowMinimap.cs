using UnityEngine;
using System.Collections;

public class ShowMinimap : MonoBehaviour
{
    public GameObject minimapCanvas;

	void Update()
    {
        if (GameManager.instance.isMenu) return;
        
        if (Input.GetButtonDown("Jump"))
        {
        //    print("Fire2 down");
            minimapCanvas.SetActive(true);
        }
        if (Input.GetButtonUp("Jump"))
        {
  //          print("Fire2 up");
            minimapCanvas.SetActive(false);
        }
        //else
        //{
        //    minimapCanvas.SetActive(false);
        //}

    }
}
