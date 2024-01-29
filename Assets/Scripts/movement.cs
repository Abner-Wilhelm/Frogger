using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{

    bool ismoving = false;
    Vector3 original_position;

    public int speed = 10;
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
            }
           
        }
       //else if (Input.GetKeyDown(KeyCode.S))
        {
         //   Move(Vector3.back);
        }
       // else if (Input.GetKeyDown(KeyCode.D))
        {
         //   Move(Vector3.right);
        }
       // else if (Input.GetKeyDown(KeyCode.A))
        {
         //   Move(Vector3.left);
        }
        Move(Vector3.forward);
    }

    private void Move(Vector3 direction)
    {
        if (ismoving == true)
        {
            if (transform.position.z >= original_position.z+2)
            {
                ismoving = false;
            }
            else { transform.position += direction * Time.deltaTime * speed; }

        }
    }
}
