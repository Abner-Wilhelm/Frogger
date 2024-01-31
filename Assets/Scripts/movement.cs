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
    bool onLog;
    private GameObject currentLog;
    private Vector3 lastLogPosition;

    void Start()
    {
        originalPosition = transform.position;
        originalRotation = transform.rotation;
    }

    void Update()
    {
        if (!isMoving && (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S) ||
            Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D)))
        {
            originalPosition = transform.position;
            originalRotation = transform.rotation;

            Vector3 direction = Input.GetKeyDown(KeyCode.W) ? Vector3.forward
                            : Input.GetKeyDown(KeyCode.S) ? Vector3.back
                            : Input.GetKeyDown(KeyCode.A) ? Vector3.left
                            : Vector3.right;

            targetRotation = Quaternion.LookRotation(direction, Vector3.up);
            isMoving = true;
        }

        if (onLog && currentLog != null)
        {
            Vector3 deltaPosition = currentLog.transform.position - lastLogPosition;
            transform.position += deltaPosition;
            lastLogPosition = currentLog.transform.position;
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
                AlignFrogToGrid(); // Snap to grid after movement
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Hazard"))
        {
            Debug.Log("Hazard Hit: Frog should die.");
            DoDeath();
        }
        else if (other.gameObject.CompareTag("Log"))
        {
            onLog = true;
            currentLog = other.gameObject;
            lastLogPosition = currentLog.transform.position;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Log"))
        {
            onLog = false;
            currentLog = null;
        }
    }

    void DoDeath()
    {
        Debug.Log("Executing Death Sequence");
        // Implement death logic here (e.g., respawn, reduce life, etc.)
    }

    void AlignFrogToGrid()
{
    Vector3 position = transform.position;

    // Align the frog's position to the nearest odd integer coordinates.
    position.x = RoundToNearestOdd(position.x);
    position.z = RoundToNearestOdd(position.z); // Use position.y for 2D games

    transform.position = position;
}

float RoundToNearestOdd(float value)
{
    // Round to the nearest whole number and adjust to the nearest odd number
    int rounded = Mathf.RoundToInt(value);
    return (rounded % 2 == 0) ? rounded + 1 : rounded;
}
}
