using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class tempcarmovement : MonoBehaviour
{
    public float speed = 10f;
    public float distance = 10f;
    private Vector3 startPosition;
    private float traveledDistance;
    public int left = 0;
    public float wait = 0;
    private float savedspeed = 0f;

    int level = 0;
    

    void Start()
    {
        startPosition = transform.position;
        traveledDistance = 0f;
        distance = distance * 2;
        savedspeed = speed;
        Scene currentScene = SceneManager.GetActiveScene ();
        string sceneName = currentScene.name;
         if (sceneName == "Level2"){
            level = 0;
        }
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
            speed = savedspeed + level;
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
           Destroy(gameObject);
          
        }
    }
}
