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
    public bool isControlBlocked;
    
    public GameObject Blinky;
    public GameObject Pinky;
    public GameObject Inky;
    public GameObject Clyde;

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
        ShowMenu();
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
        
        player.transform.position = new Vector3(5, 3, -75);
        
        // Blinky.transform.position = new Vector3(0, 1, 16);
        // Pinky.transform.position = new Vector3(-15, 1, 10);
        // .transform.position = new Vector3(15, 1, 10);
        // Clyde.transform.position = new Vector3(0, 1, 10);
        print("lose health");
        Blinky.GetComponent<GhostBlinky>().Reset();
        Pinky.GetComponent<GhostPinky>().Reset();
        Inky.GetComponent<GhostInky>().Reset();
        Clyde.GetComponent<GhostClyde>().Reset();
        
        health--;
        playerHealthText.text = "Health: " + health;
        
        if (health < 0) RestartLevel();
    }
    
    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void GameStart()
    {
        HideMenu();
    }
    
    public void GameExit()
    {
        Application.Quit();
    }
    
    public void ShowMenu()
    {
        Menu.SetActive(true);
        isMenu = true;
    }
    
    public void HideMenu()
    {
        Menu.SetActive(false);
        isMenu = false;
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) ShowMenu();
    }
}
