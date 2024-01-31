using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
{
    if (other.gameObject.CompareTag("Hazard"))
    {
        other.gameObject.tag = "Safe";
    }
}

private void OnTriggerExit(Collider other)
{
    if (other.gameObject.CompareTag("Safe"))
    {
        other.gameObject.tag = "Hazard";
    }
}
}
