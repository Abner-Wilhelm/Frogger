using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lilypad : MonoBehaviour
{
    Collider m_Collider;
    public GameObject objectToSpawn;

    void Start()
    {
        m_Collider = GetComponent<Collider>();
    }

    void OnTriggerEnter(Collider other)
    {
        // Check if the colliding object is tagged as "Player"
        if (other.gameObject.CompareTag("Player"))
        {
            // Toggle the collider's enabled state
            m_Collider.enabled = !m_Collider.enabled;

            // Instantiate a new object at the lily pad's position and rotation
            Instantiate(objectToSpawn, transform.position, transform.rotation);
        }
    }
}
