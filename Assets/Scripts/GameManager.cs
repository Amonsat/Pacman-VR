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
    
    // public GameObject Blinky;
    // public GameObject Pinky;
    // public GameObject Inky;
    // public GameObject Clyde;
    public bool huntMode;
    public float HuntModeDuration;
    private float huntModeOffset;
    private Ghost[] ghosts;

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
        
        GameObject[] gos = GameObject.FindGameObjectsWithTag("Ghost");
        ghosts = new Ghost[gos.Length];
        for (var i = 0; i < ghosts.Length; i++) ghosts[i] = gos[i].GetComponent<Ghost>();
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
        
        foreach (var ghost in ghosts) ghost.Reset();
        // Blinky.GetComponent<Ghost>().Reset();
        // Pinky.GetComponent<Ghost>().Reset();
        // Inky.GetComponent<Ghost>().Reset();
        // Clyde.GetComponent<Ghost>().Reset();
        
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
        
        if (huntMode && Time.time > huntModeOffset) HuntModeDisable();
    }
    
    public void HuntModeEnable()
    {
        huntMode = true;
        huntModeOffset = Time.time + HuntModeDuration;
        
        foreach(var ghost in ghosts) ghost.HuntModeEnable();
        // Blinky.GetComponent<Ghost>().HuntModeEnable();
        // Pinky.GetComponent<Ghost>().HuntModeEnable();
        // Inky.GetComponent<Ghost>().HuntModeEnable();
        // Clyde.GetComponent<Ghost>().HuntModeEnable();
    }
    
    public void HuntModeDisable()
    {
        huntMode = false;
        
        foreach(var ghost in ghosts) ghost.HuntModeDisable();
        // Blinky.GetComponent<Ghost>().HuntModeDisable();
        // Pinky.GetComponent<Ghost>().HuntModeDisable();
        // Inky.GetComponent<Ghost>().HuntModeDisable();
        // Clyde.GetComponent<Ghost>().HuntModeDisable();
    }
}
