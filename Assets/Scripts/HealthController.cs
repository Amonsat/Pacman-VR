using UnityEngine;
using System.Collections;

public class HealthController : MonoBehaviour 
{
    public int health;
    
    void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Ghost")) return;
        
        GameManager.instance.LoseHealth();
    }
}
