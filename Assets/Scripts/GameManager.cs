using UnityEngine;
using System.Collections;
using System.Linq;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

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
    
    public Text GameoverScore;
    public bool isMenu;
    public bool isControlBlocked;
    
    public bool huntMode;
    public float HuntModeDuration;
    
    
    private float huntModeOffset;
    private Ghost[] ghosts;
    private AudioSource audioSource;
    private string playerName;
    
    [Header("Audio")]
    public AudioClip defaultMusic;
    public AudioClip huntModeMusic;
    
    [Header("UI")]
    public GameObject MainMenu;
    public GameObject GameUI;
    public GameObject Gameover;
    public GameObject Leaderboard;
    public GameObject Nameboard;

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

    public void SetPlayerName(string playerName)
    {        
        this.playerName = playerName.First().ToString().ToUpper() + playerName.Substring(1);
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
        
        //player.transform.position = new Vector3(5, 3, -75);
        player.GetComponent<PlayerMovementWaypoint>().ResetPosition();
        
        foreach (var ghost in ghosts) ghost.Reset();
        
        health--;
        playerHealthSlider.value = health;
        
        if (health < 0) ShowGameover(); //RestartLevel();
    }
    
    public void LeaderboardShow()
    {
        Gameover.SetActive(false);
        Leaderboard.GetComponent<Leaderboard>().SaveScore(playerName, score);
        Leaderboard.SetActive(true);
        Leaderboard.GetComponent<MainMenu>().DefaultMenuItemSelect();
    }
    
    private void ShowGameover()
    {
        HideGameUI();
        GameoverScore.text = "Your score: " + score.ToString("D5");
        Gameover.SetActive(true);
        Gameover.GetComponent<MainMenu>().DefaultMenuItemSelect();
        // isMenu = true;
    }
    
    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    
    public void NameboardShow()
    {
        HideMenu();
        Nameboard.SetActive(true);
        Nameboard.GetComponent<MainMenu>().DefaultMenuItemSelect();
    }

    public void GameStart()
    {
        Nameboard.SetActive(false);
        ShowGameUI();
    }
    
    public void GameExit()
    {
        Application.Quit();
    }
    
    public void ShowMenu()
    {
        MainMenu.SetActive(true);
        // isMenu = true;
        MainMenu.GetComponent<MainMenu>().DefaultMenuItemSelect();
    }
    
    public void HideMenu()
    {
        MainMenu.SetActive(false);
        // isMenu = false;
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
