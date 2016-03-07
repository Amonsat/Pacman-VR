using UnityEngine;
using System.Collections;

public class PickUps : MonoBehaviour
{
    public int score;

	void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PickUp"))
        {            
            other.gameObject.SetActive(false);
            GameManager.instance.AddScore(score);
        }
    }
}
