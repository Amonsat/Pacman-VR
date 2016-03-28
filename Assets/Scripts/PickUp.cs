using UnityEngine;
using System.Collections;


public class PickUp : MonoBehaviour
{
    public int score;
    public AudioClip clip;
    
    public GameObject ScoreText;
    public float ScoreLifetime;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //AudioSource.PlayClipAtPoint(clip, transform.position, 10f);
            other.GetComponent<AudioSource>().Play();
            
            ScoreText.GetComponent<ScoreText>().SetText(score.ToString());
            var targetPosition = transform.position;
            targetPosition.y = 6f;
            var scoreText = (GameObject) Instantiate(ScoreText, targetPosition, Quaternion.identity);
            Destroy(scoreText, ScoreLifetime);
            
            gameObject.SetActive(false);
            //GameManager.instance.AddScore(score);
            GameManager.instance.GetPickup(this);
        }
    }
}
