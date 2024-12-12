using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{

    public CharacterController controller;
    public Transform playerCameraTransform;

    public float defaultSpeed = 12.0f;
    public float jumpSpeed = 5f;
    public float gravity = 9.8f;
    public float crouchDistance = 10f;

    private Vector3 v;
    private float crouchSpeed;
    private float speed;

    void Start()
    {
        crouchSpeed = defaultSpeed / 2;
        speed = defaultSpeed;
    }

    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        v.y -= gravity * Time.deltaTime;

        if(controller.isGrounded)
        {
            v.y = 0f;
        }
        //Jumped
        if (Input.GetKeyDown(KeyCode.Space))
        {
            v.y = jumpSpeed;
        }
        //Started crouching
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            speed = crouchSpeed;
            Vector3 cameraPosition = playerCameraTransform.localPosition;
            cameraPosition.y = Mathf.Lerp(cameraPosition.y, playerCameraTransform.localPosition.y - crouchDistance, 5.0f * Time.deltaTime);
            playerCameraTransform.localPosition = cameraPosition;
        }
        //Stopped crouching
        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            speed = defaultSpeed;
            Vector3 cameraPosition = playerCameraTransform.localPosition;
            cameraPosition.y = Mathf.Lerp(cameraPosition.y, playerCameraTransform.localPosition.y + crouchDistance, 5.0f * Time.deltaTime);
            playerCameraTransform.localPosition = cameraPosition;
        }

        controller.Move(move * speed * Time.deltaTime);
        controller.Move(v * Time.deltaTime);
    }
}
