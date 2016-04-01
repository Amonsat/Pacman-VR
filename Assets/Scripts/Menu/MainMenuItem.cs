using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MainMenuItem : MonoBehaviour 
{
    public enum State {Off, On};
    public State state;
    
    public Image imageOn;
    public Image imageOff;
    
    private Image sourceImage;
    
    void Awake()
    {
        // sourceImage = GetComponent<Image>().
    }
    
    public void ItemOn()
    {
        
    }
}
