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
    public Slider playerHealthSlider;
    public int pickupsCount;
    public int health;
    public GameObject player;
    public GameObject MainMenu;
    public GameObject GameUI;
    public GameObject Gameover;
    public Text GameoverScore;
    public bool isMenu;
    public bool isControlBlocked;
    
    public bool huntMode;
    public float HuntModeDuration;
    private float huntModeOffset;
    private Ghost[] ghosts;
    private AudioSource audioSource;
    
    [HeaderAttribute("Audio")]
    public AudioClip defaultMusic;
    public AudioClip huntModeMusic;

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
        HideGameUI();
        ShowMenu();
        
        audioSource = GetComponent<AudioSource>();
        
        GameObject[] gos = GameObject.FindGameObjectsWithTag("Ghost");
        ghosts = new Ghost[gos.Length];
        for (var i = 0; i < ghosts.Length; i++) ghosts[i] = gos[i].GetComponent<Ghost>();
        
        scoreText.text = "Score: " + score.ToString("D5");
        playerHealthSlider.value = health;
    }

    public void AddScore(int value)
    {
        score += value;
        scoreText.text = "Score: " + score.ToString("D5");
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
        
        health--;
        playerHealthSlider.value = health;
        
        if (health < 0) ShowGameover(); //RestartLevel();
    }
    
    private void ShowGameover()
    {
        GameoverScore.text = "Your score: " + score.ToString("D5");
        Gameover.SetActive(true);
    }
    
    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void GameStart()
    {
        HideMenu();
        ShowGameUI();
    }
    
    public void GameExit()
    {
        Application.Quit();
    }
    
    public void ShowMenu()
    {
        MainMenu.SetActive(true);
        isMenu = true;
        MainMenu.GetComponent<MainMenu>().DefaultMenuItemSelect();
    }
    
    public void HideMenu()
    {
        MainMenu.SetActive(false);
        isMenu = false;
    }
    
    public void ShowGameUI()
    {
        GameUI.SetActive(true);        
    }
    
    public void HideGameUI()
    {
        GameUI.SetActive(false);
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
        
        audioSource.clip = huntModeMusic;
        audioSource.Play();
        
        player.GetComponent<PlayerHuntMode>().HuntmodeEnable();
        
        foreach(var ghost in ghosts) ghost.HuntModeEnable();
    }
    
    public void HuntModeDisable()
    {
        huntMode = false;
        
        audioSource.clip = defaultMusic;
        audioSource.Play();
        
        player.GetComponent<PlayerHuntMode>().HuntmodeDisable();
        
        foreach(var ghost in ghosts) ghost.HuntModeDisable();
    }
}
