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
     //move direction
        transform.Translate(Vector3.left * speed * Time.deltaTime);

     //distance checker
        traveledDistance += speed * Time.deltaTime;

     //if traveled distance meets distance
        if (traveledDistance >= distance)
        {
      //teleport back to start
            transform.position = startPosition;
            traveledDistance = 0f;
        }
    }
}

