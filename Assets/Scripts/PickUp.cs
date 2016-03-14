using UnityEngine;
using System.Collections;


public class PickUp : MonoBehaviour
{
    public int score;
    public AudioClip clip;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //AudioSource.PlayClipAtPoint(clip, transform.position, 10f);
            other.GetComponent<AudioSource>().Play();
            gameObject.SetActive(false);
            //GameManager.instance.AddScore(score);
            GameManager.instance.GetPickup(this);
        }
    }
}
