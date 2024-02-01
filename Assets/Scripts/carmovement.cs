using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carmovement : MonoBehaviour
{
    public float speed = 10f;
    public float distance = 10f;
    private Vector3 startPosition;
    private float traveledDistance;
    public int left = 0;
    public float wait = 0;
    private float savedspeed = 0f;
    

    void Start()
    {
        startPosition = transform.position;
        traveledDistance = 0f;
        distance = distance * 2;
        savedspeed = speed;
    }

    void Update()
    {
        if (wait > 0)
        {
            speed = 0;
            wait -= Time.deltaTime; 
        }
        else
        {
            speed = savedspeed;
            if (left == 0)
            {
                transform.Translate(Vector3.left * speed * Time.deltaTime);
            }
            else
            {
                transform.Translate(Vector3.right * speed * Time.deltaTime);
            }
        }
    
     //move direction

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

