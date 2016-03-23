using UnityEngine;
using System.Collections;

public class HealthController : MonoBehaviour 
{
    public int health;
    private Animator anim;
    // public AnimationClip animDeath;
    
    void Start()
    {
        anim = GetComponent<Animator>();
    }
    
    void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Ghost")) return;
        
        GameManager.instance.isMenu = true;
        anim.SetTrigger("LoseHealth");        
        //GameManager.instance.LoseHealth();
    }
    
    void LoseHealth()
    {
        GameManager.instance.isMenu = false;
        GameManager.instance.LoseHealth();
    }
}
