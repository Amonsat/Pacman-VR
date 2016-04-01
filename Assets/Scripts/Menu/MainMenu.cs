using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class MainMenu : MonoBehaviour 
{
    
    public GameObject defaultButton;
    
    void Start()
    {
        DefaultMenuItemSelect();
    }
    
    public void DefaultMenuItemSelect()
    {
        EventSystem.current.SetSelectedGameObject(defaultButton);
    }
}
