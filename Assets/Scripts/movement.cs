using System.Collections;
using System.Collections.Generic;
using TMPro.Examples;
using UnityEngine;
using UnityEngine.SceneManagement;

public class movement : MonoBehaviour
{
    [SerializeField] private PhysicMaterial noFrictionMaterial;
    bool isMoving = false;
    Vector3 originalPosition;

    Vector3 spawn;
    Quaternion originalRotation;
    Quaternion targetRotation;
    public int speed = 5;
    public float rotationSpeed = 5f;
    bool onLog = false;
    private GameObject currentLog;
    private Vector3 lastLogPosition;

    [SerializeField]
    public Animator anim;
    int wins = 0;

    int lives = 3;

    void Start()
    {
        originalPosition = transform.position;
        originalRotation = transform.rotation;
        spawn = transform.position;
        
    }

    void Update()
    {
        if (!isMoving && (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S) ||
            Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D)))
        {
            // play animation
            anim.Play("jump",-1,0f);
            SetDirectionAndMove();
        }

        if (onLog && currentLog != null)
        {
            FollowLog();
        }

        MoveCharacter();

        
    }

    

    void SetDirectionAndMove()
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

    void FollowLog()
    {
        Vector3 deltaPosition = currentLog.transform.position - lastLogPosition;
        transform.position += deltaPosition;
        lastLogPosition = currentLog.transform.position;
    }

    void MoveCharacter()
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

    void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.CompareTag("Log"))
        {
            onLog = true;
            currentLog = other.gameObject;
            lastLogPosition = currentLog.transform.position;
        }
        else if (other.gameObject.CompareTag("Hazard"))
        {
            DoDeath();
        }
         else if (other.gameObject.CompareTag("Wall"))
        {
            DoDeath();
        }
        else if (other.gameObject.CompareTag("Win"))
        {
            DoWin();
        }
    }

    

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Log") && other.gameObject == currentLog)
        {
            onLog = false;
            currentLog = null;
        }
    }

    void DoDeath()
    {
        lives -= 1;

        transform.position = spawn; 

    isMoving = false;
    onLog = false;
    currentLog = null;

    var rb = GetComponent<Rigidbody>();
    if (rb != null)
    {
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
    }

    if (wins == 5){
    SceneManager.LoadScene (sceneName:"Level2");
    }

        if (lives == 0)
        {
        SceneManager.LoadScene (sceneName:"GameOverMenu");
        }
    }

    void DoWin()
{
    wins += 1;
    transform.position = spawn; 
 
    isMoving = false;
    onLog = false;
    currentLog = null;

    var rb = GetComponent<Rigidbody>();
    if (rb != null)
    {
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
    }

    if (wins == 5){
    SceneManager.LoadScene (sceneName:"Level2");
    }
        if (wins == 10)
        {
            SceneManager.LoadScene(sceneName: "GameWinMenu");
        }
    }

}
