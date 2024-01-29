using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{

    bool ismoving = false;
    Vector3 original_position;
    bool direction = true;
    int way = 2;

    public int speed = 5;
    // Start is called before the first frame update
    void Start()
    {
        original_position = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
       if (Input.GetKeyDown(KeyCode.W))
        {
            if (ismoving == false)
            {
                original_position = transform.position;
                ismoving = true;
                direction = true;
                way = 2;
            }
           
        }
       else if (Input.GetKeyDown(KeyCode.S))
        {
            if (ismoving == false)
            {
                original_position = transform.position;
                ismoving = true;
                direction = true;
                way = -2;
            }
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            if (ismoving == false)
            {
                original_position = transform.position;
                ismoving = true;
                direction = false;
                way = 2;
            }
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            if (ismoving == false)
            {
                original_position = transform.position;
                ismoving = true;
                direction = false;
                way = -2;
            }
        }
        Move();
    }

    private void Move()
    {
        if (ismoving == true)
        {
            if (direction == false)
            {
                if (Mathf.Round(transform.position.x) == original_position.x + way)
                {
                    transform.position = new Vector3(original_position.x + way, 0,original_position.z);
                    ismoving = false;
                }
                else { transform.position += new Vector3(Time.deltaTime * speed*way,0,0); }
            }
            else
            {
                if (Mathf.Round(transform.position.z) == original_position.z + way)
                {
                    transform.position = new Vector3(original_position.x, 0, original_position.z + way);
                    ismoving = false;
                }
                else { transform.position += new Vector3(0, 0, Time.deltaTime * speed * way); }
            }

        }

    }
}
