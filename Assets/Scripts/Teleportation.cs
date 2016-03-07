using UnityEngine;
using System.Collections;

public class Teleportation : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Portal"))
        {
            gameObject.transform.position = other.GetComponent<Portal>().Destination.position + other.transform.forward * -10;
        }
    }
}
