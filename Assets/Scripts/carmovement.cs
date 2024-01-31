using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carmovement : MonoBehaviour
{
    public float speed = 5f;
    public float distance = 10f;
    private Vector3 startPosition;
    private float traveledDistance;
    

    void Start()
    {
        startPosition = transform.position;
        traveledDistance = 0f;
    }

    void Update()
    {
        // Move the car forward
        transform.Translate(Vector3.left * speed * Time.deltaTime);

        // Calculate the traveled distance
        traveledDistance += speed * Time.deltaTime;

        // Check if the car has traveled the specified distance
        if (traveledDistance >= distance)
        {
            // Reset the car's position and traveled distance
            transform.position = startPosition;
            traveledDistance = 0f;
        }
    }
}

