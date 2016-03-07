using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    public int score;
    public Text scoreText;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else instance = null;
    }

    public void AddScore(int value)
    {
        score += value;
        scoreText.text = "Score: " + score;
    }

}
