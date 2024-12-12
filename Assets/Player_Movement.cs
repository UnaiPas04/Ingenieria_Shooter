using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    public Transform playerCameraTransform;
    public Transform capsuleTransform;

    [SerializeField] KeyCode jumpKey = KeyCode.Space;
    [SerializeField] KeyCode crouchKey = KeyCode.LeftControl;
    [SerializeField] KeyCode runKey = KeyCode.LeftShift;

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

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        rigidbody.freezeRotation = true;

        speed = defaultSpeed;
    }

    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        isGrounded = Physics.Raycast(transform.position, Vector3.down, playerHeight/2 + 0.1f);

        if(isGrounded)
        {
            rigidbody.drag = groundDrag;
        } else
        {
            rigidbody.drag = airDrag;
        }

        direction = transform.right * x + transform.forward * z;

        //Jumped
        if (Input.GetKeyDown(jumpKey) && isGrounded)
        {
            rigidbody.AddForce(transform.up * jumpSpeed, ForceMode.Impulse);
        }
        //Started crouching
        if (Input.GetKeyDown(crouchKey) && isGrounded)
        {
            speed = crouchSpeed;
            Vector3 cameraPosition = playerCameraTransform.localPosition;
            cameraPosition.y = Mathf.Lerp(cameraPosition.y, playerCameraTransform.localPosition.y - crouchDistance, 5.0f * Time.deltaTime);
            playerCameraTransform.localPosition = cameraPosition;
        }
        //Stopped crouching
        if (Input.GetKeyUp(crouchKey))
        {
            speed = defaultSpeed;
            Vector3 cameraPosition = playerCameraTransform.localPosition;
            cameraPosition.y = Mathf.Lerp(cameraPosition.y, playerCameraTransform.localPosition.y + crouchDistance, 5.0f * Time.deltaTime);
            playerCameraTransform.localPosition = cameraPosition;
        }
        //Running
        if (Input.GetKeyDown(runKey) && isGrounded)
        {
            speed = runningSpeed;
        }
        //Stopped running
        if (Input.GetKeyUp(runKey))
        {
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
