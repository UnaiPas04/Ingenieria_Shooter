using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    public Transform playerCameraTransform;
    public Transform capsuleTransform;

    [Header("Key Binds")]
    [SerializeField] public KeyCode jumpKey = KeyCode.Space;
    [SerializeField] public KeyCode crouchKey = KeyCode.LeftControl;
    [SerializeField] public KeyCode runKey = KeyCode.LeftShift;

    [Header("Movement variables")]
    public float defaultSpeed = 12.0f;
    public float jumpSpeed = 5f;
    public float runningSpeed = 24f;
    public float crouchDistance = 10f;
    [SerializeField] float airSpeedMultiplier = 0.4f;
    [SerializeField] float crouchSpeed = 6f;

    [Header("Player drag")]
    public float groundDrag = 6f;
    public float airDrag = 3f;

    Rigidbody rigidbody;

    Vector3 direction;
    float speed;

    float playerHeight = 2f;
    bool isGrounded;

    public bool isCrouched;
    public bool isRunning;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        rigidbody.freezeRotation = true;

        speed = defaultSpeed;
    }

    void Update()
    {

        isGrounded = Physics.Raycast(transform.position, Vector3.down, playerHeight/2 + 0.1f);

        if(isGrounded)
        {
            rigidbody.drag = groundDrag;
        } else
        {
            rigidbody.drag = airDrag;
        }
    }

    public void Move(float x, float z)
    {
        direction = transform.right * x + transform.forward * z;
    }

    public void Jump()
    {
        if(isGrounded) 
        {
            rigidbody.AddForce(transform.up * jumpSpeed, ForceMode.Impulse);
        }
    }

    public void StartCrouch()
    {
        if (isGrounded && !isCrouched)
        {
            isCrouched = true;
            speed = crouchSpeed;
            Vector3 cameraPosition = playerCameraTransform.localPosition;
            cameraPosition.y -= crouchDistance;
            playerCameraTransform.localPosition = cameraPosition;
        }
    }

    public void StopCrouch()
    {
        if (isCrouched)
        {
            isCrouched = false;
            speed = defaultSpeed;
            Vector3 cameraPosition = playerCameraTransform.localPosition;
            cameraPosition.y += crouchDistance;
            playerCameraTransform.localPosition = cameraPosition;
        }
    }

    public void StartRun()
    {
        if(isGrounded && !isRunning)
        {
            isRunning = true;
            speed = runningSpeed;
        }
    }

    public void StopRun()
    {
        if(isRunning)
        {
            isRunning = false;
            speed = defaultSpeed;
        }
    }

    void FixedUpdate()
    {
        if (isGrounded)
        {
            rigidbody.AddForce(direction.normalized * speed, ForceMode.Acceleration);
        }
        else
        {
            rigidbody.AddForce(direction.normalized * speed * airSpeedMultiplier, ForceMode.Acceleration);
        }

    }
}
