using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class VirtualKeyboard : MonoBehaviour 
{
    public InputField targetInput;
    
	public void StartGame()
    {
        GameManager.instance.SetPlayerName(targetInput.text);
        GameManager.instance.GameStart();
    }
    
    public void SendStringToTargetText(string character)
    {
        targetInput.text += character;
    }
}
