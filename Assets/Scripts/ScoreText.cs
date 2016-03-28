using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour 
{
    public Text scoreText;
	
	public void SetText(string text)
    {
        scoreText.text = text;
    }
}
