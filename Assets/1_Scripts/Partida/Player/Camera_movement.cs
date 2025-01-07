using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_movement : MonoBehaviour
{

    [SerializeField] float horizontalSensitivity = 100f;
    [SerializeField] float verticalSensitivity = 100f;

    public Transform playerBody;

    float xRotation;

    void Start()
    {
        xRotation = 0f;
    }
    void Update()
    {
        if (!GameStateManager.Instance.GameStarted) return;

        float mouseX = Input.GetAxisRaw("Mouse X") * horizontalSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxisRaw("Mouse Y") * verticalSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        playerBody.Rotate(Vector3.up * mouseX);
    }

    public void RotateCamera(float mouseX, float mouseY)
    {
        mouseX *= horizontalSensitivity * Time.deltaTime;
        mouseY *= verticalSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        playerBody.Rotate(Vector3.up * mouseX);
    }

}
