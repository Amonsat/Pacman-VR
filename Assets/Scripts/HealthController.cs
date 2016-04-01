using UnityEngine;
using System.Collections;

public class HealthController : MonoBehaviour 
{
    public int health;
    private Animator anim;
    private AudioSource audioSource;
    public AudioClip deathClip;
    // public AnimationClip animDeath;
    
    void Start()
    {
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }
    
    // void OnTriggerEnter(Collider other)
    // {
    //     if (!other.CompareTag("Ghost")) return;
        
    //     GameManager.instance.isMenu = true;
    //     anim.SetTrigger("LoseHealth");        
    //     //GameManager.instance.LoseHealth();
    // }
    
    void LoseHealth()
    {
        GameManager.instance.isMenu = false;        
        GameManager.instance.LoseHealth();
    }
    
    public void SetDamage()
    {
        GameManager.instance.isMenu = true;
        audioSource.PlayOneShot(deathClip, 1);
        anim.SetTrigger("LoseHealth");     
    }
}
