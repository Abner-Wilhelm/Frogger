using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    bool isMoving = false;
    Vector3 originalPosition;
    Quaternion originalRotation;
    Quaternion targetRotation;
    public int speed = 5;
    public float rotationSpeed = 5f;

    void Start()
    {
        originalPosition = transform.position;
        originalRotation = transform.rotation;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S) ||
            Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D))
        {
            if (!isMoving)
            {
                originalPosition = transform.position;
                originalRotation = transform.rotation;

                Vector3 direction = Vector3.forward;
                if (Input.GetKeyDown(KeyCode.S))
                    direction = Vector3.back;
                else if (Input.GetKeyDown(KeyCode.A))
                    direction = Vector3.left;
                else if (Input.GetKeyDown(KeyCode.D))
                    direction = Vector3.right;

                targetRotation = Quaternion.LookRotation(direction, Vector3.up);
                isMoving = true;
            }
        }

        Move();
    }

    private void Move()
    {
        if (isMoving)
        {

            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);

    
            Vector3 movementDirection = targetRotation * Vector3.forward;
            Vector3 targetPosition = originalPosition + movementDirection * 2;
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, Time.deltaTime * speed);

    
            if (Vector3.Distance(transform.position, targetPosition) < 0.01f)
            {
                transform.position = targetPosition;
                isMoving = false;
            }
        }
    }
}
