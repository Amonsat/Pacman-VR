using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour 
{
    
    public Button defaultButton;
    
    public void DefaultMenuItemSelect()
    {
        // EventSystem.current.SetSelectedGameObject(null);        
        defaultButton.Select();
    }
    
    void OnEnable() 
    {
        GameManager.instance.isMenu = true;
        // defaultButton.Select();
    }
    
    void OnDisable()
    {
        GameManager.instance.isMenu = false;
    }
}
