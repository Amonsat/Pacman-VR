using UnityEngine;
using System.Collections;

public class MenuPointer : MonoBehaviour 
{
	public Vector3 positionStart;
    public Vector3 positionExit;
    
    void Start()
    {
        transform.localPosition = positionStart;
    }
	// Update is called once per frame
	void Update ()     
    {                        
        if (!GameManager.instance.isMenu) return;
        
	    if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (transform.localPosition == positionStart) transform.localPosition = positionExit;
            else if (transform.localPosition == positionExit) transform.localPosition = positionStart;                                    
        }
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (transform.localPosition == positionStart) GameManager.instance.GameStart();
            else if (transform.localPosition == positionExit) GameManager.instance.GameExit();
        }
	}
}
