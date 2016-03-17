using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    public int score;
    public Text scoreText;
    public Text playerHealthText;
    public int pickupsCount;
    public int health;
    public GameObject player;
    public GameObject Menu;
    public bool isMenu;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            Init();
        }            
        else instance = null;
    }
    
    public void Init()
    {
        Menu.SetActive(true);
        isMenu = true;
        //Time.timeScale = 0;
    }

    public void AddScore(int value)
    {
        score += value;
        scoreText.text = "Score: " + score;
    }

    public void GetPickup(PickUp pickup)
    {
        AddScore(pickup.score);
        pickupsCount--;
        if (pickupsCount < 1) RestartLevel();
    }
    
    public void LoseHealth()
    {
        health--;
        playerHealthText.text = "Health: " + health;
        player.transform.position = new Vector3(5, 3, -75);
        if (health < 0) RestartLevel();
    }
    
    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void GameStart()
    {
        Menu.SetActive(false);
        isMenu = false;
    }
    
    public void GameExit()
    {
        Application.Quit();
    }
}
